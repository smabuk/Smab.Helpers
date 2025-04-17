namespace Smab.Helpers;

public static partial class ArrayHelpers {

	/// <summary>
	/// Transposes the specified two-dimensional array, swapping its rows and columns.
	/// </summary>
	/// <remarks>The resulting array will have the number of rows and columns swapped compared to the input array.
	/// For example, if the input array has dimensions [m, n], the returned array will have dimensions [n, m].</remarks>
	/// <typeparam name="T">The type of elements in the array.</typeparam>
	/// <param name="array">The two-dimensional array to transpose. Cannot be <see langword="null"/>.</param>
	/// <returns>A new two-dimensional array where the rows and columns of the input array are swapped.</returns>
	public static T[,] Transpose<T>(this T[,] array) {
		int cols = array.ColsCount();
		int rows = array.RowsCount();

		T[,] result = new T[rows, cols];

		foreach ((int col, int row) in array.Indexes()) {
			result[row, col] = array[col, row];
		}

		return result;
	}

	/// <summary>
	/// Transposes a collection of strings, swapping rows and columns.
	/// </summary>
	/// <remarks>This method assumes that all strings in the input collection have the same length. If the input
	/// collection contains strings of varying lengths, the behavior is undefined. The method processes the input lazily, 
	/// generating each transposed row on demand.</remarks>
	/// <param name="array">The collection of strings to transpose. Each string in the collection must have the same length.</param>
	/// <returns>An enumerable collection of strings where each string represents a column from the original input as a row.</returns>
	public static IEnumerable<string> Transpose(this IEnumerable<string> array) {
		List<string> stringArray = [.. array];
		int cols = stringArray[0].Length;
		int rows = stringArray.Count;

		StringBuilder stringBuilder = new();
		for (int col = 0; col < cols; col++) {
			for (int row = 0; row < rows; row++) {
				_ = stringBuilder.Append(stringArray[row][col]);
			}
			yield return stringBuilder.ToString();
			stringBuilder.Clear();
		}
	}
}