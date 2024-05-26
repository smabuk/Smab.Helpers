namespace Smab.Helpers;
public static partial class ParsingHelpers {
	public static IEnumerable<Cell<char>> AsCells(this IEnumerable<string> input, char[]? matches = null, int? cols = null, int? rows = null) {
		string[] array = [.. input];
		rows ??= array.Length;
		cols ??= array[0].Length;

		for (int row = 0; row < rows; row++) {
		for (int col = 0; col < cols; col++) {
			if ((   matches is     null && array[row][col] != ' ') 
				|| (matches is not null && matches.Contains(array[row][col]))) {
				yield return new Cell<char>(col, row, array[row][col]);
			}
		}
		}
	}

	public static IEnumerable<Cell<char>> AsCells(this string input, char[]? matches = null, int? cols = null, int? rows = null)
		=> input.Split(Environment.NewLine).AsCells(matches, cols, rows);
}
