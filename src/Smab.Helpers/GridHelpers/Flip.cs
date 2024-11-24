namespace Smab.Helpers;
public static partial class ArrayHelpers {
	public static T[,] FlipHorizontally<T>(this T[,] array) {
		int colsCount = array.ColsCount();
		int rowsCount = array.RowsCount();

		T[,] result = new T[colsCount, rowsCount];

		for (int row = 0; row < rowsCount; row++) {
			for (int col = 0; col < colsCount; col++) {
				result[col, row] = array[colsCount - col - 1, row];
			}
		}

		return result;
	}

	public static T[,] FlipVertically<T>(this T[,] array) {
		int colsCount = array.ColsCount();
		int rowsCount = array.RowsCount();

		T[,] result = new T[colsCount, rowsCount];

		for (int row = 0; row < rowsCount; row++) {
			for (int col = 0; col < colsCount; col++) {
				result[col, row] = array[col, rowsCount - row - 1];
			}
		}

		return result;
	}
}
