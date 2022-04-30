using System.Diagnostics;

namespace Tk.Extensions
{
    public static class PipeExtensions
    {
        [DebuggerStepThrough]
        public static TResult Pipe<TValue, TResult>(this TValue value, Func<TValue, TResult> selector)
        {
            selector.ArgNotNull(nameof(selector));

            return selector(value);
        }


        [DebuggerStepThrough]
#pragma warning disable CS8601 // Possible null reference assignment.
        public static TResult PipeIfNotNull<TValue, TResult>(this TValue value, Func<TValue, TResult> selector, TResult defaultValue = default)
#pragma warning restore CS8601 // Possible null reference assignment.
                where TValue : class
        {
            selector.ArgNotNull(nameof(selector));

            return value != null
                ? selector(value)
                : defaultValue;
        }
    }
}
