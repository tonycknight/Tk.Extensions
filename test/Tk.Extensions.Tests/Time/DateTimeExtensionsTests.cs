using System;
using FluentAssertions;
using Tk.Extensions.Time;
using Xunit;

namespace Tk.Extensions.Tests.Time
{
    public class DateTimeExtensionsTests
    {
        
        [Theory]
        [InlineData(11, 0)]
        [InlineData(12, 0)]
        [InlineData(1, 0)]
        [InlineData(5, 1)]
        [InlineData(6, 1)]
        [InlineData(9, 1)]
        public void ToUkDateTime_IsWithinAnHourOfUtc(int month, int utcOffset)
        {
            var now = new DateTime(2022, month, 1, 12, 0, 0, DateTimeKind.Utc);
            var expected = now.AddHours(utcOffset);
            var r = now.ToUkDateTime();

            r.Should().Be(expected);
        }
    }
}
