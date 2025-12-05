namespace Smab.Helpers;

public static partial class ArrayHelpers {
	extension<T>(Grid<T> grid) {
		// Cell enumeration
		/// <summary>
		/// Enumerates all cells in the grid, providing their coordinates and values.
		/// </summary>
		/// <returns>An enumerable of Cell objects, where each object contains the coordinates and value.</returns>
		public IEnumerable<Cell<T>> ForEachCell()
			=> grid.Indexes().Select(ix => new Cell<T>(ix.X, ix.Y, grid[ix.X, ix.Y]));
	}

	extension<T>(T[,] array) {
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
		public IEnumerable<Cell<T>> ForEachCell()
			=> array.Indexes().Select(ix => new Cell<T>(ix.X, ix.Y, array[ix.X, ix.Y]));

		[Obsolete("Use ForEachCell instead", false)]
		public IEnumerable<Cell<T>> WalkWithValues() {
			int cols = array.GetUpperBound(COL_DIMENSION);
			int rows = array.GetUpperBound(ROW_DIMENSION);

			for (int row = 0; row <= rows; row++) {
				for (int col = 0; col <= cols; col++) {
					yield return new(col, row, array[col, row]);
				}
			}
		}

		[Obsolete("Use ForEach instead", false)]
		public IEnumerable<(int X, int Y)> Walk() {
			int cols = array.GetUpperBound(COL_DIMENSION);
			int rows = array.GetUpperBound(ROW_DIMENSION);

			for (int row = 0; row <= rows; row++) {
				for (int col = 0; col <= cols; col++) {
					yield return new(col, row);
				}
			}
		}
	}
}
