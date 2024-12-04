namespace Smab.Helpers;

public static partial class ArrayHelpers {

	public static T[,] SubArray<T>(this T[,] array, int topLeftCol, int topLeftRow, int noOfCols, int noOfRows, T init = default!) {
		T[,] result = new T[noOfCols, noOfRows];

		foreach ((int col, int row) in result.Indexes()) {
			if (array.TryGetValue(topLeftCol + col, topLeftRow + row, out T value)) {
				result[col, row] = value;
			} else {
				result[col, row] = init;
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