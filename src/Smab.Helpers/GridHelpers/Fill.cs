namespace Smab.Helpers;
public static partial class ArrayHelpers {
	public static T[,] Fill<T>(this T[,] array, T value) {
		T[,] result = array;

		array.Indexes().ForEach(ix => result[ix.X, ix.Y] = value);

		return result;
	}
}
