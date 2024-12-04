namespace Smab.Helpers;

public static partial class ArrayHelpers {

	public static IEnumerable<IEnumerable<T>> Diagonals<T>(this T[,] array)
		=> [.. array.DiagonalsSouthEast(), .. array.DiagonalsSouthWest()];

	public static IEnumerable<IEnumerable<T>> DiagonalsSouthEast<T>(this T[,] array) {
		IEnumerable<T> result = [];
		int iterationEnd = -(int.Max(array.ColsMax(), array.RowsMax()));

		for (int col = array.ColsMax(); col >= iterationEnd; col--) {
			bool stop = false;
			foreach (int row in array.RowIndexes()) {
				if (array.TryGetValue(col + row, row, out T value)) {
					stop = true;
					result =[.. result, value];
				} else if (stop) {
					break;
				}
			}

			yield return result;
			result = [];
		}
	}

	public static IEnumerable<T> DiagonalsSouthEast<T>(this T[,] array, int index)
		=> array.DiagonalsSouthEast().Skip(index).FirstOrDefault([]);

	public static IEnumerable<IEnumerable<T>> DiagonalsSouthWest<T>(this T[,] array) {
		IEnumerable<T> result = [];
		int iterationEnd = int.Max(array.ColsMax(), array.RowsMax()) * 2;

		for (int col = 0; col <= iterationEnd; col++) {
			bool stop = false;
			foreach (int row in array.RowIndexes()) {
				if (array.TryGetValue(col - row, row, out T value)) {
					stop = true;
					result = [.. result, value];
				} else if (stop) {
					break;
				}
			}

			yield return result;
			result = [];
		}
	}

	public static IEnumerable<T> DiagonalsSouthWest<T>(this T[,] array, int index)
		=> array.DiagonalsSouthWest().Skip(index).FirstOrDefault([]);
}
