namespace Smab.Helpers;

public static partial class ArrayHelpers {
	extension<T>(T[,] array) {
		/// <summary>
		/// Retrieves all diagonals from a two-dimensional array, traversing in both south-east and south-west directions.
		/// </summary>
		/// <remarks>This method combines the diagonals traversed in two directions: south-east (from top-left to
		/// bottom-right) and south-west (from top-right to bottom-left). Each diagonal is represented as an enumerable of
		/// elements.</remarks>
		/// <typeparam name="T">The type of elements in the array.</typeparam>
		/// <param name="array">The two-dimensional array from which to extract diagonals. Cannot be null.</param>
		/// <returns>An enumerable of enumerables, where each inner enumerable represents a diagonal of the array. The diagonals are
		/// returned in order, starting with the south-east diagonals followed by the south-west diagonals.</returns>
		public IEnumerable<IEnumerable<T>> Diagonals()
			=> [.. array.DiagonalsSouthEast(), .. array.DiagonalsSouthWest()];

		/// <summary>
		/// Enumerates the diagonals of a two-dimensional array in a south-east direction.
		/// </summary>
		/// <remarks>The method iterates over the diagonals of the array, starting from the top-left corner and moving
		/// diagonally towards the bottom-right corner. Each diagonal is represented as an enumerable of elements. If the array
		/// is empty, the returned enumerable will also be empty.</remarks>
		/// <typeparam name="T">The type of elements in the array.</typeparam>
		/// <param name="array">The two-dimensional array to process. Cannot be <see langword="null"/>.</param>
		/// <returns>An enumerable of enumerables, where each inner enumerable represents a diagonal of the array starting from the
		/// top-left corner and proceeding in a south-east direction.</returns>
		public IEnumerable<IEnumerable<T>> DiagonalsSouthEast() {
			IEnumerable<T> result = [];
			int iterationEnd = -(int.Max(array.ColsMax(), array.RowsMax()));

			for (int col = array.ColsMax(); col >= iterationEnd; col--) {
				bool stop = false;
				foreach (int row in array.RowIndexes()) {
					if (array.TryGetValue(col + row, row, out T value)) {
						stop = true;
						result = [.. result, value];
					} else if (stop) {
						break;
					}
				}

				yield return result;
				result = [];
			}
		}

		/// <summary>
		/// Retrieves the diagonal elements of a two-dimensional array that run from the top-left to the bottom-right, starting
		/// from the specified diagonal index.
		/// </summary>
		/// <typeparam name="T">The type of elements in the array.</typeparam>
		/// <param name="array">The two-dimensional array from which to extract the diagonal elements.</param>
		/// <param name="index">The zero-based index of the diagonal to retrieve. A value of 0 corresponds to the main diagonal,  positive values
		/// correspond to diagonals below the main diagonal, and negative values correspond to  diagonals above the main
		/// diagonal.</param>
		/// <returns>An <see cref="IEnumerable{T}"/> containing the elements of the specified diagonal.  Returns <see langword="null"/>
		/// if the specified diagonal does not exist.</returns>
		public IEnumerable<T> DiagonalsSouthEast(int index)
			=> array.DiagonalsSouthEast().Skip(index).FirstOrDefault([]);

		/// <summary>
		/// Enumerates the diagonals of a two-dimensional array in a south-west direction.
		/// </summary>
		/// <remarks>The diagonals are traversed in a south-west direction, starting from the top-right corner of the
		/// array  and moving towards the bottom-left corner. Each diagonal is yielded as a separate sequence of
		/// elements.</remarks>
		/// <typeparam name="T">The type of elements in the array.</typeparam>
		/// <param name="array">The two-dimensional array to process. Cannot be <see langword="null"/>.</param>
		/// <returns>An enumerable of diagonals, where each diagonal is represented as an <see cref="IEnumerable{T}"/>  containing the
		/// elements along that diagonal.</returns>
		public IEnumerable<IEnumerable<T>> DiagonalsSouthWest() {
			IEnumerable<T> result = [];
			int iterationEnd = int.Max(array.ColsMax(), array.RowsMax()) * 2;

			for (int col = 0; col <= iterationEnd; col++) {
				bool stop = false;
				foreach (int row in array.RowIndexes()) {
					if (array.TryGetValue(col - row, row, out T value)) {
						stop = true;
						result = [.. result, value];
					} else if (stop) {
						break;
					}
				}

				yield return result;
				result = [];
			}
		}

		/// <summary>
		/// Retrieves the diagonal elements of a two-dimensional array starting from the specified index, moving in the
		/// south-west direction.
		/// </summary>
		/// <remarks>The method skips the specified number of diagonals and retrieves the first diagonal that matches
		/// the given index. Diagonals are traversed in a south-west direction, starting from the top-right corner of the
		/// array.</remarks>
		/// <typeparam name="T">The type of elements in the array.</typeparam>
		/// <param name="array">The two-dimensional array from which to retrieve the diagonal elements.</param>
		/// <param name="index">The starting index of the diagonal to retrieve. Must be a non-negative integer and within the bounds of the array's
		/// dimensions.</param>
		/// <returns>An <see cref="IEnumerable{T}"/> containing the elements of the specified diagonal. Returns  <see langword="null"/>
		/// if the specified index is out of range or no diagonal exists at the given index.</returns>
		public IEnumerable<T> DiagonalsSouthWest(int index)
			=> array.DiagonalsSouthWest().Skip(index).FirstOrDefault([]);
	}
}
