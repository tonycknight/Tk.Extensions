using System.Diagnostics;

namespace Tk.Extensions.Tasks
{
    public static class TaskExtensions
    {
        /// <summary>
        /// Convert a value to a Task result.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        [DebuggerStepThrough]
        public static Task<T> ToTaskResult<T>(this T value) => Task.FromResult(value);
    }
}
