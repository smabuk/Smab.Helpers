namespace Smab.Helpers;

/// <summary>
/// Represents a two-dimensional grid of values.
/// </summary>
/// <typeparam name="T">The type of elements stored in the grid.</typeparam>
/// <param name="ColsCount">The number of columns in the grid.</param>
/// <param name="RowsCount">The number of rows in the grid.</param>
[DebuggerDisplay("{DebugDisplay,nq}")]
public record Grid<T>(int ColsCount, int RowsCount) : IEnumerable<T> {

	internal T[,] InternalCells { get; set; } = new T[ColsCount, RowsCount];

	public IEnumerator<T> GetEnumerator() {
		foreach (T value in InternalCells) {
			yield return value;
		}
	}

	// Add Height and Width properties for compatibility
	public int Height => RowsCount;
	public int Width => ColsCount;

	System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() => GetEnumerator();

	// Indexer
	/// <summary>
	/// Gets or sets the element at the specified column and row.
	/// </summary>
	/// <param name="col">The zero-based column index.</param>
	/// <param name="row">The zero-based row index.</param>
	/// <returns>The element at the specified position.</returns>
	public T this[int col, int row] {
		get => InternalCells[col, row];
		set => InternalCells[col, row] = value;
	}

	// Indexer
	/// <summary>
	/// Gets or sets the element at the specified column and row using Index values.
	/// </summary>
	/// <param name="colIndex">The column index (supports index from end using ^).</param>
	/// <param name="rowIndex">The row index (supports index from end using ^).</param>
	/// <returns>The element at the specified position.</returns>
	public T this[Index colIndex, Index rowIndex] {
		get => InternalCells[colIndex.GetOffset(ColsCount), rowIndex.GetOffset(RowsCount)];
		set => InternalCells[colIndex.GetOffset(ColsCount), rowIndex.GetOffset(RowsCount)] = value;
	}

	// Indexer
	/// <summary>
	/// Gets or sets the element at the specified column and row.
	/// </summary>
	/// <param name="col">The zero-based column index.</param>
	/// <param name="rowIndex">The row index (supports index from end using ^).</param>
	/// <returns>The element at the specified position.</returns>
	public T this[int col, Index rowIndex] {
		get => InternalCells[col, rowIndex.GetOffset(RowsCount)];
		set => InternalCells[col, rowIndex.GetOffset(RowsCount)] = value;
	}

	// Indexer
	/// <summary>
	/// Gets or sets the element at the specified column and row.
	/// </summary>
	/// <param name="colIndex">The column index (supports index from end using ^).</param>
	/// <param name="row">The zero-based row index.</param>
	/// <returns>The element at the specified position.</returns>
	public T this[Index colIndex, int row] {
		get => InternalCells[colIndex.GetOffset(ColsCount), row];
		set => InternalCells[colIndex.GetOffset(ColsCount), row] = value;
	}

	// Indexer
	/// <summary>
	/// Gets or sets the value at the specified grid location.
	/// </summary>
	/// <param name="point">The grid coordinates used to access the value. The X and Y properties specify the column and row indices,
	/// respectively.</param>
	/// <returns>The value stored at the given grid location.</returns>
	public T this[Point point] {
		get => InternalCells[point.X, point.Y];
		set => InternalCells[point.X, point.Y] = value;
	}

	// Indexer
	/// <summary>
	/// Gets or sets the value at the specified two-dimensional grid coordinates.
	/// </summary>
	/// <param name="point">A tuple containing the X and Y coordinates of the cell to access. Both values must be within the valid range of the
	/// grid.</param>
	/// <returns>The value stored at the cell located at the specified coordinates.</returns>
	public T this[(int X, int Y) point] {
		get => InternalCells[point.X, point.Y];
		set => InternalCells[point.X, point.Y] = value;
	}

	// Indexer
	/// <summary>
	/// Gets or sets a sub-grid containing the elements within the specified column and row ranges.
	/// </summary>
	/// <param name="colRange">The range of columns to include.</param>
	/// <param name="rowRange">The range of rows to include.</param>
	/// <returns>A new grid containing the elements within the specified ranges.</returns>
	/// <remarks>
	/// When setting, the value can be either a Grid with matching dimensions or will fill all cells with the first cell value.
	/// </remarks>
	public Grid<T> this[Range colRange, Range rowRange] {
		get {
			(int colOffset, int colLength) = colRange.GetOffsetAndLength(ColsCount);
			(int rowOffset, int rowLength) = rowRange.GetOffsetAndLength(RowsCount);

			Grid<T> result = new(colLength, rowLength);
			for (int col = 0; col < colLength; col++) {
				for (int row = 0; row < rowLength; row++) {
					result[col, row] = InternalCells[colOffset + col, rowOffset + row];
				}
			}

			return result;
		}
		set {
			(int colOffset, int colLength) = colRange.GetOffsetAndLength(ColsCount);
			(int rowOffset, int rowLength) = rowRange.GetOffsetAndLength(RowsCount);

			if (value.ColsCount == colLength && value.RowsCount == rowLength) {
				for (int col = 0; col < colLength; col++) {
					for (int row = 0; row < rowLength; row++) {
						InternalCells[colOffset + col, rowOffset + row] = value[col, row];
					}
				}
			} else if (value.ColsCount == 1 && value.RowsCount == 1) {
				T fillValue = value[0, 0];
				for (int col = 0; col < colLength; col++) {
					for (int row = 0; row < rowLength; row++) {
						InternalCells[colOffset + col, rowOffset + row] = fillValue;
					}
				}
			} else {
				throw new ArgumentException($"Grid dimensions must match the target range ({colLength}x{rowLength}) or be 1x1 for filling.");
			}
		}
	}

	// Indexer
	/// <summary>
	/// Gets or sets a sequence of elements from a specific column across a range of rows.
	/// </summary>
	/// <param name="colIndex">The column index to retrieve.</param>
	/// <param name="rowRange">The range of rows to include.</param>
	/// <returns>A sequence of elements from the specified column and row range.</returns>
	/// <remarks>
	/// When setting, provide an IEnumerable with matching count or a single-element collection to fill all cells.
	/// </remarks>
	public IEnumerable<T> this[Index colIndex, Range rowRange] {
		get {
			int col = colIndex.GetOffset(ColsCount);
			(int rowOffset, int rowLength) = rowRange.GetOffsetAndLength(RowsCount);

			for (int row = 0; row < rowLength; row++) {
				yield return InternalCells[col, rowOffset + row];
			}
		}
		set {
			int col = colIndex.GetOffset(ColsCount);
			(int rowOffset, int rowLength) = rowRange.GetOffsetAndLength(RowsCount);

			T[] values = [.. value];
			if (values.Length == rowLength) {
				for (int row = 0; row < rowLength; row++) {
					InternalCells[col, rowOffset + row] = values[row];
				}
			} else if (values.Length == 1) {
				T fillValue = values[0];
				for (int row = 0; row < rowLength; row++) {
					InternalCells[col, rowOffset + row] = fillValue;
				}
			} else {
				throw new ArgumentException($"Collection count must match the target range length ({rowLength}) or be 1 for filling.");
			}
		}
	}

	// Indexer
	/// <summary>
	/// Gets or sets a sequence of elements from a range of columns at a specific row.
	/// </summary>
	/// <param name="colRange">The range of columns to include.</param>
	/// <param name="rowIndex">The row index to retrieve.</param>
	/// <returns>A sequence of elements from the specified column range and row.</returns>
	/// <remarks>
	/// When setting, provide an IEnumerable with matching count or a single-element collection to fill all cells.
	/// </remarks>
	public IEnumerable<T> this[Range colRange, Index rowIndex] {
		get {
			(int colOffset, int colLength) = colRange.GetOffsetAndLength(ColsCount);
			int row = rowIndex.GetOffset(RowsCount);

			for (int col = 0; col < colLength; col++) {
				yield return InternalCells[colOffset + col, row];
			}
		}
		set {
			(int colOffset, int colLength) = colRange.GetOffsetAndLength(ColsCount);
			int row = rowIndex.GetOffset(RowsCount);

			T[] values = [.. value];
			if (values.Length == colLength) {
				for (int col = 0; col < colLength; col++) {
					InternalCells[colOffset + col, row] = values[col];
				}
			} else if (values.Length == 1) {
				T fillValue = values[0];
				for (int col = 0; col < colLength; col++) {
					InternalCells[colOffset + col, row] = fillValue;
				}
			} else {
				throw new ArgumentException($"Collection count must match the target range length ({colLength}) or be 1 for filling.");
			}
		}
	}

	// Conversion to underlying array
	/// <summary>
	/// Gets a reference to the underlying two-dimensional array.
	/// </summary>
	/// <remarks>Direct modifications to the returned array will affect the grid.</remarks>
	/// <returns>The underlying two-dimensional array.</returns>
	public T[,] ToArray() => InternalCells;

	private string DebugDisplay => $$"""{{nameof(Grid<>)}} [{{ColsCount}}, {{RowsCount}}]""";
}
