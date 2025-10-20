namespace Smab.Helpers;

public static partial class ArrayHelpers {

	extension<T>(T[,] array) {
		/// <summary>
		/// Flips a two-dimensional array horizontally, reversing the order of columns in each row.
		/// </summary>
		/// <typeparam name="T">The type of the elements in the array.</typeparam>
		/// <param name="array">The two-dimensional array to flip.</param>
		/// <returns>A new two-dimensional array that is flipped horizontally.</returns>
		public T[,] FlipHorizontally() {
			int colsCount = array.ColsCount();
			int rowsCount = array.RowsCount();

			T[,] result = new T[colsCount, rowsCount];

			array.Indexes().ForEach(ix => { result[ix.X, ix.Y] = array[colsCount - ix.X - 1, ix.Y]; });

			return result;
		}

		/// <summary>
		/// Flips a two-dimensional array vertically, reversing the order of rows in each column.
		/// </summary>
		/// <typeparam name="T">The type of the elements in the array.</typeparam>
		/// <param name="array">The two-dimensional array to flip.</param>
		/// <returns>A new two-dimensional array that is flipped vertically.</returns>
		public T[,] FlipVertically() {
			int colsCount = array.ColsCount();
			int rowsCount = array.RowsCount();

			T[,] result = new T[colsCount, rowsCount];

			array.Indexes().ForEach(ix => { result[ix.X, ix.Y] = array[ix.X, rowsCount - ix.Y - 1]; });

			return result;
		}
	}
}
