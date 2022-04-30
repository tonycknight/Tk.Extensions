using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;

namespace Tk.Extensions
{
    public static class DateTimeExtensions
    {
        private static readonly TimeZoneInfo _ukTimeZone = GetUkTimeZone();

        [DebuggerStepThrough]
        public static DateTime ToUkDateTime(this DateTime value)
            => System.TimeZoneInfo.ConvertTimeFromUtc(value, _ukTimeZone);


        [ExcludeFromCodeCoverage]
        private static TimeZoneInfo GetUkTimeZone()
        {
            var tzId = RuntimeInformation.IsOSPlatform(OSPlatform.Linux)
                ? "Europe/London"
                : "GMT Standard Time";

            return TimeZoneInfo.GetSystemTimeZones().Single(tzi => tzi.Id == tzId);
        }
    }
}
