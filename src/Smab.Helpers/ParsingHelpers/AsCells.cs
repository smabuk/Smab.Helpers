namespace Smab.Helpers;
public static partial class ParsingHelpers {
	public static IEnumerable<Cell<char>> AsCells(this IEnumerable<string> input, char[]? matches = null, int? cols = null, int? rows = null) {
		string[] array = [.. input];
		rows ??= array.Length;
		cols ??= array[0].Length;

		for (int r = 0; r < rows; r++) {
			for (int c = 0; c < cols; c++) {
				if ((   matches is     null && array[r][c] != ' ') 
					|| (matches is not null && matches.Contains(array[r][c]))) {
					yield return new Cell<char>(c, r, array[r][c]);
				}
			}
		}
	}

	public static IEnumerable<Cell<char>> AsCells(this string input, char[]? matches = null, int? cols = null, int? rows = null)
		=> input.Split(Environment.NewLine).AsCells(matches, cols, rows);
}
