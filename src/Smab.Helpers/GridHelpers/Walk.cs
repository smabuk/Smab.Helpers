using System.Data;

namespace Smab.Helpers;

public static partial class ArrayHelpers {
	/// <summary>
	/// 
	/// </summary>
	/// <typeparam name="T"></typeparam>
	/// <param name="array"></param>
	/// <returns></returns>
	public static IEnumerable<Cell<T>> Walk2dArrayWithValues<T>(this T[,] array) {
		int cols = array.GetUpperBound(COL_DIMENSION);
		int rows = array.GetUpperBound(ROW_DIMENSION);

		for (int row = 0; row <= rows; row++) {
		for (int col = 0; col <= cols; col++) {
			yield return new(col, row, array[col, row]);
		}}
	}

	public static IEnumerable<(int X, int Y)> Walk2dArray<T>(this T[,] array)
		=> array
			.Walk2dArrayWithValues()
			.Select(cell => (cell.Index.X, cell.Index.Y));



	public static IEnumerable<Cell<T>> GetAdjacentCells<T>(this T[,] array, int x, int y, bool includeDiagonals = false, IEnumerable<(int dX, int dY)>? exclude = null) {
		int cols = array.GetUpperBound(0);
		int rows = array.GetUpperBound(1);

		IEnumerable<(int dX, int dY)> DIRECTIONS = includeDiagonals switch {
			true  => ALL_DIRECTIONS,
			false => CARDINAL_DIRECTIONS,
		};

		foreach ((int dX, int dY) in DIRECTIONS) {
			if (exclude is null || !exclude.Contains((dX, dY))) {
				int newX = x + dX;
				int newY = y + dY;
				if (array.InBounds(newX, newY)) {
					yield return new(newX, newY, array[newX, newY]);
				}
			}
		}
	}

	public static IEnumerable<Cell<T>> GetAdjacentCells<T>(this T[,] array, (int x, int y) point, bool includeDiagonals = false, IEnumerable<(int dX, int dY)>? exclude = null)
		=> GetAdjacentCells<T>(array, point.x, point.y, includeDiagonals, exclude);
}
