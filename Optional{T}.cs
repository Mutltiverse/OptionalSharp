using System.Collections.Generic;
using System;

namespace Utility
{
    public readonly struct Optional<T> : IEquatable<Optional<T>>
    {
        // Holds the value of the Optional instance. If HasValue is false, the value of _value is meaningless.
        private readonly T _value;


        /// <summary> Potentially the value of the optional instance. </summary>
        public T Value
        {
            get
            {
                if (!HasValue)
                {
                    #if SANDBOX

                    Log.Error("Cannot get value of an empty Optional");
                    return default;

#else

                                        throw new InvalidOperationException("Cannot get value of an empty Optional");


#endif

                }

                return _value;
            }
        }

        /// <summary> Indicating whether the Optional instance has a value. </summary>
        public bool HasValue { get; }


        /// <summary> 
        /// Initializes a new instance of the Optional class with a value. 
        /// 
        /// <para><strong>Design Note:</strong> Private so forced to use the <see cref="Optional{T}.Of(T)"/> mechanism.</para>
        /// </summary>
        private Optional(T value)
        {
            _value = value;
            HasValue = true;
        }

        /// <summary>
        /// Creates a new instance of the Optional class with a value.
        /// </summary>
        /// <param name="value">The value to use.</param>
        public static Optional<T> Of(T value) => new Optional<T>(value);

        /// <summary> Gets an Optional instance with no value. </summary>
        public static Optional<T> None => new Optional<T>();

        /// <summary>
        /// Returns the optional value if it exists, otherwise returns the default value.
        /// 
        /// <para>Example:</para> 
        /// <code>
        /// Optional&lt;int&gt; optionalWithValue = Optional&lt;int&gt;.Of(42);
        /// Console.WriteLine(optionalWithValue.ValueOrElse(0));  // Output: 42
        ///
        /// Optional&lt;int&gt; optionalWithoutValue = Optional&lt;int&gt;.None;
        /// Console.WriteLine(optionalWithoutValue.ValueOrElse(0));  // Output: 0
        /// </code>
        /// </summary>
        /// <param name="defaultValue">The value to return if the optional does not have a value.</param>
        /// <returns>The optional value if it exists, otherwise the default value.</returns>
        public T ValueOrElse(T defaultValue) => HasValue ? Value : defaultValue;

        public bool Equals(Optional<T> other)
        {
            // If both are None, then they are equal.
            if (!HasValue && !other.HasValue)
                return true;

            // If one has value and the other doesn't, they are not equal.
            if (HasValue != other.HasValue)
                return false;

            // If both have values, compare the values for equality.
            return EqualityComparer<T>.Default.Equals(_value, other._value);
        }

        public override bool Equals(object obj) => obj is Optional<T> optional && Equals(optional);

        public override int GetHashCode()
        {
            // Hash code should be calculated based on HasValue and Value.
            // If HasValue is false, Value is ignored.
            return HasValue ? _value.GetHashCode() : 0;
        }

        public static bool operator ==(Optional<T> left, Optional<T> right)
            => left.Equals(right);

        public static bool operator !=(Optional<T> left, Optional<T> right)
            =>!(left == right);
    }
}
