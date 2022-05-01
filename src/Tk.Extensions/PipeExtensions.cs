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
    }
}
