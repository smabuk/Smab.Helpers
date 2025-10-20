using System.Numerics;

namespace Smab.Helpers;
public static partial class ParsingHelpers {

	extension(string s) {
		/// <summary>
		/// Converts each character in the specified string to a numeric value of type <typeparamref name="T"/>.
		/// </summary>
		/// <remarks>This method processes each character in the input string individually and attempts to parse it into
		/// the specified numeric type. Ensure that the input string contains only characters that can be converted to valid
		/// numeric values of type <typeparamref name="T"/>.</remarks>
		/// <typeparam name="T">The numeric type to which each character is converted. Must implement <see cref="System.Numerics.INumber{T}"/>.</typeparam>
		/// <param name="s">The input string containing characters to be converted to digits.</param>
		/// <param name="provider">An optional format provider to use for parsing each character. If <see langword="null"/>, the current culture is
		/// used.</param>
		/// <returns>An <see cref="IEnumerable{T}"/> containing the numeric values of type <typeparamref name="T"/> corresponding to
		/// each character in the input string.</returns>
		public IEnumerable<T> AsDigits<T>(IFormatProvider? provider = null) where T : INumber<T> =>
			s.Select(x => T.Parse($"{x}", provider));

		/// <summary>
		/// Converts each character in the string to its numeric representation if it is an ASCII digit; otherwise, substitutes
		/// a default value.
		/// </summary>
		/// <remarks>This method processes each character in the input string individually. Characters that are ASCII
		/// digits (0-9) are parsed into the specified numeric type <typeparamref name="T"/>. Non-ASCII digit characters are
		/// replaced with the provided <paramref name="defaultValue"/>, or <see langword="T.Zero"/> if <paramref
		/// name="defaultValue"/> is <c>null</c>.</remarks>
		/// <typeparam name="T">The numeric type to which the ASCII digits are converted. Must implement <see cref="INumber{T}"/>.</typeparam>
		/// <param name="s">The input string to process.</param>
		/// <param name="defaultValue">The value to use for non-ASCII digit characters. If <c>null</c>, <see langword="T.Zero"/> is used as the default.</param>
		/// <param name="provider">An optional format provider to use when parsing the ASCII digits. If <c>null</c>, the default format provider is
		/// used.</param>
		/// <returns>An <see cref="IEnumerable{T}"/> where each element is the numeric representation of an ASCII digit in the input
		/// string, or the specified default value for non-ASCII digit characters.</returns>
		public IEnumerable<T> AsDigitsOrDefaults<T>(T? defaultValue, IFormatProvider? provider = null) where T : INumber<T> =>
			s.Select(x => char.IsAsciiDigit(x) ? T.Parse($"{x}", provider) : defaultValue ?? T.Zero);
	}

	extension(IEnumerable<string> s) {
		/// <summary>
		/// Converts each string in the source collection to a collection of numeric digits of type <typeparamref name="T"/>.
		/// </summary>
		/// <typeparam name="T">The numeric type of the digits. Must implement <see cref="INumber{T}"/>.</typeparam>
		/// <param name="s">The collection of strings to convert. Each string is expected to represent a sequence of numeric digits.</param>
		/// <param name="provider">An optional format provider to interpret the numeric values. If <see langword="null"/>, the current culture is
		/// used.</param>
		/// <returns>A collection of collections, where each inner collection contains the numeric digits of type <typeparamref
		/// name="T"/> parsed from the corresponding string in the source collection.</returns>
		public IEnumerable<IEnumerable<T>> AsDigits<T>(IFormatProvider? provider = null) where T : INumber<T> =>
			s.Select(x => x.AsDigits<T>(provider));

		/// <summary>
		/// Converts each string in the source collection to a sequence of digits of type <typeparamref name="T"/>. If a string
		/// cannot be converted, the specified default value is used for its digits.
		/// </summary>
		/// <typeparam name="T">The numeric type of the digits, which must implement <see cref="INumber{T}"/>.</typeparam>
		/// <param name="s">The collection of strings to convert.</param>
		/// <param name="defaultValue">The value to use for digits when a string cannot be converted. Can be <see langword="null"/> if <typeparamref
		/// name="T"/> is nullable.</param>
		/// <param name="provider">An optional format provider to use for parsing the strings. If <see langword="null"/>, the current culture is used.</param>
		/// <returns>A collection of sequences, where each sequence represents the digits of the corresponding string in the source
		/// collection. If a string cannot be converted, its sequence contains the specified default value.</returns>
		public IEnumerable<IEnumerable<T>> AsDigitsOrDefaults<T>(T? defaultValue, IFormatProvider? provider = null) where T : INumber<T> =>
			s.Select(x => x.AsDigitsOrDefaults<T>(defaultValue, provider));
	}
}
