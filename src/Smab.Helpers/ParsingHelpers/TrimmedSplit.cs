namespace Smab.Helpers;
public static partial class ParsingHelpers {
	private const StringSplitOptions RemoveEmptyAndTrim = StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries;
	
	public static string[] TrimmedSplit(this string s, string?   separator = null)     => s.Split(separator,        RemoveEmptyAndTrim);

	public static string[] TrimmedSplit(this string s, char      separator)            => s.Split(separator,        RemoveEmptyAndTrim);
	public static string[] TrimmedSplit(this string s, char[]?   separator)            => s.Split(separator,        RemoveEmptyAndTrim);
	public static string[] TrimmedSplit(this string s, string[]? separator)            => s.Split(separator,        RemoveEmptyAndTrim);

	public static string[] TrimmedSplit(this string s, char      separator, int count) => s.Split(separator, count, RemoveEmptyAndTrim);
	public static string[] TrimmedSplit(this string s, char[]?   separator, int count) => s.Split(separator, count, RemoveEmptyAndTrim);
	public static string[] TrimmedSplit(this string s, string?   separator, int count) => s.Split(separator, count, RemoveEmptyAndTrim);
	public static string[] TrimmedSplit(this string s, string[]? separator, int count) => s.Split(separator, count, RemoveEmptyAndTrim);
}
