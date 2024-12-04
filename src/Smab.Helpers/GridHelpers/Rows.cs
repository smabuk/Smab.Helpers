namespace Smab.Helpers;

public static partial class ArrayHelpers {
	public static IEnumerable<T> Row<T>(this T[,] array, int rowNo)
		=> array.ColIndexes().Select(col => array[col, rowNo]);

	public static IEnumerable<IEnumerable<T>> Rows<T>(this T[,] array)
		=> array.RowIndexes().Select(ix => array.Row(ix));
}
