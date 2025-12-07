namespace Smab.Helpers;

public static partial class ArrayHelpers {
	extension<T>(Grid<T> grid) {
		/// <summary>
		/// Concatenates another grid to the right of this grid.
		/// </summary>
		/// <param name="other">The grid to concatenate to the right.</param>
		/// <returns>A new Grid with the combined columns. The number of rows must match.</returns>
		/// <exception cref="ArgumentException">Thrown when the number of rows in both grids don't match.</exception>
		public Grid<T> ConcatRight(Grid<T> other) {
			if (grid.RowsCount != other.RowsCount) {
				throw new ArgumentException($"Cannot concatenate grids with different row counts. Left grid has {grid.RowsCount} rows, right grid has {other.RowsCount} rows.");
			}

			Grid<T> result = new(grid.ColsCount + other.ColsCount, grid.RowsCount);

			// Copy left grid
			for (int col = 0; col < grid.ColsCount; col++) {
				for (int row = 0; row < grid.RowsCount; row++) {
					result[col, row] = grid[col, row];
				}
			}

			// Copy right grid
			for (int col = 0; col < other.ColsCount; col++) {
				for (int row = 0; row < other.RowsCount; row++) {
					result[grid.ColsCount + col, row] = other[col, row];
				}
			}

			return result;
		}

		/// <summary>
		/// Concatenates another grid to the bottom of this grid.
		/// </summary>
		/// <param name="other">The grid to concatenate to the bottom.</param>
		/// <returns>A new Grid with the combined rows. The number of columns must match.</returns>
		/// <exception cref="ArgumentException">Thrown when the number of columns in both grids don't match.</exception>
		public Grid<T> ConcatBottom(Grid<T> other) {
			if (grid.ColsCount != other.ColsCount) {
				throw new ArgumentException($"Cannot concatenate grids with different column counts. Top grid has {grid.ColsCount} columns, bottom grid has {other.ColsCount} columns.");
			}

			Grid<T> result = new(grid.ColsCount, grid.RowsCount + other.RowsCount);

			// Copy top grid
			for (int col = 0; col < grid.ColsCount; col++) {
				for (int row = 0; row < grid.RowsCount; row++) {
					result[col, row] = grid[col, row];
				}
			}

			// Copy bottom grid
			for (int col = 0; col < other.ColsCount; col++) {
				for (int row = 0; row < other.RowsCount; row++) {
					result[col, grid.RowsCount + row] = other[col, row];
				}
			}

			return result;
		}
	}

	extension<T>(T[,] array) {
		/// <summary>
		/// Concatenates another array to the right of this array.
		/// </summary>
		/// <param name="other">The array to concatenate to the right.</param>
		/// <returns>A new two-dimensional array with the combined columns. The number of rows must match.</returns>
		/// <exception cref="ArgumentException">Thrown when the number of rows in both arrays don't match.</exception>
		public T[,] ConcatRight(T[,] other) {
			int leftCols = array.GetLength(0);
			int leftRows = array.GetLength(1);
			int rightCols = other.GetLength(0);
			int rightRows = other.GetLength(1);

			if (leftRows != rightRows) {
				throw new ArgumentException($"Cannot concatenate arrays with different row counts. Left array has {leftRows} rows, right array has {rightRows} rows.");
			}

			T[,] result = new T[leftCols + rightCols, leftRows];

			// Copy left array
			for (int col = 0; col < leftCols; col++) {
				for (int row = 0; row < leftRows; row++) {
					result[col, row] = array[col, row];
				}
			}

			// Copy right array
			for (int col = 0; col < rightCols; col++) {
				for (int row = 0; row < rightRows; row++) {
					result[leftCols + col, row] = other[col, row];
				}
			}

			return result;
		}

		/// <summary>
		/// Concatenates another array to the bottom of this array.
		/// </summary>
		/// <param name="other">The array to concatenate to the bottom.</param>
		/// <returns>A new two-dimensional array with the combined rows. The number of columns must match.</returns>
		/// <exception cref="ArgumentException">Thrown when the number of columns in both arrays don't match.</exception>
		public T[,] ConcatBottom(T[,] other) {
			int topCols = array.GetLength(0);
			int topRows = array.GetLength(1);
			int bottomCols = other.GetLength(0);
			int bottomRows = other.GetLength(1);

			if (topCols != bottomCols) {
				throw new ArgumentException($"Cannot concatenate arrays with different column counts. Top array has {topCols} columns, bottom array has {bottomCols} columns.");
			}

			T[,] result = new T[topCols, topRows + bottomRows];

			// Copy top array
			for (int col = 0; col < topCols; col++) {
				for (int row = 0; row < topRows; row++) {
					result[col, row] = array[col, row];
				}
			}

			// Copy bottom array
			for (int col = 0; col < bottomCols; col++) {
				for (int row = 0; row < bottomRows; row++) {
					result[col, topRows + row] = other[col, row];
				}
			}

			return result;
		}
	}
}
