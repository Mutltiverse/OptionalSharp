using System.Collections.Generic;
using System;

namespace Utility
{
    public class Optional<T> : IEquatable<Optional<T>>
    {
        public T Value { get; }
        public bool HasValue { get; }

        private Optional(T value)
        {
            Value = value;
            HasValue = true;
        }

        private Optional() { }

        public static Optional<T> Of(T value) => new Optional<T>(value);

        public static Optional<T> None => new Optional<T>();

        public bool Equals(Optional<T> other)
        {
            // If both are None, then they are equal.
            if (!HasValue && !other.HasValue)
                return true;

            // If one has value and the other doesn't, they are not equal.
            if (HasValue != other.HasValue)
                return false;

            // If both have values, compare the values for equality.
            return EqualityComparer<T>.Default.Equals(Value, other.Value);
        }

        public override bool Equals(object obj)
        {
            return obj is Optional<T> optional && Equals(optional);
        }

        public override int GetHashCode()
        {
            // Hash code should be calculated based on HasValue and Value.
            // If HasValue is false, Value is ignored.
            return HasValue ? Value.GetHashCode() : 0;
        }
    }
}
