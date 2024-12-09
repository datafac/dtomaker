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
    public interface IT_ParentName_ { }
    public interface IT_EntityName_ : IT_ParentName_
    {
        //##if MemberIsNullable
        T_MemberType_? T_ScalarNullableMemberName_ { get; set; }
        //##else
        T_MemberType_ T_ScalarRequiredMemberName_ { get; set; }
        //##endif
        ReadOnlyMemory<T_MemberType_> T_VectorMemberName_ { get; set; }
    }
    public class T_ParentName_ : EntityBase, IT_ParentName_, IEquatable<T_ParentName_>
    {
        public T_ParentName_() { }
        public T_ParentName_(IT_ParentName_ source, bool frozen = false) : base(source, frozen) { }
        public bool Equals(T_ParentName_? other)
        {
            if (ReferenceEquals(this, other)) return true;
            if (other is null) return false;
            if (!base.Equals(other)) return false;
            return true;
        }
    }
    //##endif
    [MessagePackObject]
    public partial class T_EntityName_ : T_ParentName_, IT_EntityName_, IFreezable
    {
        //##if false
        private const int T_ScalarNullableMemberSequence_ = 1;
        private const int T_ScalarRequiredMemberSequence_ = 2;
        private const int T_VectorMemberSequence_ = 3;
        private const string T_MemberObsoleteMessage_ = null;
        private const bool T_MemberObsoleteIsError_ = false;
        private const int T_EntityTag_ = 1;
        //##endif

        public const int EntityTag = T_EntityTag_;
        protected override void OnFreeze()
        {
            base.OnFreeze();
            // todo freezable members
        }

        protected override IFreezable OnPartCopy() => new T_EntityName_(this);

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
        [Key(T_VectorMemberSequence_)]
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
        private T_MemberType_ _T_ScalarRequiredMemberName_;
        //##endif
        //##if MemberIsObsolete
        [Obsolete("T_MemberObsoleteMessage_", T_MemberObsoleteIsError_)]
        //##endif
        //##if MemberIsNullable
        [Key(T_ScalarNullableMemberSequence_)]
        public T_MemberType_? T_ScalarNullableMemberName_
        {
            get => _T_ScalarNullableMemberName_;
            set => _T_ScalarNullableMemberName_ = IfNotFrozen(ref value);
        }
        //##else
        [Key(T_ScalarRequiredMemberSequence_)]
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
            if (!_T_ScalarNullableMemberName_.Equals(other.T_ScalarNullableMemberName_)) return false;
            //##else
            if (!_T_ScalarRequiredMemberName_.Equals(other.T_ScalarRequiredMemberName_)) return false;
            //##endif
            //##endif
            //##endfor
            return true;
        }

        public override bool Equals(object? obj)
        {
            return obj is T_EntityName_ other && Equals(other);
        }

        private int CalcHashCode()
        {
            HashCode result = new HashCode();
            // todo result.Add(base.GetHashCode());
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

        private int? _hashCode;
        public override int GetHashCode()
        {
            if (_hashCode.HasValue) return _hashCode.Value;
            if (!this.IsFrozen()) return CalcHashCode();
            _hashCode = CalcHashCode();
            return _hashCode.Value;
        }

    }
}