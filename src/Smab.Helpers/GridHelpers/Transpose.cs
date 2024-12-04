namespace Smab.Helpers;

public static partial class ArrayHelpers {

	public static T[,] Transpose<T>(this T[,] array) {
		int cols = array.ColsCount();
		int rows = array.RowsCount();

		T[,] result = new T[rows, cols];

		foreach ((int col, int row) in array.Indexes()) {
			result[row, col] = array[col, row];
		}

		return result;
	}

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