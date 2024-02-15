using System.Numerics;

namespace Smab.Helpers;

public static partial class MathsHelpers {
	/// <summary>
	/// Finds the Median value and returns it as double
	/// </summary>
	/// <typeparam name="T"></typeparam>
	/// <param name="numbers"></param>
	/// <returns></returns>
	public static double MedianAsDouble<T>(this T[] numbers) where T : INumber<T> {
		IOrderedEnumerable<T> sortedNumbers = numbers.OrderBy(n => n);
		int midPoint = numbers.Length / 2;
		return (numbers.Length % 2) switch {
			0 => (Convert.ToDouble(sortedNumbers.ElementAt(midPoint))
				+ Convert.ToDouble(sortedNumbers.ElementAt(midPoint - 1)))
				/ 2.0,
			_ => Convert.ToDouble(sortedNumbers.ElementAt(midPoint))
		};
	}

	/// <summary>
	/// Finds the Median value and returns it as double
	/// </summary>
	/// <typeparam name="T"></typeparam>
	/// <param name="numbers"></param>
	/// <returns></returns>
	public static double Median<T>(this IEnumerable<T> numbers) where T : INumber<T> {
		return numbers.ToArray().MedianAsDouble();
	}

	/// <summary>
	/// Finds the Median value and returns it as an int
	/// </summary>
	/// <param name="numbers"></param>
	/// <returns></returns>
	public static int Median(this IEnumerable<int> numbers) {
		return Convert.ToInt32(numbers.ToArray().MedianAsDouble());
	}

	/// <summary>
	/// Finds the Median value and returns it as a long
	/// </summary>
	/// <param name="numbers"></param>
	/// <returns></returns>
	public static long Median(this IEnumerable<long> numbers) {
		return Convert.ToInt64(numbers.ToArray().MedianAsDouble());
	}
}
