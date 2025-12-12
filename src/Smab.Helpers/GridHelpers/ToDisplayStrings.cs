namespace Smab.Helpers;

public static partial class ArrayHelpers {

	extension<T>(Grid<T> grid) {
		/// <summary>
		/// Returns an enumerable collection of strings representing each row of the grid, with optional cell value
		/// replacements applied.
		/// </summary>
		/// <remarks>If no replacements are provided, the method returns the grid's rows as strings without
		/// modification. If multiple replacements are specified for the same original value, the last occurrence is
		/// used.</remarks>
		/// <param name="replacements">A variable-length array of enumerable collections containing pairs of original cell values and their corresponding
		/// replacement strings. If a cell's value matches an original value, it is replaced with the specified replacement in
		/// the output.</param>
		/// <returns>An enumerable collection of strings, each representing a row of the grid with replacements applied. Each string
		/// contains the concatenated cell values for a single row.</returns>
		public IEnumerable<string> ToDisplayStrings(params IEnumerable<(string, string)> replacements) {
			StringBuilder line = new();
			Dictionary<string, string> replacementsLookup = [];
			foreach ((string key, string value) in replacements) {
				replacementsLookup[key] = value; // Allows overwriting, last one wins
			}
			foreach (int r in grid.RowIndexes()) {
				line.Clear();
				foreach (int c in grid.ColIndexes()) {
					string cell = grid[c, r]?.ToString() ?? "";
					if (replacementsLookup.TryGetValue(cell, out string? replacement)) {
						cell = replacement;
					}
					line.Append(cell);
				}
				yield return line.ToString();
			}
		}

		/// <summary>
		/// Returns a string representation of the grid with each row separated by a new line, applying the specified
		/// replacements to the display output.
		/// </summary>
		/// <param name="replacements">A set of replacement pairs to apply to the display strings. Each tuple consists of the value to be replaced and
		/// its replacement. If no replacements are provided, the original display values are used.</param>
		/// <returns>A string containing the display representation of the grid, with each row on a separate line and replacements
		/// applied as specified.</returns>
		public string ToDisplayStringWithNewLines(params IEnumerable<(string, string)> replacements) => string.Join(Environment.NewLine, ToDisplayStrings(grid, replacements));

		/// <summary>
		/// Creates a string representation of the grid, joining each element's display string using the specified separator
		/// and applying the provided replacements.
		/// </summary>
		/// <param name="separator">The string to use as a separator between elements in the resulting display string. If null, an empty string is
		/// used.</param>
		/// <param name="replacements">A set of key-value pairs specifying substrings to replace in each element's display string. Each tuple contains
		/// the substring to find and its replacement.</param>
		/// <returns>A string that represents the grid, with each element's display string joined by the specified separator and
		/// replacements applied.</returns>
		public string ToDisplayString(string? separator = "", params IEnumerable<(string, string)> replacements) => string.Join(separator, ToDisplayStrings(grid, replacements));
	}
}
