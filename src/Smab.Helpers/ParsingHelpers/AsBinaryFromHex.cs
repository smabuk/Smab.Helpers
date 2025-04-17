namespace Smab.Helpers;
public static partial class ParsingHelpers {
	/// <summary>
	/// Converts a hexadecimal string to its binary representation.
	/// </summary>
	/// <remarks>The resulting binary string will have a length of 4 times the number of characters in the input
	/// string.</remarks>
	/// <param name="input">The hexadecimal string to convert. Each character must be a valid hexadecimal digit (0-9, A-F, a-f).</param>
	/// <returns>A string representing the binary equivalent of the input hexadecimal string. Each hexadecimal digit is converted to
	/// a 4-bit binary value.</returns>
	public static string AsBinaryFromHex(this string input)
		=> string.Join(
			string.Empty,
			input.Select(c => Convert.ToString(Convert.ToInt32(c.ToString(), 16), 2).PadLeft(4, '0')));

	/// <summary>
	/// Converts a collection of hexadecimal string values to their binary string representations and concatenates the
	/// results into a single string.
	/// </summary>
	/// <remarks>Each hexadecimal string in the input collection is individually converted to its binary
	/// representation. The resulting binary strings are then concatenated into a single string.</remarks>
	/// <param name="input">A collection of strings, each representing a hexadecimal value.</param>
	/// <returns>A single string containing the binary representations of the input hexadecimal values, concatenated together.
	/// Returns an empty string if the input collection is empty.</returns>
	public static string AsBinaryFromHex(this IEnumerable<string> input)
		=> string.Join(string.Empty, input.Select(AsBinaryFromHex));
}
