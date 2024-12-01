namespace Smab.Helpers;
public static partial class ParsingHelpers {
	private static readonly string[] WHITESPACE_SEPARATORS = [" ",  "\t"];
	private static readonly string[] WHITESPACE_SEPARATORS_WITH_NEWLINE = [..WHITESPACE_SEPARATORS, Environment.NewLine];

	public static string[] SplitOnWhitespace(this string s, bool treatNewlineAsWhitespace = true) =>
			s.TrimmedSplit(treatNewlineAsWhitespace ? WHITESPACE_SEPARATORS_WITH_NEWLINE : WHITESPACE_SEPARATORS);

	public static string[] SplitOnWhitespace(this string s, int count, bool treatNewlineAsWhitespace = true) =>
		s.TrimmedSplit(treatNewlineAsWhitespace ? WHITESPACE_SEPARATORS_WITH_NEWLINE : WHITESPACE_SEPARATORS, count);
}
