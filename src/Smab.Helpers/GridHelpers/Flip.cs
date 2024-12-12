namespace Smab.Helpers;
public static partial class ArrayHelpers {
	public static T[,] FlipHorizontally<T>(this T[,] array) {
		int colsCount = array.ColsCount();
		int rowsCount = array.RowsCount();

		T[,] result = new T[colsCount, rowsCount];

		array.Indexes().ForEach(ix => { result[ix.X, ix.Y] = array[colsCount - ix.X - 1, ix.Y]; });

		return result;
	}

	public static T[,] FlipVertically<T>(this T[,] array) {
		int colsCount = array.ColsCount();
		int rowsCount = array.RowsCount();

		T[,] result = new T[colsCount, rowsCount];

		array.Indexes().ForEach(ix => { result[ix.X, ix.Y] = array[ix.X, rowsCount - ix.Y - 1]; });

		return result;
	}
}
