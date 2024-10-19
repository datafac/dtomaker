﻿// <auto-generated>
// This file was generated by DTOMaker.MemBlocks.
// NuGet: https://www.nuget.org/packages/DTOMaker.MemBlocks
// Warning: Changes made to this file will be lost if re-generated.
// </auto-generated>
#pragma warning disable CS0414
#nullable enable
using System;
using System.Runtime.CompilerServices;
using DTOMaker.Runtime;
//##if false
using T_MemberType_ = System.DayOfWeek;
using T_MemberWireType_ = System.Int32;
namespace DTOMaker.Runtime
{
    public static class Codec_T_MemberWireType__T_MemberBELE_
    {
        public static T_MemberWireType_ ReadFromSpan(ReadOnlySpan<byte> source) => Codec_Int32_LE.ReadFromSpan(source);
        public static void WriteToSpan(Span<byte> source, T_MemberWireType_ value) => Codec_Int32_LE.WriteToSpan(source, value);
    }
}
//##endif
namespace T_DomainName_.MemBlocks
{
    //##if false
    public interface IT_EntityName_
    {
        T_MemberType_ T_MemberName_ { get; set; }
    }
    //##endif
    public sealed partial class T_EntityName_ : IT_EntityName_, IFreezable
    {
        //##if false
        private const int T_BlockLength_ = 128;
        private const bool T_MemberObsoleteIsError_ = false;
        //##endif
        private const int BlockLength = T_BlockLength_;
        private readonly Memory<byte> _writableBlock;
        private readonly ReadOnlyMemory<byte> _readonlyBlock;
        public ReadOnlyMemory<byte> Block => _frozen ? _readonlyBlock : _writableBlock.ToArray();

        public T_EntityName_() => _readonlyBlock = _writableBlock = new byte[BlockLength];

        public T_EntityName_(ReadOnlySpan<byte> source, bool frozen)
        {
            Memory<byte> memory = new byte[BlockLength];
            source.Slice(0, BlockLength).CopyTo(memory.Span);
            _readonlyBlock = memory;
            _writableBlock = memory;
            _frozen = frozen;
        }

        public T_EntityName_(ReadOnlyMemory<byte> source)
        {
            if (source.Length >= BlockLength)
            {
                _readonlyBlock = source.Slice(0, BlockLength);
            }
            else
            {
                // forced copy as source is too short
                Memory<byte> memory = new byte[BlockLength];
                source.Slice(0, BlockLength).Span.CopyTo(memory.Span);
                _readonlyBlock = memory;
            }
            _writableBlock = Memory<byte>.Empty;
            _frozen = true;
        }
        // todo move to base
        private volatile bool _frozen = false;
        public bool IsFrozen() => _frozen;
        public IFreezable PartCopy() => new T_EntityName_(this);

        [MethodImpl(MethodImplOptions.NoInlining)]
        private void ThrowIsFrozenException(string? methodName) => throw new InvalidOperationException($"Cannot call {methodName} when frozen.");

        public void Freeze()
        {
            if (_frozen) return;
            _frozen = true;
            // todo freeze base
            // todo freeze model type refs
        }

        public T_EntityName_(T_EntityName_ source)
        {
            // todo base ctor
            // todo freezable members
            _writableBlock = source._writableBlock.ToArray();
            _readonlyBlock = _writableBlock;
            _frozen = false;
        }

        public T_EntityName_(IT_EntityName_ source) : this(ReadOnlySpan<byte>.Empty, false)
        {
            // todo base ctor
            // todo freezable members
            //##foreach Members
            this.T_MemberName_ = source.T_MemberName_;
            //##endfor
        }

        //##if false
        private const int T_FlagsOffset_ = 0;
        private const int T_FieldOffset_ = 40;
        private const int T_FieldLength_ = 8;
        //##endif
        //##foreach Members
        //##if MemberIsObsolete
        [Obsolete("T_MemberObsoleteMessage_", T_MemberObsoleteIsError_)]
        //##endif
        //##if MemberIsNullable
        public T_MemberType_? T_NullableMemberName_
        {
            get
            {
                byte flags = DTOMaker.Runtime.Codec_Byte_LE.ReadFromSpan(_readonlyBlock.Slice(T_FlagsOffset_, 1).Span);
                if (flags == 0) return null;
                return (T_MemberType_)DTOMaker.Runtime.Codec_T_MemberWireType__T_MemberBELE_.ReadFromSpan(_readonlyBlock.Slice(T_FieldOffset_, T_FieldLength_).Span);
            }

            set
            {
                if (_frozen) ThrowIsFrozenException(nameof(T_NullableMemberName_));
                byte flags = value.HasValue ? (byte)1 : (byte)0;
                DTOMaker.Runtime.Codec_Byte_LE.WriteToSpan(_writableBlock.Slice(T_FlagsOffset_, 1).Span, flags);
                T_MemberWireType_ wireValue = value.HasValue ? (T_MemberWireType_)value.Value : default;
                DTOMaker.Runtime.Codec_T_MemberWireType__T_MemberBELE_.WriteToSpan(_writableBlock.Slice(T_FieldOffset_, T_FieldLength_).Span, wireValue);
            }
        }
        //##else
        public T_MemberType_ T_MemberName_
        {
            get
            {
                return (T_MemberType_)DTOMaker.Runtime.Codec_T_MemberWireType__T_MemberBELE_.ReadFromSpan(_readonlyBlock.Slice(T_FieldOffset_, T_FieldLength_).Span);
            }

            set
            {
                if (_frozen) ThrowIsFrozenException(nameof(T_MemberName_));
                T_MemberWireType_ wireValue = (T_MemberWireType_)value;
                DTOMaker.Runtime.Codec_T_MemberWireType__T_MemberBELE_.WriteToSpan(_writableBlock.Slice(T_FieldOffset_, T_FieldLength_).Span, wireValue);
            }
        }
        //##endif

        //##endfor
    }
}
