namespace Smab.Helpers;

public static partial class ArrayHelpers {
	extension<T>(Grid<T> grid) where T : IEquatable<T> {
		/// <summary>
		/// Finds the first occurrence of a value in the grid.
		/// </summary>
		/// <param name="value">The value to find.</param>
		/// <returns>The column and row coordinates of the first occurrence, or null if not found.</returns>
		public (int col, int row)? Find(T value) {
			for (int col = 0; col < grid.ColsCount; col++) {
				for (int row = 0; row < grid.RowsCount; row++) {
					if (grid[col, row].Equals(value)) {
						return (col, row);
					}
				}
			}
			return null;
		}

		/// <summary>
		/// Finds all occurrences of a value in the grid.
		/// </summary>
		/// <param name="value">The value to find.</param>
		/// <returns>An enumerable of column and row coordinates where the value is found.</returns>
		public IEnumerable<(int col, int row)> FindAll(T value) {
			for (int col = 0; col < grid.ColsCount; col++) {
				for (int row = 0; row < grid.RowsCount; row++) {
					if (grid[col, row].Equals(value)) {
						yield return (col, row);
					}
				}
			}
		}

		/// <summary>
		/// Determines whether the grid contains the specified value.
		/// </summary>
		/// <param name="value">The value to locate in the grid.</param>
		/// <returns>true if the value is found; otherwise, false.</returns>
		public bool Contains(T value) => grid.Find(value).HasValue;

		/// <summary>
		/// Finds the first occurrence of a value in the grid and returns the position as a Point.
		/// </summary>
		/// <param name="value">The value to find.</param>
		/// <returns>The Point coordinates of the first occurrence, or null if not found.</returns>
		public Point? FindAsPoint(T value) {
			(int col, int row)? result = grid.Find(value);
			return result.HasValue ? new Point(result.Value.col, result.Value.row) : null;
		}

		/// <summary>
		/// Finds all occurrences of a value in the grid and returns the positions as Points.
		/// </summary>
		/// <param name="value">The value to find.</param>
		/// <returns>An enumerable of Point coordinates where the value is found.</returns>
		public IEnumerable<Point> FindAllAsPoints(T value) {
			foreach ((int col, int row) in grid.FindAll(value)) {
				yield return new Point(col, row);
			}
		}
	}

	extension<T>(Grid<T> grid) {
		/// <summary>
		/// Finds the first element that satisfies the specified predicate.
		/// </summary>
		/// <param name="predicate">A function to test each element.</param>
		/// <returns>The column and row coordinates of the first matching element, or null if no match is found.</returns>
		public (int col, int row)? Find(Predicate<T> predicate) {
			for (int col = 0; col < grid.ColsCount; col++) {
				for (int row = 0; row < grid.RowsCount; row++) {
					if (predicate(grid[col, row])) {
						return (col, row);
					}
				}
			}
			return null;
		}

		/// <summary>
		/// Finds all elements that satisfy the specified predicate.
		/// </summary>
		/// <param name="predicate">A function to test each element.</param>
		/// <returns>An enumerable of column and row coordinates where elements match the predicate.</returns>
		public IEnumerable<(int col, int row)> FindAll(Predicate<T> predicate) {
			for (int col = 0; col < grid.ColsCount; col++) {
				for (int row = 0; row < grid.RowsCount; row++) {
					if (predicate(grid[col, row])) {
						yield return (col, row);
					}
				}
			}
		}

		/// <summary>
		/// Determines whether any element in the grid satisfies the specified predicate.
		/// </summary>
		/// <param name="predicate">A function to test each element.</param>
		/// <returns>true if any element satisfies the predicate; otherwise, false.</returns>
		public bool Any(Predicate<T> predicate) => grid.Find(predicate).HasValue;

		/// <summary>
		/// Determines whether all elements in the grid satisfy the specified predicate.
		/// </summary>
		/// <param name="predicate">A function to test each element.</param>
		/// <returns>true if all elements satisfy the predicate; otherwise, false.</returns>
		public bool All(Predicate<T> predicate) {
			for (int col = 0; col < grid.ColsCount; col++) {
				for (int row = 0; row < grid.RowsCount; row++) {
					if (!predicate(grid[col, row])) {
						return false;
					}
				}
			}
			return true;
		}

		/// <summary>
		/// Counts the number of elements that satisfy the specified predicate.
		/// </summary>
		/// <param name="predicate">A function to test each element.</param>
		/// <returns>The number of elements that satisfy the predicate.</returns>
		public int Count(Predicate<T> predicate) {
			int count = 0;
			for (int col = 0; col < grid.ColsCount; col++) {
				for (int row = 0; row < grid.RowsCount; row++) {
					if (predicate(grid[col, row])) {
						count++;
					}
				}
			}
			return count;
		}

		/// <summary>
		/// Finds the first element that satisfies the specified predicate and returns the position as a Point.
		/// </summary>
		/// <param name="predicate">A function to test each element.</param>
		/// <returns>The Point coordinates of the first matching element, or null if no match is found.</returns>
		public Point? FindAsPoint(Predicate<T> predicate) {
			(int col, int row)? result = grid.Find(predicate);
			return result.HasValue ? new Point(result.Value.col, result.Value.row) : null;
		}

		/// <summary>
		/// Finds all elements that satisfy the specified predicate and returns the positions as Points.
		/// </summary>
		/// <param name="predicate">A function to test each element.</param>
		/// <returns>An enumerable of Point coordinates where elements match the predicate.</returns>
		public IEnumerable<Point> FindAllAsPoints(Predicate<T> predicate) {
			foreach ((int col, int row) in grid.FindAll(predicate)) {
				yield return new Point(col, row);
			}
		}
	}

	extension<T>(T[,] array) where T : IEquatable<T> {
		/// <summary>
		/// Finds the first occurrence of a value in the array.
		/// </summary>
		/// <param name="value">The value to find.</param>
		/// <returns>The column and row coordinates of the first occurrence, or null if not found.</returns>
		public (int col, int row)? Find(T value) {
			int cols = array.GetLength(0);
			int rows = array.GetLength(1);

			for (int col = 0; col < cols; col++) {
				for (int row = 0; row < rows; row++) {
					if (array[col, row].Equals(value)) {
						return (col, row);
					}
				}
			}
			return null;
		}

		/// <summary>
		/// Finds all occurrences of a value in the array.
		/// </summary>
		/// <param name="value">The value to find.</param>
		/// <returns>An enumerable of column and row coordinates where the value is found.</returns>
		public IEnumerable<(int col, int row)> FindAll(T value) {
			int cols = array.GetLength(0);
			int rows = array.GetLength(1);

			for (int col = 0; col < cols; col++) {
				for (int row = 0; row < rows; row++) {
					if (array[col, row].Equals(value)) {
						yield return (col, row);
					}
				}
			}
		}

		/// <summary>
		/// Determines whether the array contains the specified value.
		/// </summary>
		/// <param name="value">The value to locate in the array.</param>
		/// <returns>true if the value is found; otherwise, false.</returns>
		public bool Contains(T value) => array.Find(value).HasValue;

		/// <summary>
		/// Finds the first occurrence of a value in the array and returns the position as a Point.
		/// </summary>
		/// <param name="value">The value to find.</param>
		/// <returns>The Point coordinates of the first occurrence, or null if not found.</returns>
		public Point? FindAsPoint(T value) {
			(int col, int row)? result = array.Find(value);
			return result.HasValue ? new Point(result.Value.col, result.Value.row) : null;
		}

		/// <summary>
		/// Finds all occurrences of a value in the array and returns the positions as Points.
		/// </summary>
		/// <param name="value">The value to find.</param>
		/// <returns>An enumerable of Point coordinates where the value is found.</returns>
		public IEnumerable<Point> FindAllAsPoints(T value) {
			foreach ((int col, int row) in array.FindAll(value)) {
				yield return new Point(col, row);
			}
		}
	}

	extension<T>(T[,] array) {
		/// <summary>
		/// Finds the first element that satisfies the specified predicate.
		/// </summary>
		/// <param name="predicate">A function to test each element.</param>
		/// <returns>The column and row coordinates of the first matching element, or null if no match is found.</returns>
		public (int col, int row)? Find(Predicate<T> predicate) {
			int cols = array.GetLength(0);
			int rows = array.GetLength(1);

			for (int col = 0; col < cols; col++) {
				for (int row = 0; row < rows; row++) {
					if (predicate(array[col, row])) {
						return (col, row);
					}
				}
			}
			return null;
		}

		/// <summary>
		/// Finds all elements that satisfy the specified predicate.
		/// </summary>
		/// <param name="predicate">A function to test each element.</param>
		/// <returns>An enumerable of column and row coordinates where elements match the predicate.</returns>
		public IEnumerable<(int col, int row)> FindAll(Predicate<T> predicate) {
			int cols = array.GetLength(0);
			int rows = array.GetLength(1);

			for (int col = 0; col < cols; col++) {
				for (int row = 0; row < rows; row++) {
					if (predicate(array[col, row])) {
						yield return (col, row);
					}
				}
			}
		}

		/// <summary>
		/// Determines whether any element in the array satisfies the specified predicate.
		/// </summary>
		/// <param name="predicate">A function to test each element.</param>
		/// <returns>true if any element satisfies the predicate; otherwise, false.</returns>
		public bool Any(Predicate<T> predicate) => array.Find(predicate).HasValue;

		/// <summary>
		/// Determines whether all elements in the array satisfy the specified predicate.
		/// </summary>
		/// <param name="predicate">A function to test each element.</param>
		/// <returns>true if all elements satisfy the predicate; otherwise, false.</returns>
		public bool All(Predicate<T> predicate) {
			int cols = array.GetLength(0);
			int rows = array.GetLength(1);

			for (int col = 0; col < cols; col++) {
				for (int row = 0; row < rows; row++) {
					if (!predicate(array[col, row])) {
						return false;
					}
				}
			}
			return true;
		}

		/// <summary>
		/// Finds the first element that satisfies the specified predicate and returns the position as a Point.
		/// </summary>
		/// <param name="predicate">A function to test each element.</param>
		/// <returns>The Point coordinates of the first matching element, or null if no match is found.</returns>
		public Point? FindAsPoint(Predicate<T> predicate) {
			(int col, int row)? result = array.Find(predicate);
			return result.HasValue ? new Point(result.Value.col, result.Value.row) : null;
		}

		/// <summary>
		/// Finds all elements that satisfies the specified predicate and returns the positions as Points.
		/// </summary>
		/// <param name="predicate">A function to test each element.</param>
		/// <returns>An enumerable of Point coordinates where elements match the predicate.</returns>
		public IEnumerable<Point> FindAllAsPoints(Predicate<T> predicate) {
			foreach ((int col, int row) in array.FindAll(predicate)) {
				yield return new Point(col, row);
			}
		}
	}
}

