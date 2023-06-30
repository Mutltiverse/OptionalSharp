using System.Collections.Generic;
using System;

namespace Utility
{
    /// <summary>
    /// Represents an optional value that may or may not be present.
    /// Provides a flexible and consistent approach to expressing the absence of a value.
    /// </summary>
    /// <typeparam name="T">The type of the optional value.</typeparam>
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
        /// Log.Info(optionalWithValue.ValueOrElse(0));  // Output: 42
        ///
        /// Optional&lt;int&gt; optionalWithoutValue = Optional&lt;int&gt;.None;
        /// Log.Info(optionalWithoutValue.ValueOrElse(0));  // Output: 0
        /// </code>
        /// </summary>
        /// <param name="defaultValue">The value to return if the optional does not have a value.</param>
        /// <returns>The optional value if it exists, otherwise the default value.</returns>
        public T ValueOrElse(T defaultValue) => HasValue ? Value : defaultValue;


        /// <summary>
        /// Transforms the value inside this Optional using the given transformation function.
        /// If this Optional does not have a value, returns an empty Optional of the result type.
        /// </summary>
        /// <typeparam name="TResult">The type of the result of the transformation function.</typeparam>
        /// <param name="transform">A function that transforms the value inside this Optional.</param>
        /// <returns>An Optional containing the transformed value, or an empty Optional if this Optional does not have a value.</returns>
        public Optional<TResult> Map<TResult>(Func<T, TResult> transform)
            => HasValue ? Optional<TResult>.Of(transform(_value)) : Optional<TResult>.None;


        /// <summary>
        /// Checks if the value inside this Optional satisfies the given predicate.
        /// If this Optional does not have a value, or if the value does not satisfy the predicate, returns an empty Optional.
        /// Otherwise, returns this Optional.
        /// </summary>
        /// <param name="predicate">A function that checks if the value inside this Optional satisfies a certain condition.</param>
        /// <returns>This Optional if it has a value that satisfies the predicate, or an empty Optional otherwise.</returns>
        public Optional<T> Filter(Func<T, bool> predicate)
            => !HasValue || !predicate(_value) ? None : this;


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
