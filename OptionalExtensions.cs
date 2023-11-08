using System.Collections.Generic;
using System;
using Utility;

public static class OptionalExtensions
{
    public static Optional<TResult> ShortCircuitForResult<T, TResult>(this IEnumerable<T> source, Func<T, Optional<TResult>> function)
    {
        foreach (T element in source)
        {
            var result = function(element);
            if (result.HasValue)
            {
                return result;
            }
        }

        return Optional<TResult>.None;
    }
}