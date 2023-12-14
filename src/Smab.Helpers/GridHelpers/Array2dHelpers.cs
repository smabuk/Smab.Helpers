using System.Text;

namespace Smab.Helpers;

public static partial class ArrayHelpers {

	public static readonly List<(int dX, int dY)> CARDINAL_DIRECTIONS = [( 0, -1), ( 0, 1), (-1, 0), (1,  0)];
	public static readonly List<(int dX, int dY)> ORDINAL_DIRECTIONS  = [(-1, -1), (-1, 1), ( 1, 1), (1, -1)];
	public static readonly List<(int dX, int dY)> ALL_DIRECTIONS = [.. CARDINAL_DIRECTIONS, .. ORDINAL_DIRECTIONS];

	public const int COL_DIMENSION = 0;
	public const int ROW_DIMENSION = 1;

	public static int NoOfColumns<T>(this T[,] array) => array.GetLength(COL_DIMENSION);
	public static int NoOfRows<T>(this T[,] array) => array.GetLength(ROW_DIMENSION);

	public static bool InBounds<T>(this T[,] array, int col, int row) 
		=> (col >= array.GetLowerBound(COL_DIMENSION) && col <= array.GetUpperBound(COL_DIMENSION))
		&& (row >= array.GetLowerBound(ROW_DIMENSION) && row <= array.GetUpperBound(ROW_DIMENSION));

	public static bool OutOfBounds<T>(this T[,] array, int col, int row) 
		=> !array.InBounds(col, row);


	public static string RowAsString<T>(this T[,] array, int rowNo, char? separator = null) {
		StringBuilder stringBuilder = new();
		for (int col = 0; col < array.NoOfColumns(); col++) {
			if (separator is not null && col != 0) {
				_ = stringBuilder.Append(separator);
			}
			_ = stringBuilder.Append(array[col, rowNo]);
		}
		return stringBuilder.ToString();
	}

	public static IEnumerable<string> RowsAsStrings<T>(this T[,] array, char? separator = null) {
		StringBuilder stringBuilder = new();
		for (int row = 0; row < array.NoOfRows(); row++) {
			for (int col = 0; col < array.NoOfColumns(); col++) {
				if (separator is not null && row != 0) {
					_ = stringBuilder.Append(separator);
				}
				_ = stringBuilder.Append(array[col, row]);
			}
			yield return stringBuilder.ToString();
			stringBuilder.Clear();
		}
	}

	public static string ColAsString<T>(this T[,] array, int colNo, char? separator = null) {
		StringBuilder stringBuilder = new();
		for (int row = 0; row < array.NoOfRows(); row++) {
			if (separator is not null && row != 0) {
				_ = stringBuilder.Append(separator);
			}
			_ = stringBuilder.Append(array[colNo, row]);
		}
		return stringBuilder.ToString();
	}
	public static string ColAsString<T>(this IEnumerable<string> array, int colNo, char? separator = null) {
		List<string> stringArray = [.. array];
		int rows = stringArray.Count;

		StringBuilder stringBuilder = new();
		for (int row = 0; row < rows; row++) {
			if (separator is not null && row != 0) {
				_ = stringBuilder.Append(separator);
			}
			_ = stringBuilder.Append(stringArray[row][colNo]);
		}
		return stringBuilder.ToString();
	}


	public static IEnumerable<string> ColsAsStrings<T>(this T[,] array, char? separator = null) {
		StringBuilder stringBuilder = new();
		for (int col = 0; col < array.NoOfColumns(); col++) {
			for (int row = 0; row < array.NoOfRows(); row++) {
				if (separator is not null && row != 0) {
					_ = stringBuilder.Append(separator);
				}
				_ = stringBuilder.Append(array[col, row]);
			}
			yield return stringBuilder.ToString();
			stringBuilder.Clear();
		}
	}

	public static IEnumerable<string> ColsAsStrings<T>(this IEnumerable<string> array, char? separator = null) {
		List<string> stringArray = [.. array];
		int cols = stringArray[0].Length;
		int rows = stringArray.Count;
		StringBuilder stringBuilder = new();
		for (int col = 0; col < cols; col++) {
			for (int row = 0; row < rows; row++) {
				if (separator is not null && row != 0) {
					_ = stringBuilder.Append(separator);
				}
				_ = stringBuilder.Append(stringArray[row][col]);
			}
			yield return stringBuilder.ToString();
			stringBuilder.Clear();
		}
	}

	public static T[,] Create2dArray<T>(int cols, int rows, T value) {
		T[,] result = new T[cols, rows];
		for (int row = 0; row < rows; row++) {
			for (int col = 0; col < cols; col++) {
				result[col, row] = value;
			}
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
		for (int r = 0; r <= array.GetUpperBound(ROW_DIMENSION); r++) {
			line.Clear();
			for (int c = 0; c <= array.GetUpperBound(COL_DIMENSION); c++) {
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
