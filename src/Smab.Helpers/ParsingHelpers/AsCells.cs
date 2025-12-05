namespace Smab.Helpers;

public static partial class ParsingHelpers {
	extension(IEnumerable<string> input) {
		/// <summary>
		/// Converts a sequence of strings into a collection of <see cref="Cell{T}"/> objects,  representing the non-empty or
		/// matching characters in a grid-like structure.
		/// </summary>
		/// <remarks>This method processes the input as a 2D grid of characters, where each string in <paramref
		/// name="input"/>  represents a row. The method yields a <see cref="Cell{T}"/> for each character that matches the
		/// specified  criteria (either non-space characters or characters in <paramref name="matches"/>).</remarks>
		/// <param name="input">The sequence of strings to process, where each string represents a row in the grid.</param>
		/// <param name="matches">An optional array of characters to match. If specified, only characters in this array will be included in the
		/// result. If null, all non-space characters will be included.</param>
		/// <param name="cols">An optional number of columns to process. If null, the number of columns is determined by the length of the first
		/// string in <paramref name="input"/>.</param>
		/// <param name="rows">An optional number of rows to process. If null, the number of rows is determined by the total number of strings in
		/// <paramref name="input"/>.</param>
		/// <returns>An enumerable collection of <see cref="Cell{T}"/> objects, where each cell contains the column index, row index, 
		/// and character value of a matching or non-space character in the input.</returns>
		public IEnumerable<Cell<char>> AsCells(char[]? matches = null, int? cols = null, int? rows = null) {
			string[] array = [.. input];
			rows ??= array.Length;
			cols ??= array[0].Length;

			for (int row = 0; row < rows; row++) {
				for (int col = 0; col < cols; col++) {
					if ((matches is null && array[row][col] != ' ')
						|| (matches is not null && matches.Contains(array[row][col]))) {
						yield return new Cell<char>(col, row, array[row][col]);
					}
				}
			}
		}
	}

	extension(string input) {
		/// <summary>
		/// Converts the input string into a sequence of <see cref="Cell{T}"/> objects,  optionally filtering by matching
		/// characters and specifying grid dimensions.
		/// </summary>
		/// <remarks>This method splits the input string by line breaks to form rows and processes each character  into
		/// a <see cref="Cell{T}"/>. The optional parameters allow filtering and customization of  the grid layout.</remarks>
		/// <param name="input">The input string to be converted into cells.</param>
		/// <param name="matches">An optional array of characters to filter the cells. Only cells containing these characters  will be included in
		/// the result. If <see langword="null"/>, all characters are included.</param>
		/// <param name="cols">An optional number of columns to define the grid structure. If <see langword="null"/>,  the number of columns is
		/// determined by the input string.</param>
		/// <param name="rows">An optional number of rows to define the grid structure. If <see langword="null"/>,  the number of rows is
		/// determined by the input string.</param>
		/// <returns>A sequence of <see cref="Cell{T}"/> objects representing the characters in the input string,  arranged in a grid
		/// structure based on the specified dimensions.</returns>
		public IEnumerable<Cell<char>> AsCells(char[]? matches = null, int? cols = null, int? rows = null)
			=> input.Split(Environment.NewLine).AsCells(matches, cols, rows);
	}
}
