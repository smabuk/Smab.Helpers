namespace Smab.Helpers;

public static partial class ArrayHelpers {

	public static T[,] Rotate<T>(this T[,] array, int rotation) {
		const int DEG_0   = 0;
		const int DEG_90  = 1;
		const int DEG_180 = 2;
		const int DEG_270 = 3;

		int rotationType = rotation >= 0 ? (rotation / 90) % 360 : ((360 + rotation) / 90) % 360;
		int cols = array.ColsCount();
		int rows = array.RowsCount();

		T[,] result = rotationType switch {
			DEG_0  or DEG_180 => new T[cols, rows],
			DEG_90 or DEG_270 => new T[rows, cols],
			_ => throw new ArgumentOutOfRangeException(nameof(rotation), "Rotation must be a multiple of 90 and be between -360 and 360"),
		};

		int maxCol = result.ColsCount() - 1;
		int maxRow = result.RowsCount() - 1;

		foreach ((int col, int row) in result.Indexes()) {
			result[col, row] = rotationType switch {
				DEG_0   => array[col, row],
				DEG_90  => array[row, maxCol - col],
				DEG_180 => array[maxCol - col, maxRow - row],
				DEG_270 => array[maxRow - row, col],
				_ => throw new ArgumentOutOfRangeException(nameof(rotation), "Rotation must be a multiple of 90 and be between -360 and 360"),
			};
		}
		return result;
	}

	public static IEnumerable<string> Rotate(this IEnumerable<string> array, int rotation)
		=> array.To2dArray().Rotate(rotation).AsStrings();

	public static string Rotate(this string array, int rotation)
		=> array.Split(Environment.NewLine).To2dArray().Rotate(rotation).PrintAsString(0);
}