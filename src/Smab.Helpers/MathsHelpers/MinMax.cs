using System.Numerics;

namespace Smab.Helpers;
public static partial class MathsHelpers {
	public static (T Min, T Max) MinMax<T>(this T number1, T number2) where T : INumber<T>
		=> number1 < number2 ? (number1, number2) : (number2, number1);

	public static (T Min, T Max) MinMax<T>(this (T number1, T number2) tuple) where T : INumber<T>
		=> tuple.number1 < tuple.number2 ? (tuple.number1, tuple.number2) : (tuple.number2, tuple.number1);

	public static (int Min, int Max) MinMax(this Point point)
		=> point.X < point.Y ? (point.X, point.Y) : (point.Y, point.X);




	public static (T Min, T Max) MinMax<T>(this IEnumerable<T> numbers) where T : INumber<T> {
		T first = numbers.First();
		T min = first;
		T max = first;

		foreach (T number in numbers.Skip(1)) {
			min = T.MinNumber(min, number);
			max = T.MaxNumber(max, number);
		}
		return (min, max);
	}

	public static (T Min, T Max) MinMax<T>(this IEnumerable<(T number1, T number2)> tuples) where T : INumber<T>
		=> tuples.SelectMany(((T, T) number) => (T[])[number.Item1, number.Item2]).MinMax<T>();

	public static (int Min, int Max) MinMax(this IEnumerable<Point> points)
		=> points.Select(point => (point.X, point.Y).MinMax()).MinMax<int>();
}
