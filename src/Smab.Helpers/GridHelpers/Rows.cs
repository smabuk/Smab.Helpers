namespace Smab.Helpers;

public static partial class ArrayHelpers {
	extension<T>(T[,] array) {
		/// <summary>
		/// Retrieves a sequence of elements from the specified row in a two-dimensional array.
		/// </summary>
		/// <remarks>This method uses deferred execution. The returned sequence is evaluated lazily as it is
		/// enumerated.</remarks>
		/// <typeparam name="T">The type of elements in the array.</typeparam>
		/// <param name="array">The two-dimensional array from which to extract the row. Cannot be <see langword="null"/>.</param>
		/// <param name="rowNo">The zero-based index of the row to retrieve. Must be within the bounds of the array's row indices.</param>
		/// <returns>An <see cref="IEnumerable{T}"/> containing the elements of the specified row in the array.</returns>
		public IEnumerable<T> Row(int rowNo)
			=> array.ColIndexes().Select(col => array[col, rowNo]);

		/// <summary>
		/// Enumerates the rows of a two-dimensional array as sequences of elements.
		/// </summary>
		/// <remarks>Each row is represented as an <see cref="IEnumerable{T}"/> containing the elements of that row in
		/// order. The method uses deferred execution, meaning the rows are not materialized until enumerated.</remarks>
		/// <typeparam name="T">The type of elements in the array.</typeparam>
		/// <param name="array">The two-dimensional array to enumerate rows from. Cannot be <see langword="null"/>.</param>
		/// <returns>An enumerable collection where each element is an enumerable representing a row of the array.</returns>
		public IEnumerable<IEnumerable<T>> Rows()
			=> array.RowIndexes().Select(ix => array.Row(ix));
	}
}
