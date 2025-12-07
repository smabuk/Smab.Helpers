namespace Smab.Helpers;

public static partial class ArrayHelpers {
	extension<T>(Grid<T> grid) {
		/// <summary>
		/// Transforms each element of the grid using the specified selector function.
		/// </summary>
		/// <typeparam name="TResult">The type of the elements in the resulting grid.</typeparam>
		/// <param name="selector">A function to transform each element.</param>
		/// <returns>A new Grid containing the transformed elements.</returns>
		public Grid<TResult> Map<TResult>(Func<T, TResult> selector) {
			Grid<TResult> result = new(grid.ColsCount, grid.RowsCount);
			for (int col = 0; col < grid.ColsCount; col++) {
				for (int row = 0; row < grid.RowsCount; row++) {
					result[col, row] = selector(grid[col, row]);
				}
			}
			return result;
		}

		/// <summary>
		/// Transforms each element of the grid using the specified selector function that also receives the element's position.
		/// </summary>
		/// <typeparam name="TResult">The type of the elements in the resulting grid.</typeparam>
		/// <param name="selector">A function to transform each element, receiving column index, row index, and the element value.</param>
		/// <returns>A new Grid containing the transformed elements.</returns>
		public Grid<TResult> Map<TResult>(Func<int, int, T, TResult> selector) {
			Grid<TResult> result = new(grid.ColsCount, grid.RowsCount);
			for (int col = 0; col < grid.ColsCount; col++) {
				for (int row = 0; row < grid.RowsCount; row++) {
					result[col, row] = selector(col, row, grid[col, row]);
				}
			}
			return result;
		}

		/// <summary>
		/// Applies an accumulator function over the grid elements.
		/// </summary>
		/// <typeparam name="TResult">The type of the accumulator value.</typeparam>
		/// <param name="seed">The initial accumulator value.</param>
		/// <param name="func">An accumulator function to be invoked on each element.</param>
		/// <returns>The final accumulator value.</returns>
		public TResult Aggregate<TResult>(TResult seed, Func<TResult, T, TResult> func) {
			TResult result = seed;
			for (int col = 0; col < grid.ColsCount; col++) {
				for (int row = 0; row < grid.RowsCount; row++) {
					result = func(result, grid[col, row]);
				}
			}
			return result;
		}
	}

	extension<T>(T[,] array) {
		/// <summary>
		/// Transforms each element of the array using the specified selector function.
		/// </summary>
		/// <typeparam name="TResult">The type of the elements in the resulting array.</typeparam>
		/// <param name="selector">A function to transform each element.</param>
		/// <returns>A new two-dimensional array containing the transformed elements.</returns>
		public TResult[,] Map<TResult>(Func<T, TResult> selector) {
			int cols = array.GetLength(0);
			int rows = array.GetLength(1);
			TResult[,] result = new TResult[cols, rows];

			for (int col = 0; col < cols; col++) {
				for (int row = 0; row < rows; row++) {
					result[col, row] = selector(array[col, row]);
				}
			}
			return result;
		}

		/// <summary>
		/// Transforms each element of the array using the specified selector function that also receives the element's position.
		/// </summary>
		/// <typeparam name="TResult">The type of the elements in the resulting array.</typeparam>
		/// <param name="selector">A function to transform each element, receiving column index, row index, and the element value.</param>
		/// <returns>A new two-dimensional array containing the transformed elements.</returns>
		public TResult[,] Map<TResult>(Func<int, int, T, TResult> selector) {
			int cols = array.GetLength(0);
			int rows = array.GetLength(1);
			TResult[,] result = new TResult[cols, rows];

			for (int col = 0; col < cols; col++) {
				for (int row = 0; row < rows; row++) {
					result[col, row] = selector(col, row, array[col, row]);
				}
			}
			return result;
		}
	}
}
