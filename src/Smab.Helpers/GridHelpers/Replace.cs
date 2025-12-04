using System.Runtime.InteropServices;

namespace Smab.Helpers;
public static partial class ArrayHelpers {
	extension<T>(T[,] array) {
		/// <summary>
		/// Returns a new two-dimensional array in which all occurrences of a specified value are replaced with a new value.
		/// </summary>
		/// <param name="value">The value to search for in the array. All elements equal to this value will be replaced.</param>
		/// <param name="replaceWith">The value to use as a replacement for each occurrence of the specified value.</param>
		/// <returns>A new two-dimensional array with all elements equal to the specified value replaced by the replacement value. The
		/// original array is not modified.</returns>
		public T[,] Replace(T value, T replaceWith) {
			T[,] result = (T[,])array.Clone();

			Span<T> span = MemoryMarshal.CreateSpan(ref result[result.XMin(), result.YMin()], array.Length);

			for (int i = 0; i < result.Length; i++) {
				if (span[i]?.Equals(value) ?? false) {
					span[i] = replaceWith;
				}
			}

			return result;
		}

		/// <summary>
		/// Replaces all occurrences of a specified value in the underlying array with a new value, modifying the array in
		/// place.
		/// </summary>
		/// <remarks>This method updates the array directly and does not create a copy. Value comparison is performed
		/// using the <see cref="object.Equals(object)"/> method. If the array contains reference types, <see
		/// langword="null"/> values are handled safely.</remarks>
		/// <param name="value">The value to search for and replace within the array.</param>
		/// <param name="replaceWith">The value to assign in place of each occurrence of the specified value.</param>
		public void ReplaceInPlace(T value, T replaceWith) {
			Span<T> span = MemoryMarshal.CreateSpan(ref array[array.XMin(), array.YMin()], array.Length);

			for (int i = 0; i < array.Length; i++) {
				if (span[i]?.Equals(value) ?? false) {
					span[i] = replaceWith;
				}
			}
		}
	}
}
