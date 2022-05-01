using System.Diagnostics;

namespace Tk.Extensions.Tasks
{
    public static class TaskExtensions
    {
        [DebuggerStepThrough]
        public static Task<T> ToTaskResult<T>(this T value) => Task.FromResult(value);
    }
}
