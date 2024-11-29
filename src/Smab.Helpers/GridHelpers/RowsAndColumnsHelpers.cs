namespace Smab.Helpers;

public static partial class ArrayHelpers {

	public static int ColsCount<T>(this T[,] array) => array.GetLength(COL_DIMENSION);
	public static int RowsCount<T>(this T[,] array) => array.GetLength(ROW_DIMENSION);

	public static int ColsMin<T>(this T[,] array) => array.GetLowerBound(COL_DIMENSION);
	public static int RowsMin<T>(this T[,] array) => array.GetLowerBound(ROW_DIMENSION);

	public static int ColsMax<T>(this T[,] array) => array.GetUpperBound(COL_DIMENSION);
	public static int RowsMax<T>(this T[,] array) => array.GetUpperBound(ROW_DIMENSION);

	public static int XMin<T>(this T[,] array) => array.GetLowerBound(COL_DIMENSION);
	public static int YMin<T>(this T[,] array) => array.GetLowerBound(ROW_DIMENSION);

	public static int XMax<T>(this T[,] array) => array.GetUpperBound(COL_DIMENSION);
	public static int YMax<T>(this T[,] array) => array.GetUpperBound(ROW_DIMENSION);



	public static bool IsInBounds<T>(this T[,] array, int col, int row)
		=> (col >= array.GetLowerBound(COL_DIMENSION) && col <= array.GetUpperBound(COL_DIMENSION))
		&& (row >= array.GetLowerBound(ROW_DIMENSION) && row <= array.GetUpperBound(ROW_DIMENSION));

	public static bool IsInBounds<T>(this T[,] array, (int col, int row) point)
		=> (point.col >= array.GetLowerBound(COL_DIMENSION) && point.col <= array.GetUpperBound(COL_DIMENSION))
		&& (point.row >= array.GetLowerBound(ROW_DIMENSION) && point.row <= array.GetUpperBound(ROW_DIMENSION));


	public static bool IsOutOfBounds<T>(this T[,] array, int col, int row)
		=> !array.IsInBounds(col, row);

	public static bool IsOutOfBounds<T>(this T[,] array, (int col, int row) point) {
		return !array.IsInBounds(point);
	}

	public static bool IsInBounds<T>(this T[,,] array, int x, int y, int z)
		=> (x >= array.GetLowerBound(0) && x <= array.GetUpperBound(0))
		&& (y >= array.GetLowerBound(1) && y <= array.GetUpperBound(1))
		&& (z >= array.GetLowerBound(1) && z <= array.GetUpperBound(2));

	public static bool IsInBounds<T>(this T[,,] array, (int x, int y, int z) point)
		=> (point.x >= array.GetLowerBound(0) && point.x <= array.GetUpperBound(0))
		&& (point.y >= array.GetLowerBound(1) && point.y <= array.GetUpperBound(1))
		&& (point.z >= array.GetLowerBound(2) && point.y <= array.GetUpperBound(2));

	public static bool IsOutOfBounds<T>(this T[,,] array, int x, int y, int z)
		=> !array.IsInBounds(x, y, z);

	public static bool IsOutOfBounds<T>(this T[,,] array, (int x, int y,int z) point) {
		return !array.IsInBounds(point);
	}

	public static string RowAsString<T>(this T[,] array, int rowNo, char? separator = null) {
		StringBuilder stringBuilder = new();
		for (int col = 0; col < array.ColsCount(); col++) {
			if (separator is not null && col != 0) {
				_ = stringBuilder.Append(separator);
			}
			_ = stringBuilder.Append(array[col, rowNo]);
		}
		return stringBuilder.ToString();
	}

	public static string RowAsString(this IEnumerable<string> array, int rowNo) {
		return array.Skip(rowNo).Take(1).Single();
	}




	public static IEnumerable<string> RowsAsStrings<T>(this T[,] array, char? separator = null) {
		StringBuilder stringBuilder = new();
		for (int row = 0; row < array.RowsCount(); row++) {
			for (int col = 0; col < array.ColsCount(); col++) {
				if (separator is not null && row != 0) {
					_ = stringBuilder.Append(separator);
				}
				_ = stringBuilder.Append(array[col, row]);
			}
			yield return stringBuilder.ToString();
			stringBuilder.Clear();
		}
	}



	public static string ColAsString<T>(this T[,] array, int colNo, char? separator = null) {
		StringBuilder stringBuilder = new();
		for (int row = 0; row < array.RowsCount(); row++) {
			if (separator is not null && row != 0) {
				_ = stringBuilder.Append(separator);
			}
			_ = stringBuilder.Append(array[colNo, row]);
		}
		return stringBuilder.ToString();
	}
	public static string ColAsString<T>(this IEnumerable<string> array, int colNo, char? separator = null) {
		List<string> stringArray = [.. array];
		int rows = stringArray.Count;

		StringBuilder stringBuilder = new();
		for (int row = 0; row < rows; row++) {
			if (separator is not null && row != 0) {
				_ = stringBuilder.Append(separator);
			}
			_ = stringBuilder.Append(stringArray[row][colNo]);
		}
		return stringBuilder.ToString();
	}




	public static IEnumerable<string> ColsAsStrings<T>(this T[,] array, char? separator = null) {
		StringBuilder stringBuilder = new();
		for (int col = 0; col < array.ColsCount(); col++) {
			for (int row = 0; row < array.RowsCount(); row++) {
				if (separator is not null && row != 0) {
					_ = stringBuilder.Append(separator);
				}
				_ = stringBuilder.Append(array[col, row]);
			}
			yield return stringBuilder.ToString();
			stringBuilder.Clear();
		}
	}

	public static IEnumerable<string> ColsAsStrings<T>(this IEnumerable<string> array, char? separator = null) {
		List<string> stringArray = [.. array];
		int cols = stringArray[0].Length;
		int rows = stringArray.Count;
		StringBuilder stringBuilder = new();
		for (int col = 0; col < cols; col++) {
			for (int row = 0; row < rows; row++) {
				if (separator is not null && row != 0) {
					_ = stringBuilder.Append(separator);
				}
				_ = stringBuilder.Append(stringArray[row][col]);
			}
			yield return stringBuilder.ToString();
			stringBuilder.Clear();
		}
	}
}