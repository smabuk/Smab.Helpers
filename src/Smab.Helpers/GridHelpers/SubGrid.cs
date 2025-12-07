namespace Smab.Helpers;

public static partial class ArrayHelpers {

	extension<T>(Grid<T> grid) {

		/// <summary>
		/// Extracts a subgrid from the grid, starting at the given top-left corner and spanning
		/// the specified number of columns and rows.
		/// </summary>
		/// <param name="topLeftCol">The zero-based column index of the top-left corner.</param>
		/// <param name="topLeftRow">The zero-based row index of the top-left corner.</param>
		/// <param name="noOfCols">The number of columns in the subgrid.</param>
		/// <param name="noOfRows">The number of rows in the subgrid.</param>
		/// <param name="init">The default value to use for positions outside the bounds of the source grid.</param>
		/// <returns>A new grid containing the extracted subgrid.</returns>
		public Grid<T> SubGrid(int topLeftCol, int topLeftRow, int noOfCols, int noOfRows, T init = default!) {
			Grid<T> result = new(noOfCols, noOfRows);
			foreach ((int col, int row) in result.Indexes()) {
				if (grid.TryGetValue(topLeftCol + col, topLeftRow + row, out T value)) {
					result[col, row] = value;
				} else {
					result[col, row] = init;
				}
			}
			return result;
		}

		/// <summary>
		/// Extracts a subgrid from the grid, starting at the given top-left position.
		/// </summary>
		/// <param name="topLeft">A tuple containing the column and row indices of the top-left corner.</param>
		/// <param name="noOfCols">The number of columns to include in the subgrid.</param>
		/// <param name="noOfRows">The number of rows to include in the subgrid.</param>
		/// <param name="init">The default value used to initialize elements outside the bounds of the source grid.</param>
		/// <returns>A new grid containing the extracted subgrid.</returns>
		public Grid<T> SubGrid((int col, int row) topLeft, int noOfCols, int noOfRows, T init = default!) {
			return grid.SubGrid(topLeft.col, topLeft.row, noOfCols, noOfRows, init);
		}

		/// <summary>
		/// Extracts a subgrid from the grid, starting at the given top-left position.
		/// </summary>
		/// <param name="topLeft">The top-left position where the subgrid begins.</param>
		/// <param name="noOfCols">The number of columns to include in the subgrid.</param>
		/// <param name="noOfRows">The number of rows to include in the subgrid.</param>
		/// <param name="init">The default value used to initialize elements outside the bounds of the source grid.</param>
		/// <returns>A new grid containing the extracted subgrid.</returns>
		public Grid<T> SubGrid(Point topLeft, int noOfCols, int noOfRows, T init = default!) {
			return grid.SubGrid(topLeft.X, topLeft.Y, noOfCols, noOfRows, init);
		}

		/// <summary>
		/// Extracts a subgrid defined by the top-left and bottom-right corner coordinates.
		/// </summary>
		/// <param name="topLeft">A tuple containing the column and row indices of the top-left corner.</param>
		/// <param name="bottomRight">A tuple containing the column and row indices of the bottom-right corner.</param>
		/// <param name="init">The default value used to initialize elements if the range exceeds the bounds.</param>
		/// <returns>A new grid containing the elements within the specified range.</returns>
		public Grid<T> SubGrid((int col, int row) topLeft, (int col, int row) bottomRight, T init = default!) {
			return grid.SubGrid(topLeft.col, topLeft.row, bottomRight.col - topLeft.col + 1, bottomRight.row - topLeft.row + 1, init);
		}

		/// <summary>
		/// Extracts a subgrid defined by the top-left and bottom-right corner points.
		/// </summary>
		/// <param name="topLeft">The coordinates of the top-left corner.</param>
		/// <param name="bottomRight">The coordinates of the bottom-right corner.</param>
		/// <param name="init">The default value used to initialize elements if the range exceeds the bounds.</param>
		/// <returns>A new grid containing the elements within the specified range.</returns>
		public Grid<T> SubGrid(Point topLeft, Point bottomRight, T init = default!) {
			return grid.SubGrid(topLeft.X, topLeft.Y, bottomRight.X - topLeft.X + 1, bottomRight.Y - topLeft.Y + 1, init);
		}

	}
}
