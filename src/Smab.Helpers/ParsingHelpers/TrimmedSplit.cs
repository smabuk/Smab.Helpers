using System.Runtime.CompilerServices;

namespace Smab.Helpers;
public static partial class ParsingHelpers {
	private const StringSplitOptions RemoveEmptyAndTrim = StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries;
	private static readonly string[] WHITESPACE_SEPARATORS = [" ", "\t"];
	private static readonly string[] WHITESPACE_SEPARATORS_WITH_NEWLINE = [.. WHITESPACE_SEPARATORS, Environment.NewLine];

	extension(string s) {
		/// <summary>
		/// Splits the input string into an array of substrings based on the specified separator,  trimming whitespace from
		/// each resulting substring and removing any empty entries.
		/// </summary>
		/// <remarks>This method ensures that each substring in the resulting array is trimmed of leading and trailing
		/// whitespace,  and any empty substrings are excluded from the result.</remarks>
		/// <param name="s">The input string to split. Cannot be <see langword="null"/>.</param>
		/// <param name="separator">The string used as the delimiter for splitting. If <see langword="null"/>, whitespace is used as the default
		/// separator.</param>
		/// <returns>An array of trimmed substrings resulting from the split operation. The array will not contain any empty entries.</returns>
		public string[] TrimmedSplit(string? separator) => s.Split(separator, RemoveEmptyAndTrim);

		/// <summary>
		/// Splits the input string into an array of substrings based on the specified separator,  trimming whitespace from
		/// each resulting substring and removing any empty entries.
		/// </summary>
		/// <param name="s">The input string to split. Cannot be <see langword="null"/>.</param>
		/// <param name="separator">The character used to separate the substrings.</param>
		/// <returns>An array of trimmed substrings. The array will not contain any empty entries. If the input string is empty, an
		/// empty array is returned.</returns>
		public string[] TrimmedSplit(char separator) => s.Split(separator, RemoveEmptyAndTrim);

		/// <summary>
		/// Splits the input string into an array of substrings based on the specified separators,  trimming whitespace from
		/// each resulting substring and removing any empty entries.
		/// </summary>
		/// <remarks>This method is a convenience extension for splitting strings while ensuring that each resulting 
		/// substring is trimmed of leading and trailing whitespace, and that no empty substrings are included  in the
		/// result.</remarks>
		/// <param name="s">The string to split. Cannot be <see langword="null"/>.</param>
		/// <param name="separator">An array of characters that delimit the substrings in this string. If <see langword="null"/>,  the method uses
		/// whitespace as the default separator.</param>
		/// <returns>An array of trimmed substrings resulting from the split operation. The array will not contain  any empty entries.</returns>
		[OverloadResolutionPriority(2)]
		public string[] TrimmedSplit(char[]? separator = null) => s.Split(separator, RemoveEmptyAndTrim);
		/// <summary>
		/// Splits the input string into an array of substrings based on the specified separators,  trimming whitespace from
		/// each resulting substring and removing empty entries.
		/// </summary>
		/// <remarks>This method ensures that each resulting substring is trimmed of leading and trailing whitespace, 
		/// and any empty substrings resulting from consecutive delimiters are excluded from the output.</remarks>
		/// <param name="s">The string to split. Cannot be <see langword="null"/>.</param>
		/// <param name="separator">An array of strings that delimit the substrings in this string. If <see langword="null"/>,  a default set of
		/// whitespace separators, including newlines, is used.</param>
		/// <returns>An array of trimmed substrings. The array will not contain any empty entries.</returns>
		[OverloadResolutionPriority(1)]
		public string[] TrimmedSplit(string[]? separator = null) => s.Split(separator ?? WHITESPACE_SEPARATORS_WITH_NEWLINE, RemoveEmptyAndTrim);


		/// <summary>
		/// Splits the input string into an array of substrings based on the specified separator,  trims whitespace from each
		/// resulting substring, and removes any empty entries.
		/// </summary>
		/// <param name="s">The input string to split. Cannot be <see langword="null"/>.</param>
		/// <param name="separator">The character used to separate the substrings.</param>
		/// <param name="count">The maximum number of substrings to return. If the input string contains more substrings  than the specified count,
		/// the remaining substrings are combined into the last element.</param>
		/// <returns>An array of trimmed substrings resulting from the split operation. The array will not  contain any empty entries.</returns>
		public string[] TrimmedSplit(char separator, int count) => s.Split(separator, count, RemoveEmptyAndTrim);

		/// <summary>
		/// Splits the input string into an array of substrings based on the specified separators,  trims whitespace from each
		/// resulting substring, and removes empty entries.
		/// </summary>
		/// <param name="s">The string to split. Cannot be <see langword="null"/>.</param>
		/// <param name="separator">An array of characters that delimit the substrings in this string.  If <see langword="null"/>, whitespace
		/// characters are used as the delimiters.</param>
		/// <param name="count">The maximum number of substrings to return. Must be greater than zero.</param>
		/// <returns>An array of trimmed substrings, excluding any empty entries. The array will contain  at most <paramref
		/// name="count"/> elements.</returns>
		public string[] TrimmedSplit(char[]? separator, int count) => s.Split(separator, count, RemoveEmptyAndTrim);

		/// <summary>
		/// Splits the input string into an array of substrings based on the specified separator,  trims whitespace from each
		/// resulting substring, and removes any empty entries.
		/// </summary>
		/// <param name="s">The input string to split. Cannot be <see langword="null"/>.</param>
		/// <param name="separator">The string to use as the separator. If <see langword="null"/>, whitespace is used as the separator.</param>
		/// <param name="count">The maximum number of substrings to return. Must be greater than zero.</param>
		/// <returns>An array of trimmed substrings resulting from the split operation. Empty entries are removed.</returns>
		public string[] TrimmedSplit(string? separator, int count) => s.Split(separator, count, RemoveEmptyAndTrim);

		/// <summary>
		/// Splits the input string into an array of substrings based on the specified separators, trims whitespace from each
		/// resulting substring, and removes any empty entries.
		/// </summary>
		/// <param name="s">The string to split. Cannot be <see langword="null"/>.</param>
		/// <param name="separator">An array of strings that delimit the substrings in this string. If <see langword="null"/>, white-space characters
		/// are used as the default separators.</param>
		/// <param name="count">The maximum number of substrings to return. Must be greater than zero. If the count is less than the number of
		/// resulting substrings, the remaining substrings are concatenated into the final element.</param>
		/// <returns>An array of substrings, with each substring trimmed of leading and trailing whitespace. Empty entries are excluded
		/// from the result.</returns>
		public string[] TrimmedSplit(string[]? separator, int count) => s.Split(separator, count, RemoveEmptyAndTrim);
	}
}
