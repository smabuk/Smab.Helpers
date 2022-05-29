namespace Smab.Helpers;
public static class DateTimeExtensions
{
    internal static readonly string DD_MMM_YYYY = "dd MMM, yyyy";
    internal static readonly string DD_MMMM_YYYY = "dd MMMM, yyyy";

	public static string ToDateLongMonthYearString(this DateTime dateTime) => dateTime.ToString(DD_MMMM_YYYY);
	public static string ToDateLongMonthYearString(this DateOnly dateOnly) => dateOnly.ToString(DD_MMMM_YYYY);
	public static string ToDateShortMonthYearString(this DateTime dateTime) => dateTime.ToString(DD_MMM_YYYY);
	public static string ToDateShortMonthYearString(this DateOnly dateOnly) => dateOnly.ToString(DD_MMM_YYYY);
}
