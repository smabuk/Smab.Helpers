namespace Smab.Helpers;

public static partial class ArrayHelpers {
	extension<T>(T[,] array) {
		/// <summary>
		/// Enumerates the indexes of a two-dimensional array as tuples of X and Y coordinates.
		/// </summary>
		/// <remarks>The method iterates over all valid indexes of the specified two-dimensional array,  returning each
		/// index as a tuple in the format (X, Y).</remarks>
		/// <typeparam name="T">The type of elements in the two-dimensional array.</typeparam>
		/// <param name="array">The two-dimensional array whose indexes are to be enumerated. Cannot be <see langword="null"/>.</param>
		/// <returns>An enumerable collection of tuples, where each tuple contains the X index (<see cref="int"/>)  and the Y
		/// index (<see cref="int"/>) of an element in the array.</returns>
		public IEnumerable<(int X, int Y)> Indexes() {
			foreach (int y in array.RowIndexes()) {
				foreach (int x in array.ColIndexes()) {
					yield return new(x, y);
				}
			}
		}

		/// <summary>
		/// Enumerates the column and row indexes of a two-dimensional array.
		/// </summary>
		/// <remarks>The method iterates over all valid row and column indexes of the specified array, yielding each
		/// pair of indexes as a tuple. The order of enumeration is by rows, with all columns of a row being enumerated before
		/// moving to the next row.</remarks>
		/// <typeparam name="T">The type of elements in the array.</typeparam>
		/// <param name="array">The two-dimensional array to enumerate. Cannot be <see langword="null"/>.</param>
		/// <returns>An <see cref="IEnumerable{T}"/> of tuples, where each tuple contains the column index (<see cref="int"/>) and row
		/// index (<see cref="int"/>) of an element in the array.</returns>
		public IEnumerable<(int Col, int Row)> IndexesColRow() {
			foreach (int row in array.RowIndexes()) {
				foreach (int col in array.ColIndexes()) {
					yield return new(col, row);
				}
			}
		}
	}
}
