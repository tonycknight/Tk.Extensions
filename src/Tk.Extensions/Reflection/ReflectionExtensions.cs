using System.Diagnostics;
using System.Reflection;

namespace Tk.Extensions.Reflection
{
    public static class ReflectionExtensions
    {
        [DebuggerStepThrough]
        public static IEnumerable<Attribute> GetAssemblyCustomAttributes(this object value)
            => value.GetType().GetAssemblyCustomAttributes();

        [DebuggerStepThrough]
        public static IEnumerable<Attribute> GetAssemblyCustomAttributes(this Type type) 
            => type.Assembly.GetCustomAttributes();

        [DebuggerStepThrough]
        public static string GetAttributeValue<T>(this IEnumerable<Attribute> attributes, Func<T, string> selector)
            where T : Attribute
#pragma warning disable CS8603 // Possible null reference return.
            => attributes.OfType<T>().Select(selector).FirstOrDefault();
#pragma warning restore CS8603 // Possible null reference return.       
    }
}
