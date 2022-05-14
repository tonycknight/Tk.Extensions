using System.Diagnostics;

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
    }
}
