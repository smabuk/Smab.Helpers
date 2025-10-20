namespace Smab.Helpers;
public static partial class StringHelpers {
	extension([NotNullWhen(true)] string? value) {
		/// <summary>
		/// Determines whether the specified string contains any non-whitespace characters.
		/// </summary>
		/// <param name="value">The string to check. Can be <see langword="null"/>.</param>
		/// <returns><see langword="true"/> if the string is not <see langword="null"/> or empty and contains at least one
		/// non-whitespace character; otherwise, <see langword="false"/>.</returns>
		public bool HasNonWhiteSpaceContent() => !string.IsNullOrWhiteSpace(value);
	}
}
