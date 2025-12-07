namespace Smab.Helpers;

public static partial class ArrayHelpers {
	extension<T>(Grid<T> grid) {
		/// <summary>
		/// Gets the neighboring elements of a cell in the grid.
		/// </summary>
		/// <param name="col">The column index of the cell.</param>
		/// <param name="row">The row index of the cell.</param>
		/// <param name="includeDiagonals">If true, includes diagonal neighbors; otherwise, only cardinal directions (N, E, S, W).</param>
		/// <returns>An enumerable collection of neighboring elements.</returns>
		public IEnumerable<T> GetNeighbors(int col, int row, bool includeDiagonals = false) {
			// Cardinal directions: North, East, South, West
			if (grid.TryGetValue(col, row - 1, out T? north)) {
				yield return north;
			}
			if (grid.TryGetValue(col + 1, row, out T? east)) {
				yield return east;
			}
			if (grid.TryGetValue(col, row + 1, out T? south)) {
				yield return south;
			}
			if (grid.TryGetValue(col - 1, row, out T? west)) {
				yield return west;
			}

			if (includeDiagonals) {
				// Diagonal directions: NW, NE, SW, SE
				if (grid.TryGetValue(col - 1, row - 1, out T? nw)) {
					yield return nw;
				}
				if (grid.TryGetValue(col + 1, row - 1, out T? ne)) {
					yield return ne;
				}
				if (grid.TryGetValue(col - 1, row + 1, out T? sw)) {
					yield return sw;
				}
				if (grid.TryGetValue(col + 1, row + 1, out T? se)) {
					yield return se;
				}
			}
		}

		/// <summary>
		/// Gets the neighboring elements of a cell along with their coordinates.
		/// </summary>
		/// <param name="col">The column index of the cell.</param>
		/// <param name="row">The row index of the cell.</param>
		/// <param name="includeDiagonals">If true, includes diagonal neighbors; otherwise, only cardinal directions.</param>
		/// <returns>An enumerable collection of tuples containing the neighbor's column, row, and value.</returns>
		public IEnumerable<(int col, int row, T value)> GetNeighborsWithCoords(int col, int row, bool includeDiagonals = false) {
			(int dc, int dr)[] offsets = includeDiagonals
				? [(0, -1), (1, 0), (0, 1), (-1, 0), (-1, -1), (1, -1), (-1, 1), (1, 1)]
				: [(0, -1), (1, 0), (0, 1), (-1, 0)];

			foreach ((int dc, int dr) in offsets) {
				int neighborCol = col + dc;
				int neighborRow = row + dr;
				if (grid.TryGetValue(neighborCol, neighborRow, out T? value)) {
					yield return (neighborCol, neighborRow, value);
				}
			}
		}

		/// <summary>
		/// Gets the neighbor to the north (above) of the specified cell.
		/// </summary>
		/// <param name="col">The column index.</param>
		/// <param name="row">The row index.</param>
		/// <returns>The value of the north neighbor, or null if out of bounds.</returns>
		public T? GetNorth(int col, int row) =>
			grid.TryGetValue(col, row - 1, out T? value) ? value : default;

		/// <summary>
		/// Gets the neighbor to the south (below) of the specified cell.
		/// </summary>
		/// <param name="col">The column index.</param>
		/// <param name="row">The row index.</param>
		/// <returns>The value of the south neighbor, or null if out of bounds.</returns>
		public T? GetSouth(int col, int row) =>
			grid.TryGetValue(col, row + 1, out T? value) ? value : default;

		/// <summary>
		/// Gets the neighbor to the east (right) of the specified cell.
		/// </summary>
		/// <param name="col">The column index.</param>
		/// <param name="row">The row index.</param>
		/// <returns>The value of the east neighbor, or null if out of bounds.</returns>
		public T? GetEast(int col, int row) =>
			grid.TryGetValue(col + 1, row, out T? value) ? value : default;

		/// <summary>
		/// Gets the neighbor to the west (left) of the specified cell.
		/// </summary>
		/// <param name="col">The column index.</param>
		/// <param name="row">The row index.</param>
		/// <returns>The value of the west neighbor, or null if out of bounds.</returns>
		public T? GetWest(int col, int row) =>
			grid.TryGetValue(col - 1, row, out T? value) ? value : default;

		/// <summary>
		/// Gets all cardinal direction neighbors (N, E, S, W) with their directions.
		/// </summary>
		/// <param name="col">The column index.</param>
		/// <param name="row">The row index.</param>
		/// <returns>An enumerable of tuples containing direction name, column, row, and value.</returns>
		public IEnumerable<(string direction, int col, int row, T value)> GetCardinalNeighbors(int col, int row) {
			if (grid.TryGetValue(col, row - 1, out T? north)) {
				yield return ("N", col, row - 1, north);
			}
			if (grid.TryGetValue(col + 1, row, out T? east)) {
				yield return ("E", col + 1, row, east);
			}
			if (grid.TryGetValue(col, row + 1, out T? south)) {
				yield return ("S", col, row + 1, south);
			}
			if (grid.TryGetValue(col - 1, row, out T? west)) {
				yield return ("W", col - 1, row, west);
			}
		}
	}

	extension<T>(T[,] array) {
		/// <summary>
		/// Gets the neighboring elements of a cell in the array.
		/// </summary>
		/// <param name="col">The column index of the cell.</param>
		/// <param name="row">The row index of the cell.</param>
		/// <param name="includeDiagonals">If true, includes diagonal neighbors; otherwise, only cardinal directions.</param>
		/// <returns>An enumerable collection of neighboring elements.</returns>
		public IEnumerable<T> GetNeighbors(int col, int row, bool includeDiagonals = false) {
			// Cardinal directions
			if (array.TryGetValue(col, row - 1, out T? north)) {
				yield return north;
			}
			if (array.TryGetValue(col + 1, row, out T? east)) {
				yield return east;
			}
			if (array.TryGetValue(col, row + 1, out T? south)) {
				yield return south;
			}
			if (array.TryGetValue(col - 1, row, out T? west)) {
				yield return west;
			}

			if (includeDiagonals) {
				// Diagonal directions
				if (array.TryGetValue(col - 1, row - 1, out T? nw)) {
					yield return nw;
				}
				if (array.TryGetValue(col + 1, row - 1, out T? ne)) {
					yield return ne;
				}
				if (array.TryGetValue(col - 1, row + 1, out T? sw)) {
					yield return sw;
				}
				if (array.TryGetValue(col + 1, row + 1, out T? se)) {
					yield return se;
				}
			}
		}

		/// <summary>
		/// Gets the neighboring elements of a cell along with their coordinates.
		/// </summary>
		/// <param name="col">The column index of the cell.</param>
		/// <param name="row">The row index of the cell.</param>
		/// <param name="includeDiagonals">If true, includes diagonal neighbors; otherwise, only cardinal directions.</param>
		/// <returns>An enumerable collection of tuples containing the neighbor's column, row, and value.</returns>
		public IEnumerable<(int col, int row, T value)> GetNeighborsWithCoords(int col, int row, bool includeDiagonals = false) {
			(int dc, int dr)[] offsets = includeDiagonals
				? [(0, -1), (1, 0), (0, 1), (-1, 0), (-1, -1), (1, -1), (-1, 1), (1, 1)]
				: [(0, -1), (1, 0), (0, 1), (-1, 0)];

			foreach ((int dc, int dr) in offsets) {
				int neighborCol = col + dc;
				int neighborRow = row + dr;
				if (array.TryGetValue(neighborCol, neighborRow, out T? value)) {
					yield return (neighborCol, neighborRow, value);
				}
			}
		}
	}
}
