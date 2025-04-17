using System.Numerics;

namespace Smab.Helpers;
public static partial class MathsHelpers {
	/// <summary>
	/// Converts the specified number to its string representation in the given base.
	/// </summary>
	/// <remarks>This method supports any numeric type that implements <see cref="INumber{T}"/>. The input number
	/// must be non-negative.</remarks>
	/// <typeparam name="T">The numeric type of the input value. Must implement <see cref="INumber{T}"/>.</typeparam>
	/// <param name="number">The number to convert. Must be greater than or equal to zero.</param>
	/// <param name="baseNumber">The base to use for the conversion. Must be greater than or equal to 2.</param>
	/// <param name="minSize">The minimum length of the resulting string. If the converted value is shorter than this length,  it will be
	/// left-padded with '0'. Defaults to 1.</param>
	/// <returns>A string representing the number in the specified base, left-padded with '0' to meet the minimum size.</returns>
	public static string ToBaseAsString<T>(this T number, int baseNumber, int minSize = 1) where T : INumber<T> {
		if (number == T.Zero) { return "0".PadLeft(minSize, '0'); }

		T divisor = T.CreateChecked(baseNumber);

		string result = "";
		while (number > T.Zero) {
			T remainder =  number % divisor;
			result = remainder + result;
			number /= divisor;
		}

		return result.PadLeft(minSize, '0');
	}
}
