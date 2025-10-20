using System.Numerics;

namespace Smab.Helpers;
public static partial class ParsingHelpers {
	extension(string input) {
		/// <summary>
		/// Converts a binary string representation to a numeric value of the specified type.
		/// </summary>
		/// <remarks>This method replaces all occurrences of <paramref name="zeroChar"/> with '0' and <paramref
		/// name="oneChar"/> with '1', then parses the resulting string as a binary number. The numeric type <typeparamref
		/// name="T"/> must support binary parsing and implement <see cref="INumber{T}"/>.</remarks>
		/// <typeparam name="T">The numeric type to convert the binary string to. Must implement <see cref="INumber{T}"/>.</typeparam>
		/// <param name="input">The binary string to convert. The string should use the specified characters to represent binary digits.</param>
		/// <param name="zeroChar">The character representing a binary 0 in the input string. Defaults to <c>'.'</c>.</param>
		/// <param name="oneChar">The character representing a binary 1 in the input string. Defaults to <c>'#'</c>.</param>
		/// <returns>A numeric value of type <typeparamref name="T"/> corresponding to the binary representation in the input string.</returns>
		public T FromBinaryAs<T>(char zeroChar = '.', char oneChar = '#') where T : INumber<T>
			=> T.CreateChecked(T.Parse(input.Replace(zeroChar, '0').Replace(oneChar, '1'), System.Globalization.NumberStyles.BinaryNumber, null));
	}
}
