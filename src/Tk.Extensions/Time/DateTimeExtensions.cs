using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;

namespace Tk.Extensions.Time
{
    public static class DateTimeExtensions
    {
        private static readonly TimeZoneInfo _ukTimeZone = GetUkTimeZone();

        /// <summary>
        /// Converts the <paramref name="value"/> to a form in the relevant UK time zone.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        [DebuggerStepThrough]
        public static DateTime ToUkDateTime(this DateTime value)
            => TimeZoneInfo.ConvertTimeFromUtc(value, _ukTimeZone);


        /// <summary>
        /// Gets the UK TimeZoneInfo object, per OS.
        /// </summary>
        /// <returns></returns>
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
