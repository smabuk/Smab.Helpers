namespace Smab.Helpers;

public static partial class ArrayHelpers {

	/// <summary>
	/// Retrieves the adjacent cells of a specified element in a two-dimensional array.
	/// </summary>
	/// <remarks>The method checks bounds to ensure that only valid adjacent cells within the array are returned. 
	/// Use the <paramref name="exclude"/> parameter to filter out specific directions if needed.</remarks>
	/// <typeparam name="T">The type of elements in the array.</typeparam>
	/// <param name="array">The two-dimensional array to search for adjacent cells.</param>
	/// <param name="x">The x-coordinate of the element whose adjacent cells are to be retrieved.</param>
	/// <param name="y">The y-coordinate of the element whose adjacent cells are to be retrieved.</param>
	/// <param name="includeDiagonals">A value indicating whether diagonal neighbors should be included.  If <see langword="true"/>, diagonal neighbors
	/// are included; otherwise, only cardinal neighbors are returned.</param>
	/// <param name="exclude">An optional collection of direction offsets to exclude from the results.  Each offset is represented as a tuple of
	/// x and y deltas (dX, dY).</param>
	/// <returns>An enumerable collection of <see cref="Cell{T}"/> objects representing the adjacent cells.  Each cell includes its
	/// coordinates and value. The collection is empty if no valid adjacent cells exist.</returns>
	public static IEnumerable<Cell<T>> GetAdjacentCells<T>(this T[,] array, int x, int y, bool includeDiagonals = false, IEnumerable<(int dX, int dY)>? exclude = null) {
		IEnumerable<(int dX, int dY)> DIRECTIONS = includeDiagonals switch {
			true  => ALL_DIRECTIONS,
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
	/// <remarks>The method considers the boundaries of the array and excludes any neighbors that fall outside its
	/// dimensions.</remarks>
	/// <typeparam name="T">The type of elements in the array.</typeparam>
	/// <param name="array">The two-dimensional array to search for adjacent cells.</param>
	/// <param name="point">The coordinates of the point for which adjacent cells are retrieved, represented as a tuple (x, y).</param>
	/// <param name="includeDiagonals">A value indicating whether diagonal neighbors should be included.  <see langword="true"/> to include diagonal
	/// neighbors; otherwise, <see langword="false"/>.</param>
	/// <param name="exclude">An optional collection of relative offsets (dX, dY) to exclude from the adjacent cells.  If <see langword="null"/>,
	/// no offsets are excluded.</param>
	/// <returns>An enumerable collection of <see cref="Cell{T}"/> objects representing the adjacent cells of the specified point.</returns>
	public static IEnumerable<Cell<T>> GetAdjacentCells<T>(this T[,] array, (int x, int y) point, bool includeDiagonals = false, IEnumerable<(int dX, int dY)>? exclude = null)
		=> GetAdjacentCells<T>(array, point.x, point.y, includeDiagonals, exclude);

	public static IEnumerable<Cell<T>> GetCornerCells<T>(this T[,] array, int x, int y, IEnumerable<(int dX, int dY)>? exclude = null) {
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
	public static IEnumerable<Cell<T>> GetCornerCells<T>(this T[,] array, (int x, int y) point, IEnumerable<(int dX, int dY)>? exclude = null)
		=> GetCornerCells<T>(array, point.x, point.y, exclude);
}
