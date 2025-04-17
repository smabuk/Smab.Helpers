namespace Smab.Helpers;
public static partial class StringHelpers {
	/// <summary>
	/// Determines whether the specified string contains any non-whitespace characters.
	/// </summary>
	/// <param name="value">The string to check. Can be <see langword="null"/>.</param>
	/// <returns><see langword="true"/> if the string is not <see langword="null"/> or empty and contains at least one
	/// non-whitespace character; otherwise, <see langword="false"/>.</returns>
	public static bool HasNonWhiteSpaceContent([NotNullWhen(true)] this string? value) => !string.IsNullOrWhiteSpace(value);
}
