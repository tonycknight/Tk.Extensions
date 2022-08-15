using System.Diagnostics;

namespace Tk.Extensions
{
    public static class StringExtensions
    {
        /// <summary>
        /// Join a sequence of strings, combining with <paramref name="delimiter"/>
        /// </summary>
        /// <param name="values"></param>
        /// <param name="delimiter"></param>
        /// <returns></returns>
        [DebuggerStepThrough]
        public static string Join(this IEnumerable<string> values, string delimiter) => string.Join(delimiter, values);

        /// <summary>
        /// Formats a string, given the format's single value
        /// </summary>
        /// <param name="value"></param>
        /// <param name="format"></param>
        /// <returns></returns>
        [DebuggerStepThrough]
        public static string Format(this string value, string format) => string.Format(format, value);

        /// <summary>
        /// Trim the end of a string of <paramref name="trailing"/> characters.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="trailing"></param>
        /// <returns></returns>
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
