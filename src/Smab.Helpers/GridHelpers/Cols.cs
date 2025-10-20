namespace Smab.Helpers;

public static partial class ArrayHelpers {
	extension<T>(T[,] array) {
		/// <summary>
		/// Retrieves all elements from the specified column of a two-dimensional array.
		/// </summary>
		/// <typeparam name="T">The type of elements in the array.</typeparam>
		/// <param name="array">The two-dimensional array to extract the column from. Cannot be <see langword="null"/>.</param>
		/// <param name="colNo">The zero-based index of the column to retrieve. Must be within the bounds of the array's columns.</param>
		/// <returns>An <see cref="IEnumerable{T}"/> containing the elements of the specified column in the order of their rows.</returns>
		public IEnumerable<T> Col(int colNo)
			=> array.RowIndexes().Select(row => array[colNo, row]);

		/// <summary>
		/// Enumerates the columns of a two-dimensional array as sequences of elements.
		/// </summary>
		/// <remarks>This method allows you to iterate over the columns of a two-dimensional array as individual
		/// sequences. Each column is represented as an <see cref="IEnumerable{T}"/>.</remarks>
		/// <typeparam name="T">The type of elements in the array.</typeparam>
		/// <param name="array">The two-dimensional array to extract columns from.</param>
		/// <returns>An enumerable of sequences, where each sequence represents a column of the array. The order of the columns in the
		/// result matches their order in the array.</returns>
		public IEnumerable<IEnumerable<T>> Cols()
			=> array.ColIndexes().Select(ix => array.Col(ix));
	}
}
