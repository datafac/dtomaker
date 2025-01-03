﻿using DTOMaker.Gentime;
using Microsoft.CodeAnalysis;
using System.Collections.Immutable;
using System.Linq;

namespace DTOMaker.MemBlocks
{
    public readonly struct IdAttribute { }
    public readonly struct LayoutAttribute { }
    public readonly struct OffsetAttribute { }
    public readonly struct LengthAttribute { }
    public readonly struct EndianAttribute { }

    internal class MemBlocksSyntaxReceiver : SyntaxReceiverBase
    {
        private static TargetDomain DomainFactory(string name, Location location) => new MemBlockDomain(name, location);
        private static TargetEntity EntityFactory(TargetDomain domain, string nameSpace, string name, Location location) => new MemBlockEntity(domain, nameSpace, name, location);
        private static TargetMember MemberFactory(TargetEntity entity, string name, Location location) => new MemBlockMember(entity, name, location);

        protected override void OnProcessEntityAttributes(TargetEntity baseEntity, Location location, ImmutableArray<AttributeData> entityAttributes)
        {
            if (baseEntity is MemBlockEntity entity)
            {
                entity.EntityId = entity.EntityName.FullName;
                if (entityAttributes.FirstOrDefault(a => a.AttributeClass?.Name == nameof(IdAttribute)) is AttributeData idAttr)
                {
                    // found entity id attribute
                    entity.HasEntityLayoutAttribute = true;
                    var attributeArguments = idAttr.ConstructorArguments;
                    if (CheckAttributeArguments(nameof(IdAttribute), attributeArguments, 1, entity, location))
                    {
                        TryGetAttributeArgumentValue<string>(entity, location, attributeArguments, 0, (value) => { entity.EntityId = value; });
                    }
                }
                if (entityAttributes.FirstOrDefault(a => a.AttributeClass?.Name == nameof(LayoutAttribute)) is AttributeData entityLayoutAttr)
                {
                    // found entity layout attribute
                    entity.HasEntityLayoutAttribute = true;
                    var attributeArguments = entityLayoutAttr.ConstructorArguments;
                    if (CheckAttributeArguments(nameof(LayoutAttribute), attributeArguments, 2, entity, location))
                    {
                        TryGetAttributeArgumentValue<int>(entity, location, attributeArguments, 0, (value) => { entity.LayoutMethod = (LayoutMethod)value; });
                        TryGetAttributeArgumentValue<int>(entity, location, attributeArguments, 1, (value) => { entity.BlockLength = value; });
                    }
                }
            }
        }

        protected override void OnProcessMemberAttributes(TargetMember baseMember, Location location, ImmutableArray<AttributeData> memberAttributes)
        {
            if (baseMember is MemBlockMember member)
            {
                if (memberAttributes.FirstOrDefault(a => a.AttributeClass?.Name == nameof(OffsetAttribute)) is AttributeData memberOffsetAttr)
                {
                    member.HasOffsetAttribute = true;
                    var attributeArguments = memberOffsetAttr.ConstructorArguments;
                    if (CheckAttributeArguments(nameof(OffsetAttribute), attributeArguments, 1, member, location))
                    {
                        TryGetAttributeArgumentValue<int>(member, location, attributeArguments, 0, (value) => { member.FieldOffset = value; });
                    }
                }
                if (memberAttributes.FirstOrDefault(a => a.AttributeClass?.Name == nameof(LengthAttribute)) is AttributeData memberLengthAttr)
                {
                    member.HasLengthAttribute = true;
                    var attributeArguments = memberLengthAttr.ConstructorArguments;
                    if (CheckAttributeArguments(nameof(LengthAttribute), attributeArguments, 1, member, location))
                    {
                        TryGetAttributeArgumentValue<int>(member, location, attributeArguments, 0, (value) => { member.ArrayLength = value; });
                    }
                }
                if (memberAttributes.FirstOrDefault(a => a.AttributeClass?.Name == nameof(EndianAttribute)) is AttributeData memberEndianAttr)
                {
                    member.HasEndianAttribute = true;
                    var attributeArguments = memberEndianAttr.ConstructorArguments;
                    if (CheckAttributeArguments(nameof(EndianAttribute), attributeArguments, 1, member, location))
                    {
                        TryGetAttributeArgumentValue<bool>(member, location, attributeArguments, 0, (value) => { member.IsBigEndian = value; });
                    }
                }
            }
        }

        public MemBlocksSyntaxReceiver() : base(DomainFactory, EntityFactory, MemberFactory)
        {
        }
    }
}
