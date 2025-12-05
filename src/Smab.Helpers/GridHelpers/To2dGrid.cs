namespace Smab.Helpers;

public static partial class ArrayHelpers {


	extension<T>(T[,] array) {
		public Grid<T> To2dGrid() => new(array.ColsCount(), array.RowsCount()) { Cells = array };
	}

	extension<T>(IEnumerable<T> input) {
		/// <summary>
		/// Converts the input sequence to a two-dimensional grid with the specified number of columns and optional number of
		/// rows.
		/// </summary>
		/// <param name="cols">The number of columns in the resulting grid. Must be greater than zero.</param>
		/// <param name="rows">The number of rows in the resulting grid. If null, the number of rows is calculated based on the input sequence
		/// and the specified column count.</param>
		/// <returns>A <see cref="Grid{T}"/> containing the elements of the input sequence arranged in a two-dimensional structure.</returns>
		public Grid<T> To2dGrid(int cols, int? rows = null) => input.To2dArray(cols, rows).To2dGrid();
	}

	extension<T>(IEnumerable<IEnumerable<T>> input) {
		/// <summary>
		/// Converts the input collection to a two-dimensional grid with the specified number of columns and rows.
		/// </summary>
		/// <param name="cols">The number of columns in the resulting grid. If null, the number of columns is determined automatically based on
		/// the input size and the value of <paramref name="rows"/>.</param>
		/// <param name="rows">The number of rows in the resulting grid. If null, the number of rows is determined automatically based on the
		/// input size and the value of <paramref name="cols"/>.</param>
		/// <returns>A <see cref="Grid{T}"/> containing the input elements arranged in a two-dimensional structure with the specified
		/// dimensions.</returns>
		public Grid<T> To2dGrid(int? cols = null, int? rows = null) => input.To2dArray(cols, rows).To2dGrid();
	}

	extension(IEnumerable<string> input) {
		/// <summary>
		/// Converts the input sequence to a two-dimensional grid of characters with the specified number of columns and rows.
		/// </summary>
		/// <param name="cols">The number of columns in the resulting grid. If null, the default column count is determined based on the input
		/// sequence.</param>
		/// <param name="rows">The number of rows in the resulting grid. If null, the default row count is determined based on the input
		/// sequence.</param>
		/// <returns>A Grid<char> instance containing the characters from the input sequence arranged in a two-dimensional grid.</returns>
		public Grid<char> To2dGrid(int? cols = null, int? rows = null) => input.To2dArray(cols, rows).To2dGrid();
	}

	extension(IEnumerable<Point> input) {
		/// <summary>
		/// Creates a two-dimensional grid populated with the specified initial and value elements.
		/// </summary>
		/// <typeparam name="T">The type of elements contained in the grid.</typeparam>
		/// <param name="initial">The element used to initialize the grid's cells before applying the specified value.</param>
		/// <param name="value">The element to assign to the grid's cells after initialization.</param>
		/// <returns>A <see cref="Grid{T}"/> instance containing the elements arranged in a two-dimensional structure.</returns>
		public Grid<T> To2dGrid<T>(T initial, T value) => input.To2dArray(initial, value).To2dGrid();
	}
}
