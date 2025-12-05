namespace Smab.Helpers;

public static partial class ArrayHelpers {
	extension<T>(Grid<T> grid) where T : struct {
		/// <summary>
		/// Converts the grid of value types into a sequence of formatted strings, with optional column width
		/// alignment and text replacements.
		/// </summary>
		/// <typeparam name="T">The type of the elements in the grid. Must be a value type.</typeparam>
		/// <param name="grid">The grid to process.</param>
		/// <param name="width">The minimum width of each column in the output. Defaults to 0, meaning no padding is applied.</param>
		/// <param name="replacements">An optional array of string replacement pairs.</param>
		/// <returns>An enumerable sequence of strings, where each string represents a row of the grid.</returns>
		public IEnumerable<string> PrintAsStringArray(int width = 0, (string, string)[]? replacements = null) {
			StringBuilder line = new();
			for (int r = 0; r < grid.RowsCount; r++) {
				line.Clear();
				for (int c = 0; c < grid.ColsCount; c++) {
					string cell = grid[c, r].ToString() ?? "";
					line.Append(width switch {
						0 => cell,
						_ => $"{new string(' ', (width - cell.Length))}{cell}",
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

		/// <summary>
		/// Converts the grid of value types into a list of strings, with optional formatting and replacements applied.
		/// </summary>
		/// <typeparam name="T">The type of the elements in the grid. Must be a value type.</typeparam>
		/// <param name="grid">The grid to be converted.</param>
		/// <param name="width">The minimum width of each element in the resulting strings. Defaults to 0.</param>
		/// <param name="replacements">An optional array of tuples specifying string replacements to apply.</param>
		/// <returns>A list of strings where each string represents a row of the grid.</returns>
		public List<string> PrintAsStringList(int width = 0, (string, string)[]? replacements = null) => [.. grid.PrintAsStringArray(width, replacements)];

		/// <summary>
		/// Converts the grid of value types into a formatted string representation.
		/// </summary>
		/// <typeparam name="T">The type of the elements in the grid. Must be a value type.</typeparam>
		/// <param name="grid">The grid to format as a string.</param>
		/// <param name="width">The minimum width of each element in the output. Defaults to 0.</param>
		/// <param name="replacements">An optional array of tuples specifying string replacements to apply to the formatted output.</param>
		/// <returns>A string containing the formatted representation of the grid, with rows separated by line breaks.</returns>
		public string PrintAsString(int width = 0, (string, string)[]? replacements = null) => string.Join(Environment.NewLine, grid.PrintAsStringArray(width, replacements));

		/// <summary>
		/// Converts the grid of value types into an enumerable sequence of strings, with optional replacements applied.
		/// </summary>
		/// <typeparam name="T">The type of the elements in the grid. Must be a value type.</typeparam>
		/// <param name="grid">The grid to convert.</param>
		/// <param name="replacements">Optional replacements to apply to the resulting strings.</param>
		/// <returns>An enumerable sequence of strings, where each string represents a row of the grid.</returns>
		public IEnumerable<string> AsStrings(params IEnumerable<(string, string)> replacements) {
			StringBuilder line = new();
			foreach (int r in grid.RowIndexes()) {
				line.Clear();
				foreach (int c in grid.ColIndexes()) {
					string cell = grid[c, r].ToString() ?? "";
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
		/// Converts the grid into a single string with rows separated by new lines.
		/// </summary>
		/// <typeparam name="T">The type of the elements in the grid. Must be a value type.</typeparam>
		/// <param name="grid">The grid to convert.</param>
		/// <param name="replacements">Optional replacements to apply to the resulting strings.</param>
		/// <returns>A single string with rows separated by new lines.</returns>
		public string AsStringWithNewLines(params IEnumerable<(string, string)> replacements) => string.Join(Environment.NewLine, grid.AsStrings(replacements));

		/// <summary>
		/// Converts the grid into a single string with elements separated by a specified separator.
		/// </summary>
		/// <typeparam name="T">The type of the elements in the grid. Must be a value type.</typeparam>
		/// <param name="grid">The grid to convert.</param>
		/// <param name="separator">The separator to use between elements.</param>
		/// <param name="replacements">Optional replacements to apply to the resulting strings.</param>
		/// <returns>A single string with elements separated by the specified separator.</returns>
		public string AsString(string? separator = "", params IEnumerable<(string, string)> replacements) => string.Join(separator, grid.AsStrings(replacements));
	}

	extension<T>(Grid<T> grid) {
		/// <summary>
		/// Converts a specific row of the grid into a string.
		/// </summary>
		/// <typeparam name="T">The type of the elements in the grid.</typeparam>
		/// <param name="grid">The grid.</param>
		/// <param name="rowNo">The row number to convert.</param>
		/// <param name="separator">Optional separator to use between elements in the row.</param>
		/// <returns>A string representation of the specified row.</returns>
		public string RowAsString(int rowNo, char? separator = null)
			=> string.Join(separator is null ? "" : $"{separator}", grid.Row(rowNo).Select(v => $"{v}"));

		/// <summary>
		/// Converts all rows of the grid into an enumerable sequence of strings.
		/// </summary>
		/// <typeparam name="T">The type of the elements in the grid.</typeparam>
		/// <param name="grid">The grid to convert.</param>
		/// <param name="separator">Optional separator to use between elements in each row.</param>
		/// <returns>An enumerable sequence of strings representing the rows of the grid.</returns>
		public IEnumerable<string> RowsAsStrings(char? separator = null) {
			StringBuilder stringBuilder = new();
			foreach (int row in grid.RowIndexes()) {
				foreach (int col in grid.ColIndexes()) {
					if (separator is not null && row != 0) {
						_ = stringBuilder.Append(separator);
					}
					_ = stringBuilder.Append(grid[col, row]);
				}
				yield return stringBuilder.ToString();
				stringBuilder.Clear();
			}
		}

		/// <summary>
		/// Converts a specific column of the grid into a string.
		/// </summary>
		/// <typeparam name="T">The type of the elements in the grid.</typeparam>
		/// <param name="grid">The grid.</param>
		/// <param name="colNo">The column number to convert.</param>
		/// <param name="separator">Optional separator to use between elements in the column.</param>
		/// <returns>A string representation of the specified column.</returns>
		public string ColAsString(int colNo, char? separator = null)
			=> string.Join(separator is null ? "" : $"{separator}", grid.Col(colNo).Select(v => $"{v}"));

		/// <summary>
		/// Converts all columns of the grid into an enumerable sequence of strings.
		/// </summary>
		/// <typeparam name="T">The type of the elements in the grid.</typeparam>
		/// <param name="grid">The grid to convert.</param>
		/// <param name="separator">Optional separator to use between elements in each column.</param>
		/// <returns>An enumerable sequence of strings representing the columns of the grid.</returns>
		public IEnumerable<string> ColsAsStrings(char? separator = null) {
			StringBuilder stringBuilder = new();
			foreach (int col in grid.ColIndexes()) {
				foreach (int row in grid.RowIndexes()) {
					if (separator is not null && row != 0) {
						_ = stringBuilder.Append(separator);
					}
					_ = stringBuilder.Append(grid[col, row]);
				}
				yield return stringBuilder.ToString();
				stringBuilder.Clear();
			}
		}
	}

	extension<T>(T[,] array) where T : struct {
		/// <summary>
		/// Converts a two-dimensional array of value types into a sequence of formatted strings,  with optional column width
		/// alignment and text replacements.
		/// </summary>
		/// <remarks>This method processes the array row by row, converting each element to its string representation
		/// and applying optional formatting. The output can be used for display or logging purposes.</remarks>
		/// <typeparam name="T">The type of the elements in the array. Must be a value type.</typeparam>
		/// <param name="array">The two-dimensional array to process. Each element will be converted to its string representation.</param>
		/// <param name="width">The minimum width of each column in the output. If greater than 0, each cell will be padded with  leading spaces to
		/// meet the specified width. Defaults to 0, meaning no padding is applied.</param>
		/// <param name="replacements">An optional array of string replacement pairs. Each tuple specifies a substring to replace  (the first item) and
		/// its replacement value (the second item). If provided, these replacements  will be applied to each line of the
		/// output.</param>
		/// <returns>An enumerable sequence of strings, where each string represents a row of the input array,  formatted according to
		/// the specified width and replacements.</returns>
		public IEnumerable<string> PrintAsStringArray(int width = 0, (string, string)[]? replacements = null) {
			StringBuilder line = new();
			for (int r = 0; r <= array.GetUpperBound(ROW_DIMENSION); r++) {
				line.Clear();
				for (int c = 0; c <= array.GetUpperBound(COL_DIMENSION); c++) {
					string cell = array[c, r].ToString() ?? "";
					line.Append(width switch {
						0 => cell,
						_ => $"{new string(' ', (width - cell.Length))}{cell}",
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

		/// <summary>
		/// Converts a two-dimensional array of value types into a list of strings,  with optional formatting and replacements
		/// applied.
		/// </summary>
		/// <remarks>This method is an extension method for two-dimensional arrays of value types.  It provides a
		/// convenient way to represent the array as a list of strings,  with optional formatting for alignment and string
		/// replacements for customization.</remarks>
		/// <typeparam name="T">The type of the elements in the array. Must be a value type.</typeparam>
		/// <param name="array">The two-dimensional array to be converted. Cannot be null.</param>
		/// <param name="width">The minimum width of each element in the resulting strings.  If set to 0, no padding is applied. Defaults to 0.</param>
		/// <param name="replacements">An optional array of tuples specifying string replacements to apply.  Each tuple contains a target string and its
		/// replacement.  If null, no replacements are applied.</param>
		/// <returns>A list of strings where each string represents a row of the array,  formatted according to the specified width and
		/// replacements.</returns>
		public List<string> PrintAsStringList(int width = 0, (string, string)[]? replacements = null) => [.. PrintAsStringArray(array, width, replacements)];

		/// <summary>
		/// Converts a two-dimensional array of value types into a formatted string representation.
		/// </summary>
		/// <remarks>This method formats the array into a human-readable string, with optional padding and string
		/// replacements. The output is suitable for display or logging purposes.</remarks>
		/// <typeparam name="T">The type of the elements in the array. Must be a value type.</typeparam>
		/// <param name="array">The two-dimensional array to format as a string. Cannot be null.</param>
		/// <param name="width">The minimum width of each element in the output. If set to 0, no padding is applied.</param>
		/// <param name="replacements">An optional array of tuples specifying string replacements to apply to the formatted output. Each tuple consists of
		/// a target string and its replacement.</param>
		/// <returns>A string containing the formatted representation of the array, with rows separated by line breaks.</returns>
		public string PrintAsString(int width = 0, (string, string)[]? replacements = null) => string.Join(Environment.NewLine, PrintAsStringArray(array, width, replacements));
	}
}
