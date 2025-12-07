namespace Smab.Helpers;

public static partial class ArrayHelpers {
	extension<T>(Grid<T> grid) {
		/// <summary>
		/// Returns the top edge of the grid (first row).
		/// </summary>
		/// <returns>An enumerable collection of elements in the top row of the grid.</returns>
		public IEnumerable<T> TopEdge() => grid.Row(0);

		/// <summary>
		/// Returns the bottom edge of the grid (last row).
		/// </summary>
		/// <returns>An enumerable collection of elements in the bottom row of the grid.</returns>
		public IEnumerable<T> BottomEdge() => grid.Row(grid.RowsMax);

		/// <summary>
		/// Returns the left edge of the grid (first column).
		/// </summary>
		/// <returns>An enumerable collection of elements in the leftmost column of the grid.</returns>
		public IEnumerable<T> LeftEdge() => grid.Col(0);

		/// <summary>
		/// Returns the right edge of the grid (last column).
		/// </summary>
		/// <returns>An enumerable collection of elements in the rightmost column of the grid.</returns>
		public IEnumerable<T> RightEdge() => grid.Col(grid.ColsMax);

		/// <summary>
		/// Returns all edge elements of the grid in clockwise order starting from the top-left corner.
		/// </summary>
		/// <remarks>The elements are returned in the following order: top edge (left to right), 
		/// right edge (top to bottom, excluding corners), bottom edge (right to left, excluding right corner), 
		/// and left edge (bottom to top, excluding both corners).</remarks>
		/// <returns>An enumerable collection of all edge elements in clockwise order.</returns>
		public IEnumerable<T> Edges() {
			if (grid.ColsCount == 0 || grid.RowsCount == 0) {
				yield break;
			}

			// Top edge (left to right)
			foreach (T value in grid.TopEdge()) {
				yield return value;
			}

			// Right edge (top to bottom, skip first which is already included)
			foreach (T value in grid.RightEdge().Skip(1)) {
				yield return value;
			}

			// If more than one row, add bottom and left edges
			if (grid.RowsCount > 1) {
				// Bottom edge (right to left, skip last which is already included)
				foreach (T value in grid.BottomEdge().Reverse().Skip(1)) {
					yield return value;
				}

				// If more than one column, add left edge
				if (grid.ColsCount > 1) {
					// Left edge (bottom to top, skip both corners)
					foreach (T value in grid.LeftEdge().Reverse().Skip(1).Take(grid.RowsCount - 2)) {
						yield return value;
					}
				}
			}
		}

		/// <summary>
		/// Gets the value at the top-left corner of the grid.
		/// </summary>
		/// <returns>The element at position (0, 0).</returns>
		public T TopLeft() => grid[0, 0];

		/// <summary>
		/// Gets the value at the top-right corner of the grid.
		/// </summary>
		/// <returns>The element at position (ColsMax, 0).</returns>
		public T TopRight() => grid[grid.ColsMax, 0];

		/// <summary>
		/// Gets the value at the bottom-left corner of the grid.
		/// </summary>
		/// <returns>The element at position (0, RowsMax).</returns>
		public T BottomLeft() => grid[0, grid.RowsMax];

		/// <summary>
		/// Gets the value at the bottom-right corner of the grid.
		/// </summary>
		/// <returns>The element at position (ColsMax, RowsMax).</returns>
		public T BottomRight() => grid[grid.ColsMax, grid.RowsMax];

		/// <summary>
		/// Returns all four corner values of the grid.
		/// </summary>
		/// <returns>An enumerable containing the four corner values in clockwise order: TopLeft, TopRight, BottomRight, BottomLeft.</returns>
		public IEnumerable<T> Corners() {
			yield return grid.TopLeft();
			yield return grid.TopRight();
			yield return grid.BottomRight();
			yield return grid.BottomLeft();
		}

		/// <summary>
		/// Returns the top edge cells of the grid (first row) with their coordinates.
		/// </summary>
		/// <returns>An enumerable collection of cells in the top row of the grid.</returns>
		public IEnumerable<Cell<T>> TopEdgeCells() => grid.RowCells(0);

		/// <summary>
		/// Returns the bottom edge cells of the grid (last row) with their coordinates.
		/// </summary>
		/// <returns>An enumerable collection of cells in the bottom row of the grid.</returns>
		public IEnumerable<Cell<T>> BottomEdgeCells() => grid.RowCells(grid.RowsMax);

		/// <summary>
		/// Returns the left edge cells of the grid (first column) with their coordinates.
		/// </summary>
		/// <returns>An enumerable collection of cells in the leftmost column of the grid.</returns>
		public IEnumerable<Cell<T>> LeftEdgeCells() => grid.ColCells(0);

		/// <summary>
		/// Returns the right edge cells of the grid (last column) with their coordinates.
		/// </summary>
		/// <returns>An enumerable collection of cells in the rightmost column of the grid.</returns>
		public IEnumerable<Cell<T>> RightEdgeCells() => grid.ColCells(grid.ColsMax);

		/// <summary>
		/// Returns all edge cells of the grid in clockwise order starting from the top-left corner.
		/// </summary>
		/// <remarks>The cells are returned in the following order: top edge (left to right), 
		/// right edge (top to bottom, excluding corners), bottom edge (right to left, excluding right corner), 
		/// and left edge (bottom to top, excluding both corners).</remarks>
		/// <returns>An enumerable collection of all edge cells with their coordinates in clockwise order.</returns>
		public IEnumerable<Cell<T>> EdgeCells() {
			if (grid.ColsCount == 0 || grid.RowsCount == 0) {
				yield break;
			}

			// Top edge (left to right)
			foreach (Cell<T> cell in grid.TopEdgeCells()) {
				yield return cell;
			}

			// Right edge (top to bottom, skip first which is already included)
			foreach (Cell<T> cell in grid.RightEdgeCells().Skip(1)) {
				yield return cell;
			}

			// If more than one row, add bottom and left edges
			if (grid.RowsCount > 1) {
				// Bottom edge (right to left, skip last which is already included)
				foreach (Cell<T> cell in grid.BottomEdgeCells().Reverse().Skip(1)) {
					yield return cell;
				}

				// If more than one column, add left edge
				if (grid.ColsCount > 1) {
					// Left edge (bottom to top, skip both corners)
					foreach (Cell<T> cell in grid.LeftEdgeCells().Reverse().Skip(1).Take(grid.RowsCount - 2)) {
						yield return cell;
					}
				}
			}
		}

		/// <summary>
		/// Returns all four corner cells of the grid with their coordinates.
		/// </summary>
		/// <returns>An enumerable containing the four corner cells in clockwise order: TopLeft, TopRight, BottomRight, BottomLeft.</returns>
		public IEnumerable<Cell<T>> GetCornerCells() {
			yield return new Cell<T>(0, 0, grid.TopLeft());
			yield return new Cell<T>(grid.ColsMax, 0, grid.TopRight());
			yield return new Cell<T>(grid.ColsMax, grid.RowsMax, grid.BottomRight());
			yield return new Cell<T>(0, grid.RowsMax, grid.BottomLeft());
		}
	}

	extension<T>(T[,] array) {
		/// <summary>
		/// Returns the top edge of the array (first row).
		/// </summary>
		/// <returns>An enumerable collection of elements in the top row of the array.</returns>
		public IEnumerable<T> TopEdge() => array.Row(0);

		/// <summary>
		/// Returns the bottom edge of the array (last row).
		/// </summary>
		/// <returns>An enumerable collection of elements in the bottom row of the array.</returns>
		public IEnumerable<T> BottomEdge() => array.Row(array.RowsMax());

		/// <summary>
		/// Returns the left edge of the array (first column).
		/// </summary>
		/// <returns>An enumerable collection of elements in the leftmost column of the array.</returns>
		public IEnumerable<T> LeftEdge() => array.Col(0);

		/// <summary>
		/// Returns the right edge of the array (last column).
		/// </summary>
		/// <returns>An enumerable collection of elements in the rightmost column of the array.</returns>
		public IEnumerable<T> RightEdge() => array.Col(array.ColsMax());

		/// <summary>
		/// Returns all edge elements of the array in clockwise order starting from the top-left corner.
		/// </summary>
		/// <returns>An enumerable collection of all edge elements in clockwise order.</returns>
		public IEnumerable<T> Edges() {
			int cols = array.GetLength(0);
			int rows = array.GetLength(1);

			if (cols == 0 || rows == 0) {
				yield break;
			}

			// Top edge (left to right)
			foreach (T value in array.TopEdge()) {
				yield return value;
			}

			// Right edge (top to bottom, skip first)
			foreach (T value in array.RightEdge().Skip(1)) {
				yield return value;
			}

			// If more than one row, add bottom and left edges
			if (rows > 1) {
				// Bottom edge (right to left, skip last)
				foreach (T value in array.BottomEdge().Reverse().Skip(1)) {
					yield return value;
				}

				// If more than one column, add left edge
				if (cols > 1) {
					// Left edge (bottom to top, skip both corners)
					foreach (T value in array.LeftEdge().Reverse().Skip(1).Take(rows - 2)) {
						yield return value;
					}
				}
			}
		}

		/// <summary>
		/// Gets the value at the top-left corner of the array.
		/// </summary>
		/// <returns>The element at position (0, 0).</returns>
		public T TopLeft() => array[0, 0];

		/// <summary>
		/// Gets the value at the top-right corner of the array.
		/// </summary>
		/// <returns>The element at position (ColsMax, 0).</returns>
		public T TopRight() => array[array.ColsMax(), 0];

		/// <summary>
		/// Gets the value at the bottom-left corner of the array.
		/// </summary>
		/// <returns>The element at position (0, RowsMax).</returns>
		public T BottomLeft() => array[0, array.RowsMax()];

		/// <summary>
		/// Gets the value at the bottom-right corner of the array.
		/// </summary>
		/// <returns>The element at position (ColsMax, RowsMax).</returns>
		public T BottomRight() => array[array.ColsMax(), array.RowsMax()];

		/// <summary>
		/// Returns all four corner values of the array.
		/// </summary>
		/// <returns>An enumerable containing the four corner values in clockwise order: TopLeft, TopRight, BottomRight, BottomLeft.</returns>
		public IEnumerable<T> Corners() {
			yield return array.TopLeft();
			yield return array.TopRight();
			yield return array.BottomRight();
			yield return array.BottomLeft();
		}

		/// <summary>
		/// Returns the top edge cells of the array (first row) with their coordinates.
		/// </summary>
		/// <returns>An enumerable collection of cells in the top row of the array.</returns>
		public IEnumerable<Cell<T>> TopEdgeCells() => array.RowCells(0);

		/// <summary>
		/// Returns the bottom edge cells of the array (last row) with their coordinates.
		/// </summary>
		/// <returns>An enumerable collection of cells in the bottom row of the array.</returns>
		public IEnumerable<Cell<T>> BottomEdgeCells() => array.RowCells(array.RowsMax());

		/// <summary>
		/// Returns the left edge cells of the array (first column) with their coordinates.
		/// </summary>
		/// <returns>An enumerable collection of cells in the leftmost column of the array.</returns>
		public IEnumerable<Cell<T>> LeftEdgeCells() => array.ColCells(0);

		/// <summary>
		/// Returns the right edge cells of the array (last column) with their coordinates.
		/// </summary>
		/// <returns>An enumerable collection of cells in the rightmost column of the array.</returns>
		public IEnumerable<Cell<T>> RightEdgeCells() => array.ColCells(array.ColsMax());

		/// <summary>
		/// Returns all edge cells of the array in clockwise order starting from the top-left corner.
		/// </summary>
		/// <returns>An enumerable collection of all edge cells with their coordinates in clockwise order.</returns>
		public IEnumerable<Cell<T>> EdgeCells() {
			int cols = array.GetLength(0);
			int rows = array.GetLength(1);

			if (cols == 0 || rows == 0) {
				yield break;
			}

			// Top edge (left to right)
			foreach (Cell<T> cell in array.TopEdgeCells()) {
				yield return cell;
			}

			// Right edge (top to bottom, skip first)
			foreach (Cell<T> cell in array.RightEdgeCells().Skip(1)) {
				yield return cell;
			}

			// If more than one row, add bottom and left edges
			if (rows > 1) {
				// Bottom edge (right to left, skip last)
				foreach (Cell<T> cell in array.BottomEdgeCells().Reverse().Skip(1)) {
					yield return cell;
				}

				// If more than one column, add left edge
				if (cols > 1) {
					// Left edge (bottom to top, skip both corners)
					foreach (Cell<T> cell in array.LeftEdgeCells().Reverse().Skip(1).Take(rows - 2)) {
						yield return cell;
					}
				}
			}
		}

		/// <summary>
		/// Returns all four corner cells of the array with their coordinates.
		/// </summary>
		/// <returns>An enumerable containing the four corner cells in clockwise order: TopLeft, TopRight, BottomRight, BottomLeft.</returns>
		public IEnumerable<Cell<T>> GetCornerCells() {
			yield return new Cell<T>(0, 0, array.TopLeft());
			yield return new Cell<T>(array.ColsMax(), 0, array.TopRight());
			yield return new Cell<T>(array.ColsMax(), array.RowsMax(), array.BottomRight());
			yield return new Cell<T>(0, array.RowsMax(), array.BottomLeft());
		}
	}
}

