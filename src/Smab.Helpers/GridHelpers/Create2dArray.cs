namespace Smab.Helpers;

public static partial class ArrayHelpers {

	public static T[,] Create2dArray<T>(int cols, int rows, T value)
		=> (new T[cols, rows]).Fill(value);

	public static T[,] Create2dArray<T>(int cols, int rows, int colLowerBound, int rowLowerBound, T value)
		=> ((T[,])Array.CreateInstance(typeof(T), [cols, rows], [colLowerBound, rowLowerBound])).Fill(value);
}
