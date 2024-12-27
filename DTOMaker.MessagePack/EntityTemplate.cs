﻿// <auto-generated>
// This file was generated by DTOMaker.MessagePack.
// NuGet: https://www.nuget.org/packages/DTOMaker.MessagePack
// Warning: Changes made to this file will be lost if re-generated.
// </auto-generated>
#pragma warning disable CS0414
#nullable enable
using DataFac.Runtime;
using MessagePack;
using System;

namespace T_DomainName_.MessagePack
{
    //##if false
    using T_MemberType_ = System.Int32;
    public interface IT_BaseName_ { }
    public interface IT_EntityName_ : IT_BaseName_
    {
        //##if MemberIsNullable
        T_MemberType_? T_ScalarNullableMemberName_ { get; set; }
        //##else
        T_MemberType_ T_ScalarRequiredMemberName_ { get; set; }
        //##endif
        ReadOnlyMemory<T_MemberType_> T_VectorMemberName_ { get; set; }
    }
    [MessagePackObject]
    [Union(T_EntityName_.EntityKey, typeof(T_EntityName_))]
    public abstract class T_BaseName_ : EntityBase, IT_BaseName_, IEquatable<T_BaseName_>
    {
        public const int EntityKey = 1;

        public T_BaseName_() { }
        public T_BaseName_(IT_BaseName_ source, bool frozen = false) : base(source, frozen) { }

        protected override void OnFreeze() => base.OnFreeze();
        protected override IFreezable OnPartCopy() => throw new NotImplementedException();

        [Key(1)] public T_MemberType_ BaseField1 { get; set; }

        public bool Equals(T_BaseName_? other)
        {
            if (ReferenceEquals(this, other)) return true;
            if (other is null) return false;
            if (!base.Equals(other)) return false;
            return true;
        }
        public override bool Equals(object? obj) => obj is T_BaseName_ other && Equals(other);
        public override int GetHashCode() => base.GetHashCode();
    }
    //##endif
    [MessagePackObject]
    //##foreach DerivedEntities
    //##if DerivedEntityCount == 0
    [Union(T_EntityName_.EntityKey, typeof(T_EntityName_))]
    //##endif
    //##endfor
    //##if DerivedEntityCount > 0
    public abstract partial class T_EntityName2_ { }
    //##endif
    public partial class T_EntityName_ : T_BaseName_, IT_EntityName_, IEquatable<T_EntityName_>
    {
        // Derived entities: T_DerivedEntityCount_
        //##foreach DerivedEntities
        // - T_EntityName_
        //##endfor
        //##if false
        private const string T_MemberObsoleteMessage_ = null;
        private const bool T_MemberObsoleteIsError_ = false;
        private const int T_EntityKey_ = 2;
        private const int T_MemberKeyOffset_ = 10;
        private const int T_ScalarNullableMemberKey_ = T_MemberKeyOffset_ + 1;
        private const int T_ScalarRequiredMemberKey_ = T_MemberKeyOffset_ + 2;
        private const int T_VectorMemberKey_ = T_MemberKeyOffset_ + 3;
        private const int T_MemberDefaultValue_ = 0;
        //##endif

        public new const int EntityKey = T_EntityKey_;

        public new static T_EntityName_ Create(int entityKey, ReadOnlyMemory<byte> buffer)
        {
            return entityKey switch
            {
                //##foreach DerivedEntities
                //##if DerivedEntityCount == 0
                T_EntityName_.EntityKey => MessagePackSerializer.Deserialize<T_EntityName_>(buffer, out var _),
                //##endif
                //##endfor
                _ => throw new ArgumentOutOfRangeException(nameof(entityKey), entityKey, null)
            };
        }

        protected override void OnFreeze()
        {
            base.OnFreeze();
            // todo freezable members
        }

        //##if DerivedEntityCount == 0
        protected override IFreezable OnPartCopy() => new T_EntityName_(this);

        //##endif
        public T_EntityName_() { }
        public T_EntityName_(IT_EntityName_ source, bool frozen = false) : base(source, frozen)
        {
            //##foreach Members
            //##if MemberIsArray
            _T_VectorMemberName_ = source.T_VectorMemberName_;
            //##else
            //##if MemberIsNullable
            _T_ScalarNullableMemberName_ = source.T_ScalarNullableMemberName_;
            //##else
            _T_ScalarRequiredMemberName_ = source.T_ScalarRequiredMemberName_;
            //##endif
            //##endif
            //##endfor
        }

        //##foreach Members
        //##if MemberIsArray
        [IgnoreMember]
        private ReadOnlyMemory<T_MemberType_> _T_VectorMemberName_;
        //##if MemberIsObsolete
        [Obsolete("T_MemberObsoleteMessage_", T_MemberObsoleteIsError_)]
        //##endif
        [Key(T_VectorMemberKey_)]
        public ReadOnlyMemory<T_MemberType_> T_VectorMemberName_
        {
            get => _T_VectorMemberName_;
            set => _T_VectorMemberName_ = IfNotFrozen(ref value);
        }

        //##else
        //##if MemberIsNullable
        [IgnoreMember]
        private T_MemberType_? _T_ScalarNullableMemberName_;
        //##else
        [IgnoreMember]
        private T_MemberType_ _T_ScalarRequiredMemberName_ = T_MemberDefaultValue_;
        //##endif
        //##if MemberIsObsolete
        [Obsolete("T_MemberObsoleteMessage_", T_MemberObsoleteIsError_)]
        //##endif
        //##if MemberIsNullable
        [Key(T_ScalarNullableMemberKey_)]
        public T_MemberType_? T_ScalarNullableMemberName_
        {
            get => _T_ScalarNullableMemberName_;
            set => _T_ScalarNullableMemberName_ = IfNotFrozen(ref value);
        }
        //##else
        [Key(T_ScalarRequiredMemberKey_)]
        public T_MemberType_ T_ScalarRequiredMemberName_
        {
            get => _T_ScalarRequiredMemberName_;
            set => _T_ScalarRequiredMemberName_ = IfNotFrozen(ref value);
        }
        //##endif

        //##endif
        //##endfor

        public bool Equals(T_EntityName_? other)
        {
            if (ReferenceEquals(this, other)) return true;
            if (other is null) return false;
            if (!base.Equals(other)) return false;
            //##foreach Members
            //##if MemberIsArray
            if (!_T_VectorMemberName_.Span.SequenceEqual(other.T_VectorMemberName_.Span)) return false;
            //##else
            //##if MemberIsNullable
            if (_T_ScalarNullableMemberName_ != other.T_ScalarNullableMemberName_) return false;
            //##else
            if (_T_ScalarRequiredMemberName_ != other.T_ScalarRequiredMemberName_) return false;
            //##endif
            //##endif
            //##endfor
            return true;
        }

        public override bool Equals(object? obj) => obj is T_EntityName_ other && Equals(other);
        public static bool operator ==(T_EntityName_? left, T_EntityName_? right) => left is not null ? left.Equals(right) : (right is null);
        public static bool operator !=(T_EntityName_? left, T_EntityName_? right) => left is not null ? !left.Equals(right) : (right is not null);

        private int CalcHashCode()
        {
            HashCode result = new HashCode();
            result.Add(base.GetHashCode());
            //##foreach Members
            //##if MemberIsArray
            result.Add(_T_VectorMemberName_.Length);
            for (int i = 0; i < _T_VectorMemberName_.Length; i++)
            {
                result.Add(_T_VectorMemberName_.Span[i]);
            }
            //##else
            //##if MemberIsNullable
            result.Add(_T_ScalarNullableMemberName_);
            //##else
            result.Add(_T_ScalarRequiredMemberName_);
            //##endif
            //##endif
            //##endfor
            return result.ToHashCode();
        }

        [IgnoreMember]
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