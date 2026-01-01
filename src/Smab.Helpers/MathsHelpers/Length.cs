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
		public int Length {
			get {
				if (number is null) { return 0; }
				if (number == T.Zero) { return 1; }

				if (number < T.One) {
					throw new ArgumentOutOfRangeException(nameof(number), $"{number} must be >= 0");
				}

				return number switch {
					int num => QuickLength(num),
					long num => QuickLength(num),
					uint num => QuickLength(num),
					short num => QuickLength(num),
					byte num => QuickLength(num),
					sbyte num => QuickLength(num),
					ulong num => (int)Math.Log10(num) + 1,
					ushort num => (int)Math.Log10(num) + 1,
					_ => number.ToString()?.Length ?? 0,
				};

				static int QuickLength(long value) {
					return value switch {
						< 10 => 1,
						< 100 => 2,
						< 1_000 => 3,
						< 10_000 => 4,
						< 100_000 => 5,
						< 1_000_000 => 6,
						< 10_000_000 => 7,
						< 100_000_000 => 8,
						< 1_000_000_000 => 9,
						< 10_000_000_000 => 10,
						< 100_000_000_000 => 11,
						< 1_000_000_000_000 => 12,
						< 10_000_000_000_000 => 13,
						< 100_000_000_000_000 => 14,
						< 1_000_000_000_000_000 => 15,
						< 10_000_000_000_000_000 => 16,
						< 100_000_000_000_000_000 => 17,
						_ => value.ToString()?.Length ?? 0,
					};
				}
			}
		}
	}
}
