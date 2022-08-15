using System.Diagnostics;

namespace Tk.Extensions.Guards
{
    public static class GuardExtensions
    {
        /// <summary>
        /// Throw an exception if the given value is null.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <param name="paramName"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="value"/> is null. </exception>
        [DebuggerStepThrough]
        public static T ArgNotNull<T>(this T value, string paramName) where T : class
        {
            if (ReferenceEquals(null, value))
            {
                throw new ArgumentNullException(paramName: paramName);
            }
            return value;
        }


        /// <summary>
        /// Throw an exception if the given <paramref name="predicate"/> is true.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value">The value to test</param>
        /// <param name="predicate">The assert predicate: return true if the assertion fails and exceptions should be thrown.</param>
        /// <param name="message">The exception's message.</param>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
        [DebuggerStepThrough]
        public static T InvalidOpArg<T>(this T value, Func<T, bool> predicate, string message)
        {
            predicate.ArgNotNull(nameof(predicate));

            if (ReferenceEquals(null, value) || predicate(value))
            {
                throw new InvalidOperationException(message);
            }

            return value;
        }
    }
}
