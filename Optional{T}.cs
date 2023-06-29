using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utility
{
    /// <summary>
    /// Optional pattern exists to make it more obvious and avoid nullable contexts and confusion.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Optional<T> : IEquatable<Optional<T>>
    {
        public T Value { get; }
        public bool HasValue { get; }

        public Optional(T value)
        {
            Value = value;
            HasValue = true;
        }

        public Optional() { }


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

        // Ensure the base class Equals is overridden as well.
        public override bool Equals(object obj)
        {
            return obj is Optional<T> optional && Equals(optional);
        }

        public override int GetHashCode()
        {
            // Hash code should be calculated based on HasValue and Value.
            // If HasValue is false, Value is ignored.
            var hashCode = -1827433384;
            hashCode = hashCode * -1521134295 + HasValue.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<T>.Default.GetHashCode(Value);
            return hashCode;
        }

    }
}
