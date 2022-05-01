using System.Diagnostics;

namespace Tk.Extensions
{
    public static class DictionaryExtensions
    {
        [DebuggerStepThrough]
        public static TValue? GetOrDefault<TKey, TValue>(this Dictionary<TKey, TValue> values, TKey key)
            where TKey : class
            where TValue : class
        {
            values.ArgNotNull(nameof(values));
            key.ArgNotNull(nameof(key));

            if (values.TryGetValue(key, out var value))
            {
                return value;
            }
            return default(TValue);
        }
    }
}
