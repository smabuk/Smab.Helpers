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

		for (int row = 0; row < rows; row++) {
		for (int col = 0; col < cols; col++) {
			if (array[row][col] == match) {
				yield return new Point(col, row);
			}
		}
		}
	}

	public static IEnumerable<Point> AsPoints(this string input, char match, int? cols = null, int? rows = null)
		=> input.Split(Environment.NewLine).AsPoints(match, cols, rows);
}
