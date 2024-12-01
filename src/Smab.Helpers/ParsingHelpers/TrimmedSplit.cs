namespace Smab.Helpers;
public static partial class ParsingHelpers {
	private const StringSplitOptions RemoveEmptyAndTrim = StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries;
	private static readonly string[] WHITESPACE_SEPARATORS = [" ", "\t"];
	private static readonly string[] WHITESPACE_SEPARATORS_WITH_NEWLINE = [.. WHITESPACE_SEPARATORS, Environment.NewLine];

	public static string[] TrimmedSplit(this string s, string?   separator)            => s.Split(separator,        RemoveEmptyAndTrim);

	public static string[] TrimmedSplit(this string s, char      separator)            => s.Split(separator,        RemoveEmptyAndTrim);
	public static string[] TrimmedSplit(this string s, char[]?   separator)            => s.Split(separator,        RemoveEmptyAndTrim);
	public static string[] TrimmedSplit(this string s, string[]? separator = null)     => s.Split(separator ?? WHITESPACE_SEPARATORS_WITH_NEWLINE,        RemoveEmptyAndTrim);

	public static string[] TrimmedSplit(this string s, char      separator, int count) => s.Split(separator, count, RemoveEmptyAndTrim);
	public static string[] TrimmedSplit(this string s, char[]?   separator, int count) => s.Split(separator, count, RemoveEmptyAndTrim);
	public static string[] TrimmedSplit(this string s, string?   separator, int count) => s.Split(separator, count, RemoveEmptyAndTrim);
	public static string[] TrimmedSplit(this string s, string[]? separator, int count) => s.Split(separator, count, RemoveEmptyAndTrim);
}
