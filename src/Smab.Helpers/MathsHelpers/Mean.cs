namespace Smab.Helpers;

public static partial class MathsHelpers {

	extension<T>(IEnumerable<T> numbers) where T : INumber<T> {
		/// <summary>
		/// Finds the mean average and returns it as a double
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="numbers"></param>
		/// <returns></returns>
		public double Mean() => numbers.Select(n => Convert.ToDouble(n)).Average();
	}
}
