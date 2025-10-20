namespace Smab.Helpers;

public static class DataInputCleanup {
	extension(string? input) {
		/// <summary>
		/// Removes the trailing blank line from the specified string, or returns the provided default value if the input is
		/// <see langword="null"/>.
		/// </summary>
		/// <param name="input">The input string to process. Can be <see langword="null"/>.</param>
		/// <param name="defaultValue">The value to return if <paramref name="input"/> is <see langword="null"/>. Defaults to an empty string.</param>
		/// <returns>A string with the trailing blank line removed if <paramref name="input"/> is not <see langword="null"/>; 
		/// otherwise, the value of <paramref name="defaultValue"/>.</returns>
		public string StripTrailingBlankLineOrDefault(string defaultValue = "")
			=> input is not null ? input.RemoveBlankLineFromEnd() : defaultValue;

		/// <summary>
		/// Removes any trailing blank lines from the end of the specified string.
		/// </summary>
		/// <param name="input">The input string to process. Can be <see langword="null"/>.</param>
		/// <returns>A string with trailing blank lines removed. If <paramref name="input"/> is <see langword="null"/>,  an empty string
		/// is returned.</returns>
		public string RemoveBlankLineFromEnd() => input?.TrimEnd() ?? "";
	}

	extension(string[]? input) {
		/// <summary>
		/// Removes the trailing blank line from the input array of strings, or returns the specified default value if the
		/// input is null.
		/// </summary>
		/// <param name="input">The array of strings to process. If null, the method returns the <paramref name="defaultValue"/>.</param>
		/// <param name="defaultValue">The array of strings to return if <paramref name="input"/> is null. If this parameter is null, an empty array is
		/// returned.</param>
		/// <returns>An array of strings with the trailing blank line removed, if <paramref name="input"/> is not null; otherwise, the
		/// <paramref name="defaultValue"/> or an empty array if <paramref name="defaultValue"/> is null.</returns>
		public string[] StripTrailingBlankLineOrDefault(string[]? defaultValue = default)
			=> input is not null ? input.RemoveBlankLineFromEnd() : (defaultValue is not null ? defaultValue : []);

		/// <summary>
		/// Removes the last line from the input array if it is blank or consists only of whitespace.
		/// </summary>
		/// <param name="input">The array of strings to process. Can be null.</param>
		/// <returns>A new array of strings with the last line removed if it is blank or consists only of whitespace. If the input is
		/// null, an empty array is returned. If the last line is not blank, the original array is returned.</returns>
		public string[] RemoveBlankLineFromEnd() {
			if (input is null) { return []; }

			return string.IsNullOrWhiteSpace(input[^1]) ? input[..^1] : input;
		}
	}
}
