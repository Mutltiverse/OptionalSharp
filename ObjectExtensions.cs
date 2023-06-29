using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utility
{
    public static class OptionalExtensions
    {
        public static Optional<T> ToOptional<T>(this T value)
        {
            return value != null ? Optional<T>.Of(value) : Optional<T>.None;
        }
    }
}
