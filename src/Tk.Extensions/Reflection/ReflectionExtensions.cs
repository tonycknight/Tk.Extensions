using System.Diagnostics;
using System.Reflection;
using Tk.Extensions.Linq;

namespace Tk.Extensions.Reflection
{
    public static class ReflectionExtensions
    {
        /// <summary>
        /// Get the object's type's assembly custom attributes.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        [DebuggerStepThrough]
        public static IEnumerable<Attribute> GetAssemblyCustomAttributes(this object value)
            => value.GetType().GetAssemblyCustomAttributes();

        /// <summary>
        /// Gets the type's assembly custom attributes.
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        [DebuggerStepThrough]
        public static IEnumerable<Attribute> GetAssemblyCustomAttributes(this Type type) 
            => type.Assembly.GetCustomAttributes();

        /// <summary>
        /// Get the first instance of an <typeparamref name="T"/> attribute, and project the value.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="attributes"></param>
        /// <param name="selector"></param>
        /// <returns></returns>
        [DebuggerStepThrough]
        public static TValue GetAttributeValue<T, TValue>(this IEnumerable<Attribute> attributes, Func<T, TValue> selector)
            where T : Attribute
#pragma warning disable CS8603 // Possible null reference return.
            => attributes.NullToEmpty().OfType<T>().Select(selector).FirstOrDefault();
#pragma warning restore CS8603 // Possible null reference return.       
    }
}
