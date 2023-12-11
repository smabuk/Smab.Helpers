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

	public static IEnumerable<Point> AsPoints(this IEnumerable<string> input, char match, int? cols = null, int? rows = null) {
		string[] array = [.. input];
		rows ??= array.Length;
		cols ??= array[0].Length;

		for (int r = 0; r < rows; r++) {
			for (int c = 0; c < cols; c++) {
				if (array[r][c] == match) {
					yield return new Point(c, r);
				}
			}
		}
	}

	public static IEnumerable<Point> AsPoints(this string input, char match, int? cols = null, int? rows = null)
		=> input.Split(Environment.NewLine).AsPoints(match, cols, rows);
}
