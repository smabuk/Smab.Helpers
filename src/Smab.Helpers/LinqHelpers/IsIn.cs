namespace Smab.Helpers;
public static partial class LinqHelpers {
	public static bool IsIn<T>(this T value, IEnumerable<T> values) => values.Contains(value);
}
