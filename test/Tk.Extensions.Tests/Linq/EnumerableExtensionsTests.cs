using System;
using System.Linq;
using Shouldly;
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

            r.ShouldBe(new string[0]);
        }

        [Fact]
        public void NullToEmpty_Empty_ReturnsEmpty()
        {
            var xs = new string[0];

            var r = xs.NullToEmpty();

            r.ShouldBe(new string[0]);
        }

        [Fact]
        public void NullToEmpty_NonEmpty_ReturnsSame()
        {
            var xs = new[] { "1" };

            var r = xs.NullToEmpty();

            r.ShouldBe(xs);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData(" a ")]
        public void Singleton_ReturnsSequence(string? value)
        {
            var r = value.Singleton();

            var expected = new[] { value };

            r.ShouldBe(expected);
        }

        [Fact]
        public void SelectFlat_EmptyValues_EmptyResult()
        {
            var result = Enumerable.Empty<int>().SelectFlat(x => x.Singleton()).ToList();

            result.ShouldBeEmpty();
        }

        [Theory]
        [InlineData(2)]
        [InlineData(2, 1)]
        [InlineData(2, 1, 3)]
        public void SelectFlat_SingleValue_SingleResult(params int[] values)
        {

            var result = values.SelectFlat(x => Enumerable.Empty<int>()).ToList();

            result.ShouldBe(values);
        }

        [Theory]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(5)]
        [InlineData(7)]
        public void SelectFlat_SingleValue_DepthCheck(int limit)
        {
            var result = 1.Singleton()
                           .SelectFlat(x => (x + 1).Singleton())
                           .TakeWhile(x => x <= limit)
                           .ToList();
            var expected = Enumerable.Range(1, limit).ToList();

            result.ShouldBe(expected);
        }

        [Theory]
        [InlineData(1, 3)]
        [InlineData(2, 83)]
        [InlineData(3, 1723)]
        [InlineData(4, 34603)]
        public void SelectFlat_MultipleValues_MultiplePly(int depth, int expected)
        {
            var xs = Enumerable.Range(1, 2);
            var limit = Math.Pow(10, depth);
            var ys = xs.SelectFlat(x => Enumerable.Range(x, 2)
                                                  .Select(y => y * 10)
                                                  .TakeWhile(x => x < limit))
                       .ToList();

            var sum = ys.Sum();

            sum.ShouldBe(expected);
        }

        [Theory]
        [InlineData(0, 3)]
        [InlineData(1, 3)]
        [InlineData(3, 0)]
        [InlineData(3, 1)]
        [InlineData(3, 2)]
        public void ToInfinite_YieldsRepeatedSequences(int size, int count)
        {
            var xs = Enumerable.Range(1, size);
            var sequence = Enumerable.Range(1, count).SelectMany(_ => xs).ToList();

            var result = xs.ToInfinite().Take(size * count).ToList();

            result.ShouldBe(sequence);
        }

    }
}
