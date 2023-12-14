namespace Smab.Helpers;

public static partial class ArrayHelpers {

	public static T[,] Create2dArray<T>(int cols, int rows, T value) {
		T[,] result = new T[cols, rows];

		for (int row = 0; row < rows; row++) {
		for (int col = 0; col < cols; col++) {
			result[col, row] = value;
		}}

		return result;
	}
}
