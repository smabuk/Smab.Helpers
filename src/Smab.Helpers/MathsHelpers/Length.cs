using System.Numerics;

namespace Smab.Helpers;
public static partial class MathsHelpers {

	extension<T>(T number) where T : INumber<T> {
		/// <summary>
		/// Calculates the number of digits in the specified non-negative number.
		/// </summary>
		/// <remarks>This method supports various numeric types, including <see cref="int"/>, <see cref="long"/>, <see
		/// cref="uint"/>, <see cref="ulong"/>, <see cref="short"/>, <see cref="ushort"/>, <see cref="byte"/>, and <see
		/// cref="sbyte"/>. For other numeric types, the method falls back to calculating the length of the string
		/// representation of the number.</remarks>
		/// <typeparam name="T">The numeric type of the input, which must implement <see cref="INumber{T}"/>.</typeparam>
		/// <param name="number">The number whose digit count is to be calculated. Must be greater than or equal to <see langword="0"/>.</param>
		/// <returns>The number of digits in the specified number. Returns <c>0</c> if <paramref name="number"/> is <see
		/// langword="null"/>.</returns>
		/// <exception cref="ArgumentOutOfRangeException">Thrown if <paramref name="number"/> is less than <see langword="0"/>.</exception>
		public int Length() {

			if (number is null) { return 0; }
			if (number == T.Zero) { return 1; }

			if (number < T.One) {
				throw new ArgumentOutOfRangeException(nameof(number), $"{number} must be >= 0");
			}

			return number switch {
				int num => (int)Math.Log10(num) + 1,
				long num => (int)Math.Log10(num) + 1,
				uint num => (int)Math.Log10(num) + 1,
				ulong num => (int)Math.Log10(num) + 1,
				ushort num => (int)Math.Log10(num) + 1,
				short num => (int)Math.Log10(num) + 1,
				byte num => (int)Math.Log10(num) + 1,
				sbyte num => (int)Math.Log10(num) + 1,
				_ => number.ToString()?.Length ?? 0,
			};
		}
	}
}
