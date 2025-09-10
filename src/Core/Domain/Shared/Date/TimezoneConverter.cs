namespace Domain.Shared.DateTime;

using System.Collections.Concurrent;
using System.Runtime.CompilerServices;
using DateTime=System.DateTime;

public static class TimezoneConverter
{
    // Cache for timezone info to avoid repeated lookups
    private static readonly ConcurrentDictionary<string, TimeZoneInfo> _timezoneCache = new();
    
    public static DateTime ConvertToUserTimezone(DateTime utcTime, string timezone)
    {
        if (string.IsNullOrWhiteSpace(timezone))
            return utcTime;

        try
        {
            var timeZoneInfo = _timezoneCache.GetOrAdd(timezone, GetTimeZoneInfo);
            var utcDateTime = DateTime.SpecifyKind(utcTime, DateTimeKind.Utc);
            return TimeZoneInfo.ConvertTimeFromUtc(utcDateTime, timeZoneInfo);
        }
        catch
        {
            return utcTime;
        }
    }

    private static TimeZoneInfo GetTimeZoneInfo(string timezone)
    {
        try
        {
            // Try direct lookup first
            return TimeZoneInfo.FindSystemTimeZoneById(timezone);
        }
        catch (TimeZoneNotFoundException)
        {
            // Use switch expression for common timezone mappings
            var systemId = timezone.ToUpperInvariant() switch
            {
                "EST" or "EASTERN" => "Eastern Standard Time",
                "PST" or "PACIFIC" => "Pacific Standard Time", 
                "CST" or "CENTRAL" => "Central Standard Time",
                "MST" or "MOUNTAIN" => "Mountain Standard Time",
                "EDT" => "Eastern Standard Time",
                "PDT" => "Pacific Standard Time",
                "CDT" => "Central Standard Time", 
                "MDT" => "Mountain Standard Time",
                "GMT" => "GMT Standard Time",
                "UTC" or "Z" => "UTC",
                "JST" => "Tokyo Standard Time",
                "IST" => "India Standard Time",
                "CET" => "Central European Standard Time",
                "EET" => "E. Europe Standard Time",
                "WET" => "GMT Standard Time",
                "AEST" => "AUS Eastern Standard Time",
                "AWST" => "W. Australia Standard Time",
                "NZST" => "New Zealand Standard Time",
                _ => null
            };

            if (systemId != null)
            {
                try
                {
                    return TimeZoneInfo.FindSystemTimeZoneById(systemId);
                }
                catch (TimeZoneNotFoundException)
                {
                    // Fall through to UTC
                }
            }

            return TimeZoneInfo.Utc;
        }
    }

    // Optimized offset-based conversion with switch
    public static DateTime ConvertToUserTimezoneByOffset(DateTime utcTime, string timezoneOffset)
    {
        if (string.IsNullOrWhiteSpace(timezoneOffset))
            return utcTime;

        // Handle common offset patterns with switch
        var offset = timezoneOffset.Trim().ToUpperInvariant() switch
        {
            "Z" or "UTC" or "+00:00" or "+0000" => TimeSpan.Zero,
            "+01:00" or "+0100" => TimeSpan.FromHours(1),
            "+02:00" or "+0200" => TimeSpan.FromHours(2),
            "+03:00" or "+0300" => TimeSpan.FromHours(3),
            "+04:00" or "+0400" => TimeSpan.FromHours(4),
            "+05:00" or "+0500" => TimeSpan.FromHours(5),
            "+05:30" or "+0530" => TimeSpan.FromMinutes(330), // India
            "+06:00" or "+0600" => TimeSpan.FromHours(6),
            "+07:00" or "+0700" => TimeSpan.FromHours(7),
            "+08:00" or "+0800" => TimeSpan.FromHours(8),
            "+09:00" or "+0900" => TimeSpan.FromHours(9),
            "+10:00" or "+1000" => TimeSpan.FromHours(10),
            "+11:00" or "+1100" => TimeSpan.FromHours(11),
            "+12:00" or "+1200" => TimeSpan.FromHours(12),
            "-01:00" or "-0100" => TimeSpan.FromHours(-1),
            "-02:00" or "-0200" => TimeSpan.FromHours(-2),
            "-03:00" or "-0300" => TimeSpan.FromHours(-3),
            "-04:00" or "-0400" => TimeSpan.FromHours(-4),
            "-05:00" or "-0500" => TimeSpan.FromHours(-5),
            "-06:00" or "-0600" => TimeSpan.FromHours(-6),
            "-07:00" or "-0700" => TimeSpan.FromHours(-7),
            "-08:00" or "-0800" => TimeSpan.FromHours(-8),
            "-09:00" or "-0900" => TimeSpan.FromHours(-9),
            "-10:00" or "-1000" => TimeSpan.FromHours(-10),
            "-11:00" or "-1100" => TimeSpan.FromHours(-11),
            "-12:00" or "-1200" => TimeSpan.FromHours(-12),
            _ => ParseCustomOffset(timezoneOffset)
        };

        return utcTime.Add(offset);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static TimeSpan ParseCustomOffset(string timezoneOffset)
    {
        try
        {
            if (TimeSpan.TryParse(timezoneOffset, out var directOffset))
                return directOffset;

            // Handle formats like "+05:30" or "-08:00"
            if (timezoneOffset.Length >= 3 && (timezoneOffset[0] is '+' or '-'))
            {
                var sign = timezoneOffset[0] == '+' ? 1 : -1;
                var parts = timezoneOffset.AsSpan(1).ToString().Split(':');
                
                if (parts.Length >= 1 && int.TryParse(parts[0], out var hours))
                {
                    var minutes = parts.Length > 1 && int.TryParse(parts[1], out var mins) ? mins : 0;
                    return TimeSpan.FromMinutes(sign * (hours * 60 + minutes));
                }
            }
        }
        catch
        {
            // Return zero offset if parsing fails
        }

        return TimeSpan.Zero;
    }

    public static void ClearTimezoneCache() => _timezoneCache.Clear();
}
