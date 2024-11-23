﻿// <auto-generated>
// This file was generated by DTOMaker.MemBlocks.
// NuGet: https://www.nuget.org/packages/DTOMaker.MemBlocks
// Warning: Changes made to this file will be lost if re-generated.
// </auto-generated>
#pragma warning disable CS0414
#nullable enable
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using DataFac.Memory;
using DataFac.Runtime;
//##if false
using T_MemberType_ = System.Int32;
namespace DataFac.Memory
{
    public static class Codec_T_MemberType__T_MemberBELE_
    {
        public static T_MemberType_ ReadFromSpan(ReadOnlySpan<byte> source) => Codec_Int32_LE.ReadFromSpan(source);
        public static void WriteToSpan(Span<byte> source, T_MemberType_ value) => Codec_Int32_LE.WriteToSpan(source, value);
    }
}
//##endif
namespace T_DomainName_.MemBlocks
{
    //##if false
    public interface IT_EntityName_
    {
        T_MemberType_ T_ScalarMemberName_ { get; set; }
        ReadOnlyMemory<T_MemberType_> T_VectorMemberName_ { get; set; }
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

        // -------------------- field map -----------------------------
        //  Seq.  Off.  Len.  N.    Type    End.  Name
        //  ----  ----  ----  ----  ------- ----  -------
        //##foreach Members
        //  T_MemberSequenceR4_  T_FieldOffsetR4_  T_FieldLengthR4_  T_ArrayLengthR4_  T_MemberTypeL7_ T_MemberBELE_    T_MemberName_
        //##endfor
        // ------------------------------------------------------------

        public T_EntityName_() => _readonlyBlock = _writableBlock = new byte[BlockLength];

        public T_EntityName_(ReadOnlySpan<byte> source, bool frozen)
        {
            Memory<byte> memory = new byte[BlockLength];
            if (source.Length <= BlockLength)
                source.CopyTo(memory.Span);
            else
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
            //##if MemberIsArray
            this.T_VectorMemberName_ = source.T_VectorMemberName_;
            //##else
            this.T_ScalarMemberName_ = source.T_ScalarMemberName_;
            //##endif
            //##endfor
        }

        //##if false
        private const int T_FieldOffset_ = 32;
        private const int T_FieldLength_ = 8;
        private const bool T_IsBigEndian_ = false;
        private const int T_ArrayLength_ = 4;
        //##endif
        //##foreach Members
        //##if MemberIsObsolete
        [Obsolete("T_MemberObsoleteMessage_", T_MemberObsoleteIsError_)]
        //##endif
        //##if MemberIsArray
        public ReadOnlyMemory<T_MemberType_> T_VectorMemberName_
        {
            get
            {
                var sourceSpan = _readonlyBlock.Slice(T_FieldOffset_, T_FieldLength_ * T_ArrayLength_).Span;
                //##if FieldLength == 1
                return MemoryMarshal.Cast<byte, T_MemberType_>(sourceSpan).ToArray(); // todo alloc!
                //##else
                if (BitConverter.IsLittleEndian != T_IsBigEndian_)
                {
                    // endian match
                    return MemoryMarshal.Cast<byte, T_MemberType_>(sourceSpan).ToArray(); // todo alloc!
                }
                else
                {
                    // endian mismatch - decode each element
                    var target = new T_MemberType_[T_ArrayLength_]; // todo alloc!
                    Span<T_MemberType_> targetSpan = target.AsSpan();
                    for (int i = 0; i < T_ArrayLength_; i++)
                    {
                        var elementSpan = sourceSpan.Slice(T_FieldLength_ * i, T_FieldLength_);
                        targetSpan[i] = Codec_T_MemberType__T_MemberBELE_.ReadFromSpan(elementSpan);
                    }
                    return target;
                }
                //##endif
            }

            set
            {
                if (_frozen) ThrowIsFrozenException(nameof(T_VectorMemberName_));
                var targetSpan = _writableBlock.Slice(T_FieldOffset_, T_FieldLength_ * T_ArrayLength_).Span;
                targetSpan.Clear();
                //##if FieldLength == 1
                value.Span.CopyTo(MemoryMarshal.Cast<byte, T_MemberType_>(targetSpan));
                //##else
                if (BitConverter.IsLittleEndian != T_IsBigEndian_)
                {
                    // endian match
                    value.Span.CopyTo(MemoryMarshal.Cast<byte, T_MemberType_>(targetSpan));
                }
                else
                {
                    // endian mismatch - encode each element
                    var sourceSpan = value.Span;
                    for (int i = 0; i < sourceSpan.Length; i++)
                    {
                        var elementSpan = targetSpan.Slice(T_FieldLength_ * i, T_FieldLength_);
                        Codec_T_MemberType__T_MemberBELE_.WriteToSpan(elementSpan, sourceSpan[i]);
                    }
                }
                //##endif
            }
        }

        //##else
        public T_MemberType_ T_ScalarMemberName_
        {
            get
            {
                return (T_MemberType_)Codec_T_MemberType__T_MemberBELE_.ReadFromSpan(_readonlyBlock.Slice(T_FieldOffset_, T_FieldLength_).Span);
            }

            set
            {
                if (_frozen) ThrowIsFrozenException(nameof(T_ScalarMemberName_));
                Codec_T_MemberType__T_MemberBELE_.WriteToSpan(_writableBlock.Slice(T_FieldOffset_, T_FieldLength_).Span, value);
            }
        }

        //##endif
        //##endfor
    }
}
