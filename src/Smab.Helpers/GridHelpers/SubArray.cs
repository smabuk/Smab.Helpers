namespace Smab.Helpers;

public static partial class ArrayHelpers {

	public static T[,] SubArray<T>(this T[,] array, int topLeftCol, int topLeftRow, int noOfCols, int noOfRows, T init = default!) {
		T[,] result = new T[noOfCols, noOfRows];

		for (int row = 0; row < noOfRows; row++) {
			for (int col = 0; col < noOfCols; col++) {
				if (array.TryGetValue(topLeftCol + col, topLeftRow + row, out T value)) {
					result[col, row] = value;
				} else {
					result[col, row] = init;
				}
			}
		}

		return result;
	}

	public static T[,] SubArray<T>(this T[,] array, Point topLeft, int noOfCols, int noOfRows, T init = default!) {
		return array.SubArray(topLeft.X, topLeft.Y, noOfCols, noOfRows, init);
	}

	public static T[,] SubArray<T>(this T[,] array, Point topLeft, Point bottomRight, T init = default!) {
		return array.SubArray(topLeft.X, topLeft.Y, bottomRight.X - topLeft.X + 1, bottomRight.Y - topLeft.Y + 1, init);
	}
}