namespace Smab.Helpers;
public static partial class ArrayHelpers {
	extension<T>(T[,] array) {
		/// <summary>
		/// Creates a shallow copy of the underlying two-dimensional array.
		/// </summary>
		/// <remarks>Modifications to the returned array do not affect the original array, and vice versa. However, if
		/// the array contains reference types, the references themselves are copied, not the objects they refer to.</remarks>
		/// <returns>A new two-dimensional array containing the same elements as the original array. The returned array is a shallow
		/// copy; reference-type elements are not cloned.</returns>
		public T[,] Copy() {
			T[,] result = (T[,])array.Clone();
			return result;
		}
	}
}
