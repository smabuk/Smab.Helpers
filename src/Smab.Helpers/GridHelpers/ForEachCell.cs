namespace Smab.Helpers;

public static partial class ArrayHelpers {
	/// <summary>
	/// Enumerates all cells in a two-dimensional array, providing their coordinates and values.
	/// </summary>
	/// <remarks>This method allows iteration over all elements in a two-dimensional array, providing both the 
	/// coordinates and the value of each element. It is particularly useful for scenarios where both  the position and
	/// value of elements are required.</remarks>
	/// <typeparam name="T">The type of elements in the array.</typeparam>
	/// <param name="array">The two-dimensional array to enumerate. Cannot be <see langword="null"/>.</param>
	/// <returns>An <see cref="IEnumerable{T}"/> of <see cref="Cell{T}"/> objects, where each object contains the  X and Y
	/// coordinates of a cell and its corresponding value in the array.</returns>
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
