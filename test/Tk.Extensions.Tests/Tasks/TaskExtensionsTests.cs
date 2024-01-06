using System.Threading.Tasks;
using FluentAssertions;
using Tk.Extensions.Tasks;
using Xunit;

namespace Tk.Extensions.Tests.Tasks
{
    public class TaskExtensionsTests
    {
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData(" abc ")]
        public async Task ToTaskResult_TaskReturned(string? value)
        {
            var r = value.ToTaskResult();

            var r2 = await r;

            r2.Should().Be(value);
        }
    }
}
