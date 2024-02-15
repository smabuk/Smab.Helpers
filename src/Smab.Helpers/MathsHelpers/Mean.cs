using System.Numerics;

namespace Smab.Helpers;

public static partial class MathsHelpers {

	/// <summary>
	/// Finds the mean average and returns it as a double
	/// </summary>
	/// <typeparam name="T"></typeparam>
	/// <param name="numbers"></param>
	/// <returns></returns>
	public static double Mean<T>(this IEnumerable<T> numbers) where T : INumber<T>
		=> numbers.Select(n => Convert.ToDouble(n)).Average();
}
