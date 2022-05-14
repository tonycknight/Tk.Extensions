using System.Diagnostics;
using Tk.Extensions.Guards;

namespace Tk.Extensions.Funcs
{
    public static class PipeExtensions
    {
        /// <summary>
        /// Applies a value to a given function.
        /// </summary>
        /// <typeparam name="TValue"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="value"></param>
        /// <param name="selector"></param>
        /// <returns>The result of <paramref name="selector"/> given <paramref name="value"/></returns>
        [DebuggerStepThrough]
        public static TResult Pipe<TValue, TResult>(this TValue value, Func<TValue, TResult> selector)
        {
            selector.ArgNotNull(nameof(selector));

            return selector(value);
        }
    }
}
