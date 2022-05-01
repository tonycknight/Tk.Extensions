using System.Diagnostics;

namespace Tk.Extensions
{
    public static class StringExtensions
    {
        [DebuggerStepThrough]
        public static string Join(this IEnumerable<string> values, string delimiter) => string.Join(delimiter, values);

        [DebuggerStepThrough]
        public static string Format(this string value, string format) => string.Format(format, value);

        [DebuggerStepThrough]
        public static string TrimEnd(this string value, string trailing)
        {
            if (value.EndsWith(trailing))
            {
                var i = value.LastIndexOf(trailing);
                return value.Substring(0, i);
            }
            return value;
        }
    }
}
