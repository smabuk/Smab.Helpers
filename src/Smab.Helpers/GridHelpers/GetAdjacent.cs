namespace Smab.Helpers;

public static partial class ArrayHelpers {

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

	public static IEnumerable<Cell<T>> GetAdjacentCells<T>(this T[,] array, int x, int y, bool includeDiagonals = false, T[]? exclude = null) {
		IEnumerable<(int dX, int dY)> DIRECTIONS = includeDiagonals switch {
			true  => ALL_DIRECTIONS,
			false => CARDINAL_DIRECTIONS,
		};

		foreach ((int dX, int dY) in DIRECTIONS) {
			int newX = x + dX;
			int newY = y + dY;
			if (array.IsInBounds(newX, newY)) {
				if (exclude is null || !exclude.Contains(array[newX, newY])) {
					yield return new(newX, newY, array[newX, newY]);
				}
			}
		}
	}

	public static IEnumerable<Cell<T>> GetAdjacentCells<T>(this T[,] array, (int x, int y) point, bool includeDiagonals = false, IEnumerable<(int dX, int dY)>? exclude = null)
		=> GetAdjacentCells<T>(array, point.x, point.y, includeDiagonals, exclude);
}
