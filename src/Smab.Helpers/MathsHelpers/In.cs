using System.Numerics;

namespace Smab.Helpers;
public static partial class MathsHelpers {
	public static bool IsIn<T>(this T value, IList<T> values) where T : INumber<T>
		=> values.Contains(value);

	public static bool IsIn<T>(this T value, HashSet<T> values) where T : INumber<T>
		=> values.Contains(value);

	public static bool IsIn<T>(this T value, IEnumerable<T> values) where T : INumber<T>
		=> values.Contains(value);




	public static bool IsInRange<T>(this T value, T minValue, T maxValueExclusive) where T : INumber<T>
	=> minValue <= value && value < maxValueExclusive;

	public static bool IsInRange<T>(this T value, (T MinValue, T MaxValueExclusive) range) where T : INumber<T>
		=> range.MinValue <= value && value < range.MaxValueExclusive;

}
