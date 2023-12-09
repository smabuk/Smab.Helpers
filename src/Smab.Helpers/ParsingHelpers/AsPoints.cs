namespace Smab.Helpers;
public static partial class ParsingHelpers {
	public static IEnumerable<Point> AsPoints(this IEnumerable<string> input) =>
		input.Select(i => i.Split(",")).Select(x => new Point(x[0].As<int>(), x[1].As<int>()));

	/// <summary>
	/// Returns Points from an input of (int x,int y) tuples
	/// </summary>
	/// <param name="input"></param>
	/// <returns>IEnumerable<Point></returns>
	public static IEnumerable<Point> AsPoints(this IEnumerable<(int x, int y)> input) =>
		input.Select(p => new Point(X: p.x, Y: p.y));
}
