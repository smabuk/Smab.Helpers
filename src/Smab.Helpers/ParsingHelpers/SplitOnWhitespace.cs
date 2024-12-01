namespace Smab.Helpers;
public static partial class ParsingHelpers {
	public static string[] SplitOnWhitespace(this string s, bool treatNewlineAsWhitespace = true) =>
			s.TrimmedSplit(treatNewlineAsWhitespace ? WHITESPACE_SEPARATORS_WITH_NEWLINE : WHITESPACE_SEPARATORS);

	public static string[] SplitOnWhitespace(this string s, int count, bool treatNewlineAsWhitespace = true) =>
		s.TrimmedSplit(treatNewlineAsWhitespace ? WHITESPACE_SEPARATORS_WITH_NEWLINE : WHITESPACE_SEPARATORS, count);
}
