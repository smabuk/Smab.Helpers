namespace Smab.Helpers;

public static partial class ParsingHelpers {

	extension(IEnumerable<string> s) {
		/// <summary>
		/// Converts each string in the source collection to the specified type using the provided format provider.
		/// </summary>
		/// <remarks>This method uses the <see cref="IParsable{T}.Parse(string, IFormatProvider?)"/> method to perform
		/// the conversion.</remarks>
		/// <typeparam name="T">The type to which the strings will be converted. Must implement <see cref="IParsable{T}"/>.</typeparam>
		/// <param name="s">The source collection of strings to convert.</param>
		/// <param name="defaultIfInvalid">The default value to use if a string cannot be parsed. Defaults to the default value of <typeparamref name="T"/>.</param>
		/// <param name="provider">An optional format provider to use during parsing. If null, the default format provider is used.</param>
		/// <returns>An <see cref="IEnumerable{T}"/> containing the parsed values. If a string cannot be parsed, the corresponding
		/// element in the result will be <paramref name="defaultIfInvalid"/>.</returns>
		public IEnumerable<T> As<T>(T defaultIfInvalid = default!, IFormatProvider? provider = null) where T : IParsable<T>
			=> s.Select(s => s.As(defaultIfInvalid, provider));
	}

	extension(char c) {
		/// <summary>
		/// Attempts to parse the specified string into the specified type, returning a default value if parsing fails.
		/// </summary>
		/// <typeparam name="T">The type to which the string should be parsed. Must implement <see cref="IParsable{T}"/>.</typeparam>
		/// <param name="s">The string to parse.</param>
		/// <param name="defaultIfInvalid">The value to return if parsing fails. Defaults to the default value of <typeparamref name="T"/>.</param>
		/// <param name="provider">An optional <see cref="IFormatProvider"/> to use for parsing. If null, the default format provider is used.</param>
		/// <returns>The parsed value of type <typeparamref name="T"/> if parsing succeeds; otherwise, <paramref
		/// name="defaultIfInvalid"/>.</returns>
		public T As<T>(T defaultIfInvalid = default!, IFormatProvider? provider = null) where T : IParsable<T>
			=> T.TryParse(c.ToString(), provider, out T? value) switch { true => value, false => defaultIfInvalid };
	}

	extension(string s) {
		/// <summary>
		/// Attempts to parse the specified string into the specified type, returning a default value if parsing fails.
		/// </summary>
		/// <typeparam name="T">The type to which the string should be parsed. Must implement <see cref="IParsable{T}"/>.</typeparam>
		/// <param name="s">The string to parse.</param>
		/// <param name="defaultIfInvalid">The value to return if parsing fails. Defaults to the default value of <typeparamref name="T"/>.</param>
		/// <param name="provider">An optional <see cref="IFormatProvider"/> to use for parsing. If null, the default format provider is used.</param>
		/// <returns>The parsed value of type <typeparamref name="T"/> if parsing succeeds; otherwise, <paramref
		/// name="defaultIfInvalid"/>.</returns>
		public T As<T>(T defaultIfInvalid = default!, IFormatProvider? provider = null) where T : IParsable<T>
			=> T.TryParse(s, provider, out T? value) switch { true => value, false => defaultIfInvalid };

		/// <summary>
		/// Converts the elements of a delimited string into a sequence of values of type <typeparamref name="T"/>.
		/// </summary>
		/// <typeparam name="T">The numeric type to which each element in the string will be converted. Must implement <see cref="INumber{T}"/>.</typeparam>
		/// <param name="s">The input string containing delimited numeric values.</param>
		/// <param name="separator">An array of characters that delimit the substrings in <paramref name="s"/>. If <see langword="null"/>, whitespace
		/// is used as the default separator.</param>
		/// <param name="provider">An optional <see cref="IFormatProvider"/> to use for parsing each numeric value. If <see langword="null"/>, the
		/// current culture is used.</param>
		/// <returns>An <see cref="IEnumerable{T}"/> containing the parsed numeric values of type <typeparamref name="T"/>.</returns>
		public IEnumerable<T> As<T>(char[]? separator, IFormatProvider? provider = null) where T : INumber<T>
			=> s.TrimmedSplit(separator).Select(s => T.Parse(s, provider));

		/// <summary>
		/// Splits the specified string by the given separator and converts each segment to the specified numeric type.
		/// </summary>
		/// <typeparam name="T">The numeric type to which each segment of the string will be converted. Must implement <see
		/// cref="System.Numerics.INumber{T}"/>.</typeparam>
		/// <param name="s">The string to be split and converted. Cannot be <see langword="null"/>.</param>
		/// <param name="separator">The character used to separate the segments in the string.</param>
		/// <returns>An <see cref="IEnumerable{T}"/> containing the converted numeric values of the string segments. If the string is
		/// empty, returns an empty enumerable.</returns>
		public IEnumerable<T> As<T>(char separator) where T : INumber<T> =>
			s.As<T>((char[])[separator]);

		/// <summary>
		/// Converts the elements of a delimited string into a sequence of values of type <typeparamref name="T"/>.
		/// </summary>
		/// <typeparam name="T">The numeric type to which each element of the string will be converted. Must implement <see cref="INumber{T}"/>.</typeparam>
		/// <param name="s">The input string containing delimited values to be parsed.</param>
		/// <param name="separator">An array of strings that delimit the substrings in <paramref name="s"/>. If <c>null</c>, whitespace is used as the
		/// default separator.</param>
		/// <param name="provider">An optional <see cref="IFormatProvider"/> to supply culture-specific formatting information for parsing. If
		/// <c>null</c>, the current culture is used.</param>
		/// <returns>An <see cref="IEnumerable{T}"/> containing the parsed values of type <typeparamref name="T"/>.</returns>
		public IEnumerable<T> As<T>(string[]? separator, IFormatProvider? provider = null) where T : INumber<T>
			=> s.TrimmedSplit(separator).Select(s => T.Parse(s, provider));

		/// <summary>
		/// Splits the input string by the specified separator and converts each segment to the specified numeric type.
		/// </summary>
		/// <typeparam name="T">The numeric type to which each segment of the string will be converted. Must implement <see cref="INumber{T}"/>.</typeparam>
		/// <param name="s">The input string to be split and converted. Cannot be <see langword="null"/>.</param>
		/// <param name="separator">The string used to separate the segments in the input string. Cannot be <see langword="null"/> or empty.</param>
		/// <returns>An <see cref="IEnumerable{T}"/> containing the converted numeric values. If the input string is empty, returns an
		/// empty sequence.</returns>
		public IEnumerable<T> As<T>(string separator) where T : INumber<T> =>
			s.As<T>((string[])[separator]);
	}
}
