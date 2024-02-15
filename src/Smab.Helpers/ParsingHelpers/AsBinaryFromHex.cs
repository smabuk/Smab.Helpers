namespace Smab.Helpers;
public static partial class ParsingHelpers {
	public static string AsBinaryFromHex(this string input)
		=> string.Join(
			string.Empty,
			input.Select(c => Convert.ToString(Convert.ToInt32(c.ToString(), 16), 2).PadLeft(4, '0')));
	public static string AsBinaryFromHex(this IEnumerable<string> input)
		=> string.Join(string.Empty, input.Select(AsBinaryFromHex));
}
