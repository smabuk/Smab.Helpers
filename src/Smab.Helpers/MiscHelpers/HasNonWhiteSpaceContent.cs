namespace Smab.Helpers;
public static partial class StringHelpers {
	public static bool HasNonWhiteSpaceContent([NotNullWhen(true)] this string? value) => !string.IsNullOrWhiteSpace(value);
}
