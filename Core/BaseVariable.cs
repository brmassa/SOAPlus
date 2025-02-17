using System;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Serialization;

namespace SOAPlus.Core
{
    public abstract class BaseVariable<T> : BaseEvent<T>, IEquatable<T>
    {
        [FormerlySerializedAs("_initialValue")]
        [SerializeField] private T initialValue;
        [FormerlySerializedAs("_currentValue")]
        [SerializeField] private T currentValue;

        public T Value
        {
            get => currentValue;
            set
            {
                if (!Equals(currentValue, value))
                {
                    currentValue = value;
                    Raise(value);
                }
            }
        }

        [PublicAPI]
        public BaseVariable(T initialValue)
        {
            this.initialValue = initialValue;
            currentValue = initialValue;
        }

        public void Reset() => Value = initialValue;

        public bool Equals(T other) => Equals(currentValue, other);

        public static implicit operator T(BaseVariable<T> variable) => variable.Value;

        public static bool operator ==(BaseVariable<T> a, T b)
        {
            if (a is null)
            {
                return b is null;
            }

            return a.Equals(b);
        }

        public static bool operator !=(BaseVariable<T> a, T b) => !(a == b);

        public override string ToString() => currentValue?.ToString() ?? "null";

        public override bool Equals(object obj)
        {
            if (obj is T otherValue)
            {
                return Equals(otherValue);
            }
            if (obj is BaseVariable<T> otherVariable)
            {
                return Equals(otherVariable.Value);
            }
            return false;
        }

        public override int GetHashCode() => currentValue?.GetHashCode() ?? 0;
    }
}
