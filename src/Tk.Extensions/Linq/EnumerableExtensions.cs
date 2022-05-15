﻿using System.Diagnostics;

namespace Tk.Extensions.Linq
{
    public static class EnumerableExtensions
    {
        /// <summary>
        /// Ensure a sequence is not null.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="values"></param>
        /// <returns>The <paramref name="values"/> value, or an empty sequence.</returns>
        [DebuggerStepThrough]
        public static IEnumerable<T> NullToEmpty<T>(this IEnumerable<T> values)
            => values ?? Enumerable.Empty<T>();

        /// <summary>
        /// Convert a single value to an sequence.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <returns><paramref name="value"/> in a sequence</returns>
        [DebuggerStepThrough]
        public static IEnumerable<T> Singleton<T>(this T value)
        {
            yield return value;
        }

        /// <summary>
        /// Flattens a hierarchy into a single sequence
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="values"></param>
        /// <param name="selector"></param>
        /// <returns></returns>
        public static IEnumerable<T> SelectFlat<T>(this IEnumerable<T> values, Func<T, IEnumerable<T>> selector) 
            => Flatten(values, selector);


        private static IEnumerable<T> Flatten<T>(IEnumerable<T> values, Func<T, IEnumerable<T>> selector)
        {
            var stack = new Stack<T>();

            foreach (var val in values)
            {
                stack.Push(val);
                yield return val;
            }

            while (stack.Count > 0)
            {
                var val = stack.Pop();

                foreach (var newValue in selector(val))
                {
                    yield return newValue;

                    stack.Push(newValue);
                }
            }
        }
    }
}
