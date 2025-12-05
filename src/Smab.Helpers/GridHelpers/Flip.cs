namespace Smab.Helpers;

public static partial class ArrayHelpers {

	extension<T>(Grid<T> grid) {
		/// <summary>
		/// Flips the grid horizontally, reversing the order of columns in each row.
		/// </summary>
		/// <returns>A new grid that is flipped horizontally.</returns>
		public Grid<T> FlipHorizontally() {
			Grid<T> result = new(grid.ColsCount, grid.RowsCount);
			grid.Indexes().ForEach(ix => { result[ix.X, ix.Y] = grid[grid.ColsCount - ix.X - 1, ix.Y]; });
			return result;
		}

		/// <summary>
		/// Flips the grid vertically, reversing the order of rows in each column.
		/// </summary>
		/// <returns>A new grid that is flipped vertically.</returns>
		public Grid<T> FlipVertically() {
			Grid<T> result = new(grid.ColsCount, grid.RowsCount);
			grid.Indexes().ForEach(ix => { result[ix.X, ix.Y] = grid[ix.X, grid.RowsCount - ix.Y - 1]; });
			return result;
		}

	}

	extension<T>(T[,] array) {
		/// <summary>
		/// Flips a two-dimensional array horizontally, reversing the order of columns in each row.
		/// </summary>
		/// <typeparam name="T">The type of the elements in the array.</typeparam>
		/// <param name="array">The two-dimensional array to flip.</param>
		/// <returns>A new two-dimensional array that is flipped horizontally.</returns>
		public T[,] FlipHorizontally() {
			int colsCount = array.ColsCount();
			int rowsCount = array.RowsCount();

			T[,] result = new T[colsCount, rowsCount];

			array.Indexes().ForEach(ix => { result[ix.X, ix.Y] = array[colsCount - ix.X - 1, ix.Y]; });

			return result;
		}

		/// <summary>
		/// Flips a two-dimensional array vertically, reversing the order of rows in each column.
		/// </summary>
		/// <typeparam name="T">The type of the elements in the array.</typeparam>
		/// <param name="array">The two-dimensional array to flip.</param>
		/// <returns>A new two-dimensional array that is flipped vertically.</returns>
		public T[,] FlipVertically() {
			int colsCount = array.ColsCount();
			int rowsCount = array.RowsCount();

			T[,] result = new T[colsCount, rowsCount];

			array.Indexes().ForEach(ix => { result[ix.X, ix.Y] = array[ix.X, rowsCount - ix.Y - 1]; });

			return result;
		}
	}
}
