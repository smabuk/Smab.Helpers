namespace Smab.Helpers;

public static partial class ArrayHelpers {

	extension<T>(Grid<T> grid) {
		/// <summary>
		/// Returns the adjacent cells surrounding the specified cell coordinates.
		/// </summary>
		/// <remarks>Cells returned are within the bounds of the grid. Excluded offsets are applied after determining
		/// adjacency. This method does not return the cell at (x, y) itself.</remarks>
		/// <param name="x">The zero-based X coordinate of the target cell.</param>
		/// <param name="y">The zero-based Y coordinate of the target cell.</param>
		/// <param name="includeDiagonals">true to include diagonal neighbours; otherwise, false to include only orthogonal neighbours.</param>
		/// <param name="exclude">An optional collection of relative coordinate offsets to exclude from the results. If null, no offsets are
		/// excluded.</param>
		/// <returns>An enumerable collection of adjacent cells. The collection may be empty if no adjacent cells exist at the
		/// specified location.</returns>
		public IEnumerable<Cell<T>> GetAdjacentCells(int x, int y, bool includeDiagonals = false, IEnumerable<(int dX, int dY)>? exclude = null)
			=> grid.InternalCells.GetAdjacentCells<T>(x, y, includeDiagonals, exclude);

		/// <summary>
		/// Returns the adjacent cells surrounding the specified point in the grid.
		/// </summary>
		/// <param name="point">The coordinates of the cell for which to retrieve adjacent cells. The tuple represents the x and y position within
		/// the grid.</param>
		/// <param name="includeDiagonals">Specifies whether to include diagonal neighbours in the result. If <see langword="true"/>, diagonal cells are
		/// included; otherwise, only orthogonal neighbours are returned.</param>
		/// <param name="exclude">An optional collection of relative coordinate offsets to exclude from the adjacency search. Each tuple represents
		/// a direction (dX, dY) to omit from the results. If <see langword="null"/>, no directions are excluded.</param>
		/// <returns>An enumerable collection of adjacent <see cref="Cell{T}"/> instances. The collection may be empty if the specified
		/// point has no valid neighbours.</returns>
		public IEnumerable<Cell<T>> GetAdjacentCells((int x, int y) point, bool includeDiagonals = false, IEnumerable<(int dX, int dY)>? exclude = null)
			=> grid.InternalCells.GetAdjacentCells<T>(point.x, point.y, includeDiagonals, exclude);

		/// <summary>
		/// Returns the adjacent cells surrounding the specified point in the grid.
		/// </summary>
		/// <param name="point">The point coordinates for which to retrieve adjacent cells.</param>
		/// <param name="includeDiagonals">Specifies whether to include diagonal neighbours in the result. If <see langword="true"/>, diagonal cells are
		/// included; otherwise, only orthogonal neighbours are returned.</param>
		/// <param name="exclude">An optional collection of relative coordinate offsets to exclude from the adjacency search. Each tuple represents
		/// a direction (dX, dY) to omit from the results. If <see langword="null"/>, no directions are excluded.</param>
		/// <returns>An enumerable collection of adjacent <see cref="Cell{T}"/> instances. The collection may be empty if the specified
		/// point has no valid neighbours.</returns>
		public IEnumerable<Cell<T>> GetAdjacentCells(Point point, bool includeDiagonals = false, IEnumerable<(int dX, int dY)>? exclude = null)
			=> grid.InternalCells.GetAdjacentCells<T>(point.X, point.Y, includeDiagonals, exclude);

		/// <summary>
		/// Returns the corner cells adjacent to the specified cell coordinates.
		/// </summary>
		/// <param name="x">The x-coordinate of the target cell for which to retrieve adjacent corner cells.</param>
		/// <param name="y">The y-coordinate of the target cell for which to retrieve adjacent corner cells.</param>
		/// <param name="exclude">An optional collection of direction offsets to exclude from the result. Each tuple represents a relative direction
		/// (dX, dY) to omit.</param>
		/// <returns>An enumerable collection of corner cells adjacent to the specified cell. The collection will be empty if no corner
		/// cells are found.</returns>
		public IEnumerable<Cell<T>> GetCornerCells(int x, int y, IEnumerable<(int dX, int dY)>? exclude = null)
			=> grid.InternalCells.GetCornerCells<T>(x, y, exclude);

		/// <summary>
		/// Returns the corner-adjacent cells surrounding the specified point in the grid.
		/// </summary>
		/// <param name="point">The coordinates of the cell for which to retrieve corner-adjacent neighbours. The tuple represents the x and y
		/// position within the grid.</param>
		/// <param name="exclude">An optional collection of relative corner directions to exclude from the result. Each tuple specifies the x and y
		/// offset of a corner direction to omit.</param>
		/// <returns>An enumerable collection of corner-adjacent cells. The collection may be empty if no valid corner neighbours exist
		/// or all are excluded.</returns>
		public IEnumerable<Cell<T>> GetCornerCells((int x, int y) point, IEnumerable<(int dX, int dY)>? exclude = null)
			=> grid.InternalCells.GetCornerCells<T>(point.x, point.y, exclude);

		/// <summary>
		/// Returns the corner-adjacent cells surrounding the specified point in the grid.
		/// </summary>
		/// <param name="point">The point coordinates for which to retrieve corner-adjacent neighbours.</param>
		/// <param name="exclude">An optional collection of relative corner directions to exclude from the result. Each tuple specifies the x and y
		/// offset of a corner direction to omit.</param>
		/// <returns>An enumerable collection of corner-adjacent cells. The collection may be empty if no valid corner neighbours exist
		/// or all are excluded.</returns>
		public IEnumerable<Cell<T>> GetCornerCells(Point point, IEnumerable<(int dX, int dY)>? exclude = null)
			=> grid.InternalCells.GetCornerCells<T>(point.X, point.Y, exclude);
	}

	extension<T>(T[,] array) {
		/// <summary>
		/// Retrieves the adjacent cells of a specified element in a two-dimensional array.
		/// </summary>
		/// <remarks>The method checks bounds to ensure that only valid adjacent cells within the array are returned.
		/// Use the <paramref name="exclude"/> parameter to filter out specific directions if needed.</remarks>
		/// <typeparam name="T">The type of elements in the array.</typeparam>
		/// <param name="array">The two-dimensional array to search for adjacent cells.</param>
		/// <param name="x">The x-coordinate of the element whose adjacent cells are to be retrieved.</param>
		/// <param name="y">The y-coordinate of the element whose adjacent cells are to be retrieved.</param>
		/// <param name="includeDiagonals">A value indicating whether diagonal neighbours should be included.  If <see langword="true"/>, diagonal neighbours
		/// are included; otherwise, only cardinal neighbours are returned.</param>
		/// <param name="exclude">An optional collection of direction offsets to exclude from the results.  Each offset is represented as a tuple of
		/// x and y deltas (dX, dY).</param>
		/// <returns>An enumerable collection of <see cref="Cell{T}"/> objects representing the adjacent cells.  Each cell includes its
		/// coordinates and value. The collection is empty if no valid adjacent cells exist.</returns>
		public IEnumerable<Cell<T>> GetAdjacentCells(int x, int y, bool includeDiagonals = false, IEnumerable<(int dX, int dY)>? exclude = null) {
			IEnumerable<(int dX, int dY)> DIRECTIONS = includeDiagonals switch {
				true => ALL_DIRECTIONS,
				false => CARDINAL_DIRECTIONS,
			};

			foreach ((int dX, int dY) in DIRECTIONS) {
				if (exclude is null || !exclude.Contains((dX, dY))) {
					int newX = x + dX;
					int newY = y + dY;
					if (array.IsInBounds(newX, newY)) {
						yield return new(newX, newY, array[newX, newY]);
					}
				}
			}
		}

		/// <summary>
		/// Retrieves the adjacent cells of a specified point in a two-dimensional array.
		/// </summary>
		/// <remarks>The method considers the boundaries of the array and excludes any neighbours that fall outside its
		/// dimensions.</remarks>
		/// <typeparam name="T">The type of elements in the array.</typeparam>
		/// <param name="array">The two-dimensional array to search for adjacent cells.</param>
		/// <param name="point">The coordinates of the point for which adjacent cells are retrieved, represented as a tuple (x, y).</param>
		/// <param name="includeDiagonals">A value indicating whether diagonal neighbours should be included.  <see langword="true"/> to include diagonal
		/// neighbours; otherwise, <see langword="false"/>.</param>
		/// <param name="exclude">An optional collection of relative offsets (dX, dY) to exclude from the adjacent cells.  If <see langword="null"/>,
		/// no offsets are excluded.</param>
		/// <returns>An enumerable collection of <see cref="Cell{T}"/> objects representing the adjacent cells of the specified point.</returns>
		public IEnumerable<Cell<T>> GetAdjacentCells((int x, int y) point, bool includeDiagonals = false, IEnumerable<(int dX, int dY)>? exclude = null)
			=> GetAdjacentCells<T>(array, point.x, point.y, includeDiagonals, exclude);

		/// <summary>
		/// Retrieves the adjacent cells of a specified point in a two-dimensional array.
		/// </summary>
		/// <remarks>The method considers the boundaries of the array and excludes any neighbours that fall outside its
		/// dimensions.</remarks>
		/// <typeparam name="T">The type of elements in the array.</typeparam>
		/// <param name="array">The two-dimensional array to search for adjacent cells.</param>
		/// <param name="point">The point coordinates for which adjacent cells are retrieved.</param>
		/// <param name="includeDiagonals">A value indicating whether diagonal neighbours should be included.  <see langword="true"/> to include diagonal
		/// neighbours; otherwise, <see langword="false"/>.</param>
		/// <param name="exclude">An optional collection of relative offsets (dX, dY) to exclude from the adjacent cells.  If <see langword="null"/>,
		/// no offsets are excluded.</param>
		/// <returns>An enumerable collection of <see cref="Cell{T}"/> objects representing the adjacent cells of the specified point.</returns>
		public IEnumerable<Cell<T>> GetAdjacentCells(Point point, bool includeDiagonals = false, IEnumerable<(int dX, int dY)>? exclude = null)
			=> GetAdjacentCells<T>(array, point.X, point.Y, includeDiagonals, exclude);

		public IEnumerable<Cell<T>> GetCornerCells(int x, int y, IEnumerable<(int dX, int dY)>? exclude = null) {
			IEnumerable<(int dX, int dY)> DIRECTIONS = CARDINAL_DIRECTIONS;

			foreach ((int dX, int dY) in DIRECTIONS) {
				if (exclude is null || !exclude.Contains((dX, dY))) {
					int newX = x + dX;
					int newY = y + dY;
					if (array.IsInBounds(newX, newY)) {
						yield return new(newX, newY, array[newX, newY]);
					}
				}
			}
		}

		/// <summary>
		/// Retrieves the corner cells of a two-dimensional array relative to a specified point.
		/// </summary>
		/// <typeparam name="T">The type of elements in the array.</typeparam>
		/// <param name="array">The two-dimensional array from which to retrieve the corner cells.</param>
		/// <param name="point">A tuple representing the coordinates of the reference point in the array.  The first value is the x-coordinate, and
		/// the second value is the y-coordinate.</param>
		/// <param name="exclude">An optional collection of relative offsets to exclude from the result.  Each offset is represented as a tuple of x
		/// and y deltas.</param>
		/// <returns>An enumerable collection of <see cref="Cell{T}"/> objects representing the corner cells  around the specified
		/// point. The collection may be empty if no valid corner cells are found.</returns>
		public IEnumerable<Cell<T>> GetCornerCells((int x, int y) point, IEnumerable<(int dX, int dY)>? exclude = null)
			=> GetCornerCells<T>(array, point.x, point.y, exclude);

		/// <summary>
		/// Retrieves the corner cells of a two-dimensional array relative to a specified point.
		/// </summary>
		/// <typeparam name="T">The type of elements in the array.</typeparam>
		/// <param name="array">The two-dimensional array from which to retrieve the corner cells.</param>
		/// <param name="point">The point coordinates of the reference cell in the array.</param>
		/// <param name="exclude">An optional collection of relative offsets to exclude from the result.  Each offset is represented as a tuple of x
		/// and y deltas.</param>
		/// <returns>An enumerable collection of <see cref="Cell{T}"/> objects representing the corner cells  around the specified
		/// point. The collection may be empty if no valid corner cells are found.</returns>
		public IEnumerable<Cell<T>> GetCornerCells(Point point, IEnumerable<(int dX, int dY)>? exclude = null)
			=> GetCornerCells<T>(array, point.X, point.Y, exclude);
	}
}

