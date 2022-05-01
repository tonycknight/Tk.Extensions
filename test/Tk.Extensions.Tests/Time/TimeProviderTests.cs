using System;
using FluentAssertions;
using Tk.Extensions.Time;
using Xunit;

namespace Tk.Extensions.Tests.Time
{
    public class TimeProviderTests
    {
        [Fact]
        public void UtcNow_ReturnsUtcTimeKind()
        {
            var tp = new TimeProvider();

            var r = tp.UtcNow();

            r.Kind.Should().Be(DateTimeKind.Utc);
        }

        [Fact]
        public void UtcNow_ReturnsUtcTime()
        {
            var now = DateTime.UtcNow;
            var tp = new TimeProvider();

            var r = tp.UtcNow();

            r.Should().BeCloseTo(now, TimeSpan.FromSeconds(1));
        }

    }
}
