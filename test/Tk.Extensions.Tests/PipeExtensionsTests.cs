using System;
using System.Linq;
using FluentAssertions;
using Xunit;

namespace Tk.Extensions.Tests
{
    public class PipeExtensionsTests
    {
        [Fact]
        public void Pipe_NullSelector_ExceptionThrown()
        {
            Func<int, string> f = null;

            Action a = () => 1.Pipe(f);

            a.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Pipe_NullValue_NoExceptionThrown()
        {
            string s = null;

            var r = s.Pipe(x => x != null ? 1 : 0);

            r.Should().Be(0);
        }

        [Theory]
        [InlineData(1, "2")]
        [InlineData(2, "4")]
        public void Pipe_ValueIsPipedThroughComposition(int x, string expected)
        {
            var r  = x.Pipe(i => i * 2)
                      .Pipe(i => i.ToString());

            r.Should().Be(expected);
        }
    }
}
