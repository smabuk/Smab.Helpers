namespace Smab.Helpers;
public static partial class ParsingHelpers {
	public static string[] TrimmedSplit(this string s, string? separator = null) =>
		s.Split(separator, StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);

	public static string[] TrimmedSplit(this string s, char[]? separator) =>
		s.Split(separator, StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);

	public static string[] TrimmedSplit(this string s, char separator)
		=> s.Split(separator, StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);

	public static string[] TrimmedSplit(this string s, char separator, int count)
		=> s.Split(separator, count, StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);

	public static string[] TrimmedSplit(this string s, char[]? separator, int count)
		=> s.Split(separator, count, StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);

	public static string[] TrimmedSplit(this string s, string[]? separator)
		=> s.Split(separator, StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);

	public static string[] TrimmedSplit(this string s, string? separator, int count)
		=> s.Split(separator, count, StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);

	public static string[] TrimmedSplit(this string s, string[]? separator, int count)
		=> s.Split(separator, count, StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
}
