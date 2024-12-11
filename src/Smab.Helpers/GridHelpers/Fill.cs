using System.Runtime.InteropServices;

namespace Smab.Helpers;
public static partial class ArrayHelpers {
	public static T[,] Fill<T>(this T[,] array, T value) {
		T[,] result = (T[,])array.Clone();

		Span<T> span = MemoryMarshal.CreateSpan(ref result[result.XMin(), result.YMin()], array.Length);

		for (int i = 0; i < result.Length; i++) {
			span[i] = value;
		}

		return result;
	}

	public static void FillInPlace<T>(this T[,] array, T value) {
		Span<T> span = MemoryMarshal.CreateSpan(ref array[array.XMin(), array.YMin()], array.Length);

		for (int i = 0; i < array.Length; i++) {
			span[i] = value;
		}
	}
}
