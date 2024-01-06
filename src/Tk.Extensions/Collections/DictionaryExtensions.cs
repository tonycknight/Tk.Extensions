using System.Diagnostics;
using Tk.Extensions.Guards;

namespace Tk.Extensions.Collections
{
    public static class DictionaryExtensions
    {
        /// <summary>
        /// Queries a dictionary where <typeparamref name="TValue"/> is a class type. If the <paramref name="key"/> is not found, null is returned.
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="values"></param>
        /// <param name="key"></param>
        /// <returns>The value associated with <paramref name="key"/>, otherwise null.</returns>
        [DebuggerStepThrough]
        public static TValue? GetOrDefault<TKey, TValue>(this Dictionary<TKey, TValue> values, TKey key)
            where TKey : notnull
            where TValue : class
        {
            values.ArgNotNull(nameof(values));

            if (values.TryGetValue(key, out var value))
            {
                return value;
            }
            return default;
        }
    }
}
