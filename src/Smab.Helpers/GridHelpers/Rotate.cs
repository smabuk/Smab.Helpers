namespace Smab.Helpers;

public static partial class ArrayHelpers {

	/// <summary>
	/// Rotates a two-dimensional array by the specified angle in degrees.
	/// </summary>
	/// <remarks>The method supports rotations of 0, 90, 180, and 270 degrees (or their negative equivalents). For
	/// example: <list type="bullet"> <item><description>A 90-degree rotation swaps rows and columns, rotating the array
	/// clockwise.</description></item> <item><description>A 180-degree rotation reverses both rows and
	/// columns.</description></item> <item><description>A 270-degree rotation swaps rows and columns, rotating the array
	/// counterclockwise.</description></item> </list></remarks>
	/// <typeparam name="T">The type of elements in the array.</typeparam>
	/// <param name="array">The two-dimensional array to rotate. Cannot be <see langword="null"/>.</param>
	/// <param name="rotation">The angle of rotation in degrees. Must be a multiple of 90 and within the range -360 to 360. Positive values rotate
	/// the array clockwise, while negative values rotate it counterclockwise.</param>
	/// <returns>A new two-dimensional array containing the rotated elements. The dimensions of the returned array depend on the
	/// rotation angle.</returns>
	/// <exception cref="ArgumentOutOfRangeException">Thrown if <paramref name="rotation"/> is not a multiple of 90 or is outside the range -360 to 360.</exception>
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

	/// <summary>
	/// Rotates the elements of a collection of strings by the specified number of degrees.
	/// </summary>
	/// <param name="array">The collection of strings to rotate. Cannot be null.</param>
	/// <param name="rotation">The number of degrees to rotate the collection. A positive value rotates to the right,  while a negative value
	/// rotates to the left.</param>
	/// <returns>A new collection of strings with the elements rotated by the specified number of degrees.</returns>
	public static IEnumerable<string> Rotate(this IEnumerable<string> array, int rotation)
		=> array.To2dArray().Rotate(rotation).AsStrings();

	/// <summary>
	/// Rotates the elements of a 2D representation of the input string by the specified number of degrees.
	/// </summary>
	/// <remarks>The input string is split into lines to form a 2D array, which is then rotated.  The result is
	/// converted back into a string with rows joined by newline characters.</remarks>
	/// <param name="array">The input string, where each line represents a row in a 2D array.</param>
	/// <param name="rotation">The number of degrees clockwise to apply.  Positive values rotate clockwise, while negative values
	/// rotate counterclockwise.</param>
	/// <returns>A string representation of the rotated 2D array, with rows separated by newline characters.</returns>
	public static string Rotate(this string array, int rotation)
		=> array.Split(Environment.NewLine).To2dArray().Rotate(rotation).PrintAsString(0);
}