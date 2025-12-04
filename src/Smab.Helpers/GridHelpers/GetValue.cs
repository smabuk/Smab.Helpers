namespace Smab.Helpers;

public static partial class ArrayHelpers {

	extension<T>(T[,] array) {
		/// <summary>
		/// Retrieves the value stored at the specified coordinates in the two-dimensional array.
		/// </summary>
		/// <param name="x">The zero-based column index of the value to retrieve. Must be within the bounds of the array.</param>
		/// <param name="y">The zero-based row index of the value to retrieve. Must be within the bounds of the array.</param>
		/// <returns>The value of type T located at the specified position in the array.</returns>
		public T GetValue(int x, int y) => array[x, y];

		/// <summary>
		/// Retrieves the value at the specified two-dimensional coordinates.
		/// </summary>
		/// <param name="point">A tuple containing the X and Y coordinates of the element to retrieve. Both values must be within the bounds of
		/// the array.</param>
		/// <returns>The value of type T located at the specified coordinates.</returns>
		public T GetValue((int X, int Y) point) => array[point.X, point.Y];

		/// <summary>
		/// Retrieves the value of type <typeparamref name="T"/> at the specified coordinates.
		/// </summary>
		/// <param name="point">The coordinates within the array from which to retrieve the value. The X and Y properties specify the column and
		/// row indices, respectively.</param>
		/// <returns>The value of type <typeparamref name="T"/> located at the specified point.</returns>
		public T GetValue(Point point) => array[point.X, point.Y];
	}

	extension<T>(T[,,] array) {
		/// <summary>
		/// Retrieves the value stored at the specified three-dimensional coordinates within the array.
		/// </summary>
		/// <param name="x">The zero-based index along the first dimension of the array.</param>
		/// <param name="y">The zero-based index along the second dimension of the array.</param>
		/// <param name="z">The zero-based index along the third dimension of the array.</param>
		/// <returns>The value of type <typeparamref name="T"/> located at the specified coordinates.</returns>
		public T GetValue(int x, int y, int z) => array[x, y, z];

		/// <summary>
		/// Retrieves the value at the specified three-dimensional point in the array.
		/// </summary>
		/// <param name="point">A tuple containing the X, Y, and Z coordinates of the point whose value is to be retrieved.</param>
		/// <returns>The value of type T located at the given coordinates in the array.</returns>
		public T GetValue((int X, int Y, int Z) point) => array[point.X, point.Y, point.Z];

		/// <summary>
		/// Retrieves the value at the specified three-dimensional point within the array.
		/// </summary>
		/// <param name="point">The location in three-dimensional space for which to retrieve the value. The coordinates must be within the bounds
		/// of the array.</param>
		/// <returns>The value of type T stored at the given point in the array.</returns>
		public T GetValue(Point3d point) => array[point.X, point.Y, point.Z];
	}
}
