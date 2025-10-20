namespace Smab.Helpers;

public static partial class ArrayHelpers {

	extension<T>(T[,] array) {
		/// <summary>
		/// Extracts a subarray from the specified two-dimensional array, starting at the given top-left corner and spanning
		/// the specified number of columns and rows. If the source array does not contain a value for a given position, the
		/// specified default value is used.
		/// </summary>
		/// <remarks>This method allows for safe extraction of a subarray from a two-dimensional array, even if the
		/// specified dimensions extend beyond the bounds of the source array. The <paramref name="init"/> parameter ensures
		/// that the resulting subarray is fully populated, even for out-of-bounds positions.</remarks>
		/// <typeparam name="T">The type of elements in the array.</typeparam>
		/// <param name="array">The source two-dimensional array from which to extract the subarray.</param>
		/// <param name="topLeftCol">The zero-based column index of the top-left corner of the subarray.</param>
		/// <param name="topLeftRow">The zero-based row index of the top-left corner of the subarray.</param>
		/// <param name="noOfCols">The number of columns in the subarray. Must be greater than or equal to 0.</param>
		/// <param name="noOfRows">The number of rows in the subarray. Must be greater than or equal to 0.</param>
		/// <param name="init">The default value to use for positions in the subarray that are outside the bounds of the source array.</param>
		/// <returns>A two-dimensional array containing the extracted subarray. If the specified dimensions exceed the bounds of the
		/// source array, the resulting subarray will contain the specified default value for out-of-bounds positions.</returns>
		public T[,] SubArray(int topLeftCol, int topLeftRow, int noOfCols, int noOfRows, T init = default!) {
			T[,] result = new T[noOfCols, noOfRows];

			foreach ((int col, int row) in result.Indexes()) {
				if (array.TryGetValue(topLeftCol + col, topLeftRow + row, out T value)) {
					result[col, row] = value;
				} else {
					result[col, row] = init;
				}
			}

			return result;
		}

		/// <summary>
		/// Extracts a subarray from the specified two-dimensional array, starting at the given top-left position and spanning
		/// the specified number of columns and rows.
		/// </summary>
		/// <typeparam name="T">The type of elements in the array.</typeparam>
		/// <param name="array">The source two-dimensional array from which the subarray is extracted.</param>
		/// <param name="topLeft">The top-left position in the source array where the subarray begins. The <see cref="Point.X"/> property specifies
		/// the column index, and the <see cref="Point.Y"/> property specifies the row index.</param>
		/// <param name="noOfCols">The number of columns to include in the subarray. Must be greater than or equal to 0.</param>
		/// <param name="noOfRows">The number of rows to include in the subarray. Must be greater than or equal to 0.</param>
		/// <param name="init">The default value used to initialize elements in the subarray that fall outside the bounds of the source array.</param>
		/// <returns>A two-dimensional array containing the extracted subarray. If the specified dimensions exceed the bounds of the
		/// source array, the resulting subarray will be padded with the <paramref name="init"/> value.</returns>
		public T[,] SubArray(Point topLeft, int noOfCols, int noOfRows, T init = default!) {
			return array.SubArray(topLeft.X, topLeft.Y, noOfCols, noOfRows, init);
		}

		/// <summary>
		/// Extracts a subarray from the specified two-dimensional array, defined by the top-left and bottom-right corner
		/// points.
		/// </summary>
		/// <typeparam name="T">The type of elements in the array.</typeparam>
		/// <param name="array">The source two-dimensional array from which the subarray is extracted.</param>
		/// <param name="topLeft">The coordinates of the top-left corner of the subarray.</param>
		/// <param name="bottomRight">The coordinates of the bottom-right corner of the subarray.</param>
		/// <param name="init">The default value used to initialize elements in the subarray if the specified range exceeds the bounds of the
		/// source array.</param>
		/// <returns>A two-dimensional array containing the elements within the specified range. If the range exceeds the bounds of the
		/// source array, the returned subarray will be padded with the <paramref name="init"/> value.</returns>
		public T[,] SubArray(Point topLeft, Point bottomRight, T init = default!) {
			return array.SubArray(topLeft.X, topLeft.Y, bottomRight.X - topLeft.X + 1, bottomRight.Y - topLeft.Y + 1, init);
		}
	}
}