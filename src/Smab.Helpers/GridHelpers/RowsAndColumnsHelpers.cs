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
}