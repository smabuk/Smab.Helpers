using System.Numerics;

namespace Smab.Helpers;

public static partial class AverageHelpers {

	/// <summary>
	/// Finds the mean average and returns it as a double
	/// </summary>
	/// <typeparam name="T"></typeparam>
	/// <param name="numbers"></param>
	/// <returns></returns>
	public static double Mean<T>(this IEnumerable<T> numbers) where T : INumber<T>
		=> numbers.Select(n => Convert.ToDouble(n)).Average();

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


	/// <summary>
	/// Returns the values occuring the most times
	/// </summary>
	/// <typeparam name="T"></typeparam>
	/// <param name="array"></param>
	/// <returns></returns>
	public static IEnumerable<T> Modes<T>(this T[] array) {
		(T Key, int Count)[] counts = array
			.GroupBy(x => x)
			.Select(g => (g.Key, Count: g.Count()))
			.ToArray();

		int maxCount = counts.Max(c => c.Count);

		IEnumerable<T>? modes = counts
			.Where(m => m.Count == maxCount)
			.Select(item => item.Key);

		foreach (T item in modes) {
			yield return item;
		}
	}

}
