namespace Smab.Helpers;

public static partial class ArrayHelpers {


	public static T[,] To2dArray<T>(this IEnumerable<T> input, int cols, int? rows = null) {
		ReadOnlySpan<T> array = input.ToArray().AsSpan();
		int arrayLength = array.Length;
		rows ??= arrayLength % cols == 0 ? arrayLength / cols : (arrayLength / cols) + 1;
		T[,] result = new T[cols, (int)rows];
		int i = 0;
		for (int r = 0; r < rows; r++) {
			for (int c = 0; c < cols; c++) {
				result[c, r] = array[i++];
				if (i >= arrayLength) {
					return result;
				}
			}
		}

		return result;
	}

	public static T[,] To2dArray<T>(this IEnumerable<IEnumerable<T>> input, int? cols = null, int? rows = null) {
		rows ??= input.Count();
		cols ??= input.First().Count();
		T[,] result = new T[(int)cols, (int)rows];
		int r = 0;
		foreach (List<T> row in input.Cast<List<T>>()) {
			int c = 0;
			foreach (T item in row) {
				result[c, r] = item;
				c++;
			}
			r++;
		}

		return result;
	}

	public static char[,] To2dArray(this IEnumerable<string> input, int? cols = null, int? rows = null) {
		ReadOnlySpan<string> array = input.ToArray().AsSpan();
		rows ??= array.Length;
		cols ??= array[0].Length;
		char[,] result = new char[(int)cols, (int)rows];
		for (int r = 0; r < rows; r++) {
			for (int c = 0; c < cols; c++) {
				result[c, r] = array[r][c];
			}
		}

		return result;
	}

	public static T[,] To2dArray<T>(this IEnumerable<Point> input, T initial, T value) {
		int minX = int.MaxValue;
		int minY = int.MaxValue;
		int maxX = int.MinValue;
		int maxY = int.MinValue;
		foreach (Point point in input) {
			minX = Math.Min(minX, point.X);
			maxX = Math.Max(maxX, point.X);
			minY = Math.Min(minY, point.Y);
			maxY = Math.Max(maxY, point.Y);
		}

		if (minX > 0) { minX = 0; }
		if (minY > 0) { minY = 0; }

		int cols = maxX - minX + 1;
		int rows = maxY - minY + 1;

		T[,] result = new T[cols, rows];
		for (int r = 0; r < rows; r++) {
			for (int c = 0; c < cols; c++) {
				result[c, r] = initial;
			}
		}

		foreach (Point p in input) {
			result[p.X - minX, p.Y - minY] = value;
		}

		return result;
	}

}