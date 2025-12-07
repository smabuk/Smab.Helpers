namespace Smab.Helpers;

public static partial class ArrayHelpers {
	extension<T>(Grid<T> grid) where T : INumber<T> {
		/// <summary>
		/// Computes the sum of all numeric values in the grid.
		/// </summary>
		/// <returns>The sum of all values in the grid.</returns>
		public T Sum() {
			T sum = T.Zero;
			for (int col = 0; col < grid.ColsCount; col++) {
				for (int row = 0; row < grid.RowsCount; row++) {
					sum += grid[col, row];
				}
			}
			return sum;
		}

		/// <summary>
		/// Finds the minimum value in the grid.
		/// </summary>
		/// <returns>The minimum value found in the grid.</returns>
		/// <exception cref="InvalidOperationException">Thrown when the grid is empty.</exception>
		public T Min() {
			if (grid.ColsCount == 0 || grid.RowsCount == 0) {
				throw new InvalidOperationException("Cannot find minimum of an empty grid.");
			}

			T min = grid[0, 0];
			for (int col = 0; col < grid.ColsCount; col++) {
				for (int row = 0; row < grid.RowsCount; row++) {
					T value = grid[col, row];
					if (value < min) {
						min = value;
					}
				}
			}
			return min;
		}

		/// <summary>
		/// Finds the maximum value in the grid.
		/// </summary>
		/// <returns>The maximum value found in the grid.</returns>
		/// <exception cref="InvalidOperationException">Thrown when the grid is empty.</exception>
		public T Max() {
			if (grid.ColsCount == 0 || grid.RowsCount == 0) {
				throw new InvalidOperationException("Cannot find maximum of an empty grid.");
			}

			T max = grid[0, 0];
			for (int col = 0; col < grid.ColsCount; col++) {
				for (int row = 0; row < grid.RowsCount; row++) {
					T value = grid[col, row];
					if (value > max) {
						max = value;
					}
				}
			}
			return max;
		}

		/// <summary>
		/// Computes the average of all numeric values in the grid.
		/// </summary>
		/// <returns>The average of all values in the grid.</returns>
		/// <exception cref="InvalidOperationException">Thrown when the grid is empty.</exception>
		public T Average() {
			if (grid.ColsCount == 0 || grid.RowsCount == 0) {
				throw new InvalidOperationException("Cannot compute average of an empty grid.");
			}

			T sum = grid.Sum();
			T count = T.CreateChecked(grid.ColsCount * grid.RowsCount);
			return sum / count;
		}
	}

	extension<T>(T[,] array) where T : INumber<T> {
		/// <summary>
		/// Computes the sum of all numeric values in the array.
		/// </summary>
		/// <returns>The sum of all values in the array.</returns>
		public T Sum() {
			T sum = T.Zero;
			int cols = array.GetLength(0);
			int rows = array.GetLength(1);

			for (int col = 0; col < cols; col++) {
				for (int row = 0; row < rows; row++) {
					sum += array[col, row];
				}
			}
			return sum;
		}

		/// <summary>
		/// Finds the minimum value in the array.
		/// </summary>
		/// <returns>The minimum value found in the array.</returns>
		/// <exception cref="InvalidOperationException">Thrown when the array is empty.</exception>
		public T Min() {
			int cols = array.GetLength(0);
			int rows = array.GetLength(1);

			if (cols == 0 || rows == 0) {
				throw new InvalidOperationException("Cannot find minimum of an empty array.");
			}

			T min = array[0, 0];
			for (int col = 0; col < cols; col++) {
				for (int row = 0; row < rows; row++) {
					T value = array[col, row];
					if (value < min) {
						min = value;
					}
				}
			}
			return min;
		}

		/// <summary>
		/// Finds the maximum value in the array.
		/// </summary>
		/// <returns>The maximum value found in the array.</returns>
		/// <exception cref="InvalidOperationException">Thrown when the array is empty.</exception>
		public T Max() {
			int cols = array.GetLength(0);
			int rows = array.GetLength(1);

			if (cols == 0 || rows == 0) {
				throw new InvalidOperationException("Cannot find maximum of an empty array.");
			}

			T max = array[0, 0];
			for (int col = 0; col < cols; col++) {
				for (int row = 0; row < rows; row++) {
					T value = array[col, row];
					if (value > max) {
						max = value;
					}
				}
			}
			return max;
		}

		/// <summary>
		/// Computes the average of all numeric values in the array.
		/// </summary>
		/// <returns>The average of all values in the array.</returns>
		/// <exception cref="InvalidOperationException">Thrown when the array is empty.</exception>
		public T Average() {
			int cols = array.GetLength(0);
			int rows = array.GetLength(1);

			if (cols == 0 || rows == 0) {
				throw new InvalidOperationException("Cannot compute average of an empty array.");
			}

			T sum = array.Sum();
			T count = T.CreateChecked(cols * rows);
			return sum / count;
		}
	}
}
