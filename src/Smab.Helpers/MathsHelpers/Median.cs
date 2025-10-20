using System.Numerics;

namespace Smab.Helpers;

public static partial class MathsHelpers {
	extension<T>(T[] numbers) where T : INumber<T> {
		/// <summary>
		/// Finds the Median value and returns it as double
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="numbers"></param>
		/// <returns></returns>
		public double MedianAsDouble() {
			IOrderedEnumerable<T> sortedNumbers = numbers.OrderBy(n => n);
			int midPoint = numbers.Length / 2;
			return (numbers.Length % 2) switch {
				0 => (Convert.ToDouble(sortedNumbers.ElementAt(midPoint))
					+ Convert.ToDouble(sortedNumbers.ElementAt(midPoint - 1)))
					/ 2.0,
				_ => Convert.ToDouble(sortedNumbers.ElementAt(midPoint))
			};
		}
	}

	extension<T>(IEnumerable<T> numbers) where T : INumber<T> {
		/// <summary>
		/// Finds the Median value and returns it as double
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="numbers"></param>
		/// <returns></returns>
		public double Median() {
			return numbers.ToArray().MedianAsDouble();
		}
	}

	extension(IEnumerable<int> numbers) {
		/// <summary>
		/// Finds the Median value and returns it as an int
		/// </summary>
		/// <param name="numbers"></param>
		/// <returns></returns>
		public int Median() {
			return Convert.ToInt32(numbers.ToArray().MedianAsDouble());
		}
	}

	extension(IEnumerable<long> numbers) {
		/// <summary>
		/// Finds the Median value and returns it as a long
		/// </summary>
		/// <param name="numbers"></param>
		/// <returns></returns>
		public long Median() {
			return Convert.ToInt64(numbers.ToArray().MedianAsDouble());
		}
	}
}
