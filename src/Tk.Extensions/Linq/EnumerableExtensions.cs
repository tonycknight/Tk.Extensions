using System.Diagnostics;

namespace Tk.Extensions.Linq
{
    public static class EnumerableExtensions
    {
        [DebuggerStepThrough]
        public static IEnumerable<T> NullToEmpty<T>(this IEnumerable<T> values)
            => values == null ? Enumerable.Empty<T>() : values;

        [DebuggerStepThrough]
        public static IEnumerable<T> Singleton<T>(this T value)
        {
            yield return value;
        }
    }
}
