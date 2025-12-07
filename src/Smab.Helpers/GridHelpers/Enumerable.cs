namespace Smab.Helpers;

public static partial class ArrayHelpers {
	extension<T>(Grid<T> grid) {
		/// <summary>
		/// Returns an enumerable collection of all values in the grid.
		/// </summary>
		/// <returns>An enumerable collection of all elements in the grid in row-major order.</returns>
		public IEnumerable<T> Values() {
			foreach (T value in grid.InternalCells) {
				yield return value;
			}
		}

		/// <summary>
		/// Returns an enumerable collection of all cells in the grid.
		/// </summary>
		/// <returns>An enumerable collection of all cells in the grid in row-major order.</returns>
		public IEnumerable<Cell<T>> ValuesAsCells() {
			for (int row = 0; row < grid.Height; row++) {
				for (int col = 0; col < grid.Width; col++) {
					yield return new Cell<T>(new Point(col, row), grid.InternalCells[col, row]);
				}
			}
		}
	}

}

