using System.Linq;
using FluentAssertions;
using Tk.Extensions.Reflection;
using Xunit;

namespace Tk.Extensions.Tests.Reflection
{
    public class ReflectionExtensionsTests
    {
        [Fact]
        public void GetAssemblyCustomAttributes_ReturnsMinimumAttributes()
        {
            var attrs = (new Tk.Extensions.Time.TimeProvider()).GetAssemblyCustomAttributes().ToList();

            attrs.Should().NotBeEmpty();
            var prodAttr = attrs.Where(a => a is System.Reflection.AssemblyProductAttribute).FirstOrDefault();
            prodAttr.Should().NotBeNull();
        }

        [Fact]
        public void GetAttributeValue_KnownAttribute_ReturnsValue()
        {
            var attrs = (new Tk.Extensions.Time.TimeProvider()).GetAssemblyCustomAttributes().ToList();

            var val = attrs.GetAttributeValue<System.Reflection.AssemblyProductAttribute>(a => a.Product);

            val.Should().NotBeNullOrWhiteSpace();
        }

        [Fact]
        public void GetAttributeValue_UnknownAttribute_DoesNotReturnValue()
        {
            var attrs = (new Tk.Extensions.Time.TimeProvider()).GetAssemblyCustomAttributes().ToList();

#pragma warning disable CS8603 // Possible null reference return.
            var val = attrs.GetAttributeValue<Newtonsoft.Json.JsonPropertyAttribute>(a => a.PropertyName);
#pragma warning restore CS8603 // Possible null reference return.

            val.Should().BeNull();
        }
    }
}
