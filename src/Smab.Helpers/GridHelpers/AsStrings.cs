namespace Smab.Helpers;

public static partial class ArrayHelpers {

	extension<T>(T[,] array) where T : struct {
		/// <summary>
		/// Converts a two-dimensional array of value types into an enumerable sequence of strings,  with optional replacements
		/// applied to the resulting strings.
		/// </summary>
		/// <remarks>Each row of the array is processed from left to right, and the elements are concatenated into a
		/// single string.  If <paramref name="replacements"/> is provided, the specified replacements are applied to each
		/// resulting string.</remarks>
		/// <typeparam name="T">The type of the elements in the array. Must be a value type.</typeparam>
		/// <param name="array">The two-dimensional array to convert. Each row of the array is transformed into a string.</param>
		/// <param name="replacements">An optional collection of replacement pairs, where each tuple specifies a substring to replace  and its replacement
		/// value. These replacements are applied to each row string in the order they appear.</param>
		/// <returns>An <see cref="IEnumerable{T}"/> of strings, where each string represents a row of the array.</returns>
		public IEnumerable<string> AsStrings(params IEnumerable<(string, string)> replacements) {
			StringBuilder line = new();
			foreach (int r in array.RowIndexes()) {
				line.Clear();
				foreach (int c in array.ColIndexes()) {
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

		/// <summary>
		/// Converts a two-dimensional array into a single string with rows separated by new lines.
		/// </summary>
		/// <typeparam name="T">The type of the elements in the array. Must be a value type.</typeparam>
		/// <param name="array">The two-dimensional array to convert.</param>
		/// <param name="replacements">Optional replacements to apply to the resulting strings.</param>
		/// <returns>A single string with rows separated by new lines.</returns>
		public string AsStringWithNewLines(params IEnumerable<(string, string)> replacements) => string.Join(Environment.NewLine, AsStrings(array, replacements));

		/// <summary>
		/// Converts a two-dimensional array into a single string with elements separated by a specified separator.
		/// </summary>
		/// <typeparam name="T">The type of the elements in the array. Must be a value type.</typeparam>
		/// <param name="array">The two-dimensional array to convert.</param>
		/// <param name="separator">The separator to use between elements.</param>
		/// <param name="replacements">Optional replacements to apply to the resulting strings.</param>
		/// <returns>A single string with elements separated by the specified separator.</returns>
		public string AsString(string? separator = "", params IEnumerable<(string, string)> replacements) => string.Join(separator, AsStrings(array, replacements));
	}

	extension<T>(T[,] array) {
		/// <summary>
		/// Converts a specific row of a two-dimensional array into a string.
		/// </summary>
		/// <typeparam name="T">The type of the elements in the array. Must be a value type.</typeparam>
		/// <param name="array">The two-dimensional array.</param>
		/// <param name="rowNo">The row number to convert.</param>
		/// <param name="separator">Optional separator to use between elements in the row.</param>
		/// <returns>A string representation of the specified row.</returns>
		public string RowAsString(int rowNo, char? separator = null)
			=> string.Join(separator is null ? "" : $"{separator}", array.Row(rowNo).Select(v => $"{v}"));

		/// <summary>
		/// Converts all rows of a two-dimensional array into an enumerable sequence of strings.
		/// </summary>
		/// <typeparam name="T">The type of the elements in the array. Must be a value type.</typeparam>
		/// <param name="array">The two-dimensional array to convert.</param>
		/// <param name="separator">Optional separator to use between elements in each row.</param>
		/// <returns>An enumerable sequence of strings representing the rows of the array.</returns>
		public IEnumerable<string> RowsAsStrings(char? separator = null) {
			StringBuilder stringBuilder = new();
			foreach (int row in array.RowIndexes()) {
				foreach (int col in array.ColIndexes()) {
					if (separator is not null && row != 0) {
						_ = stringBuilder.Append(separator);
					}
					_ = stringBuilder.Append(array[col, row]);
				}
				yield return stringBuilder.ToString();
				stringBuilder.Clear();
			}
		}

		/// <summary>
		/// Converts a specific column of a two-dimensional array into a string.
		/// </summary>
		/// <typeparam name="T">The type of the elements in the array. Must be a value type.</typeparam>
		/// <param name="array">The two-dimensional array.</param>
		/// <param name="colNo">The column number to convert.</param>
		/// <param name="separator">Optional separator to use between elements in the column.</param>
		/// <returns>A string representation of the specified column.</returns>
		public string ColAsString(int colNo, char? separator = null)
			=> string.Join(separator is null ? "" : $"{separator}", array.Col(colNo).Select(v => $"{v}"));

		/// <summary>
		/// Converts all columns of a two-dimensional array into an enumerable sequence of strings.
		/// </summary>
		/// <typeparam name="T">The type of the elements in the array. Must be a value type.</typeparam>
		/// <param name="array">The two-dimensional array to convert.</param>
		/// <param name="separator">Optional separator to use between elements in each column.</param>
		/// <returns>An enumerable sequence of strings representing the columns of the array.</returns>
		public IEnumerable<string> ColsAsStrings(char? separator = null) {
			StringBuilder stringBuilder = new();
			foreach (int col in array.ColIndexes()) {
				foreach (int row in array.RowIndexes()) {
					if (separator is not null && row != 0) {
						_ = stringBuilder.Append(separator);
					}
					_ = stringBuilder.Append(array[col, row]);
				}
				yield return stringBuilder.ToString();
				stringBuilder.Clear();
			}
		}
	}

	extension(IEnumerable<string> array) {
		/// <summary>
		/// Retrieves a specific row from an enumerable sequence of strings.
		/// </summary>
		/// <param name="array">The enumerable sequence of strings.</param>
		/// <param name="rowNo">The row number to retrieve.</param>
		/// <returns>The string representation of the specified row.</returns>
		public string RowAsString(int rowNo) {
			return array.Skip(rowNo).Take(1).Single();
		}

		/// <summary>
		/// Converts a specific column from an enumerable sequence of strings into a single string.
		/// </summary>
		/// <typeparam name="T">The type of the elements in the array.</typeparam>
		/// <param name="array">The enumerable sequence of strings.</param>
		/// <param name="colNo">The column number to convert.</param>
		/// <param name="separator">Optional separator to use between elements in the column.</param>
		/// <returns>A string representation of the specified column.</returns>
		public string ColAsString<T>(int colNo, char? separator = null) {
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

		/// <summary>
		/// Converts all columns from an enumerable sequence of strings into an enumerable sequence of strings.
		/// </summary>
		/// <typeparam name="T">The type of the elements in the array.</typeparam>
		/// <param name="array">The enumerable sequence of strings.</param>
		/// <param name="separator">Optional separator to use between elements in each column.</param>
		/// <returns>An enumerable sequence of strings representing the columns.</returns>
		public IEnumerable<string> ColsAsStrings<T>(char? separator = null) {
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
	}

	extension(char[,] array) {
		/// <summary>
		/// Converts all diagonals running southeast in a two-dimensional character array into an enumerable sequence of strings.
		/// </summary>
		/// <param name="array">The two-dimensional character array.</param>
		/// <returns>An enumerable sequence of strings representing the southeast diagonals.</returns>
		public IEnumerable<string> DiagonalsSouthEastAsStrings()
			=> array.DiagonalsSouthEast().Select(row => string.Join("", row));

		/// <summary>
		/// Converts all diagonals running southwest in a two-dimensional character array into an enumerable sequence of strings.
		/// </summary>
		/// <param name="array">The two-dimensional character array.</param>
		/// <returns>An enumerable sequence of strings representing the southwest diagonals.</returns>
		public IEnumerable<string> DiagonalsSouthWestAsStrings()
			=> array.DiagonalsSouthWest().Select(row => string.Join("", row));
	}
}
