namespace Smab.Helpers;
public static partial class ParsingHelpers {
	/// <summary>
	/// Splits the input string into an array of substrings based on whitespace characters.
	/// </summary>
	/// <param name="s">The string to be split. Cannot be <see langword="null"/>.</param>
	/// <param name="treatNewlineAsWhitespace">A value indicating whether newline characters (<see langword="\n"/> and <see langword="\r"/>) should be treated as
	/// whitespace for splitting. If <see langword="true"/>, newline characters are included as separators; otherwise, they
	/// are not.</param>
	/// <returns>An array of substrings obtained by splitting the input string on whitespace characters. The array will not contain
	/// empty entries, and leading and trailing whitespace is ignored.</returns>
	public static string[] SplitOnWhitespace(this string s, bool treatNewlineAsWhitespace = true) =>
			s.TrimmedSplit(treatNewlineAsWhitespace ? WHITESPACE_SEPARATORS_WITH_NEWLINE : WHITESPACE_SEPARATORS);

	/// <summary>
	/// Splits the specified string into an array of substrings based on whitespace characters.
	/// </summary>
	/// <remarks>Whitespace characters include spaces, tabs, and optionally newline characters, depending on the
	/// value of <paramref name="treatNewlineAsWhitespace"/>. Leading and trailing whitespace in the input string is
	/// ignored.</remarks>
	/// <param name="s">The string to split. Cannot be <see langword="null"/>.</param>
	/// <param name="count">The maximum number of substrings to return. If the value is less than or equal to 0, the method returns all
	/// substrings.</param>
	/// <param name="treatNewlineAsWhitespace">A value indicating whether newline characters should be treated as whitespace. If <see langword="true"/>, newline
	/// characters are included as delimiters; otherwise, they are not.</param>
	/// <returns>An array of substrings resulting from splitting the input string on whitespace characters. The array will be empty
	/// if the input string is empty or consists only of whitespace.</returns>
	public static string[] SplitOnWhitespace(this string s, int count, bool treatNewlineAsWhitespace = true) =>
		s.TrimmedSplit(treatNewlineAsWhitespace ? WHITESPACE_SEPARATORS_WITH_NEWLINE : WHITESPACE_SEPARATORS, count);
}
