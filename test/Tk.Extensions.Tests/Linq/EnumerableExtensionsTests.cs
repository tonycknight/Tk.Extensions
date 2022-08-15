using System.Linq;
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

        [Fact]
        public void SelectFlat_EmptyValues_EmptyResult()
        {
            var xs = new int[0];

            var result = xs.SelectFlat(x => x.Singleton()).ToList();

            result.Should().BeEmpty();
        }

        [Theory]
        [InlineData(2)]
        [InlineData(2, 1, 3)]
        public void SelectFlat_SingleValue_SingleResult(params int[] values)
        {
            var xs = 1.Singleton();
            
            var result = xs.SelectFlat(x => values)
                           .Take(1 + values.Length)
                           .ToList();
            var expected = xs.Concat(values).ToArray();
            result.Should().BeEquivalentTo(expected);
        }

        [Theory]
        [InlineData(2)]
        [InlineData(2, 1, 3)]
        public void SelectFlat_DoubleValue_SingleResult(params int[] values)
        {
            var xs = new[] { 10, 20 };

            var result = xs.SelectFlat(x => values)
                           .Take(xs.Length + (values.Length * 2))
                           .ToList();
            var expected = xs.Concat(values).Concat(values).ToList();

            result.Should().BeEquivalentTo(expected);
        }

        [Theory]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(5)]
        [InlineData(7)]
        public void SelectFlat_SingleValue_DepthCheck(int limit)
        {            
            var result = 1.Singleton()
                           .SelectFlat(x => (x+1).Singleton())
                           .TakeWhile(x => x <= limit)
                           .ToList();
            var expected = Enumerable.Range(1, limit).ToList();

            result.Should().BeEquivalentTo(expected);
        }

    }
}
