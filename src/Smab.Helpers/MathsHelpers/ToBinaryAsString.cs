using System.Numerics;

namespace Smab.Helpers;

public static partial class MathsHelpers {
	extension<T>(T number) where T : INumber<T> {
		/// <summary>
		/// Converts the specified numeric value to its binary string representation, optionally padded to a minimum length.
		/// </summary>
		/// <remarks>This method supports various numeric types, including <see langword="int"/>, <see
		/// langword="byte"/>, <see langword="short"/>, and <see langword="long"/>. For other numeric types, the conversion is
		/// performed using the <see cref="ToBaseAsString"/> method with a base of 2.</remarks>
		/// <typeparam name="T">The type of the numeric value. Must implement <see cref="INumber{T}"/>.</typeparam>
		/// <param name="number">The numeric value to convert to a binary string.</param>
		/// <param name="minSize">The minimum length of the resulting binary string. If the binary representation of <paramref name="number"/> is
		/// shorter than this value, it will be left-padded with '0' characters. Defaults to 1.</param>
		/// <returns>A string containing the binary representation of <paramref name="number"/>, padded to at least <paramref
		/// name="minSize"/> characters.</returns>
		public string ToBinaryAsString(int minSize = 1) {

			return number switch {
				int num => Convert.ToString(num, 2).PadLeft(minSize, '0'),
				byte num => Convert.ToString(num, 2).PadLeft(minSize, '0'),
				short num => Convert.ToString(num, 2).PadLeft(minSize, '0'),
				long num => Convert.ToString(num, 2).PadLeft(minSize, '0'),
				_ => number.ToBaseAsString(2, minSize),
			};
		}
	}
}
