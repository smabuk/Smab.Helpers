namespace Smab.Helpers;

public static partial class ArrayHelpers {
	/// <summary>
	/// Creates a Grid from a two-dimensional array.
	/// </summary>
	/// <typeparam name="T">The type of elements in the array.</typeparam>
	/// <param name="array">The two-dimensional array to convert to a Grid.</param>
	/// <returns>A new Grid containing a copy of the array elements.</returns>
	public static Grid<T> ToGrid<T>(T[,] array) {
		Grid<T> grid = new(array.GetLength(0), array.GetLength(1));
		Array.Copy(array, grid.Cells, array.Length);
		return grid;
	}

	/// <summary>
	/// Creates a Grid from a collection of rows.
	/// </summary>
	/// <typeparam name="T">The type of elements in the rows.</typeparam>
	/// <param name="rows">A collection of rows, where each row is a collection of elements.</param>
	/// <returns>A new Grid constructed from the rows.</returns>
	/// <exception cref="ArgumentException">Thrown when rows have inconsistent lengths.</exception>
	public static Grid<T> FromRows<T>(IEnumerable<IEnumerable<T>> rows) {
		T[][] rowList = [.. rows.Select(r => r.ToArray())];
		if (rowList.Length == 0) {
			return new Grid<T>(0, 0);
		}

		int cols = rowList[0].Length;
		int rowCount = rowList.Length;

		// Validate all rows have same length
		for (int i = 1; i < rowCount; i++) {
			if (rowList[i].Length != cols) {
				throw new ArgumentException($"All rows must have the same length. Row 0 has {cols} elements, but row {i} has {rowList[i].Length} elements.");
			}
		}

		Grid<T> grid = new(cols, rowCount);
		for (int row = 0; row < rowCount; row++) {
			for (int col = 0; col < cols; col++) {
				grid[col, row] = rowList[row][col];
			}
		}
		return grid;
	}

	/// <summary>
	/// Creates a Grid from a collection of columns.
	/// </summary>
	/// <typeparam name="T">The type of elements in the columns.</typeparam>
	/// <param name="columns">A collection of columns, where each column is a collection of elements.</param>
	/// <returns>A new Grid constructed from the columns.</returns>
	/// <exception cref="ArgumentException">Thrown when columns have inconsistent lengths.</exception>
	public static Grid<T> FromColumns<T>(IEnumerable<IEnumerable<T>> columns) {
		T[][] colList = [.. columns.Select(c => c.ToArray())];
		if (colList.Length == 0) {
			return new Grid<T>(0, 0);
		}

		int colCount = colList.Length;
		int rows = colList[0].Length;

		// Validate all columns have same length
		for (int i = 1; i < colCount; i++) {
			if (colList[i].Length != rows) {
				throw new ArgumentException($"All columns must have the same length. Column 0 has {rows} elements, but column {i} has {colList[i].Length} elements.");
			}
		}

		Grid<T> grid = new(colCount, rows);
		for (int col = 0; col < colCount; col++) {
			for (int row = 0; row < rows; row++) {
				grid[col, row] = colList[col][row];
			}
		}
		return grid;
	}

	/// <summary>
	/// Creates a Grid with elements initialized using a function.
	/// </summary>
	/// <typeparam name="T">The type of elements in the grid.</typeparam>
	/// <param name="cols">The number of columns in the grid.</param>
	/// <param name="rows">The number of rows in the grid.</param>
	/// <param name="initializer">A function that takes column and row indices and returns the value for that cell.</param>
	/// <returns>A new Grid with elements initialized by the provided function.</returns>
	public static Grid<T> CreateGrid<T>(int cols, int rows, Func<int, int, T> initializer) {
		Grid<T> grid = new(cols, rows);
		for (int col = 0; col < cols; col++) {
			for (int row = 0; row < rows; row++) {
				grid[col, row] = initializer(col, row);
			}
		}
		return grid;
	}
}
