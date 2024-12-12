namespace Smab.Helpers;

public static partial class ArrayHelpers {
	public static IEnumerable<(int X, int Y)> Indexes<T>(this T[,] array) {
		foreach (int row in array.RowIndexes()) {
		foreach (int col in array.ColIndexes()) {
			yield return new(col, row);
		}}
	}

	public static IEnumerable<(int Col, int Row)> IndexesColRow<T>(this T[,] array) {
		foreach (int row in array.RowIndexes()) {
		foreach (int col in array.ColIndexes()) {
			yield return new(col, row);
		}}
	}
}
