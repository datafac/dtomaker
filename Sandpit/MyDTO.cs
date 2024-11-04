﻿// <auto-generated>
// This file was generated by DTOMaker.MemBlocks.
// NuGet: https://www.nuget.org/packages/DTOMaker.MemBlocks
// Warning: Changes made to this file will be lost if re-generated.
// </auto-generated>
#pragma warning disable CS0414
#nullable enable
using System;
using System.Collections;
using System.Collections.Specialized;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using DTOMaker.Runtime;
namespace MyOrg.Models.MemBlocks
{
    public sealed partial class MyDTO : IMyDTO, IFreezable
    {
        private const int BlockLength = 4;
        private readonly Memory<byte> _writableBlock;
        private readonly ReadOnlyMemory<byte> _readonlyBlock;
        public ReadOnlyMemory<byte> Block => _frozen ? _readonlyBlock : _writableBlock.ToArray();

        public MyDTO() => _readonlyBlock = _writableBlock = new byte[BlockLength];

        public MyDTO(ReadOnlySpan<byte> source, bool frozen)
        {
            Memory<byte> memory = new byte[BlockLength];
            source.Slice(0, BlockLength).CopyTo(memory.Span);
            _readonlyBlock = memory;
            _writableBlock = memory;
            _frozen = frozen;
        }

        public MyDTO(ReadOnlyMemory<byte> source)
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
        public IFreezable PartCopy() => new MyDTO(this);

        [MethodImpl(MethodImplOptions.NoInlining)]
        private void ThrowIsFrozenException(string? methodName) => throw new InvalidOperationException($"Cannot call {methodName} when frozen.");

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private ref T IfNotFrozen<T>(ref T value, [CallerMemberName] string? methodName = null)
        {
            if (_frozen) ThrowIsFrozenException(methodName);
            return ref value;
        }

        public void Freeze()
        {
            if (_frozen) return;
            _frozen = true;
            // todo freeze base
            // todo freeze model type refs
        }

        public MyDTO(MyDTO source)
        {
            // todo base ctor
            // todo freezable members
            _writableBlock = source._writableBlock.ToArray();
            _readonlyBlock = _writableBlock;
            _frozen = false;
        }

        public MyDTO(IMyDTO source) : this(ReadOnlySpan<byte>.Empty, false)
        {
            // todo base ctor
            // todo freezable members
            // todo copy members
            this.Field1 = source.Field1;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static (T, byte) GetValueAndFlags<T>(T? input) where T : struct
        {
            if (input.HasValue)
                return (input.Value, 1);
            else
                return (default, 0);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private void ThrowOutOfRangeException(int count, int maxCount) => throw new ArgumentOutOfRangeException(nameof(count), count, $"0 <= {nameof(count)} <= {maxCount}");

        private ArrayFacade<Int16>? _facade_Field1;
        public IList<Int16?>? Field1
        {
            get
            {
                const int _flagsOffset = 0;
                const int _countOffset = 2;
                const int _fieldLength = 2;
                const int _maxCapacity = 8;
                const int _flagsArrayOffset = 16;
                const int _valueArrayOffset = 16;
                byte flags = DTOMaker.Runtime.Codec_Byte_LE.ReadFromSpan(_readonlyBlock.Slice(_flagsOffset, 1).Span);
                if (flags == 0) return null;
                if (_facade_Field1 is null)
                {
                    _facade_Field1 = new ArrayFacade<Int16>(nameof(Field1), DTOMaker.Runtime.Codec_Int16_LE.Instance, () => _frozen,
                        _readonlyBlock, _writableBlock, _countOffset, _maxCapacity, _fieldLength, _flagsArrayOffset, _valueArrayOffset);
                }
                return _facade_Field1;
            }

            set
            {
                const int _flagsOffset = 0;
                const int _countOffset = 2;
                const int _fieldLength = 2;
                const int _maxCapacity = 8;
                const int _flagsArrayOffset = 16;
                const int _valueArrayOffset = 16;
                if (_frozen) ThrowIsFrozenException(nameof(Field1));
                if (value is null)
                {
                    DTOMaker.Runtime.Codec_Byte_LE.WriteToSpan(_writableBlock.Slice(_flagsOffset, 1).Span, 0);
                    return;
                }
                DTOMaker.Runtime.Codec_Byte_LE.WriteToSpan(_writableBlock.Slice(_flagsOffset, 1).Span, 1);
                if (_facade_Field1 is null)
                {
                    _facade_Field1 = new ArrayFacade<Int16>(nameof(Field1), DTOMaker.Runtime.Codec_Int16_LE.Instance, () => _frozen,
                        _readonlyBlock, _writableBlock, _countOffset, _maxCapacity, _fieldLength, _flagsArrayOffset, _valueArrayOffset);
                }
                if (value.Count > _maxCapacity)
                {
                    ThrowOutOfRangeException(value.Count, _maxCapacity);
                    return;
                }
                ushort count = (ushort)value.Count;
                DTOMaker.Runtime.Codec_UInt16_LE.WriteToSpan(_writableBlock.Slice(_countOffset, 2).Span, count);
                for (int i = 0; i < count; i++)
                {
                    _facade_Field1.UnsafeSet(i, value[i]);
                }
            }
        }

        public bool Field2_HasValue
        {
            get
            {
                const int _valueOffset = 16;
                return DTOMaker.Runtime.Codec_Boolean_LE.ReadFromSpan(_readonlyBlock.Slice(_valueOffset, 1).Span);
            }

            set
            {
                const int _valueOffset = 16;
                DTOMaker.Runtime.Codec_Boolean_LE.WriteToSpan(_writableBlock.Slice(_valueOffset, 1).Span, value);
            }
        }
        public double Field2_Value
        {
            get
            {
                const int _valueOffset = 16;
                return DTOMaker.Runtime.Codec_Double_LE.ReadFromSpan(_readonlyBlock.Slice(_valueOffset, 8).Span);
            }

            set
            {
                const int _valueOffset = 16;
                DTOMaker.Runtime.Codec_Double_LE.WriteToSpan(_writableBlock.Slice(_valueOffset, 8).Span, value);
            }
        }

        public ReadOnlyMemory<byte> Field4
        {
            get
            {
                const int _countOffset = 2;
                const int _maxCapacity = 8;
                const int _valueOffset = 16;
                ushort count = DTOMaker.Runtime.Codec_UInt16_LE.ReadFromSpan(_readonlyBlock.Slice(_countOffset, 2).Span);
                if (count == 0) return ReadOnlyMemory<byte>.Empty;
                var fullSlice = _readonlyBlock.Slice(_valueOffset, _maxCapacity);
                return fullSlice.Slice(0, count);
            }

            set
            {
                const int _countOffset = 2;
                const int _maxCapacity = 8;
                const int _valueOffset = 16;
                if (_frozen) ThrowIsFrozenException(nameof(Field4));
                if (value.Length > _maxCapacity)
                {
                    ThrowOutOfRangeException(value.Length, _maxCapacity);
                    return;
                }
                ushort count = (ushort)value.Length;
                DTOMaker.Runtime.Codec_UInt16_LE.WriteToSpan(_writableBlock.Slice(_countOffset, 2).Span, count);
                if (count > 0)
                {
                    var fullSlice = _writableBlock.Slice(_valueOffset, _maxCapacity).Slice(0, count);
                    value.CopyTo(fullSlice);
                }
            }
        }

        // Octets
        public ReadOnlyMemory<byte>? Field5
        {
            get
            {
                const int _flagsOffset = 0;
                const int _countOffset = 2;
                const int _maxCapacity = 8;
                const int _valueOffset = 16;
                Flags flags = DTOMaker.Runtime.Codec_Flags.ReadFromSpan(_readonlyBlock.Slice(_flagsOffset, 1).Span);
                if (flags.IsNull) return null;
                ushort count = DTOMaker.Runtime.Codec_UInt16_LE.ReadFromSpan(_readonlyBlock.Slice(_countOffset, 2).Span);
                if (count == 0) return ReadOnlyMemory<byte>.Empty;
                var fullSlice = _readonlyBlock.Slice(_valueOffset, _maxCapacity);
                return fullSlice.Slice(0, count);
            }

            set
            {
                const int _flagsOffset = 0;
                const int _countOffset = 2;
                const int _maxCapacity = 8;
                const int _valueOffset = 16;
                if (_frozen) ThrowIsFrozenException(nameof(Field5));
                if (value is null)
                {
                    DTOMaker.Runtime.Codec_Flags.WriteToSpan(_writableBlock.Slice(_flagsOffset, 1).Span, Flags.Null);
                    return;
                }
                DTOMaker.Runtime.Codec_Flags.WriteToSpan(_writableBlock.Slice(_flagsOffset, 1).Span, Flags.NonNull);
                if (value.Value.Length > _maxCapacity)
                {
                    ThrowOutOfRangeException(value.Value.Length, _maxCapacity);
                    return;
                }
                ushort count = (ushort)value.Value.Length;
                DTOMaker.Runtime.Codec_UInt16_LE.WriteToSpan(_writableBlock.Slice(_countOffset, 2).Span, count);
                if (count > 0)
                {
                    var fullSlice = _writableBlock.Slice(_valueOffset, _maxCapacity).Slice(0, count);
                    value.Value.CopyTo(fullSlice);
                }
            }
        }

        // UTF8-encoded string
        public string? Field6
        {
            get
            {
                const int _flagsOffset = 0;
                const int _countOffset = 2;
                const int _maxCapacity = 8;
                const int _valueOffset = 16;
                Flags flags = DTOMaker.Runtime.Codec_Flags.ReadFromSpan(_readonlyBlock.Slice(_flagsOffset, 1).Span);
                if (flags.IsNull) return null;
                ushort count = DTOMaker.Runtime.Codec_UInt16_LE.ReadFromSpan(_readonlyBlock.Slice(_countOffset, 2).Span);
                if (count == 0) return string.Empty;
                var fullSlice = _readonlyBlock.Slice(_valueOffset, _maxCapacity);
#if NET6_0_OR_GREATER
                return UTF8Encoding.UTF8.GetString(fullSlice.Span.Slice(0, count));
#else
                return Encoding.UTF8.GetString(fullSlice.ToArray(), 0, count);
#endif
            }

            set
            {
                const int _flagsOffset = 0;
                const int _countOffset = 2;
                const int _maxCapacity = 8;
                const int _valueOffset = 16;
                if (_frozen) ThrowIsFrozenException(nameof(Field4));
                if (value is null)
                {
                    DTOMaker.Runtime.Codec_Flags.WriteToSpan(_writableBlock.Slice(_flagsOffset, 1).Span, Flags.Null);
                    return;
                }
                DTOMaker.Runtime.Codec_Flags.WriteToSpan(_writableBlock.Slice(_flagsOffset, 1).Span, Flags.NonNull);
                var fullSpan = _writableBlock.Slice(_valueOffset, _maxCapacity).Span;
                fullSpan.Clear();
#if NET6_0_OR_GREATER
                int bytesWritten = UTF8Encoding.UTF8.GetBytes(value.AsSpan(), fullSpan);
                ushort count = (ushort)bytesWritten;
                DTOMaker.Runtime.Codec_UInt16_LE.WriteToSpan(_writableBlock.Slice(_countOffset, 2).Span, count);
#else
                var encoded = Encoding.UTF8.GetBytes(value);
                ushort count = (ushort)encoded.Length;
                if (count > 0)
                {
                    encoded.CopyTo(fullSpan);
                }
                DTOMaker.Runtime.Codec_UInt16_LE.WriteToSpan(_writableBlock.Slice(_countOffset, 2).Span, count);
#endif
            }
        }

    }

    internal sealed class ArrayFacade<TWireType> : IList<TWireType?> where TWireType : struct
    {
        private readonly string _fieldName;
        private readonly ITypedFieldCodec<TWireType> _codec;
        private readonly Func<bool> _isFrozenFn;
        private readonly int _countOffset;
        private readonly int _flagsArrayOffset;
        private readonly int _valueArrayOffset;
        private readonly int _fieldLength;
        private readonly int _maxCapacity;
        private readonly ReadOnlyMemory<byte> _readonlyCountBlock;
        private readonly ReadOnlyMemory<byte> _readonlyFlagsBlock;
        private readonly ReadOnlyMemory<byte> _readonlyValueBlock;
        private readonly Memory<byte> _writableCountBlock;
        private readonly Memory<byte> _writableFlagsBlock;
        private readonly Memory<byte> _writableValueBlock;

        public ArrayFacade(string fieldName, ITypedFieldCodec<TWireType> codec, Func<bool> isFrozenFn,
            ReadOnlyMemory<byte> readonlyBlock, Memory<byte> writableBlock,
            int countOffset, int maxCapacity, int fieldLength, int flagsArrayOffset, int valueArrayOffset)
        {
            _fieldName = fieldName;
            _codec = codec;
            _countOffset = countOffset;
            _maxCapacity = maxCapacity;
            _fieldLength = fieldLength;
            _flagsArrayOffset = flagsArrayOffset;
            _valueArrayOffset = valueArrayOffset;
            _isFrozenFn = isFrozenFn;
            _readonlyCountBlock = readonlyBlock.Slice(_countOffset, 2);
            _writableCountBlock = writableBlock.Slice(_countOffset, 2);
            _readonlyFlagsBlock = readonlyBlock.Slice(_flagsArrayOffset, 1 * _maxCapacity);
            _writableFlagsBlock = writableBlock.Slice(_flagsArrayOffset, 1 * _maxCapacity);
            _readonlyValueBlock = readonlyBlock.Slice(_valueArrayOffset, _fieldLength * _maxCapacity);
            _writableValueBlock = writableBlock.Slice(_valueArrayOffset, _fieldLength * _maxCapacity);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private void ThrowIsFrozenException(string? methodName) => throw new InvalidOperationException($"Cannot call {methodName} when frozen.");

        [MethodImpl(MethodImplOptions.NoInlining)]
        private void ThrowOutOfRangeException(int index, int count) => throw new ArgumentOutOfRangeException(nameof(index), index, $"0 <= {nameof(index)} < {count}");

        public TWireType? this[int index]
        {
            get
            {
                ushort count = DTOMaker.Runtime.Codec_UInt16_LE.ReadFromSpan(_readonlyCountBlock.Span);
                if (index < 0 || index >= count) ThrowOutOfRangeException(index, count);
                byte flags = DTOMaker.Runtime.Codec_Byte_LE.ReadFromSpan(_readonlyFlagsBlock.Slice(index, 1).Span);
                if (flags == 0) return null;
                return _codec.ReadFrom(_readonlyValueBlock.Slice(_fieldLength * index, _fieldLength).Span);
            }
            set
            {
                if (_isFrozenFn()) ThrowIsFrozenException(_fieldName);
                ushort count = DTOMaker.Runtime.Codec_UInt16_LE.ReadFromSpan(_readonlyCountBlock.Span);
                if (index < 0 || index >= count) ThrowOutOfRangeException(index, count);
                UnsafeSet(index, value);
            }
        }

        public void UnsafeSet(int index, TWireType? value)
        {
            (byte flags, TWireType wireValue) = (value is null) ? ((byte)0, default) : ((byte)1, value.Value);
            DTOMaker.Runtime.Codec_Byte_LE.WriteToSpan(_writableFlagsBlock.Slice(index, 1).Span, flags);
            _codec.WriteTo(_writableValueBlock.Slice(_fieldLength * index, _fieldLength).Span, wireValue);
        }

        public int Count => DTOMaker.Runtime.Codec_UInt16_LE.ReadFromSpan(_readonlyCountBlock.Span);

        public bool IsReadOnly => _isFrozenFn();

        public IEnumerator<TWireType?> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public int IndexOf(TWireType? item)
        {
            throw new NotImplementedException();
        }

        public bool Contains(TWireType? item)
        {
            throw new NotImplementedException();
        }

        public void CopyTo(TWireType?[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public void Insert(int index, TWireType? item)
        {
            if (_isFrozenFn()) ThrowIsFrozenException(nameof(Insert));
            throw new NotImplementedException();
        }

        public void RemoveAt(int index)
        {
            if (_isFrozenFn()) ThrowIsFrozenException(nameof(RemoveAt));
            throw new NotImplementedException();
        }

        public void Add(TWireType? item)
        {
            if (_isFrozenFn()) ThrowIsFrozenException(nameof(Add));
            throw new NotImplementedException();
        }

        public void Clear()
        {
            if (_isFrozenFn()) ThrowIsFrozenException(nameof(Clear));
            throw new NotImplementedException();
        }

        public bool Remove(TWireType? item)
        {
            if (_isFrozenFn()) ThrowIsFrozenException(nameof(Remove));
            throw new NotImplementedException();
        }
    }
}