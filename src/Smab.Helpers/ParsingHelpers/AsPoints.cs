namespace Smab.Helpers;
public static partial class ParsingHelpers {

	extension(IEnumerable<string> input) {
		/// <summary>
		/// Converts a collection of comma-separated string representations of points into a collection of <see cref="Point"/>
		/// objects.
		/// </summary>
		/// <remarks>Each input string is expected to be in the format "x,y", where "x" and "y" are integer values.  The
		/// method splits each string by the comma delimiter and converts the resulting values into a <see cref="Point"/>
		/// object.</remarks>
		/// <param name="input">An enumerable collection of strings, where each string represents a point in the format "x,y".</param>
		/// <returns>An enumerable collection of <see cref="Point"/> objects parsed from the input strings.</returns>
		public IEnumerable<Point> AsPoints() =>
			input.Select(i => i.Split(",")).Select(x => new Point(x[0].As<int>(), x[1].As<int>()));

		/// <summary>
		/// Converts a sequence of strings into a collection of <see cref="Point"/> objects representing the positions of
		/// characters that match a specified value.
		/// </summary>
		/// <remarks>The method treats the input as a grid of characters, where each string in the sequence represents a
		/// row. If <paramref name="cols"/> or <paramref name="rows"/> are specified, the method limits the search to the
		/// specified number of columns and rows, respectively. If not specified, the method defaults to the full size of the
		/// input.</remarks>
		/// <param name="input">The sequence of strings to search. Each string represents a row in a grid-like structure.</param>
		/// <param name="match">The character to search for within the input strings.</param>
		/// <param name="cols">The number of columns to consider in each row. If <see langword="null"/>, the length of the first string in the
		/// input is used.</param>
		/// <param name="rows">The number of rows to consider in the input. If <see langword="null"/>, the total number of strings in the input is
		/// used.</param>
		/// <returns>An enumerable collection of <see cref="Point"/> objects, where each point represents the column and row indices of
		/// a character in the input that matches the specified <paramref name="match"/> character.</returns>
		public IEnumerable<Point> AsPoints(char match, int? cols = null, int? rows = null) {
			string[] array = [.. input];
			rows ??= array.Length;
			cols ??= array[0].Length;

			for (int row = 0; row < rows; row++) {
				for (int col = 0; col < cols; col++) {
					if (array[row][col] == match) {
						yield return new Point(col, row);
					}
				}
			}
		}
	}

	extension(IEnumerable<(int x, int y)> input) {
		/// <summary>
		/// Converts a sequence of tuples representing coordinates into a sequence of <see cref="Point"/> objects.
		/// </summary>
		/// <remarks>This method projects each tuple in the input sequence into a <see cref="Point"/> object, preserving
		/// the order of the input.</remarks>
		/// <param name="input">The sequence of tuples, where each tuple contains the X and Y coordinates as integers.</param>
		/// <returns>An <see cref="IEnumerable{T}"/> of <see cref="Point"/> objects corresponding to the input tuples.</returns>
		public IEnumerable<Point> AsPoints() =>
			input.Select(p => new Point(X: p.x, Y: p.y));
	}

	extension(string input) {
		/// <summary>
		/// Converts the input string into a collection of <see cref="Point"/> objects based on the specified matching
		/// character and optional grid dimensions.
		/// </summary>
		/// <remarks>This method processes the input string as a grid, where each line represents a row. It identifies
		/// the positions of the specified <paramref name="match"/> character and converts them into <see cref="Point"/>
		/// objects, with the X and Y coordinates corresponding to the column and row indices, respectively.</remarks>
		/// <param name="input">The input string to process, typically representing a grid of characters.</param>
		/// <param name="match">The character to match in the input string. Only positions containing this character will be converted to points.</param>
		/// <param name="cols">The optional number of columns in the grid. If not specified, the method infers the column count from the input
		/// string.</param>
		/// <param name="rows">The optional number of rows in the grid. If not specified, the method infers the row count from the input string.</param>
		/// <returns>An enumerable collection of <see cref="Point"/> objects representing the positions in the grid where the <paramref
		/// name="match"/> character is found.</returns>
		public IEnumerable<Point> AsPoints(char match, int? cols = null, int? rows = null)
			=> input.Split(Environment.NewLine).AsPoints(match, cols, rows);
	}
}
