namespace Smab.Helpers;

public static partial class ArrayHelpers {
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
	public static IEnumerable<string> PrintAsStringArray<T>(this T[,] array, int width = 0, (string, string)[]? replacements = null) where T : struct {
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
	public static List<string> PrintAsStringList<T>(this T[,] array, int width = 0, (string, string)[]? replacements = null) where T : struct
		=> [.. PrintAsStringArray(array, width, replacements)];

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
	public static string PrintAsString<T>(this T[,] array, int width = 0, (string, string)[]? replacements = null) where T : struct
		=> string.Join(Environment.NewLine, PrintAsStringArray(array, width, replacements));
}
