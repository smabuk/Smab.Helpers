namespace Smab.Helpers;

public static partial class ArrayHelpers {
	/// <summary>
	/// Creates a two-dimensional array with the specified dimensions and initializes all elements to the specified value.
	/// </summary>
	/// <typeparam name="T">The type of the elements in the array.</typeparam>
	/// <param name="cols">The number of columns in the array. Must be greater than or equal to 0.</param>
	/// <param name="rows">The number of rows in the array. Must be greater than or equal to 0.</param>
	/// <param name="value">The value to initialize each element of the array with.</param>
	/// <returns>A two-dimensional array of type <typeparamref name="T"/> with the specified dimensions, where all elements are set
	/// to <paramref name="value"/>.</returns>
	public static T[,] Create2dArray<T>(int cols, int rows, T value)
		=> (new T[cols, rows]).Fill(value);

	/// <summary>
	/// Creates a two-dimensional array with specified dimensions, bounds, and an initial value.
	/// </summary>
	/// <remarks>The created array uses non-zero-based indexing if <paramref name="colLowerBound"/> or <paramref
	/// name="rowLowerBound"/> is not 0. This allows for custom lower bounds for array indices.</remarks>
	/// <typeparam name="T">The type of elements in the array.</typeparam>
	/// <param name="cols">The number of columns in the array. Must be greater than or equal to 0.</param>
	/// <param name="rows">The number of rows in the array. Must be greater than or equal to 0.</param>
	/// <param name="colLowerBound">The lower bound for the column indices.</param>
	/// <param name="rowLowerBound">The lower bound for the row indices.</param>
	/// <param name="value">The initial value to populate each element of the array.</param>
	/// <returns>A two-dimensional array of type <typeparamref name="T"/> with the specified dimensions and bounds, where each
	/// element is initialized to the specified <paramref name="value"/>.</returns>
	public static T[,] Create2dArray<T>(int cols, int rows, int colLowerBound, int rowLowerBound, T value)
		=> ((T[,])Array.CreateInstance(typeof(T), [cols, rows], [colLowerBound, rowLowerBound])).Fill(value);
}
