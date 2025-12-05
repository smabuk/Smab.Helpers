using System;

namespace Smab.Helpers;

/// <summary>
/// Represents a two-dimensional grid of values.
/// </summary>
/// <typeparam name="T">The type of elements stored in the grid.</typeparam>
/// <param name="ColsCount">The number of columns in the grid.</param>
/// <param name="RowsCount">The number of rows in the grid.</param>
[DebuggerDisplay("{DebugDisplay,nq}")]
public record Grid<T>(int ColsCount, int RowsCount) {

	private readonly T[,] cells = new T[ColsCount, RowsCount];
	internal T[,] Cells => cells;

	// Indexer
	/// <summary>
	/// Gets or sets the element at the specified column and row.
	/// </summary>
	/// <param name="col">The zero-based column index.</param>
	/// <param name="row">The zero-based row index.</param>
	/// <returns>The element at the specified position.</returns>
	public T this[int col, int row] {
		get => cells[col, row];
		set => cells[col, row] = value;
	}

	// Indexer
	/// <summary>
	/// Gets or sets the value at the specified grid location.
	/// </summary>
	/// <param name="point">The grid coordinates used to access the value. The X and Y properties specify the column and row indices,
	/// respectively.</param>
	/// <returns>The value stored at the given grid location.</returns>
	public T this[Point point] {
		get => cells[point.X, point.Y];
		set => cells[point.X, point.Y] = value;
	}

	// Indexer
	/// <summary>
	/// Gets or sets the value at the specified two-dimensional grid coordinates.
	/// </summary>
	/// <param name="point">A tuple containing the X and Y coordinates of the cell to access. Both values must be within the valid range of the
	/// grid.</param>
	/// <returns>The value stored at the cell located at the specified coordinates.</returns>
	public T this[(int X, int Y) point] {
		get => cells[point.X, point.Y];
		set => cells[point.X, point.Y] = value;
	}

	// Conversion to underlying array
	/// <summary>
	/// Gets a reference to the underlying two-dimensional array.
	/// </summary>
	/// <remarks>Direct modifications to the returned array will affect the grid.</remarks>
	/// <returns>The underlying two-dimensional array.</returns>
	public T[,] ToArray() => cells;

	private string DebugDisplay => $$"""{{nameof(Grid<>)}} [{{ColsCount}}, {{RowsCount}}]""";
}
