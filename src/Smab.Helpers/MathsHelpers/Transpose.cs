namespace Smab.Helpers;
public static partial class MathsHelpers {
	public static IEnumerable<Point> Transpose(this IEnumerable<Point> points) => points.Select(point => point.Transpose());

	public static (T Item1, T Item2) Transpose<T>(this (T Item1, T Item2) item) => (item.Item2, item.Item1);
}
