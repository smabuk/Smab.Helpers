namespace Smab.Helpers;

public static partial class ArrayHelpers {

	extension<T>(Grid<T> grid) {
		/// <summary>
		/// Attempts to set the value at the specified coordinates.
		/// </summary>
		/// <param name="x">The zero-based column index.</param>
		/// <param name="y">The zero-based row index.</param>
		/// <param name="value">The value to assign.</param>
		/// <returns>true if the value was set successfully; otherwise, false.</returns>
		public bool TrySetValue(int x, int y, T value) {
			if (grid.IsOutOfBounds(x, y)) {
				return false;
			}
			grid[x, y] = value;
			return true;
		}

		/// <summary>
		/// Attempts to set the value at the specified point.
		/// </summary>
		/// <param name="point">The coordinates as a tuple.</param>
		/// <param name="value">The value to assign.</param>
		/// <returns>true if the value was set successfully; otherwise, false.</returns>
		public bool TrySetValue((int X, int Y) point, T value) {
			if (grid.IsOutOfBounds(point.X, point.Y)) {
				return false;
			}
			grid[point.X, point.Y] = value;
			return true;
		}

		/// <summary>
		/// Attempts to set the value at the specified point.
		/// </summary>
		/// <param name="point">The point coordinates.</param>
		/// <param name="value">The value to assign.</param>
		/// <returns>true if the value was set successfully; otherwise, false.</returns>
		public bool TrySetValue(Point point, T value) {
			if (grid.IsOutOfBounds(point.X, point.Y)) {
				return false;
			}
			grid[point.X, point.Y] = value;
			return true;
		}
	}

	extension<T>(T[,] array) {
		/// <summary>
		/// Attempts to set the value at the specified coordinates in the underlying two-dimensional array.
		/// </summary>
		/// <remarks>No changes are made if the specified coordinates are outside the bounds of the array.</remarks>
		/// <param name="x">The zero-based column index at which to set the value.</param>
		/// <param name="y">The zero-based row index at which to set the value.</param>
		/// <param name="value">The value to assign at the specified coordinates.</param>
		/// <returns>true if the value was set successfully; otherwise, false if the specified coordinates are out of bounds.</returns>
		public bool TrySetValue(int x, int y, T value) {
			if (array.IsOutOfBounds(x, y)) {
				return false;
			}

			array[x, y] = value;
			return true;
		}

		/// <summary>
		/// Attempts to set the value at the specified point in the array. Returns a value indicating whether the operation
		/// succeeded.
		/// </summary>
		/// <remarks>If the specified point is outside the bounds of the array, the method does not modify the array
		/// and returns false.</remarks>
		/// <param name="point">The coordinates of the element to set, represented as a tuple containing the X and Y indices.</param>
		/// <param name="value">The value to assign to the element at the specified point.</param>
		/// <returns>true if the value was set successfully; otherwise, false.</returns>
		public bool TrySetValue((int X, int Y) point, T value) {
			if (array.IsOutOfBounds(point.X, point.Y)) {
				return false;
			}

			array[point.X, point.Y] = value;
			return true;
		}

		/// <summary>
		/// Attempts to set the value at the specified point in the array.
		/// </summary>
		/// <remarks>No changes are made if the specified point is outside the bounds of the array.</remarks>
		/// <param name="point">The coordinates within the array where the value should be set.</param>
		/// <param name="value">The value to assign at the specified point.</param>
		/// <returns>true if the value was successfully set; otherwise, false.</returns>
		public bool TrySetValue(Point point, T value) {
			if (array.IsOutOfBounds(point.X, point.Y)) {
				return false;
			}

			array[point.X, point.Y] = value;
			return true;
		}
	}

	extension<T>(T[,,] array) {
		/// <summary>
		/// Attempts to set the value at the specified three-dimensional coordinates within the array.
		/// </summary>
		/// <param name="x">The x-coordinate of the element to set. Must be within the bounds of the array.</param>
		/// <param name="y">The y-coordinate of the element to set. Must be within the bounds of the array.</param>
		/// <param name="z">The z-coordinate of the element to set. Must be within the bounds of the array.</param>
		/// <param name="value">The value to assign to the element at the specified coordinates.</param>
		/// <returns>true if the value was set successfully; otherwise, false if the specified coordinates are out of bounds.</returns>
		public bool TrySetValue(int x, int y, int z, T value) {
			if (array.IsOutOfBounds(x, y, z)) {
				return false;
			}

			array[x, y, z] = value;
			return true;
		}

		/// <summary>
		/// Attempts to set the value at the specified three-dimensional point in the array.
		/// </summary>
		/// <param name="point">A tuple representing the coordinates (X, Y, Z) of the point at which to set the value. Coordinates must be within
		/// the bounds of the array.</param>
		/// <param name="value">The value to assign at the specified point.</param>
		/// <returns>true if the value was successfully set; otherwise, false if the point is out of bounds.</returns>
		public bool TrySetValue((int X, int Y, int Z) point, T value) {
			if (array.IsOutOfBounds(point.X, point.Y, point.Z)) {
				return false;
			}

			array[point.X, point.Y, point.Z] = value;
			return true;
		}

		/// <summary>
		/// Attempts to set the value at the specified three-dimensional point within the array.
		/// </summary>
		/// <param name="point">The three-dimensional coordinates at which to set the value. Must be within the bounds of the array.</param>
		/// <param name="value">The value to assign at the specified point.</param>
		/// <returns>true if the value was set successfully; otherwise, false if the point is out of bounds.</returns>
		public bool TrySetValue(Point3d point, T value) {
			if (array.IsOutOfBounds(point.X, point.Y, point.Z)) {
				return false;
			}

			array[point.X, point.Y, point.Z] = value;
			return true;
		}
	}
}
