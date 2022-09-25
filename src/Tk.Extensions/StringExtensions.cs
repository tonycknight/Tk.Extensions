using System.Diagnostics;
using Tk.Extensions.Guards;

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
            if (value.ArgNotNull(nameof(value))
                     .EndsWith(trailing))
            {
                var i = value.LastIndexOf(trailing);
                return value.Substring(0, i);
            }
            return value;
        }

        /// <summary>
        /// Produce a string of repeated sets of characters
        /// </summary>
        /// <param name="chars">The characters to repeat</param>
        /// <param name="len">The result string's maximum length</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public static string Repeat(this string chars, int len)
        {
            if (string.IsNullOrEmpty(chars)) throw new ArgumentException();

            var result = new char[len];
            for (var x = 0; x < len; x++)
            {
                var i = x % chars.Length;
                result[x] = chars[i];
            }

            return new string(result);
        }

        /// <summary>
        /// Calculate the Levenshtein edit distance of two strings
        /// </summary>
        /// <param name="value"></param>
        /// <param name="comparand"></param>
        /// <returns></returns>
        [DebuggerStepThrough]
        public static int GetLevenshteinDistance(this string value, string comparand)
        {
            value.ArgNotNull(nameof(value));
            comparand.ArgNotNull(nameof(comparand));

            return value.GetLevenshteinDistance(comparand, false, (a, b) => a == b);
        }
                
        /// <summary>
        /// Calculate the Levenshtein edit distance of two strings
        /// </summary>
        /// <param name="value"></param>
        /// <param name="comparand"></param>
        /// <param name="comparer"></param>
        /// <returns></returns>
        [DebuggerStepThrough]
        public static int GetLevenshteinDistance(this string value, string comparand, StringComparer comparer)
        {
            value.ArgNotNull(nameof(value));
            comparand.ArgNotNull(nameof(comparand));
            comparer.ArgNotNull(nameof(comparer));

            return value.GetLevenshteinDistance(comparand, false,
                                                (a, b) => comparer.Equals(a.ToString(), b.ToString()));
        }

        /// <summary>
        /// Calculate the Damareu-Levenshtein edit distance of two strings
        /// </summary>
        /// <param name="value"></param>
        /// <param name="comparand"></param>
        /// <returns></returns>
        [DebuggerStepThrough]
        public static int GetDamareuLevenshteinDistance(this string value, string comparand)
        {
            value.ArgNotNull(nameof(value));
            comparand.ArgNotNull(nameof(comparand));

            return value.GetLevenshteinDistance(comparand, true, (a, b) => a == b);
        }

        /// <summary>
        /// Calculate the Damareu-Levenshtein edit distance of two strings
        /// </summary>
        /// <param name="value"></param>
        /// <param name="comparand"></param>
        /// <param name="comparer"></param>
        /// <returns></returns>
        [DebuggerStepThrough]
        public static int GetDamareuLevenshteinDistance(this string value, string comparand, StringComparer comparer)
        {
            value.ArgNotNull(nameof(value));
            comparand.ArgNotNull(nameof(comparand));
            comparer.ArgNotNull(nameof(comparer));

            return value.GetLevenshteinDistance(comparand, true,
                                                (a, b) => comparer.Equals(a.ToString(), b.ToString()));
        }


        private static int GetLevenshteinDistance(this string value, string comparand, bool damareu, Func<char, char, bool> equality)
        {
            if (value.Length == 0) return comparand.Length;
            if (comparand.Length == 0) return value.Length;

            var distances = new int[value.Length + 1, comparand.Length + 1];

            for (var i = 1; i <= value.Length; i++) distances[i, 0] = i;
            for (var j = 1; j <= comparand.Length; j++) distances[0, j] = j;

            for (var j = 1; j <= comparand.Length; j++)
            {
                for (var i = 1; i <= value.Length; i++)
                {
                    var equal = equality(value[i - 1], comparand[j - 1]);
                    
                    var cost = equal ? 0 : 1;

                    var distance = Math.Min(distances[i - 1, j] + 1,
                                            Math.Min(distances[i, j - 1] + 1,
                                                     distances[i - 1, j - 1] + cost));
                    
                    if (damareu &&
                        i > 1 && j > 1 &&
                        equality(value[i - 1], comparand[j - 2]) &&
                        equality(value[i - 2], comparand[j - 1]))
                    {
                        distance = Math.Min(distance, distances[i - 2, j - 2] + cost);
                    }

                    distances[i, j] = distance;
                }
            }

            return distances[value.Length, comparand.Length];
        }
    }
}
