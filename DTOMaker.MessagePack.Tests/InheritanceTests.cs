﻿using FluentAssertions;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using System;
using System.Linq;
using System.Threading.Tasks;
using VerifyXunit;
using Xunit;

namespace DTOMaker.MessagePack.Tests
{
    public class InheritanceTests
    {
        [Fact]
        public async Task Common01_EntityBaseA()
        {
            var inputSource =
                """
                using DTOMaker.Models;
                namespace MyOrg.Models
                {
                    [Entity(1)]
                    public interface IMyDTO
                    {
                    }
                }
                """;

            var generatorResult = GeneratorTestHelper.RunSourceGenerator(inputSource, LanguageVersion.LatestMajor);
            generatorResult.Exception.Should().BeNull();
            generatorResult.Diagnostics.Where(d => d.Severity == DiagnosticSeverity.Info).Should().BeEmpty();
            generatorResult.Diagnostics.Where(d => d.Severity == DiagnosticSeverity.Warning).Should().BeEmpty();
            generatorResult.Diagnostics.Where(d => d.Severity == DiagnosticSeverity.Error).Should().BeEmpty();
            generatorResult.GeneratedSources.Length.Should().Be(2);
            GeneratedSourceResult source = generatorResult.GeneratedSources[0];

            // custom generation checks
            source.HintName.Should().Be("MyOrg.Models.EntityBase.MessagePack.g.cs");
            string outputCode = string.Join(Environment.NewLine, source.SourceText.Lines.Select(tl => tl.ToString()));
            await Verifier.Verify(outputCode);
        }

        [Fact]
        public async Task Common02_EntityBaseB()
        {
            var inputSource =
                """
                using DTOMaker.Models;
                namespace MyOrg.Models
                {
                    [Entity(1)]
                    public interface IMyBase
                    {
                    }
                    [Entity(2)]
                    public interface IMyDTO : IMyBase
                    {
                    }
                }
                """;

            var generatorResult = GeneratorTestHelper.RunSourceGenerator(inputSource, LanguageVersion.LatestMajor);
            generatorResult.Exception.Should().BeNull();
            generatorResult.Diagnostics.Where(d => d.Severity == DiagnosticSeverity.Info).Should().BeEmpty();
            generatorResult.Diagnostics.Where(d => d.Severity == DiagnosticSeverity.Warning).Should().BeEmpty();
            generatorResult.Diagnostics.Where(d => d.Severity == DiagnosticSeverity.Error).Should().BeEmpty();
            generatorResult.GeneratedSources.Length.Should().Be(3);
            GeneratedSourceResult source = generatorResult.GeneratedSources[1];

            // custom generation checks
            source.HintName.Should().Be("MyOrg.Models.MyBase.MessagePack.g.cs");
            string outputCode = string.Join(Environment.NewLine, source.SourceText.Lines.Select(tl => tl.ToString()));
            await Verifier.Verify(outputCode);
        }

        [Fact]
        public async Task Common03_EntityBaseC()
        {
            var inputSource =
                """
                using DTOMaker.Models;
                namespace MyOrg.Models
                {
                    [Entity(1)]
                    public interface IMyBase
                    {
                    }
                    [Entity(2)]
                    public interface IMyDTO : IMyBase
                    {
                    }
                }
                """;

            var generatorResult = GeneratorTestHelper.RunSourceGenerator(inputSource, LanguageVersion.LatestMajor);
            generatorResult.Exception.Should().BeNull();
            generatorResult.Diagnostics.Where(d => d.Severity == DiagnosticSeverity.Info).Should().BeEmpty();
            generatorResult.Diagnostics.Where(d => d.Severity == DiagnosticSeverity.Warning).Should().BeEmpty();
            generatorResult.Diagnostics.Where(d => d.Severity == DiagnosticSeverity.Error).Should().BeEmpty();
            generatorResult.GeneratedSources.Length.Should().Be(3);
            GeneratedSourceResult source = generatorResult.GeneratedSources[2];

            // custom generation checks
            source.HintName.Should().Be("MyOrg.Models.MyDTO.MessagePack.g.cs");
            string outputCode = string.Join(Environment.NewLine, source.SourceText.Lines.Select(tl => tl.ToString()));
            await Verifier.Verify(outputCode);
        }
    }
}