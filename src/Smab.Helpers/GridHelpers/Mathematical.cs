namespace Smab.Helpers;

public static partial class ArrayHelpers {
	extension<T>(Grid<T> grid) where T : INumber<T> {
		/// <summary>
		/// Computes the sum of all numeric values in the grid.
		/// </summary>
		/// <returns>The sum of all values in the grid.</returns>
		public T Sum() {
			T sum = T.Zero;
			for (int col = 0; col < grid.ColsCount; col++) {
				for (int row = 0; row < grid.RowsCount; row++) {
					sum += grid[col, row];
				}
			}
			return sum;
		}

		/// <summary>
		/// Finds the minimum value in the grid.
		/// </summary>
		/// <returns>The minimum value found in the grid.</returns>
		/// <exception cref="InvalidOperationException">Thrown when the grid is empty.</exception>
		public T Min() {
			if (grid.ColsCount == 0 || grid.RowsCount == 0) {
				throw new InvalidOperationException("Cannot find minimum of an empty grid.");
			}

			T min = grid[0, 0];
			for (int col = 0; col < grid.ColsCount; col++) {
				for (int row = 0; row < grid.RowsCount; row++) {
					T value = grid[col, row];
					if (value < min) {
						min = value;
					}
				}
			}
			return min;
		}

		/// <summary>
		/// Finds the maximum value in the grid.
		/// </summary>
		/// <returns>The maximum value found in the grid.</returns>
		/// <exception cref="InvalidOperationException">Thrown when the grid is empty.</exception>
		public T Max() {
			if (grid.ColsCount == 0 || grid.RowsCount == 0) {
				throw new InvalidOperationException("Cannot find maximum of an empty grid.");
			}

			T max = grid[0, 0];
			for (int col = 0; col < grid.ColsCount; col++) {
				for (int row = 0; row < grid.RowsCount; row++) {
					T value = grid[col, row];
					if (value > max) {
						max = value;
					}
				}
			}
			return max;
		}

		/// <summary>
		/// Computes the average of all numeric values in the grid.
		/// </summary>
		/// <returns>The average of all values in the grid.</returns>
		/// <exception cref="InvalidOperationException">Thrown when the grid is empty.</exception>
		public T Average() {
			if (grid.ColsCount == 0 || grid.RowsCount == 0) {
				throw new InvalidOperationException("Cannot compute average of an empty grid.");
			}

			T sum = grid.Sum();
			T count = T.CreateChecked(grid.ColsCount * grid.RowsCount);
			return sum / count;
		}

		/// <summary>
		/// Multiplies all elements in the grid by a scalar value.
		/// </summary>
		/// <param name="scalar">The scalar value to multiply each element by.</param>
		/// <returns>A new grid with all elements multiplied by the scalar.</returns>
		public Grid<T> ScalarMultiply(T scalar) {
			Grid<T> result = new(grid.ColsCount, grid.RowsCount);
			for (int col = 0; col < grid.ColsCount; col++) {
				for (int row = 0; row < grid.RowsCount; row++) {
					result[col, row] = grid[col, row] * scalar;
				}
			}
			return result;
		}

		/// <summary>
		/// Divides all elements in the grid by a scalar value.
		/// </summary>
		/// <param name="scalar">The scalar value to divide each element by.</param>
		/// <returns>A new grid with all elements divided by the scalar.</returns>
		public Grid<T> ScalarDivide(T scalar) {
			Grid<T> result = new(grid.ColsCount, grid.RowsCount);
			for (int col = 0; col < grid.ColsCount; col++) {
				for (int row = 0; row < grid.RowsCount; row++) {
					result[col, row] = grid[col, row] / scalar;
				}
			}
			return result;
		}

		/// <summary>
		/// Adds a scalar value to all elements in the grid.
		/// </summary>
		/// <param name="scalar">The scalar value to add to each element.</param>
		/// <returns>A new grid with the scalar added to all elements.</returns>
		public Grid<T> ScalarAdd(T scalar) {
			Grid<T> result = new(grid.ColsCount, grid.RowsCount);
			for (int col = 0; col < grid.ColsCount; col++) {
				for (int row = 0; row < grid.RowsCount; row++) {
					result[col, row] = grid[col, row] + scalar;
				}
			}
			return result;
		}

		/// <summary>
		/// Subtracts a scalar value from all elements in the grid.
		/// </summary>
		/// <param name="scalar">The scalar value to subtract from each element.</param>
		/// <returns>A new grid with the scalar subtracted from all elements.</returns>
		public Grid<T> ScalarSubtract(T scalar) {
			Grid<T> result = new(grid.ColsCount, grid.RowsCount);
			for (int col = 0; col < grid.ColsCount; col++) {
				for (int row = 0; row < grid.RowsCount; row++) {
					result[col, row] = grid[col, row] - scalar;
				}
			}
			return result;
		}

		/// <summary>
		/// Adds corresponding elements from two grids.
		/// </summary>
		/// <param name="other">The grid to add to this grid.</param>
		/// <returns>A new grid containing the element-wise sum.</returns>
		/// <exception cref="ArgumentException">Thrown when grids have different dimensions.</exception>
		public Grid<T> Add(Grid<T> other) {
			if (grid.ColsCount != other.ColsCount || grid.RowsCount != other.RowsCount) {
				throw new ArgumentException($"Cannot add grids with different dimensions. Left grid is {grid.ColsCount}x{grid.RowsCount}, right grid is {other.ColsCount}x{other.RowsCount}.");
			}

			Grid<T> result = new(grid.ColsCount, grid.RowsCount);
			for (int col = 0; col < grid.ColsCount; col++) {
				for (int row = 0; row < grid.RowsCount; row++) {
					result[col, row] = grid[col, row] + other[col, row];
				}
			}
			return result;
		}

		/// <summary>
		/// Subtracts corresponding elements of another grid from this grid.
		/// </summary>
		/// <param name="other">The grid to subtract from this grid.</param>
		/// <returns>A new grid containing the element-wise difference.</returns>
		/// <exception cref="ArgumentException">Thrown when grids have different dimensions.</exception>
		public Grid<T> Subtract(Grid<T> other) {
			if (grid.ColsCount != other.ColsCount || grid.RowsCount != other.RowsCount) {
				throw new ArgumentException($"Cannot subtract grids with different dimensions. Left grid is {grid.ColsCount}x{grid.RowsCount}, right grid is {other.ColsCount}x{other.RowsCount}.");
			}

			Grid<T> result = new(grid.ColsCount, grid.RowsCount);
			for (int col = 0; col < grid.ColsCount; col++) {
				for (int row = 0; row < grid.RowsCount; row++) {
					result[col, row] = grid[col, row] - other[col, row];
				}
			}
			return result;
		}

		/// <summary>
		/// Multiplies corresponding elements from two grids (element-wise/Hadamard product).
		/// </summary>
		/// <param name="other">The grid to multiply with this grid.</param>
		/// <returns>A new grid containing the element-wise product.</returns>
		/// <exception cref="ArgumentException">Thrown when grids have different dimensions.</exception>
		public Grid<T> Multiply(Grid<T> other) {
			if (grid.ColsCount != other.ColsCount || grid.RowsCount != other.RowsCount) {
				throw new ArgumentException($"Cannot multiply grids with different dimensions. Left grid is {grid.ColsCount}x{grid.RowsCount}, right grid is {other.ColsCount}x{other.RowsCount}.");
			}

			Grid<T> result = new(grid.ColsCount, grid.RowsCount);
			for (int col = 0; col < grid.ColsCount; col++) {
				for (int row = 0; row < grid.RowsCount; row++) {
					result[col, row] = grid[col, row] * other[col, row];
				}
			}
			return result;
		}

		/// <summary>
		/// Divides corresponding elements of this grid by elements of another grid.
		/// </summary>
		/// <param name="other">The grid to divide this grid by.</param>
		/// <returns>A new grid containing the element-wise quotient.</returns>
		/// <exception cref="ArgumentException">Thrown when grids have different dimensions.</exception>
		public Grid<T> Divide(Grid<T> other) {
			if (grid.ColsCount != other.ColsCount || grid.RowsCount != other.RowsCount) {
				throw new ArgumentException($"Cannot divide grids with different dimensions. Left grid is {grid.ColsCount}x{grid.RowsCount}, right grid is {other.ColsCount}x{other.RowsCount}.");
			}

			Grid<T> result = new(grid.ColsCount, grid.RowsCount);
			for (int col = 0; col < grid.ColsCount; col++) {
				for (int row = 0; row < grid.RowsCount; row++) {
					result[col, row] = grid[col, row] / other[col, row];
				}
			}
			return result;
		}
	}

	// Operator overloads for Grid<T> with INumber<T> constraint
	extension<T>(Grid<T> g) where T : INumber<T> {
		/// <summary>
		/// Multiplies a grid by a scalar value using the * operator.
		/// </summary>
		public static Grid<T> operator *(Grid<T> left, T scalar) => left.ScalarMultiply(scalar);

		/// <summary>
		/// Multiplies a grid by a scalar value using the * operator (scalar on left).
		/// </summary>
		public static Grid<T> operator *(T scalar, Grid<T> right) => right.ScalarMultiply(scalar);

		/// <summary>
		/// Divides a grid by a scalar value using the / operator.
		/// </summary>
		public static Grid<T> operator /(Grid<T> left, T scalar) => left.ScalarDivide(scalar);

		/// <summary>
		/// Adds a scalar value to a grid using the + operator.
		/// </summary>
		public static Grid<T> operator +(Grid<T> left, T scalar) => left.ScalarAdd(scalar);

		/// <summary>
		/// Adds a scalar value to a grid using the + operator (scalar on left).
		/// </summary>
		public static Grid<T> operator +(T scalar, Grid<T> right) => right.ScalarAdd(scalar);

		/// <summary>
		/// Subtracts a scalar value from a grid using the - operator.
		/// </summary>
		public static Grid<T> operator -(Grid<T> left, T scalar) => left.ScalarSubtract(scalar);

		/// <summary>
		/// Adds two grids element-wise using the + operator.
		/// </summary>
		public static Grid<T> operator +(Grid<T> left, Grid<T> right) => left.Add(right);

		/// <summary>
		/// Subtracts two grids element-wise using the - operator.
		/// </summary>
		public static Grid<T> operator -(Grid<T> left, Grid<T> right) => left.Subtract(right);
	}

	extension<T>(T[,] array) where T : INumber<T> {
		/// <summary>
		/// Computes the sum of all numeric values in the array.
		/// </summary>
		/// <returns>The sum of all values in the array.</returns>
		public T Sum() {
			T sum = T.Zero;
			int cols = array.GetLength(0);
			int rows = array.GetLength(1);

			for (int col = 0; col < cols; col++) {
				for (int row = 0; row < rows; row++) {
					sum += array[col, row];
				}
			}
			return sum;
		}

		/// <summary>
		/// Finds the minimum value in the array.
		/// </summary>
		/// <returns>The minimum value found in the array.</returns>
		/// <exception cref="InvalidOperationException">Thrown when the array is empty.</exception>
		public T Min() {
			int cols = array.GetLength(0);
			int rows = array.GetLength(1);

			if (cols == 0 || rows == 0) {
				throw new InvalidOperationException("Cannot find minimum of an empty array.");
			}

			T min = array[0, 0];
			for (int col = 0; col < cols; col++) {
				for (int row = 0; row < rows; row++) {
					T value = array[col, row];
					if (value < min) {
						min = value;
					}
				}
			}
			return min;
		}

		/// <summary>
		/// Finds the maximum value in the array.
		/// </summary>
		/// <returns>The maximum value found in the array.</returns>
		/// <exception cref="InvalidOperationException">Thrown when the array is empty.</exception>
		public T Max() {
			int cols = array.GetLength(0);
			int rows = array.GetLength(1);

			if (cols == 0 || rows == 0) {
				throw new InvalidOperationException("Cannot find maximum of an empty array.");
			}

			T max = array[0, 0];
			for (int col = 0; col < cols; col++) {
				for (int row = 0; row < rows; row++) {
					T value = array[col, row];
					if (value > max) {
						max = value;
					}
				}
			}
			return max;
		}

		/// <summary>
		/// Computes the average of all numeric values in the array.
		/// </summary>
		/// <returns>The average of all values in the array.</returns>
		/// <exception cref="InvalidOperationException">Thrown when the array is empty.</exception>
		public T Average() {
			int cols = array.GetLength(0);
			int rows = array.GetLength(1);

			if (cols == 0 || rows == 0) {
				throw new InvalidOperationException("Cannot compute average of an empty array.");
			}

			T sum = array.Sum();
			T count = T.CreateChecked(cols * rows);
			return sum / count;
		}

		/// <summary>
		/// Multiplies all elements in the array by a scalar value.
		/// </summary>
		/// <param name="scalar">The scalar value to multiply each element by.</param>
		/// <returns>A new array with all elements multiplied by the scalar.</returns>
		public T[,] ScalarMultiply(T scalar) {
			int cols = array.GetLength(0);
			int rows = array.GetLength(1);
			T[,] result = new T[cols, rows];

			for (int col = 0; col < cols; col++) {
				for (int row = 0; row < rows; row++) {
					result[col, row] = array[col, row] * scalar;
				}
			}
			return result;
		}

		/// <summary>
		/// Divides all elements in the array by a scalar value.
		/// </summary>
		/// <param name="scalar">The scalar value to divide each element by.</param>
		/// <returns>A new array with all elements divided by the scalar.</returns>
		public T[,] ScalarDivide(T scalar) {
			int cols = array.GetLength(0);
			int rows = array.GetLength(1);
			T[,] result = new T[cols, rows];

			for (int col = 0; col < cols; col++) {
				for (int row = 0; row < rows; row++) {
					result[col, row] = array[col, row] / scalar;
				}
			}
			return result;
		}

		/// <summary>
		/// Adds a scalar value to all elements in the array.
		/// </summary>
		/// <param name="scalar">The scalar value to add to each element.</param>
		/// <returns>A new array with the scalar added to all elements.</returns>
		public T[,] ScalarAdd(T scalar) {
			int cols = array.GetLength(0);
			int rows = array.GetLength(1);
			T[,] result = new T[cols, rows];

			for (int col = 0; col < cols; col++) {
				for (int row = 0; row < rows; row++) {
					result[col, row] = array[col, row] + scalar;
				}
			}
			return result;
		}

		/// <summary>
		/// Subtracts a scalar value from all elements in the array.
		/// </summary>
		/// <param name="scalar">The scalar value to subtract from each element.</param>
		/// <returns>A new array with the scalar subtracted from all elements.</returns>
		public T[,] ScalarSubtract(T scalar) {
			int cols = array.GetLength(0);
			int rows = array.GetLength(1);
			T[,] result = new T[cols, rows];

			for (int col = 0; col < cols; col++) {
				for (int row = 0; row < rows; row++) {
					result[col, row] = array[col, row] - scalar;
				}
			}
			return result;
		}

		/// <summary>
		/// Adds corresponding elements from two arrays.
		/// </summary>
		/// <param name="other">The array to add to this array.</param>
		/// <returns>A new array containing the element-wise sum.</returns>
		/// <exception cref="ArgumentException">Thrown when arrays have different dimensions.</exception>
		public T[,] Add(T[,] other) {
			int cols = array.GetLength(0);
			int rows = array.GetLength(1);
			int otherCols = other.GetLength(0);
			int otherRows = other.GetLength(1);

			if (cols != otherCols || rows != otherRows) {
				throw new ArgumentException($"Cannot add arrays with different dimensions. Left array is {cols}x{rows}, right array is {otherCols}x{otherRows}.");
			}

			T[,] result = new T[cols, rows];
			for (int col = 0; col < cols; col++) {
				for (int row = 0; row < rows; row++) {
					result[col, row] = array[col, row] + other[col, row];
				}
			}
			return result;
		}

		/// <summary>
		/// Subtracts corresponding elements of another array from this array.
		/// </summary>
		/// <param name="other">The array to subtract from this array.</param>
		/// <returns>A new array containing the element-wise difference.</returns>
		/// <exception cref="ArgumentException">Thrown when arrays have different dimensions.</exception>
		public T[,] Subtract(T[,] other) {
			int cols = array.GetLength(0);
			int rows = array.GetLength(1);
			int otherCols = other.GetLength(0);
			int otherRows = other.GetLength(1);

			if (cols != otherCols || rows != otherRows) {
				throw new ArgumentException($"Cannot subtract arrays with different dimensions. Left array is {cols}x{rows}, right array is {otherCols}x{otherRows}.");
			}

			T[,] result = new T[cols, rows];
			for (int col = 0; col < cols; col++) {
				for (int row = 0; row < rows; row++) {
					result[col, row] = array[col, row] - other[col, row];
				}
			}
			return result;
		}

		/// <summary>
		/// Multiplies corresponding elements from two arrays (element-wise/Hadamard product).
		/// </summary>
		/// <param name="other">The array to multiply with this array.</param>
		/// <returns>A new array containing the element-wise product.</returns>
		/// <exception cref="ArgumentException">Thrown when arrays have different dimensions.</exception>
		public T[,] Multiply(T[,] other) {
			int cols = array.GetLength(0);
			int rows = array.GetLength(1);
			int otherCols = other.GetLength(0);
			int otherRows = other.GetLength(1);

			if (cols != otherCols || rows != otherRows) {
				throw new ArgumentException($"Cannot multiply arrays with different dimensions. Left array is {cols}x{rows}, right array is {otherCols}x{otherRows}.");
			}

			T[,] result = new T[cols, rows];
			for (int col = 0; col < cols; col++) {
				for (int row = 0; row < rows; row++) {
					result[col, row] = array[col, row] * other[col, row];
				}
			}
			return result;
		}

		/// <summary>
		/// Divides corresponding elements of this array by elements of another array.
		/// </summary>
		/// <param name="other">The array to divide this array by.</param>
		/// <returns>A new array containing the element-wise quotient.</returns>
		/// <exception cref="ArgumentException">Thrown when arrays have different dimensions.</exception>
		public T[,] Divide(T[,] other) {
			int cols = array.GetLength(0);
			int rows = array.GetLength(1);
			int otherCols = other.GetLength(0);
			int otherRows = other.GetLength(1);

			if (cols != otherCols || rows != otherRows) {
				throw new ArgumentException($"Cannot divide arrays with different dimensions. Left array is {cols}x{rows}, right array is {otherCols}x{otherRows}.");
			}

			T[,] result = new T[cols, rows];
			for (int col = 0; col < cols; col++) {
				for (int row = 0; row < rows; row++) {
					result[col, row] = array[col, row] / other[col, row];
				}
			}
			return result;
		}
	}
}
