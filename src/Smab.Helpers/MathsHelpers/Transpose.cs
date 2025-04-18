﻿namespace Smab.Helpers;
public static partial class MathsHelpers {
	/// <summary>
	/// Transposes a sequence of <see cref="Point"/> objects by swapping their X and Y coordinates.
	/// </summary>
	/// <remarks>This method applies the <see cref="Point.Transpose"/> method to each <see cref="Point"/> in the
	/// input sequence.</remarks>
	/// <param name="points">The sequence of <see cref="Point"/> objects to transpose. Cannot be <see langword="null"/>.</param>
	/// <returns>A new sequence of <see cref="Point"/> objects with their X and Y coordinates swapped. The order of the points in
	/// the sequence is preserved.</returns>
	public static IEnumerable<Point> Transpose(this IEnumerable<Point> points) => points.Select(point => point.Transpose());

	/// <summary>
	/// Swaps the positions of the two elements in the specified tuple.
	/// </summary>
	/// <typeparam name="T">The type of the elements in the tuple.</typeparam>
	/// <param name="item">The tuple whose elements are to be swapped.</param>
	/// <returns>A new tuple with the positions of <see cref="ValueTuple{T1, T2}.Item1"/> and <see cref="ValueTuple{T1, T2}.Item2"/>
	/// reversed.</returns>
	public static (T Item1, T Item2) Transpose<T>(this (T Item1, T Item2) item) => (item.Item2, item.Item1);
}
