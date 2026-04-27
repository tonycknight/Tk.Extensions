using System;
using Shouldly;
using Tk.Extensions.Time;
using Xunit;
using TimeProvider = Tk.Extensions.Time.TimeProvider;

namespace Tk.Extensions.Tests.Time
{
    public class TimeProviderTests
    {
        [Fact]
        public void UtcNow_ReturnsUtcTimeKind()
        {
            var tp = new TimeProvider();

            var r = tp.UtcNow();

            r.Kind.ShouldBe(DateTimeKind.Utc);
        }

        [Fact]
        public void UtcNow_ReturnsUtcTime()
        {
            var now = DateTime.UtcNow;
            var tp = new TimeProvider();

            var r = tp.UtcNow();

            Math.Abs((r - now).TotalSeconds).ShouldBeLessThanOrEqualTo(1);
        }

    }
}
