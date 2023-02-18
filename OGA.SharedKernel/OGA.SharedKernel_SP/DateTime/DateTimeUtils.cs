using System;

namespace OGA.SharedKernel.Extensions.DateandTime
{
    /// <summary>
    /// Adapted from this article: https://stackoverflow.com/questions/1004698/how-to-truncate-milliseconds-off-of-a-net-datetime
    /// Many thanks to Sky-Sanders (https://stackoverflow.com/users/242897/sky-sanders) for his answer.
    /// And, apologies, just the same, if this extrapolation falls short of his intent.
    /// </summary>
    public static class DateTimeUtils
    {
        /// <summary>
        /// <para>Truncates a DateTime to a specified resolution.</para>
        /// <para>A convenient source for resolution is TimeSpan.TicksPerXXXX constants.</para>
        /// </summary>
        /// <param name="date">The DateTime object to truncate</param>
        /// <param name="resolution">e.g. to round to nearest second, TimeSpan.TicksPerSecond</param>
        /// <returns>Truncated DateTime</returns>
        public static DateTime? Truncate(this DateTime? date, long resolution)
        {
            if(date == null)
                return null;
            else
                return date?.AddTicks( -((date?.Ticks ?? 0) % resolution));
        }
        public static DateTime Truncate(this DateTime date, long resolution)
        {
            return date.AddTicks( -(date.Ticks % resolution));
        }

        public static DateTime? TruncateToSecond(this DateTime? date)
        {
            if(date == null)
                return null;
            else
                return date.Truncate(TimeSpan.TicksPerSecond);
        }
        public static DateTime TruncateToSecond(this DateTime date)
        {
            return date.Truncate(TimeSpan.TicksPerSecond);
        }

        public static DateTime? TruncateToMilliSecond(this DateTime? date)
        {
            if(date == null)
                return null;
            else
                return date.Truncate(TimeSpan.TicksPerMillisecond);
        }
        public static DateTime TruncateToMilliSecond(this DateTime date)
        {
            return date.Truncate(TimeSpan.TicksPerMillisecond);
        }
    }
}
