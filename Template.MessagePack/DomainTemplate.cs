﻿// <auto-generated>
// This file was generated by DTOMaker.MessagePack.
// NuGet: https://www.nuget.org/packages/DTOMaker.MessagePack
// Warning: Changes made to this file will be lost if re-generated.
// </auto-generated>
#nullable enable
using DataFac.Runtime;
using MessagePack;
using System;
using System.Runtime.CompilerServices;

namespace T_DomainName_.MessagePack
{
    [MessagePackObject]
    //##foreach Entities
    [Union(T_EntityName_.EntityTag, typeof(T_EntityName_))]
    //##endfor
    public abstract class EntityBase : IFreezable, IEquatable<EntityBase>
    {
        public EntityBase() { }
        public EntityBase(object? notUsed, bool frozen)
        {
            _frozen = frozen;
        }
        [IgnoreMember]
        private volatile bool _frozen;
        [IgnoreMember]
        public bool IsFrozen => _frozen;
        protected virtual void OnFreeze() { }
        public void Freeze()
        {
            if (_frozen) return;
            _frozen = true;
            OnFreeze();
        }
        protected virtual IFreezable OnPartCopy() => throw new NotImplementedException();
        public IFreezable PartCopy() => OnPartCopy();

        [MethodImpl(MethodImplOptions.NoInlining)]
        private void ThrowIsFrozenException(string? methodName) => throw new InvalidOperationException($"Cannot call {methodName} when frozen.");

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        protected ref T IfNotFrozen<T>(ref T value, [CallerMemberName] string? methodName = null)
        {
            if (_frozen) ThrowIsFrozenException(methodName);
            return ref value;
        }

        public bool Equals(EntityBase? other) => true;
        public override bool Equals(object obj) => obj is EntityBase;
        public override int GetHashCode() => 0;
    }
}
