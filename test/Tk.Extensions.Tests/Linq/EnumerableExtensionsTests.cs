using FluentAssertions;
using Tk.Extensions.Linq;
using Xunit;

namespace Tk.Extensions.Tests.Linq
{
    public class EnumerableExtensionsTests
    {
        [Fact]
        public void NullToEmpty_Null_ReturnsEmpty()
        {
            string[] xs = null;

            var r = xs.NullToEmpty();

            r.Should().BeEquivalentTo(new string[0]);
        }

        [Fact]
        public void NullToEmpty_Empty_ReturnsEmpty()
        {
            var xs = new string[0];

            var r = xs.NullToEmpty();

            r.Should().BeEquivalentTo(new string[0]);
        }

        [Fact]
        public void NullToEmpty_NonEmpty_ReturnsSame()
        {
            var xs = new[] { "1" };

            var r = xs.NullToEmpty();

            r.Should().BeEquivalentTo(xs);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData(" a ")]
        public void Singleton_ReturnsSequence(string value)
        {
            var r = value.Singleton();

            var expected = new[] { value };

            r.Should().BeEquivalentTo(expected);
        }
    }
}
