namespace Smab.Helpers;
public static partial class ArrayHelpers {
	public static T[,] Fill<T>(this T[,] array, T value) {
		int colLowerBound = array.GetLowerBound(COL_DIMENSION);
		int colUpperBound = array.GetUpperBound(COL_DIMENSION);

		int rowLowerBound = array.GetLowerBound(ROW_DIMENSION);
		int rowUpperBound = array.GetUpperBound(ROW_DIMENSION);

		T[,] result = array;

		for (int row = rowLowerBound; row <= rowUpperBound; row++) {
			for (int col = colLowerBound; col <= colUpperBound; col++) {
				result[col, row] = value;
			}
		}

		return result;
	}
}
