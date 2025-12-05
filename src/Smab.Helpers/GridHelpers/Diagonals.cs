namespace Smab.Helpers;

public static partial class ArrayHelpers {
	extension<T>(Grid<T> grid) {
		/// <summary>
		/// Returns an enumerable collection of all diagonals in the grid, where each diagonal is represented as a sequence of
		/// elements of type T.
		/// </summary>
		/// <remarks>Use this method to iterate over all diagonals in the grid, which can be useful for algorithms
		/// that require diagonal traversal, such as searching for patterns or calculating diagonal sums. The method does not
		/// modify the grid.</remarks>
		/// <returns>An enumerable of enumerables, each containing the elements along a single diagonal of the grid. The order of
		/// diagonals and their direction may depend on the grid's implementation.</returns>
		public IEnumerable<IEnumerable<T>> Diagonals() => grid.Cells.Diagonals();

		/// <summary>
		/// Returns an enumerable collection of all south-east diagonals in the grid, where each diagonal is represented as a
		/// sequence of elements.
		/// </summary>
		/// <remarks>South-east diagonals run from the top-left towards the bottom-right of the grid. The order of
		/// diagonals and their elements corresponds to their position in the grid, starting from the top row and leftmost
		/// column.</remarks>
		/// <returns>An enumerable of enumerables, each containing the elements along a single south-east diagonal of the grid. If the
		/// grid is empty, the returned collection will also be empty.</returns>
		public IEnumerable<IEnumerable<T>> DiagonalsSouthEast() => grid.Cells.DiagonalsSouthEast();

		/// <summary>
		/// Returns an enumerable collection of elements located on the south-east diagonal from the specified cell index
		/// within the grid.
		/// </summary>
		/// <param name="index">The zero-based index of the cell from which to start the south-east diagonal traversal. Must be within the bounds
		/// of the grid.</param>
		/// <returns>An enumerable collection of elements of type T found along the south-east diagonal starting from the specified
		/// index. The collection will be empty if the index is out of bounds or if no diagonal cells exist.</returns>
		public IEnumerable<T> DiagonalsSouthEast(int index) => grid.Cells.DiagonalsSouthEast(index);

		/// <summary>
		/// Returns an enumerable collection of all south-west diagonals in the grid, where each diagonal is represented as a
		/// sequence of elements of type T.
		/// </summary>
		/// <remarks>South-west diagonals run from the top-right corner of the grid towards the bottom-left. The
		/// number and length of diagonals depend on the grid's dimensions. The returned sequences do not overlap and each
		/// element of the grid appears in exactly one diagonal.</remarks>
		/// <returns>An enumerable of enumerables, each containing the elements along a single south-west diagonal of the grid. The
		/// outer collection contains all such diagonals, ordered from top-right to bottom-left.</returns>
		public IEnumerable<IEnumerable<T>> DiagonalsSouthWest() => grid.Cells.DiagonalsSouthWest();

		/// <summary>
		/// Returns an enumerable collection of elements located on the south-west diagonal from the specified cell index.
		/// </summary>
		/// <param name="index">The zero-based index of the cell from which to start the south-west diagonal traversal. Must be within the bounds
		/// of the grid.</param>
		/// <returns>An enumerable collection of elements of type T found along the south-west diagonal starting from the specified
		/// index. The collection will be empty if no diagonal cells exist from the given index.</returns>
		public IEnumerable<T> DiagonalsSouthWest(int index) => grid.Cells.DiagonalsSouthWest(index);
	}

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
