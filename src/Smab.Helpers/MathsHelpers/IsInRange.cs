using System.Numerics;

namespace Smab.Helpers;
public static partial class MathsHelpers {
	/// <summary>
	/// Determines whether the specified value is within the given range.
	/// </summary>
	/// <remarks>This method uses the generic <see cref="INumber{T}"/> interface, allowing it to work with any
	/// numeric type that implements this interface, such as <see cref="int"/>, <see cref="double"/>, or <see
	/// cref="decimal"/>.</remarks>
	/// <typeparam name="T">The numeric type of the value and range bounds. Must implement <see cref="INumber{T}"/>.</typeparam>
	/// <param name="value">The value to check.</param>
	/// <param name="minValue">The inclusive lower bound of the range.</param>
	/// <param name="maxValueExclusive">The exclusive upper bound of the range.</param>
	/// <returns><see langword="true"/> if <paramref name="value"/> is greater than or equal to <paramref name="minValue"/> and less
	/// than <paramref name="maxValueExclusive"/>; otherwise, <see langword="false"/>.</returns>
	public static bool IsInRange<T>(this T value, T minValue, T maxValueExclusive) where T : INumber<T>
		=> minValue <= value && value < maxValueExclusive;

	/// <summary>
	/// Determines whether the specified value is within the given range.
	/// </summary>
	/// <remarks>This method uses the inclusive lower bound and exclusive upper bound convention for range
	/// checking.</remarks>
	/// <typeparam name="T">The numeric type of the value and range bounds. Must implement <see cref="INumber{T}"/>.</typeparam>
	/// <param name="value">The value to check.</param>
	/// <param name="range">A tuple representing the range, where <c>MinValue</c> is the inclusive lower bound and  <c>MaxValueExclusive</c> is
	/// the exclusive upper bound.</param>
	/// <returns><see langword="true"/> if <paramref name="value"/> is greater than or equal to <c>MinValue</c>  and less than
	/// <c>MaxValueExclusive</c>; otherwise, <see langword="false"/>.</returns>
	public static bool IsInRange<T>(this T value, (T MinValue, T MaxValueExclusive) range) where T : INumber<T>
		=> range.MinValue <= value && value < range.MaxValueExclusive;
}
