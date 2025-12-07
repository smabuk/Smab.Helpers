namespace Smab.Helpers;

public static partial class ArrayHelpers {

	extension<T>(Grid<T> grid) {
		/// <summary>
		/// Creates a shallow copy of the grid.
		/// </summary>
		/// <remarks>Modifications to the returned grid do not affect the original grid, and vice versa. However, if
		/// the grid contains reference types, the references themselves are copied, not the objects they refer to.</remarks>
		/// <returns>A new grid containing the same elements as the original grid.</returns>
		public Grid<T> Copy() {
			Grid<T> result = new(grid.ColsCount, grid.RowsCount);
			Array.Copy(grid.InternalCells, result.InternalCells, grid.InternalCells.Length);
			return result;
		}
	}

	extension<T>(T[,] array) {
		/// <summary>
		/// Creates a shallow copy of the underlying two-dimensional array.
		/// </summary>
		/// <remarks>Modifications to the returned array do not affect the original array, and vice versa. However, if
		/// the array contains reference types, the references themselves are copied, not the objects they refer to.</remarks>
		/// <returns>A new two-dimensional array containing the same elements as the original array. The returned array is a shallow
		/// copy; reference-type elements are not cloned.</returns>
		public T[,] Copy() => (T[,])array.Clone();
	}
}
