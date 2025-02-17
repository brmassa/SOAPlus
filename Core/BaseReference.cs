using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace SOAPlus.Core
{
    [Serializable]
    public abstract class BaseReference<T, TVariable> : IEquatable<BaseReference<T, TVariable>>
        where TVariable : BaseVariable<T>
    {
        [FormerlySerializedAs("UseConstant")]
        [SerializeField]
        internal bool useConstant = true;
        [FormerlySerializedAs("ConstantValue")]
        [SerializeField]
        internal T constantValue;
        [FormerlySerializedAs("Variable")]
        [SerializeField]
        internal TVariable variable;

        public BaseReference() { }

        public BaseReference(T value)
        {
            useConstant = true;
            constantValue = value;
        }

        public BaseReference(TVariable variable)
        {
            useConstant = false;
            this.variable = variable;
        }

        public T Value
        {
            get => useConstant ? constantValue : variable.Value;
            set
            {
                if (useConstant)
                {
                    constantValue = value;
                }
                else
                {
                    variable.Value = value;
                }
            }
        }

        public static implicit operator T(BaseReference<T, TVariable> reference) => reference.Value;

        public bool Equals(BaseReference<T, TVariable> other)
        {
            if (other == null)
            {
                return false;
            }

            return Value.Equals(other.Value);
        }

        public override bool Equals(object obj)
        {
            if (obj is BaseReference<T, TVariable> other)
            {
                return Equals(other);
            }
            return false;
        }

        public override int GetHashCode() => Value.GetHashCode();

        public static bool operator ==(BaseReference<T, TVariable> a, BaseReference<T, TVariable> b)
        {
            if (ReferenceEquals(a, b))
            {
                return true;
            }

            if (a is null || b is null)
            {
                return false;
            }

            return a.Equals(b);
        }

        public static bool operator !=(BaseReference<T, TVariable> a, BaseReference<T, TVariable> b) => !(a == b);
    }
}
