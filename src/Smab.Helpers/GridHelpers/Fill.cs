using System.Runtime.InteropServices;

namespace Smab.Helpers;
public static partial class ArrayHelpers {
	extension<T>(T[,] array) {
		/// <summary>
		/// Creates a new two-dimensional array by cloning the specified array and filling all its elements with the specified
		/// value.
		/// </summary>
		/// <remarks>The method does not modify the original array. Instead, it creates a deep copy of the array and
		/// fills the copy with the specified value.</remarks>
		/// <typeparam name="T">The type of elements in the array.</typeparam>
		/// <param name="array">The two-dimensional array to clone and fill. Must not be <see langword="null"/>.</param>
		/// <param name="value">The value to assign to each element in the cloned array.</param>
		/// <returns>A new two-dimensional array of the same dimensions as <paramref name="array"/>, with all elements set to <paramref
		/// name="value"/>.</returns>
		public T[,] Fill(T value) {
			T[,] result = (T[,])array.Clone();

			Span<T> span = MemoryMarshal.CreateSpan(ref result[result.XMin(), result.YMin()], array.Length);

			for (int i = 0; i < result.Length; i++) {
				span[i] = value;
			}

			return result;
		}

		/// <summary>
		/// Fills all elements of the specified two-dimensional array with the provided value.
		/// </summary>
		/// <remarks>This method modifies the array in place, replacing all existing elements with the specified
		/// value.</remarks>
		/// <typeparam name="T">The type of the elements in the array.</typeparam>
		/// <param name="array">The two-dimensional array to fill. Must not be null.</param>
		/// <param name="value">The value to assign to each element of the array.</param>
		public void FillInPlace(T value) {
			Span<T> span = MemoryMarshal.CreateSpan(ref array[array.XMin(), array.YMin()], array.Length);

			for (int i = 0; i < array.Length; i++) {
				span[i] = value;
			}
		}
	}
}
