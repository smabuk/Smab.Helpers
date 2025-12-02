using System.Numerics;

namespace Smab.Helpers;

public static partial class MathsHelpers {

	/// <summary>
	/// Provides a precomputed array of powers of 10, where each element represents 10 raised to the power of its index.
	/// </summary>
	/// <remarks>This array can be used for efficient lookup of powers of 10 without repeated calculation, which is
	/// useful in numeric formatting, parsing, or scaling operations. The array contains values from 10⁰ (1) up to 10¹⁸
	/// (1,000,000,000,000,000,000).</remarks>
	public static readonly long[] Pow10 = [
		1,
		10,
		100,
		1_000,
		10_000,
		100_000,
		1_000_000,
		10_000_000,
		100_000_000,
		1_000_000_000,
		10_000_000_000,
		100_000_000_000L,
		1_000_000_000_000L,
		10_000_000_000_000L,
		100_000_000_000_000L,
		1_000_000_000_000_000L,
		10_000_000_000_000_000L,
		100_000_000_000_000_000L,
		1_000_000_000_000_000_000L,
	];

	extension(int number) {
		/// <summary>
		/// Gets the value of 10 raised to the power of the specified number.
		/// </summary>
		/// <remarks>For values of the exponent between 0 and 18, the result is computed efficiently using precomputed
		/// constants. For larger exponents, the value is calculated using arbitrary-precision arithmetic and cast to a 64-bit
		/// integer, which may result in an overflow exception if the result exceeds the range of a long.</remarks>
		public long Pow10 => number switch {
			< 0 => throw new ArgumentOutOfRangeException(nameof(number), "Exponent must be non-negative."),
			< 19 => Pow10[number],
			_ => checked((long)BigInteger.Pow(10, number))
		};
	}
}
