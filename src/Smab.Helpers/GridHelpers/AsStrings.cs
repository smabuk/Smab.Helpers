namespace Smab.Helpers;

public static partial class ArrayHelpers {

	/// <summary>
	/// 
	/// </summary>
	/// <typeparam name="T"></typeparam>
	/// <param name="array"></param>
	/// <param name="replacements"></param>
	/// <returns></returns>
	public static IEnumerable<string> AsStrings<T>(this T[,] array, params IEnumerable<(string, string)> replacements) where T : struct {
		StringBuilder line = new();
		for (int r = 0; r <= array.GetUpperBound(ROW_DIMENSION); r++) {
			line.Clear();
			for (int c = 0; c <= array.GetUpperBound(COL_DIMENSION); c++) {
				string cell = array[c, r].ToString() ?? "";
				line.Append(cell);
			}
			if (replacements is not null) {
				foreach ((string from, string to) in replacements) {
					line = line.Replace(from, to);
				}
			}
			yield return line.ToString();
		}
	}

	public static string AsStringWithNewLines<T>(this T[,] array, params IEnumerable<(string, string)> replacements) where T : struct
		=> string.Join(Environment.NewLine, AsStrings(array, replacements));

	public static string AsString<T>(this T[,] array, string? separator = "", params IEnumerable<(string, string)> replacements) where T : struct
		=> string.Join(separator, AsStrings(array, replacements));



	public static string RowAsString<T>(this T[,] array, int rowNo, char? separator = null) {
		StringBuilder stringBuilder = new();
		for (int col = 0; col < array.ColsCount(); col++) {
			if (separator is not null && col != 0) {
				_ = stringBuilder.Append(separator);
			}
			_ = stringBuilder.Append(array[col, rowNo]);
		}
		return stringBuilder.ToString();
	}

	public static string RowAsString(this IEnumerable<string> array, int rowNo) {
		return array.Skip(rowNo).Take(1).Single();
	}




	public static IEnumerable<string> RowsAsStrings<T>(this T[,] array, char? separator = null) {
		StringBuilder stringBuilder = new();
		for (int row = 0; row < array.RowsCount(); row++) {
			for (int col = 0; col < array.ColsCount(); col++) {
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
		for (int row = 0; row < array.RowsCount(); row++) {
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
		for (int col = 0; col < array.ColsCount(); col++) {
			for (int row = 0; row < array.RowsCount(); row++) {
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

	public static IEnumerable<string> DiagonalsSouthEastAsStrings(this char[,] array) {
		StringBuilder stringBuilder = new();

		for (int col = array.ColsMax(); col > -array.ColsMax(); col--) {
			bool stop = false;
			for (int row = 0; row < array.RowsCount(); row++) {
				if (array.TryGetValue(col + row, row, out char c)) {
					stop = true;
					_ = stringBuilder.Append(c);
				} else if (stop) {
					break;
				}
			}

			yield return stringBuilder.ToString();
			_ = stringBuilder.Clear();
		}
	}

	public static IEnumerable<string> DiagonalsSouthWestAsStrings(this char[,] array) {
		StringBuilder stringBuilder = new();

		for (int col = 0; col < array.ColsCount() * 2; col++) {
			bool stop = false;
			for (int row = 0; row < array.RowsCount(); row++) {
				if (array.TryGetValue(col - row, row, out char c)) {
					stop = true;
					_ = stringBuilder.Append(c);
				} else if (stop) {
					break;
				}
			}

			yield return stringBuilder.ToString();
			_ = stringBuilder.Clear();
		}
	}

}
