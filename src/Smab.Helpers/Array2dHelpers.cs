using System.Text;

namespace Smab.Helpers;

public static partial class ArrayHelpers {

	public static readonly List<(int dX, int dY)> CARDINAL_DIRECTIONS = [( 0, -1), ( 0, 1), (-1, 0), (1,  0)];
	public static readonly List<(int dX, int dY)> ORDINAL_DIRECTIONS  = [(-1, -1), (-1, 1), ( 1, 1), (1, -1)];
	public static readonly List<(int dX, int dY)> ALL_DIRECTIONS = [.. CARDINAL_DIRECTIONS, .. ORDINAL_DIRECTIONS];

	public static int NoOfColumns<T>(this T[,] array) => array.GetLength(0);
	public static int NoOfRows<T>(this T[,] array) => array.GetLength(1);

	public static T[,] Create2dArray<T>(int cols, int rows, T value) {
		T[,] result = new T[cols, rows];
		for (int row = 0; row < rows; row++) {
			for (int col = 0; col < cols; col++) {
				result[col, row] = value;
			}
		}

		return result;
	}

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

	/// <summary>
	/// 
	/// </summary>
	/// <typeparam name="T"></typeparam>
	/// <param name="array"></param>
	/// <returns></returns>
	public static IEnumerable<Cell<T>> Walk2dArrayWithValues<T>(this T[,] array) {
		int cols = array.GetUpperBound(0);
		int rows = array.GetUpperBound(1);

		for (int row = 0; row <= rows; row++) {
			for (int col = 0; col <= cols; col++) {
				yield return new(col, row, array[col, row]);
			}
		}
	}

	public static IEnumerable<(int X, int Y)> Walk2dArray<T>(this T[,] array)
		=> array
			.Walk2dArrayWithValues()
			.Select(cell => (cell.Index.X, cell.Index.Y));



	public static IEnumerable<Cell<T>> GetAdjacentCells<T>(this T[,] array, int x, int y, bool includeDiagonals = false) {
		int cols = array.GetUpperBound(0);
		int rows = array.GetUpperBound(1);

		IEnumerable<(int dX, int dY)> DIRECTIONS = includeDiagonals switch {
			true => ALL_DIRECTIONS,
			false => CARDINAL_DIRECTIONS,
		};

		foreach ((int dX, int dY) in DIRECTIONS) {
			int newX = x + dX;
			int newY = y + dY;
			if (newX >= 0 && newX <= cols && newY >= 0 && newY <= rows) {
				yield return new(newX, newY, array[newX, newY]);
			}
		}
	}

	public static IEnumerable<Cell<T>> GetAdjacentCells<T>(this T[,] array, (int x, int y) point, bool includeDiagonals = false)
		=> GetAdjacentCells<T>(array, point.x, point.y, includeDiagonals);

	/// <summary>
	/// 
	/// </summary>
	/// <typeparam name="T"></typeparam>
	/// <param name="array"></param>
	/// <param name="width">If -1 then no spaces. If 0 then 1 padded space, otherwise the width of columns required</param>
	/// <returns></returns>
	public static IEnumerable<string> PrintAsStringArray<T>(this T[,] array, int? width = null, (string, string)[]? replacements = null) where T : struct {
		StringBuilder line = new();
		for (int r = 0; r <= array.GetUpperBound(1); r++) {
			line.Clear();
			for (int c = 0; c <= array.GetUpperBound(0); c++) {
				string cell = array[c, r].ToString() ?? "";
				line.Append(width switch {
					0 => cell,
					_ => $"{new string(' ', (width - cell.Length) ?? 1)}{cell}",
				});
			}
			if (replacements is not null) {
				foreach ((string from, string to) in replacements) {
					line = line.Replace(from, to);
				}
			}
			yield return line.ToString();
		}
	}

	public static List<string> PrintAsStringList<T>(this T[,] array, int? width = null, (string, string)[]? replacements = null) where T : struct
		=> [.. PrintAsStringArray(array, width, replacements)];


	public static string PrintAsString<T>(this T[,] array, int? width = null, (string, string)[]? replacements = null) where T : struct
		=> string.Join(Environment.NewLine, PrintAsStringArray(array, width, replacements));
}
