using System;
using System.Collections.Generic;
using System.Linq;

namespace eateasyapi.Core
{
    public static class Validate
    {
        public static void NotNull<T>(object input) where T : class
        {
            if (input as T == null)
            {
                throw new ArgumentException($"The {nameof(input)} cannot be null");
            }
        }

        public static void NotNull<T>(T input) where T : class
        {
            if (input == null)
            {
                throw new ArgumentException($"The {nameof(input)} cannot be null");
            }
        }

        public static void NotEmpty<T>(IEnumerable<T> input)
        {
            NotNull(input);

            if (!input.Any())
            {
                throw new ArgumentException($"The {nameof(input)} cannot be empty");
            }

        }

        public static void NotEmpty(string input)
        {
            NotNull(input);

            if (input == string.Empty)
            {
                throw new ArgumentException($"The {nameof(input)} cannot be empty");
            }
        }

        public static void EnumIsDefined(Type enumType, object input)
        {
            if(!Enum.IsDefined(enumType, input))
            {
                throw new ArgumentException($"The {nameof(input)} is out of range");
            }
        }
    }
}