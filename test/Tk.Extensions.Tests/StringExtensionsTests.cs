using System;
using System.Linq;
using FluentAssertions;
using Xunit;

namespace Tk.Extensions.Tests
{
    public class StringExtensionsTests
    {
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
#pragma warning disable CS8604 // Possible null reference argument.

        [Fact]
        public void Join_Null_ThrowsException()
        {
            string[] xs = null;

            Action a = () => xs.Join(",");

            a.Should().Throw<ArgumentNullException>().WithMessage("?*");
        }

        [Fact]
        public void Join_Empty_ReturnsEmpty()
        {
            var xs = new string[0];

            var r = xs.Join(" ");

            r.Should().BeEmpty();
        }

        [Theory]
        [InlineData(1)]
        [InlineData(3)]
        [InlineData(7)]
        public void Join_NonEmpty_ReturnsNonEmpty(int count)
        {
            var xs = Enumerable.Range(1, count);

            var cs = xs.Select(i => i.ToString()[0]).ToArray();
            var ss = xs.Select(i => i.ToString());

            var r = ss.Join("");

            var expected = new String(cs);
            
            r.Should().Be(expected);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(3)]
        [InlineData(7)]
        public void Join_NonEmptyDelimiter_ReturnsNonEmpty(int count)
        {
            var d = 'd';
            var xs = Enumerable.Range(1, count);

            var ss = xs.Select(i => "");

            var r = ss.Join(d.ToString());

            var expected = new String(d, count - 1);
            
            r.Should().Be(expected);
        }

#pragma warning restore CS8604 // Possible null reference argument.
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
    }
}
