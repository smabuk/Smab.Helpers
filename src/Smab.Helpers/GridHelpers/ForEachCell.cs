namespace Smab.Helpers;

public static partial class ArrayHelpers {
	/// <summary>
	/// 
	/// </summary>
	/// <typeparam name="T"></typeparam>
	/// <param name="array"></param>
	/// <returns></returns>
	public static IEnumerable<Cell<T>> ForEachCell<T>(this T[,] array)
		=> array.Indexes().Select(ix => new Cell<T>(ix.X, ix.Y, array[ix.X, ix.Y]));

	[Obsolete("Use ForEachCell instead", false)]
	public static IEnumerable<Cell<T>> WalkWithValues<T>(this T[,] array) {
		int cols = array.GetUpperBound(COL_DIMENSION);
		int rows = array.GetUpperBound(ROW_DIMENSION);

		for (int row = 0; row <= rows; row++) {
			for (int col = 0; col <= cols; col++) {
				yield return new(col, row, array[col, row]);
			}
		}
	}

	[Obsolete("Use ForEach instead", false)]
	public static IEnumerable<(int X, int Y)> Walk<T>(this T[,] array) {
		int cols = array.GetUpperBound(COL_DIMENSION);
		int rows = array.GetUpperBound(ROW_DIMENSION);

		for (int row = 0; row <= rows; row++) {
		for (int col = 0; col <= cols; col++) {
			yield return new(col, row);
		}}
	}
}
