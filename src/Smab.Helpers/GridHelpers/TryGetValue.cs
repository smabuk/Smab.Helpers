namespace Smab.Helpers;

public static partial class ArrayHelpers {

	extension<T>(T[,] array) {
		/// <summary>
		/// Attempts to retrieve the value at the specified coordinates in a two-dimensional array.
		/// </summary>
		/// <typeparam name="T">The type of elements in the array.</typeparam>
		/// <param name="array">The two-dimensional array to retrieve the value from. Cannot be <see langword="null"/>.</param>
		/// <param name="x">The zero-based x index of the value to retrieve.</param>
		/// <param name="y">The zero-based y index of the value to retrieve.</param>
		/// <param name="value">When this method returns, contains the value at the specified coordinates if the operation succeeds; otherwise,
		/// contains the default value for the type <typeparamref name="T"/>.</param>
		/// <returns><see langword="true"/> if the specified coordinates are within the bounds of the array and the value was
		/// successfully retrieved; otherwise, <see langword="false"/>.</returns>
		public bool TryGetValue(int x, int y, out T value) {
			value = default!;
			if (array.IsOutOfBounds(x, y)) {
				return false;
			}

			value = array[x, y];
			return true;
		}

		/// <summary>
		/// Attempts to retrieve the value at the specified coordinates in a two-dimensional array.
		/// </summary>
		/// <typeparam name="T">The type of elements in the array.</typeparam>
		/// <param name="array">The two-dimensional array to retrieve the value from. Cannot be <see langword="null"/>.</param>
		/// <param name="point">A tuple representing the coordinates (X, Y) of the value to retrieve.</param>
		/// <param name="value">When this method returns, contains the value at the specified coordinates if the operation succeeds;  otherwise,
		/// the default value for the type <typeparamref name="T"/>.</param>
		/// <returns><see langword="true"/> if the specified coordinates are within the bounds of the array and the value was
		/// successfully retrieved;  otherwise, <see langword="false"/>.</returns>
		public bool TryGetValue((int X, int Y) point, out T value) {
			value = default!;
			if (array.IsOutOfBounds(point.X, point.Y)) {
				return false;
			}

			value = array[point.X, point.Y];
			return true;
		}

		/// <summary>
		/// Attempts to retrieve the value at the specified <see cref="Point"/> in the two-dimensional array.
		/// </summary>
		/// <typeparam name="T">The type of elements in the array.</typeparam>
		/// <param name="array">The two-dimensional array to retrieve the value from. Cannot be <see langword="null"/>.</param>
		/// <param name="point">The <see cref="Point"/> specifying the coordinates of the value to retrieve.</param>
		/// <param name="value">When this method returns, contains the value at the specified <paramref name="point"/> if the operation succeeds;
		/// otherwise, the default value for the type <typeparamref name="T"/>.</param>
		/// <returns><see langword="true"/> if the specified <paramref name="point"/> is within the bounds of the array and the value
		/// was successfully retrieved; otherwise, <see langword="false"/>.</returns>
		public bool TryGetValue(Point point, out T value) {
			value = default!;
			if (array.IsOutOfBounds(point.X, point.Y)) {
				return false;
			}

			value = array[point.X, point.Y];
			return true;
		}
	}

	extension<T>(T[,,] array) {
		/// <summary>
		/// Attempts to retrieve the value at the specified coordinates in a three-dimensional array.
		/// </summary>
		/// <typeparam name="T">The type of elements in the array.</typeparam>
		/// <param name="array">The three-dimensional array to retrieve the value from. Cannot be <see langword="null"/>.</param>
		/// <param name="x">The x-coordinate of the element to retrieve.</param>
		/// <param name="y">The y-coordinate of the element to retrieve.</param>
		/// <param name="z">The z-coordinate of the element to retrieve.</param>
		/// <param name="value">When this method returns, contains the value at the specified coordinates if the coordinates are within bounds;
		/// otherwise, contains the default value for the type <typeparamref name="T"/>.</param>
		/// <returns><see langword="true"/> if the specified coordinates are within the bounds of the array and the value was
		/// successfully retrieved; otherwise, <see langword="false"/>.</returns>
		public bool TryGetValue(int x, int y, int z, out T value) {
			value = default!;
			if (array.IsOutOfBounds(x, y, z)) {
				return false;
			}

			value = array[x, y, z];
			return true;
		}

		/// <summary>
		/// Attempts to retrieve the value at the specified 3D point in the array.
		/// </summary>
		/// <typeparam name="T">The type of elements in the array.</typeparam>
		/// <param name="array">The three-dimensional array to retrieve the value from.</param>
		/// <param name="point">A tuple representing the coordinates of the point in the array, where  <see langword="X"/> is the first dimension,
		/// <see langword="Y"/> is the second dimension,  and <see langword="Z"/> is the third dimension.</param>
		/// <param name="value">When this method returns, contains the value at the specified point if the point is within bounds;  otherwise, the
		/// default value for the type <typeparamref name="T"/>.</param>
		/// <returns><see langword="true"/> if the specified point is within the bounds of the array and the value was successfully
		/// retrieved;  otherwise, <see langword="false"/>.</returns>
		public bool TryGetValue((int X, int Y, int Z) point, out T value) {
			value = default!;
			if (array.IsOutOfBounds(point.X, point.Y, point.Z)) {
				return false;
			}

			value = array[point.X, point.Y, point.Z];
			return true;
		}

		/// <summary>
		/// Attempts to retrieve the value at the specified 3D point in the array.
		/// </summary>
		/// <typeparam name="T">The type of elements in the array.</typeparam>
		/// <param name="array">The three-dimensional array to retrieve the value from.</param>
		/// <param name="point">The 3D point specifying the coordinates (X, Y, Z) within the array.</param>
		/// <param name="value">When this method returns, contains the value at the specified point if the point is within bounds; otherwise, the
		/// default value for the type <typeparamref name="T"/>.</param>
		/// <returns><see langword="true"/> if the specified point is within the bounds of the array and the value was successfully
		/// retrieved; otherwise, <see langword="false"/>.</returns>
		public bool TryGetValue(Point3d point, out T value) {
			value = default!;
			if (array.IsOutOfBounds(point.X, point.Y, point.Z)) {
				return false;
			}

			value = array[point.X, point.Y, point.Z];
			return true;
		}
	}
}
