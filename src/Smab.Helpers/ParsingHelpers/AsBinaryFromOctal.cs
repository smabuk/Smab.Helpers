namespace Smab.Helpers;

public static partial class ParsingHelpers {
	extension(string input) {
		/// <summary>
		/// Converts a string of octal digits to its equivalent binary representation.
		/// </summary>
		/// <remarks>Each octal digit in the input string is converted to its 4-bit binary equivalent.  For example, an
		/// input of "17" will produce "001111" as the output.</remarks>
		/// <param name="input">A string containing octal digits. Each character must be a valid octal digit (0-7).</param>
		/// <returns>A string representing the binary equivalent of the input octal digits, with each octal digit converted to a 4-bit
		/// binary value.</returns>
		public string AsBinaryFromOctal()
			=> string.Join(
				string.Empty,
				input.Select(c => Convert.ToString(Convert.ToInt32(c.ToString(), 8), 2).PadLeft(4, '0')));
	}

	extension(IEnumerable<string> input) {
		/// <summary>
		/// Converts a sequence of octal string values to their binary representation and concatenates the results into a
		/// single binary string.
		/// </summary>
		/// <remarks>Each string in the input sequence is expected to represent a valid octal number. Invalid or
		/// malformed octal strings may result in an exception or undefined behavior.</remarks>
		/// <param name="input">A collection of strings, where each string represents an octal number.</param>
		/// <returns>A single string containing the binary representation of all input octal values, concatenated together in the order
		/// they appear in the input sequence.</returns>
		public string AsBinaryFromOctal()
			=> string.Join(string.Empty, input.Select(AsBinaryFromOctal));
	}
}
