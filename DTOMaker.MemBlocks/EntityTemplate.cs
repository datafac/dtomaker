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
using DTOMaker.Runtime.MemBlocks;
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
namespace T_NameSpace_.MemBlocks
{
    //##if false
    public interface IT_BaseName_
    {
        T_MemberType_ BaseField1 { get; set; }
    }
    public class T_BaseName_ : EntityBase, IT_BaseName_, IEquatable<T_BaseName_>
    {
        private const int ClassHeight = 1;
        private const int BlockLength = 64;
        private readonly Memory<byte> _writableBlock;
        private readonly ReadOnlyMemory<byte> _readonlyBlock;

        protected override string OnGetEntityId() => "_undefined_";
        protected override int OnGetClassHeight() => ClassHeight;
        protected override void OnGetBuffers(ReadOnlyMemory<byte>[] buffers)
        {
            base.OnGetBuffers(buffers);
            var block = IsFrozen ? _readonlyBlock : _writableBlock.ToArray();
            buffers[ClassHeight - 1] = block;
        }

        public T_BaseName_()
        {
            _readonlyBlock = _writableBlock = new byte[BlockLength];
        }

        public T_BaseName_(T_BaseName_ source, bool frozen = false) : base(source, frozen)
        {
            _writableBlock = source._writableBlock.ToArray();
            _readonlyBlock = _writableBlock;
        }

        public T_BaseName_(IT_BaseName_ source, bool frozen = false) : base(source, frozen)
        {
            _readonlyBlock = _writableBlock = new byte[BlockLength];
            this.BaseField1 = source.BaseField1;
        }

        public T_BaseName_(ReadOnlyMemory<ReadOnlyMemory<byte>> buffers) : base(buffers)
        {
            ReadOnlyMemory<byte> source = buffers.Span[ClassHeight - 1];
            if (source.Length >= BlockLength)
            {
                _readonlyBlock = source.Slice(0, BlockLength);
            }
            else
            {
                // forced copy as source is too short
                Memory<byte> memory = new byte[BlockLength];
                source.Span.CopyTo(memory.Span);
                _readonlyBlock = memory;
            }
            _writableBlock = Memory<byte>.Empty;
        }

        private const int T_FieldOffset_ = 4;
        private const int T_FieldLength_ = 4;

        public T_MemberType_ BaseField1
        {
            get
            {
                return (T_MemberType_)Codec_T_MemberType__T_MemberBELE_.ReadFromSpan(_readonlyBlock.Slice(T_FieldOffset_, T_FieldLength_).Span);
            }

            set
            {
                ThrowExceptionIfFrozen();
                Codec_T_MemberType__T_MemberBELE_.WriteToSpan(_writableBlock.Slice(T_FieldOffset_, T_FieldLength_).Span, value);
            }
        }

        public bool Equals(T_BaseName_? other)
        {
            if (ReferenceEquals(this, other)) return true;
            if (other is null) return false;
            if (!base.Equals(other)) return false;
            if (!_readonlyBlock.Span.SequenceEqual(other._readonlyBlock.Span)) return false;
            return true;
        }
        public override bool Equals(object? obj) => obj is T_BaseName_ other && Equals(other);
        public override int GetHashCode() => base.GetHashCode();
    }
    public interface IT_EntityName_ : IT_BaseName_
    {
        T_MemberType_ T_ScalarMemberName_ { get; set; }
        ReadOnlyMemory<T_MemberType_> T_VectorMemberName_ { get; set; }
    }
    //##endif
    public partial class T_EntityName_ : T_BaseName_, IT_EntityName_, IEquatable<T_EntityName_>
    {
        // Derived entities: T_DerivedEntityCount_
        //##foreach DerivedEntities
        // - T_EntityName_
        //##endfor

        //##if false
        private const int T_ClassHeight_ = 2;
        private const int T_BlockLength_ = 128;
        private const bool T_MemberObsoleteIsError_ = false;
        //##endif
        private const int ClassHeight = T_ClassHeight_;
        private const int BlockLength = T_BlockLength_;
        private readonly Memory<byte> _writableBlock;
        private readonly ReadOnlyMemory<byte> _readonlyBlock;

        public new const string EntityId = "T_EntityId_";

        public new static T_EntityName_ CreateFrom(string entityId, ReadOnlyMemory<ReadOnlyMemory<byte>> buffers)
        {
            return entityId switch
            {
                //##foreach DerivedEntities
                T_NameSpace_.MemBlocks.T_EntityName_.EntityId => new T_NameSpace_.MemBlocks.T_EntityName_(buffers),
                //##endfor
                _ => throw new ArgumentOutOfRangeException(nameof(entityId), entityId, null)
            };
        }

        protected override string OnGetEntityId() => EntityId;
        protected override int OnGetClassHeight() => ClassHeight;
        protected override void OnGetBuffers(ReadOnlyMemory<byte>[] buffers)
        {
            base.OnGetBuffers(buffers);
            var block = IsFrozen ? _readonlyBlock : _writableBlock.ToArray();
            buffers[ClassHeight - 1] = block;
        }

        // -------------------- field map -----------------------------
        //  Seq.  Off.  Len.  N.    Type    End.  Name
        //  ----  ----  ----  ----  ------- ----  -------
        //##foreach Members
        //  T_MemberSequenceR4_  T_FieldOffsetR4_  T_FieldLengthR4_  T_ArrayLengthR4_  T_MemberTypeL7_ T_MemberBELE_    T_MemberName_
        //##endfor
        // ------------------------------------------------------------

        public T_EntityName_()
        {
            _readonlyBlock = _writableBlock = new byte[BlockLength];
        }

        public T_EntityName_(T_EntityName_ source, bool frozen = false) : base(source, frozen)
        {
            _writableBlock = source._writableBlock.ToArray();
            _readonlyBlock = _writableBlock;
        }

        public T_EntityName_(IT_EntityName_ source, bool frozen = false) : base(source, frozen)
        {
            _readonlyBlock = _writableBlock = new byte[BlockLength];
            //##foreach Members
            //##if MemberIsArray
            this.T_VectorMemberName_ = source.T_VectorMemberName_;
            //##else
            this.T_ScalarMemberName_ = source.T_ScalarMemberName_;
            //##endif
            //##endfor
        }

        public T_EntityName_(ReadOnlyMemory<ReadOnlyMemory<byte>> buffers) : base(buffers)
        {
            ReadOnlyMemory<byte> source = buffers.Span[ClassHeight - 1];
            if (source.Length >= BlockLength)
            {
                _readonlyBlock = source.Slice(0, BlockLength);
            }
            else
            {
                // forced copy as source is too short
                Memory<byte> memory = new byte[BlockLength];
                source.Span.CopyTo(memory.Span);
                _readonlyBlock = memory;
            }
            _writableBlock = Memory<byte>.Empty;
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
                ThrowExceptionIfFrozen();
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
                ThrowExceptionIfFrozen();
                Codec_T_MemberType__T_MemberBELE_.WriteToSpan(_writableBlock.Slice(T_FieldOffset_, T_FieldLength_).Span, value);
            }
        }

        //##endif
        //##endfor

        public bool Equals(T_EntityName_? other)
        {
            if (ReferenceEquals(this, other)) return true;
            if (other is null) return false;
            if (!base.Equals(other)) return false;
            if (!_readonlyBlock.Span.SequenceEqual(other._readonlyBlock.Span)) return false;
            return true;
        }

        public override bool Equals(object? obj) => obj is T_EntityName_ other && Equals(other);
        public static bool operator ==(T_EntityName_? left, T_EntityName_? right) => left is not null ? left.Equals(right) : (right is null);
        public static bool operator !=(T_EntityName_? left, T_EntityName_? right) => left is not null ? !left.Equals(right) : (right is not null);

        private int CalcHashCode()
        {
            HashCode result = new HashCode();
            result.Add(base.GetHashCode());
#if NET8_0_OR_GREATER
            result.AddBytes(_readonlyBlock.Span);
#else
            var byteSpan = _readonlyBlock.Span;
            result.Add(byteSpan.Length);
            for (int i = 0; i < byteSpan.Length; i++)
            {
                result.Add(byteSpan[i]);
            }
#endif
            return result.ToHashCode();
        }

        private int? _hashCode;
        public override int GetHashCode()
        {
            if (_hashCode.HasValue) return _hashCode.Value;
            if (!IsFrozen) return CalcHashCode();
            _hashCode = CalcHashCode();
            return _hashCode.Value;
        }

    }
}
