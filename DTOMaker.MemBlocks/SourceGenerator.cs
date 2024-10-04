﻿using DTOMaker.Gentime;
using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace DTOMaker.MemBlocks
{
    [Generator(LanguageNames.CSharp)]
    public class SourceGenerator : ISourceGenerator
    {
        public void Initialize(GeneratorInitializationContext context)
        {
            context.RegisterForSyntaxNotifications(() => new SyntaxReceiver());
        }

        private void EmitDiagnostics(GeneratorExecutionContext context, TargetBase target)
        {
            foreach (var diagnostic in target.SyntaxErrors)
            {
                context.ReportDiagnostic(
                    Diagnostic.Create(
                        new DiagnosticDescriptor(
                            diagnostic.Id, diagnostic.Title, diagnostic.Message, diagnostic.Category, diagnostic.Severity, true), diagnostic.Location));
            }
            foreach (var diagnostic in target.ValidationErrors())
            {
                context.ReportDiagnostic(
                    Diagnostic.Create(
                        new DiagnosticDescriptor(
                            diagnostic.Id, diagnostic.Title, diagnostic.Message, diagnostic.Category, diagnostic.Severity, true), diagnostic.Location));
            }
        }
        private void CheckReferencedAssemblyNamesInclude(GeneratorExecutionContext context, Assembly assembly)
        {
            string packageName = assembly.GetName().Name;
            Version packageVersion = assembly.GetName().Version;
            if (!context.Compilation.ReferencedAssemblyNames.Any(ai => ai.Name.Equals(packageName, StringComparison.OrdinalIgnoreCase)))
            {
                // todo major version error/minor version warning
                context.ReportDiagnostic(Diagnostic.Create(
                        new DiagnosticDescriptor(
                            "MFNSSG001", "DiagnosticTitle",
                            $"The generated code requires a reference to {packageName} (v{packageVersion} or later).",
                            "DiagnosticCategory",
                            DiagnosticSeverity.Warning,
                            true),
                            Location.None));
            }
        }
        private static int GetFieldLength(TargetMember member)
        {
            switch (member.MemberType)
            {
                case "Boolean":
                case "Byte":
                case "SByte":
                    return 1;
                case "Int16":
                case "UInt16":
                    return 2;
                case "Int32":
                case "UInt32":
                    return 4;
                case "Int64":
                case "UInt64":
                case "Double": 
                    return 8;
                default:
                    member.SyntaxErrors.Add(
                        new SyntaxDiagnostic(
                            DiagnosticId.DMMB0007, "Unsupported member type", DiagnosticCategory.Design, member.Location, DiagnosticSeverity.Error,
                            $"Unsupported member type: '{member.MemberType}'"));
                    return 0;
            }
        }
        private static void AutoLayoutMembers(TargetEntity entity)
        {
            if (entity.LayoutMethod != Models.LayoutMethod.SequentialV1) return;

            int minBlockLength = 0;
            int fieldOffset = 0;
            foreach (var member in entity.Members.Values.OrderBy(m => m.Sequence))
            {
                int fieldLength = GetFieldLength(member);
                // calculate this offset
                while (fieldLength > 0 && fieldOffset % fieldLength != 0)
                {
                    fieldOffset++;
                }
                member.FieldLength = fieldLength;
                member.FieldOffset = fieldOffset;
                // calc next offset
                fieldOffset = fieldOffset + fieldLength;
                while (fieldOffset > minBlockLength)
                {
                    minBlockLength = minBlockLength == 0 ? 1 : minBlockLength * 2;
                }
                // todo allocate Flags byte
            }
            entity.BlockLength = minBlockLength;
        }

        public void Execute(GeneratorExecutionContext context)
        {
            if (context.SyntaxContextReceiver is not SyntaxReceiver syntaxReceiver) return;

            // check that the users compilation references the expected libraries
            CheckReferencedAssemblyNamesInclude(context, typeof(DTOMaker.Runtime.IFieldCodec).Assembly);

            foreach (var domain in syntaxReceiver.Domains.Values)
            {
                EmitDiagnostics(context, domain);
                foreach (var entity in domain.Entities.Values.OrderBy(e => e.Name))
                {
                    // do auto-layout if required
                    AutoLayoutMembers(entity);

                    // run checks
                    EmitDiagnostics(context, entity);
                    Version fv = new Version(ThisAssembly.AssemblyFileVersion);
                    string shortVersion = $"{fv.Major}.{fv.Minor}";
                    string hintName = $"{domain.Name}.{entity.Name}.MemBlocks.g.cs";
                    var builder = new StringBuilder();
                    string entityHead =
                        $$"""
                        // <auto-generated>
                        // This file was generated by {{typeof(SourceGenerator).Namespace}} V{{shortVersion}}
                        // Warning: Changes made to this file will be lost if re-generated.
                        // </auto-generated>
                        #pragma warning disable CS0414
                        #nullable enable
                        using System;
                        namespace {{domain.Name}}.MemBlocks
                        {
                            public partial class {{entity.Name}}
                            {
                                private const int BlockSize = {{entity.BlockLength}};
                                private readonly Memory<byte> _block;
                                public ReadOnlyMemory<byte> Block => _block;
                                public {{entity.Name}}() => _block = new byte[BlockSize];
                                public {{entity.Name}}(ReadOnlySpan<byte> source) => _block = source.Slice(0, BlockSize).ToArray();
                        """;
                    string entityTail =
                        """
                            }
                        }
                        """;
                    builder.AppendLine(entityHead);
                    // begin member map
                    string memberMapHead =
                        """
                                // <field-map>
                                //  Pos.  Len.  Type        Endian  Name
                                //  ----  ----  --------    ------  --------
                        """;
                    builder.AppendLine(memberMapHead);
                    foreach (var member in entity.Members.Values.OrderBy(m => m.FieldOffset))
                    {
                        string memberMapBody =
                            $$"""
                                    //  {{member.FieldOffset,4:N0}}  {{member.FieldLength,4:N0}}  {{member.MemberType,-8}}    {{(member.IsBigEndian ? "Big   " : "Little")}}  {{member.Name}}
                            """;
                        builder.AppendLine(memberMapBody);
                    }
                    string memberMapTail =
                        """
                                // </field-map>
                        """;
                    builder.AppendLine(memberMapTail);
                    // end member map
                    foreach (var member in entity.Members.Values.OfType<MemBlockMember>().OrderBy(m => m.FieldOffset))
                    {
                        EmitDiagnostics(context, member);
                        string memberSource =
                            $$"""
                                    public {{member.MemberType}} {{member.Name}}
                                    {
                                        get => {{member.CodecTypeName}}.ReadFromSpan(_block.Slice({{member.FieldOffset}}, {{member.FieldLength}}).Span);
                                        set => {{member.CodecTypeName}}.WriteToSpan(_block.Slice({{member.FieldOffset}}, {{member.FieldLength}}).Span, value);
                                    }
                            """;
                        builder.AppendLine(memberSource);
                    }
                    builder.AppendLine(entityTail);
                    context.AddSource(hintName, builder.ToString());
                }
            }
        }
    }
}
