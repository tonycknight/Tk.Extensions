using System;
using System.Linq;
using FluentAssertions;
using Xunit;

namespace Tk.Extensions.Tests
{
    public class StringExtensionsTests
    {
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

        [Theory]
        [InlineData("", "")]
        [InlineData(" ", "")]
        [InlineData("asdf", "%s")]
        public void Format_ValueFormatted(string value, string format)
        {
            var r = value.Format(format);

            r.Should().Be(string.Format(format, value));
        }

        [Theory]
        [InlineData("", "", "")]
        [InlineData("a", "", "a")]
        [InlineData("a", "a", "")]
        [InlineData("a", "z", "a")]
        [InlineData("az", "z", "a")]
        [InlineData("az ", "z", "az ")]
        [InlineData("az ", "z ", "a")]
        [InlineData("az ", " ", "az")]
        [InlineData(" az ", " ", " az")]
        public void TrimEnd_ResultIsTrimmed(string value, string end, string expected)
        {
            var r = value.TrimEnd(end);

            r.Should().Be(expected);
        }

        [Theory]
        [InlineData("a", 3, "aaa")]
        [InlineData("ab", 1, "a")]
        [InlineData("ab", 2, "ab")]
        [InlineData("ab", 3, "aba")]
        [InlineData("ab", 4, "abab")]
        [InlineData("abc", 4, "abca")]
        public void Repeat_ResultIsRepeatedInputs(string value, int len, string expected)
        {
            var result = value.Repeat(len);

            result.Should().Be(expected);
        }

        [Theory]
        [InlineData("", "aaaa", 4)]
        [InlineData("aaa", "", 3)]
        [InlineData("", "", 0)]
        [InlineData("a", "a", 0)]
        [InlineData("a", "b", 1)]
        [InlineData("sitten", "kitten", 1)]
        [InlineData("sittin", "kitten", 2)]
        [InlineData("sitten", "kittin", 2)]
        [InlineData("sit", "kittens", 5)]
        [InlineData("kittens", "sit", 5)]
        [InlineData("king's", "kings", 1)]
        [InlineData("king's cross st pancras", "pancras", 16)]
        public void LevenshteinDistance_Calculated(string value, string comparand, int expected)
        {
            var r = value.LevenshteinDistance(comparand);

            r.Should().Be(expected);
        }
    }
}
