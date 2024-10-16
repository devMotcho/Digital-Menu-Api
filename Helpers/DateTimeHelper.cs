using System.Globalization;

namespace DigitalMenuApi.Helpers;

public static class DateTimeHelper
{
    public static int NumberOfWeek(DateTime dateTime, CultureInfo culture)
    {
        Calendar myCal = culture.Calendar;
        CalendarWeekRule weekRule = culture.DateTimeFormat.CalendarWeekRule;
        DayOfWeek firstDay = culture.DateTimeFormat.FirstDayOfWeek;
        
        return myCal.GetWeekOfYear(dateTime, weekRule, firstDay);
    }

    public static DateTime ConvertUtcToLisbonTime(DateTime utcDateTime)
    {
        TimeZoneInfo lisbonTimeZone = TimeZoneInfo.FindSystemTimeZoneById("Europe/Lisbon");
        DateTime lisbonDateTime = TimeZoneInfo.ConvertTimeFromUtc(utcDateTime, lisbonTimeZone);
        return lisbonDateTime;
    }

    public static string FormatDateByCulture(DateTime utcDateTime, CultureInfo culture)
    {
        return ConvertUtcToLisbonTime(utcDateTime).ToString("dd MMMM yyyy", culture);
    }

    public static string GetDayOfWeekByCulture(DateTime utcDateTime, CultureInfo culture)
    {
        return ConvertUtcToLisbonTime(utcDateTime).ToString("dddd", culture);
    }

}