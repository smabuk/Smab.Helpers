namespace Smab.Helpers;

public static class DataInputCleanup {
	/// <summary>
	/// If a blank line is found at the end of the array then remove it.
	/// Never returns null.
	/// </summary>
	/// <param name="input"></param>
	/// <returns>The input with the final string removed if it is empty or whitespace. Returns an empty array if null.</returns>
	public static string   StripTrailingBlankLineOrDefault(this string?   input, string defaultValue = "")
		=> input is not null ? input.RemoveBlankLineFromEnd() : defaultValue;
	public static string[] StripTrailingBlankLineOrDefault(this string[]? input, string[]? defaultValue = default)
		=> input is not null ? input.RemoveBlankLineFromEnd() : (defaultValue is not null ? defaultValue : []);

	public static string[] RemoveBlankLineFromEnd(this string[]? input) {
		if (input is null) { return []; }

		return string.IsNullOrWhiteSpace(input[^1]) ? input[..^1] : input;
	}

	public static string RemoveBlankLineFromEnd(this string? input) => input?.TrimEnd() ?? "";

}
