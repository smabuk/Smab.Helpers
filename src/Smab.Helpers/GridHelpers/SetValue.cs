namespace Smab.Helpers;

public static partial class ArrayHelpers {

	extension<T>(Grid<T> grid) {
		/// <summary>
		/// Sets the element at the specified coordinates to the given value.
		/// </summary>
		/// <param name="value">The value to assign.</param>
		/// <param name="x">The zero-based column index.</param>
		/// <param name="y">The zero-based row index.</param>
		public void SetValue(T value, int x, int y) => grid[x, y] = value;

		/// <summary>
		/// Sets the value at the specified coordinates.
		/// </summary>
		/// <param name="value">The value to assign.</param>
		/// <param name="point">A tuple representing the coordinates.</param>
		public void SetValue(T value, (int X, int Y) point) => grid[point.X, point.Y] = value;

		/// <summary>
		/// Sets the value at the specified point.
		/// </summary>
		/// <param name="value">The value to assign.</param>
		/// <param name="point">The point coordinates.</param>
		public void SetValue(T value, Point point) => grid[point.X, point.Y] = value;
	}

	extension<T>(T[,] array) {
		/// <summary>
		/// Sets the element at the specified coordinates to the given value.
		/// </summary>
		/// <param name="value">The value to assign to the element at the specified position.</param>
		/// <param name="x">The zero-based column index of the element to set.</param>
		/// <param name="y">The zero-based row index of the element to set.</param>
		public void SetValue(T value, int x, int y) => array[x, y] = value;

		/// <summary>
		/// Sets the value at the specified two-dimensional point in the array.
		/// </summary>
		/// <param name="value">The value to assign at the specified point.</param>
		/// <param name="point">A tuple representing the coordinates (X, Y) in the array where the value will be set.</param>
		public void SetValue(T value, (int X, int Y) point) => array[point.X, point.Y] = value;

		/// <summary>
		/// Sets the value at the specified position in the two-dimensional array.
		/// </summary>
		/// <param name="value">The value to assign at the specified position.</param>
		/// <param name="point">The coordinates within the array where the value will be set. The X and Y properties must be within the bounds of
		/// the array.</param>
		public void SetValue(T value, Point point) => array[point.X, point.Y] = value;
	}

	extension<T>(T[,,] array) {
		/// <summary>
		/// Sets the value at the specified three-dimensional coordinates within the array.
		/// </summary>
		/// <remarks>Throws an exception if any index is outside the bounds of the array.</remarks>
		/// <param name="value">The value to assign at the specified position.</param>
		/// <param name="x">The zero-based index along the first dimension of the array.</param>
		/// <param name="y">The zero-based index along the second dimension of the array.</param>
		/// <param name="z">The zero-based index along the third dimension of the array.</param>
		public void SetValue(T value, int x, int y, int z) => array[x, y, z] = value;

		/// <summary>
		/// Sets the value at the specified three-dimensional point in the array.
		/// </summary>
		/// <param name="value">The value to assign at the specified point.</param>
		/// <param name="point">A tuple representing the coordinates (X, Y, Z) of the point in the array where the value will be set.</param>
		public void SetValue(T value, (int X, int Y, int Z) point) => array[point.X, point.Y, point.Z] = value;

		/// <summary>
		/// Sets the value at the specified three-dimensional point within the array.
		/// </summary>
		/// <param name="value">The value to assign at the specified location.</param>
		/// <param name="point">The three-dimensional point indicating the position in the array where the value will be set.</param>
		public void SetValue(T value, Point3d point) => array[point.X, point.Y, point.Z] = value;
	}
}
