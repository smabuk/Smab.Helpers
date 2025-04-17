namespace Smab.Helpers;

public static class DateTimeExtensions {
	private const string DD_MMM_YYYY  = "dd MMM, yyyy";
	private const string DD_MMMM_YYYY = "dd MMMM, yyyy";

	/// <summary>
	/// Converts the specified <see cref="DateTime"/> to a string representation in the format "dd MMMM yyyy".
	/// </summary>
	/// <param name="dateTime">The <see cref="DateTime"/> instance to format.</param>
	/// <returns>A string representing the date in the format "dd MMMM yyyy", where "dd" is the day, "MMMM" is the full month name,
	/// and "yyyy" is the year.</returns>
	public static string ToDateLongMonthYearString(this DateTime dateTime) => dateTime.ToString(DD_MMMM_YYYY);
	/// <summary>
	/// Converts the specified <see cref="DateOnly"/> instance to its string representation in the "day month year" format
	/// (e.g., "01 January 2023").
	/// </summary>
	/// <param name="dateOnly">The <see cref="DateOnly"/> instance to convert.</param>
	/// <returns>A string representing the date in the "day month year" format.</returns>
	public static string ToDateLongMonthYearString(this DateOnly dateOnly) => dateOnly.ToString(DD_MMMM_YYYY);

	/// <summary>
	/// Converts the specified <see cref="DateTime"/> to a string representation in the format "dd MMM yyyy".
	/// </summary>
	/// <param name="dateTime">The <see cref="DateTime"/> instance to format.</param>
	/// <returns>A string representing the date in the "dd MMM yyyy" format, where "dd" is the day, "MMM" is the abbreviated month
	/// name, and "yyyy" is the year.</returns>
	public static string ToDateShortMonthYearString(this DateTime dateTime) => dateTime.ToString(DD_MMM_YYYY);
	/// <summary>
	/// Converts the specified <see cref="DateOnly"/> instance to a string representation in the format "dd MMM yyyy".
	/// </summary>
	/// <param name="dateOnly">The <see cref="DateOnly"/> instance to convert.</param>
	/// <returns>A string representing the date in the format "dd MMM yyyy".</returns>
	public static string ToDateShortMonthYearString(this DateOnly dateOnly) => dateOnly.ToString(DD_MMM_YYYY);
}
