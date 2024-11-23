namespace Smab.Helpers;

public static partial class ArrayHelpers {

	public static bool TryGetValue<T>(this T[,] array, int x, int y, out T value) {
		value = default!;
		if (array.IsOutOfBounds(x, y)) {
			return false;
		}

		value = array[x, y];
		return true;
	}

	public static bool TryGetValue<T>(this T[,] array, (int X, int Y) point, out T value) {
		value = default!;
		if (array.IsOutOfBounds(point.X, point.Y)) {
			return false;
		}

		value = array[point.X, point.Y];
		return true;
	}

	public static bool TryGetValue<T>(this T[,] array, Point point, out T value) {
		value = default!;
		if (array.IsOutOfBounds(point.X, point.Y)) {
			return false;
		}

		value = array[point.X, point.Y];
		return true;
	}
}
