namespace Domain.Shared.DateTime;

public static class TimeHelper
{
    private enum TimeRange : byte
    {
        JustNow,
        Seconds,
        Minutes,
        Hours,
        Days,
        Weeks,
        Months,
        Years
    }

    public static string GetRelativeTime(DateTime messageTime)
    {
        var timeSpan = DateTime.UtcNow - messageTime;
        var totalSeconds = timeSpan.TotalSeconds;

        if (totalSeconds < 0)
            return "Just now";

        var range = GetTimeRange(totalSeconds);

        return range switch
        {
            TimeRange.JustNow => "Just now",
            TimeRange.Seconds => $"{(int)totalSeconds} seconds ago",
            TimeRange.Minutes => FormatTimeUnit((int)timeSpan.TotalMinutes, "minute", "minutes"),
            TimeRange.Hours => FormatTimeUnit((int)timeSpan.TotalHours, "hour", "hours"),
            TimeRange.Days => FormatTimeUnit((int)timeSpan.TotalDays, "day", "days"),
            TimeRange.Weeks => FormatTimeUnit((int)(timeSpan.TotalDays / 7), "week", "weeks"),
            TimeRange.Months => FormatTimeUnit((int)(timeSpan.TotalDays / 30), "month", "months"),
            TimeRange.Years => FormatTimeUnit((int)(timeSpan.TotalDays / 365), "year", "years"),
            _ => "Just now"
        };
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static TimeRange GetTimeRange(double totalSeconds) => totalSeconds switch
    {
        < 30 => TimeRange.JustNow,
        < 60 => TimeRange.Seconds,
        < 3600 => TimeRange.Minutes,
        < 86400 => TimeRange.Hours,
        < 604800 => TimeRange.Days,
        < 2592000 => TimeRange.Weeks,
        < 31536000 => TimeRange.Months,
        _ => TimeRange.Years
    };

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static string FormatTimeUnit(int value, string singular, string plural)
        => $"{value} {(value == 1 ? singular : plural)} ago";
}
