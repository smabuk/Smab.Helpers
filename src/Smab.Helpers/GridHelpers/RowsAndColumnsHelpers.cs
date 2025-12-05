namespace Smab.Helpers;

public static partial class ArrayHelpers {

	extension<T>(Grid<T> grid) {
		/// <summary>
		/// Gets the minimum column index (always 0).
		/// </summary>
		public int ColsMin => 0;

		/// <summary>
		/// Gets the minimum row index (always 0).
		/// </summary>
		public int RowsMin => 0;

		/// <summary>
		/// Gets the maximum column index.
		/// </summary>
		public int ColsMax => grid.ColsCount - 1;

		/// <summary>
		/// Gets the maximum row index.
		/// </summary>
		public int RowsMax => grid.RowsCount - 1;

		/// <summary>
		/// Gets the minimum X index (always 0).
		/// </summary>
		public int XMin => 0;

		/// <summary>
		/// Gets the minimum Y index (always 0).
		/// </summary>
		public int YMin => 0;

		/// <summary>
		/// Gets the maximum X index.
		/// </summary>
		public int XMax => grid.ColsCount - 1;

		/// <summary>
		/// Gets the maximum Y index.
		/// </summary>
		public int YMax => grid.RowsCount - 1;

		// Bounds checking
		/// <summary>
		/// Determines whether the specified column and row indices are within the bounds of the grid.
		/// </summary>
		/// <param name="col">The column index to check.</param>
		/// <param name="row">The row index to check.</param>
		/// <returns>true if the indices are within bounds; otherwise, false.</returns>
		public bool IsInBounds(int col, int row)
			=> col >= 0 && col < grid.ColsCount && row >= 0 && row < grid.RowsCount;

		/// <summary>
		/// Determines whether the specified point is within the bounds of the grid.
		/// </summary>
		/// <param name="point">A tuple representing the coordinates to check.</param>
		/// <returns>true if the point is within bounds; otherwise, false.</returns>
		public bool IsInBounds((int col, int row) point)
			=> point.col >= 0 && point.col < grid.ColsCount && point.row >= 0 && point.row < grid.RowsCount;

		/// <summary>
		/// Determines whether the specified column and row indices are out of bounds.
		/// </summary>
		/// <param name="col">The column index to check.</param>
		/// <param name="row">The row index to check.</param>
		/// <returns>true if the indices are out of bounds; otherwise, false.</returns>
		public bool IsOutOfBounds(int col, int row) => !grid.IsInBounds(col, row);

		/// <summary>
		/// Determines whether the specified point is outside the bounds of the grid.
		/// </summary>
		/// <param name="point">A tuple representing the coordinates to check.</param>
		/// <returns>true if the point is out of bounds; otherwise, false.</returns>
		public bool IsOutOfBounds((int col, int row) point) => !grid.IsInBounds(point);

		// Index enumeration
		/// <summary>
		/// Enumerates the column indexes of the grid.
		/// </summary>
		/// <returns>An enumerable collection of column indexes.</returns>
		public IEnumerable<int> ColIndexes() {
			for (int col = 0; col < grid.ColsCount; col++) {
				yield return col;
			}
		}

		/// <summary>
		/// Enumerates the row indexes of the grid.
		/// </summary>
		/// <returns>An enumerable collection of row indexes.</returns>
		public IEnumerable<int> RowIndexes() {
			for (int row = 0; row < grid.RowsCount; row++) {
				yield return row;
			}
		}

		/// <summary>
		/// Retrieves the X values (column indexes) of the grid.
		/// </summary>
		/// <returns>An enumerable collection of X values.</returns>
		public IEnumerable<int> XValues() => grid.ColIndexes();

		/// <summary>
		/// Enumerates the Y values (row indexes) of the grid.
		/// </summary>
		/// <returns>An enumerable collection of Y values.</returns>
		public IEnumerable<int> YValues() => grid.RowIndexes();

		/// <summary>
		/// Enumerates the indexes of the grid as tuples of X and Y coordinates.
		/// </summary>
		/// <returns>An enumerable collection of tuples, where each tuple contains the X and Y indices.</returns>
		public IEnumerable<(int X, int Y)> Indexes() {
			foreach (int y in grid.RowIndexes()) {
				foreach (int x in grid.ColIndexes()) {
					yield return new(x, y);
				}
			}
		}

		/// <summary>
		/// Enumerates the column and row indexes of the grid.
		/// </summary>
		/// <returns>An enumerable collection of tuples, where each tuple contains the column and row indices.</returns>
		public IEnumerable<(int Col, int Row)> IndexesColRow() {
			foreach (int row in grid.RowIndexes()) {
				foreach (int col in grid.ColIndexes()) {
					yield return new(col, row);
				}
			}
		}

	}

	extension<T>(T[,] array) {
		/// <summary>
		/// Gets the number of columns in the specified two-dimensional array.
		/// </summary>
		/// <typeparam name="T">The type of elements in the array.</typeparam>
		/// <param name="array">The two-dimensional array to retrieve the column count from.</param>
		/// <returns>The number of columns in the specified array.</returns>
		public int ColsCount() => array.GetLength(COL_DIMENSION);
		/// <summary>
		/// Gets the number of rows in a two-dimensional array.
		/// </summary>
		/// <typeparam name="T">The type of elements in the array.</typeparam>
		/// <param name="array">The two-dimensional array to retrieve the row count from. Cannot be <see langword="null"/>.</param>
		/// <returns>The number of rows in the specified array.</returns>
		public int RowsCount() => array.GetLength(ROW_DIMENSION);

		/// <summary>
		/// Gets the lower bound of the column dimension in a two-dimensional array.
		/// </summary>
		/// <typeparam name="T">The type of elements in the array.</typeparam>
		/// <param name="array">The two-dimensional array to retrieve the column lower bound from. Cannot be <see langword="null"/>.</param>
		/// <returns>The lower bound of the column dimension in the specified array.</returns>
		public int ColsMin() => array.GetLowerBound(COL_DIMENSION);
		/// <summary>
		/// Gets the lower bound of the row dimension in a two-dimensional array.
		/// </summary>
		/// <typeparam name="T">The type of elements in the array.</typeparam>
		/// <param name="array">The two-dimensional array to retrieve the lower bound from. Cannot be <see langword="null"/>.</param>
		/// <returns>The lower bound of the row dimension in the specified array.</returns>
		public int RowsMin() => array.GetLowerBound(ROW_DIMENSION);

		/// <summary>
		/// Gets the maximum valid index for the columns in a two-dimensional array.
		/// </summary>
		/// <typeparam name="T">The type of elements in the array.</typeparam>
		/// <param name="array">The two-dimensional array to evaluate. Cannot be <see langword="null"/>.</param>
		/// <returns>The zero-based maximum index for the columns in the specified array.</returns>
		public int ColsMax() => array.GetUpperBound(COL_DIMENSION);
		/// <summary>
		/// Returns the maximum valid index for the rows in the specified two-dimensional array.
		/// </summary>
		/// <typeparam name="T">The type of elements in the array.</typeparam>
		/// <param name="array">The two-dimensional array to retrieve the maximum row index from. Must not be null.</param>
		/// <returns>The zero-based maximum index for the rows in the array.</returns>
		public int RowsMax() => array.GetUpperBound(ROW_DIMENSION);

		/// <summary>
		/// Gets the minimum valid index for the X dimension of a two-dimensional array.
		/// </summary>
		/// <typeparam name="T">The type of elements in the array.</typeparam>
		/// <param name="array">The two-dimensional array to retrieve the minimum X index from.</param>
		/// <returns>The minimum valid index for the X dimension of the specified array.</returns>
		public int XMin() => array.GetLowerBound(COL_DIMENSION);
		/// <summary>
		/// Gets the minimum valid index for the Y dimension of a two-dimensional array.
		/// </summary>
		/// <typeparam name="T">The type of elements in the array.</typeparam>
		/// <param name="array">The two-dimensional array to retrieve the minimum Y index from.</param>
		/// <returns>The minimum valid index for the Y dimension of the specified array.</returns>
		public int YMin() => array.GetLowerBound(ROW_DIMENSION);
		/// <summary>
		/// Returns the maximum valid index for the second dimension (X) of a two-dimensional array.
		/// </summary>
		/// <remarks>This method uses the <see cref="Array.GetUpperBound(int)"/> method with a dimension index of 1 to
		/// determine the maximum X index.</remarks>
		/// <typeparam name="T">The type of elements in the array.</typeparam>
		/// <param name="array">The two-dimensional array to retrieve the maximum X index from. Must not be <see langword="null"/>.</param>
		/// <returns>The zero-based maximum index for the second dimension (X) of the array.</returns>
		public int XMax() => array.GetUpperBound(COL_DIMENSION);
		/// <summary>
		/// Gets the maximum valid index for the second dimension (Y) of a two-dimensional array.
		/// </summary>
		/// <typeparam name="T">The type of elements in the array.</typeparam>
		/// <param name="array">The two-dimensional array to retrieve the maximum Y index from. Cannot be <see langword="null"/>.</param>
		/// <returns>The maximum valid index for the second dimension (Y) of the array.</returns>
		public int YMax() => array.GetUpperBound(ROW_DIMENSION);

		/// <summary>
		/// Returns an enumerable collection of column indexes for the specified two-dimensional array.
		/// </summary>
		/// <remarks>The method iterates over the column dimension of the array, yielding each column index in
		/// sequence.</remarks>
		/// <typeparam name="T">The type of elements in the two-dimensional array.</typeparam>
		/// <param name="array">The two-dimensional array for which to retrieve column indexes. Cannot be <see langword="null"/>.</param>
		/// <returns>An <see cref="IEnumerable{T}"/> containing the column indexes of the array, starting from the lower bound to the
		/// upper bound of the column dimension.</returns>
		public IEnumerable<int> ColIndexes() {
			int min = array.GetLowerBound(COL_DIMENSION);
			int max = array.GetUpperBound(COL_DIMENSION);

			for (int col = min; col <= max; col++) {
				yield return col;
			}
		}
		/// <summary>
		/// Enumerates the row indexes of a two-dimensional array.
		/// </summary>
		/// <remarks>The method iterates over the row dimension of the array, yielding each index in the range defined
		/// by the array's lower and upper bounds.</remarks>
		/// <typeparam name="T">The type of elements in the array.</typeparam>
		/// <param name="array">The two-dimensional array whose row indexes are to be enumerated. Cannot be <see langword="null"/>.</param>
		/// <returns>An <see cref="IEnumerable{T}"/> containing the row indexes of the specified array.</returns>
		public IEnumerable<int> RowIndexes() {
			int min = array.GetLowerBound(ROW_DIMENSION);
			int max = array.GetUpperBound(ROW_DIMENSION);

			for (int col = min; col <= max; col++) {
				yield return col;
			}
		}

		/// <summary>
		/// Retrieves the collection of X indices for the specified two-dimensional array.
		/// </summary>
		/// <typeparam name="T">The type of elements in the two-dimensional array.</typeparam>
		/// <param name="array">The two-dimensional array from which to retrieve X indices. Must not be null.</param>
		/// <returns>An <see cref="IEnumerable{T}"/> of integers representing the X indices of the array.</returns>
		public IEnumerable<int> XValues() => array.ColIndexes();
		/// <summary>
		/// Enumerates the Y indexes of a two-dimensional array.
		/// </summary>
		/// <typeparam name="T">The type of elements in the array.</typeparam>
		/// <param name="array">The two-dimensional array to process. Cannot be <see langword="null"/>.</param>
		/// <returns>An enumerable collection of integers representing the Y indexes of the array.</returns>
		public IEnumerable<int> YValues() => array.RowIndexes();


		/// <summary>
		/// Determines whether the specified column and row indices are within the bounds of the given two-dimensional array.
		/// </summary>
		/// <typeparam name="T">The type of elements in the array.</typeparam>
		/// <param name="array">The two-dimensional array to check.</param>
		/// <param name="col">The zero-based column index to check.</param>
		/// <param name="row">The zero-based row index to check.</param>
		/// <returns><see langword="true"/> if the specified column and row indices are within the bounds of the array;  otherwise, <see
		/// langword="false"/>.</returns>
		public bool IsInBounds(int col, int row)
			=> (col >= array.GetLowerBound(COL_DIMENSION) && col <= array.GetUpperBound(COL_DIMENSION))
			&& (row >= array.GetLowerBound(ROW_DIMENSION) && row <= array.GetUpperBound(ROW_DIMENSION));

		/// <summary>
		/// Determines whether the specified point is within the bounds of the given two-dimensional array.
		/// </summary>
		/// <typeparam name="T">The type of elements in the array.</typeparam>
		/// <param name="array">The two-dimensional array to check.</param>
		/// <param name="point">A tuple representing the column and row indices of the point to check. The first item is the column index, and the
		/// second item is the row index.</param>
		/// <returns><see langword="true"/> if the specified point is within the bounds of the array;  otherwise, <see
		/// langword="false"/>.</returns>
		public bool IsInBounds((int col, int row) point)
			=> (point.col >= array.GetLowerBound(COL_DIMENSION) && point.col <= array.GetUpperBound(COL_DIMENSION))
			&& (point.row >= array.GetLowerBound(ROW_DIMENSION) && point.row <= array.GetUpperBound(ROW_DIMENSION));

		/// <summary>
		/// Determines whether the specified column and row indices are out of bounds for the given two-dimensional array.
		/// </summary>
		/// <typeparam name="T">The type of elements in the array.</typeparam>
		/// <param name="array">The two-dimensional array to check.</param>
		/// <param name="col">The column index to check.</param>
		/// <param name="row">The row index to check.</param>
		/// <returns><see langword="true"/> if the specified indices are out of bounds for the array; otherwise, <see
		/// langword="false"/>.</returns>
		public bool IsOutOfBounds(int col, int row)
			=> !array.IsInBounds(col, row);

		/// <summary>
		/// Determines whether the specified point is outside the bounds of the two-dimensional array.
		/// </summary>
		/// <typeparam name="T">The type of elements in the array.</typeparam>
		/// <param name="array">The two-dimensional array to check.</param>
		/// <param name="point">A tuple representing the column and row indices to check.</param>
		/// <returns><see langword="true"/> if the specified point is outside the bounds of the array;  otherwise, <see
		/// langword="false"/>.</returns>
		public bool IsOutOfBounds((int col, int row) point) {
			return !array.IsInBounds(point);
		}
	}

	extension<T>(T[,,] array) {
		/// <summary>
		/// Determines whether the specified coordinates are within the bounds of the given three-dimensional array.
		/// </summary>
		/// <typeparam name="T">The type of elements in the array.</typeparam>
		/// <param name="array">The three-dimensional array to check.</param>
		/// <param name="x">The x-coordinate to check, corresponding to the first dimension of the array.</param>
		/// <param name="y">The y-coordinate to check, corresponding to the second dimension of the array.</param>
		/// <param name="z">The z-coordinate to check, corresponding to the third dimension of the array.</param>
		/// <returns><see langword="true"/> if the specified coordinates are within the bounds of the array;  otherwise, <see
		/// langword="false"/>.</returns>
		public bool IsInBounds(int x, int y, int z)
			=> (x >= array.GetLowerBound(0) && x <= array.GetUpperBound(0))
			&& (y >= array.GetLowerBound(1) && y <= array.GetUpperBound(1))
			&& (z >= array.GetLowerBound(1) && z <= array.GetUpperBound(2));

		/// <summary>
		/// Determines whether the specified point is within the bounds of the given three-dimensional array.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="array">The three-dimensional array to check.</param>
		/// <param name="point">A tuple representing the coordinates of the point to check, where <c>x</c>, <c>y</c>, and <c>z</c> correspond to
		/// the indices along the first, second, and third dimensions of the array, respectively.</param>
		/// <returns><see langword="true"/> if the specified point is within the bounds of the array; otherwise, <see
		/// langword="false"/>.</returns>
		public bool IsInBounds((int x, int y, int z) point)
			=> (point.x >= array.GetLowerBound(0) && point.x <= array.GetUpperBound(0))
			&& (point.y >= array.GetLowerBound(1) && point.y <= array.GetUpperBound(1))
			&& (point.z >= array.GetLowerBound(2) && point.y <= array.GetUpperBound(2));

		/// <summary>
		/// Determines whether the specified indices are out of bounds for the given three-dimensional array.
		/// </summary>
		/// <typeparam name="T">The type of elements in the array.</typeparam>
		/// <param name="array">The three-dimensional array to check.</param>
		/// <param name="x">The index along the first dimension.</param>
		/// <param name="y">The index along the second dimension.</param>
		/// <param name="z">The index along the third dimension.</param>
		/// <returns><see langword="true"/> if the specified indices are out of bounds for the array; otherwise, <see
		/// langword="false"/>.</returns>
		public bool IsOutOfBounds(int x, int y, int z)
			=> !array.IsInBounds(x, y, z);

		/// <summary>
		/// Determines whether the specified point is outside the bounds of the given three-dimensional array.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="array">The three-dimensional array to check.</param>
		/// <param name="point">A tuple representing the coordinates (<see langword="x"/>, <see langword="y"/>, <see langword="z"/>) of the point
		/// to evaluate.</param>
		/// <returns><see langword="true"/> if the specified point is outside the bounds of the array; otherwise, <see
		/// langword="false"/>.</returns>
		public bool IsOutOfBounds((int x, int y, int z) point) {
			return !array.IsInBounds(point);
		}
	}
}