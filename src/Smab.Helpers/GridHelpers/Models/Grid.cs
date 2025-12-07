namespace Smab.Helpers;

/// <summary>
/// Represents a two-dimensional grid of values.
/// </summary>
/// <typeparam name="T">The type of elements stored in the grid.</typeparam>
/// <param name="ColsCount">The number of columns in the grid.</param>
/// <param name="RowsCount">The number of rows in the grid.</param>
[DebuggerDisplay("{DebugDisplay,nq}")]
public record Grid<T>(int ColsCount, int RowsCount) {

	public T[,] Cells { get; internal set; } = new T[ColsCount, RowsCount];

	// Indexer
	/// <summary>
	/// Gets or sets the element at the specified column and row.
	/// </summary>
	/// <param name="col">The zero-based column index.</param>
	/// <param name="row">The zero-based row index.</param>
	/// <returns>The element at the specified position.</returns>
	public T this[int col, int row] {
		get => Cells[col, row];
		set => Cells[col, row] = value;
	}

	// Indexer
	/// <summary>
	/// Gets or sets the value at the specified grid location.
	/// </summary>
	/// <param name="point">The grid coordinates used to access the value. The X and Y properties specify the column and row indices,
	/// respectively.</param>
	/// <returns>The value stored at the given grid location.</returns>
	public T this[Point point] {
		get => Cells[point.X, point.Y];
		set => Cells[point.X, point.Y] = value;
	}

	// Indexer
	/// <summary>
	/// Gets or sets the value at the specified two-dimensional grid coordinates.
	/// </summary>
	/// <param name="point">A tuple containing the X and Y coordinates of the cell to access. Both values must be within the valid range of the
	/// grid.</param>
	/// <returns>The value stored at the cell located at the specified coordinates.</returns>
	public T this[(int X, int Y) point] {
		get => Cells[point.X, point.Y];
		set => Cells[point.X, point.Y] = value;
	}

	// Indexer
	/// <summary>
	/// Gets a sub-grid containing the elements within the specified column and row ranges.
	/// </summary>
	/// <param name="colRange">The range of columns to include.</param>
	/// <param name="rowRange">The range of rows to include.</param>
	/// <returns>A new grid containing the elements within the specified ranges.</returns>
	public Grid<T> this[Range colRange, Range rowRange] {
		get {
			(int colOffset, int colLength) = colRange.GetOffsetAndLength(ColsCount);
			(int rowOffset, int rowLength) = rowRange.GetOffsetAndLength(RowsCount);

			Grid<T> result = new(colLength, rowLength);
			for (int col = 0; col < colLength; col++) {
				for (int row = 0; row < rowLength; row++) {
					result[col, row] = Cells[colOffset + col, rowOffset + row];
				}
			}

			return result;
		}
	}

	// Indexer
	/// <summary>
	/// Gets a sequence of elements from a specific column across a range of rows.
	/// </summary>
	/// <param name="colIndex">The column index to retrieve.</param>
	/// <param name="rowRange">The range of rows to include.</param>
	/// <returns>A sequence of elements from the specified column and row range.</returns>
	public IEnumerable<T> this[Index colIndex, Range rowRange] {
		get {
			int col = colIndex.GetOffset(ColsCount);
			(int rowOffset, int rowLength) = rowRange.GetOffsetAndLength(RowsCount);

			for (int row = 0; row < rowLength; row++) {
				yield return Cells[col, rowOffset + row];
			}
		}
	}

	// Indexer
	/// <summary>
	/// Gets a sequence of elements from a range of columns at a specific row.
	/// </summary>
	/// <param name="colRange">The range of columns to include.</param>
	/// <param name="rowIndex">The row index to retrieve.</param>
	/// <returns>A sequence of elements from the specified column range and row.</returns>
	public IEnumerable<T> this[Range colRange, Index rowIndex] {
		get {
			(int colOffset, int colLength) = colRange.GetOffsetAndLength(ColsCount);
			int row = rowIndex.GetOffset(RowsCount);

			for (int col = 0; col < colLength; col++) {
				yield return Cells[colOffset + col, row];
			}
		}
	}

	// Conversion to underlying array
	/// <summary>
	/// Gets a reference to the underlying two-dimensional array.
	/// </summary>
	/// <remarks>Direct modifications to the returned array will affect the grid.</remarks>
	/// <returns>The underlying two-dimensional array.</returns>
	public T[,] ToArray() => Cells;

	private string DebugDisplay => $$"""{{nameof(Grid<>)}} [{{ColsCount}}, {{RowsCount}}]""";
}
