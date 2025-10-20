namespace Smab.Helpers;

public static partial class ArrayHelpers {

	extension<T>(IEnumerable<T> input) {
		/// <summary>
		/// Converts a one-dimensional sequence into a two-dimensional array with the specified number of columns.
		/// </summary>
		/// <remarks>If the input sequence contains fewer elements than the total number of cells in the resulting array
		/// (i.e., <paramref name="cols"/> × <paramref name="rows"/>), the remaining cells will be left uninitialized (default
		/// value for type <typeparamref name="T"/>).</remarks>
		/// <typeparam name="T">The type of elements in the input sequence.</typeparam>
		/// <param name="input">The sequence of elements to convert into a two-dimensional array.</param>
		/// <param name="cols">The number of columns in the resulting two-dimensional array. Must be greater than zero.</param>
		/// <param name="rows">The number of rows in the resulting two-dimensional array. If not specified, the number of rows is calculated
		/// automatically based on the length of the input sequence and the specified number of columns.</param>
		/// <returns>A two-dimensional array of type <typeparamref name="T"/> with the specified number of columns and the calculated or
		/// provided number of rows. The array is populated with elements from the input sequence in row-major order.</returns>
		public T[,] To2dArray(int cols, int? rows = null) {
			ReadOnlySpan<T> array = [.. input];
			int arrayLength = array.Length;
			rows ??= arrayLength % cols == 0 ? arrayLength / cols : (arrayLength / cols) + 1;
			T[,] result = new T[cols, (int)rows];
			int i = 0;
			foreach ((int col, int row) in result.Indexes()) {
				result[col, row] = array[i++];
				if (i >= arrayLength) {
					return result;
				}
			}

			return result;
		}
	}

	extension<T>(IEnumerable<IEnumerable<T>> input) {
		/// <summary>
		/// Converts a jagged collection of collections into a two-dimensional array.
		/// </summary>
		/// <remarks>If the dimensions specified by <paramref name="cols"/> or <paramref name="rows"/> do not match the
		/// structure of the input collection, the behavior is undefined. Ensure that the input collection is rectangular
		/// (i.e., all inner collections have the same number of elements) for consistent results.</remarks>
		/// <typeparam name="T">The type of elements in the input collections.</typeparam>
		/// <param name="input">The input collection of collections to convert. Each inner collection represents a row.</param>
		/// <param name="cols">The number of columns in the resulting array. If not specified, the number of columns is determined by the count of
		/// elements in the first inner collection.</param>
		/// <param name="rows">The number of rows in the resulting array. If not specified, the number of rows is determined by the count of the
		/// outer collection.</param>
		/// <returns>A two-dimensional array of type <typeparamref name="T"/> where the first dimension represents columns and the
		/// second dimension represents rows.</returns>
		public T[,] To2dArray(int? cols = null, int? rows = null) {
			rows ??= input.Count();
			cols ??= input.First().Count();
			T[,] result = new T[(int)cols, (int)rows];
			int r = 0;
			foreach (IEnumerable<T> row in input) {
				ReadOnlySpan<T> array = [.. row];
				int c = 0;
				for (int i = 0; i < array.Length; i++) {
					result[c, r] = array[i];
					c++;
				}
				r++;
			}

			return result;
		}
	}

	extension(IEnumerable<string> input) {
		/// <summary>
		/// Converts a collection of strings into a two-dimensional character array.
		/// </summary>
		/// <remarks>The method assumes that all strings in the input collection have the same length. If the input
		/// strings vary in length, or if the specified <paramref name="cols"/> or <paramref name="rows"/> exceed the
		/// dimensions of the input, the behavior is undefined.</remarks>
		/// <param name="input">The collection of strings to convert. Each string represents a row in the resulting 2D array.</param>
		/// <param name="cols">The number of columns in the resulting 2D array. If not specified, the length of the first string in the input is
		/// used.</param>
		/// <param name="rows">The number of rows in the resulting 2D array. If not specified, the number of strings in the input is used.</param>
		/// <returns>A two-dimensional character array where each element corresponds to a character from the input strings.</returns>
		public char[,] To2dArray(int? cols = null, int? rows = null) {
			ReadOnlySpan<string> array = [.. input];
			rows ??= array.Length;
			cols ??= array[0].Length;
			char[,] result = new char[(int)cols, (int)rows];
			foreach ((int col, int row) in result.Indexes()) {
				result[col, row] = array[row][col];
			}

			return result;
		}
	}

	extension(IEnumerable<Point> input) {
		/// <summary>
		/// Converts a collection of <see cref="Point"/> objects into a two-dimensional array,  with specified initial and
		/// value elements.
		/// </summary>
		/// <remarks>The resulting array's dimensions are determined by the minimum and maximum X and Y coordinates of
		/// the input points.  If the minimum X or Y coordinate is greater than 0, the array will include a margin starting at
		/// 0.</remarks>
		/// <typeparam name="T">The type of the elements in the resulting array.</typeparam>
		/// <param name="input">The collection of <see cref="Point"/> objects to be represented in the array.</param>
		/// <param name="initial">The initial value to populate all elements of the array.</param>
		/// <param name="value">The value to assign to the positions corresponding to the points in the input collection.</param>
		/// <returns>A two-dimensional array of type <typeparamref name="T"/> where the positions corresponding to the  <paramref
		/// name="input"/> points are set to <paramref name="value"/>, and all other positions are set to <paramref
		/// name="initial"/>.</returns>
		public T[,] To2dArray<T>(T initial, T value) {
			int minX = int.MaxValue;
			int minY = int.MaxValue;
			int maxX = int.MinValue;
			int maxY = int.MinValue;
			foreach (Point point in input) {
				minX = Math.Min(minX, point.X);
				maxX = Math.Max(maxX, point.X);
				minY = Math.Min(minY, point.Y);
				maxY = Math.Max(maxY, point.Y);
			}

			if (minX > 0) { minX = 0; }
			if (minY > 0) { minY = 0; }

			int cols = maxX - minX + 1;
			int rows = maxY - minY + 1;

			T[,] result = new T[cols, rows];
			result.FillInPlace(initial);

			ReadOnlySpan<Point> points = [.. input];

			for (int i = 0; i < points.Length; i++) {
				result[points[i].X - minX, points[i].Y - minY] = value;
			}

			return result;
		}
	}
}