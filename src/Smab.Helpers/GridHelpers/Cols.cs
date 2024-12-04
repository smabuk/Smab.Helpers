namespace Smab.Helpers;

public static partial class ArrayHelpers {
	public static IEnumerable<T> Col<T>(this T[,] array, int colNo)
		=> array.RowIndexes().Select(row => array[colNo, row]);

	public static IEnumerable<IEnumerable<T>> Cols<T>(this T[,] array)
		=> array.ColIndexes().Select(ix => array.Col(ix));
}
