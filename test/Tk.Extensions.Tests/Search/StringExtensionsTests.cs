using FluentAssertions;
using Tk.Extensions.Search;
using Xunit;

namespace Tk.Extensions.Tests.Search
{
    public class StringExtensionsTests
    {
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
