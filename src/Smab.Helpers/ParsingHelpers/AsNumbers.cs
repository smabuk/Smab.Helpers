using System.Numerics;
using System.Runtime.CompilerServices;

namespace Smab.Helpers;
public static partial class ParsingHelpers {
	private static readonly char[] DefaultSeparators = [',', '|', ' ', ':', ';', '~', '(', ')', '{', '}', '[', ']'];

	/// <summary>
	/// Converts the segments of the specified string into a sequence of numeric values of type <typeparamref name="T"/>.
	/// </summary>
	/// <remarks>This method trims the input string, splits it into segments using the specified separator, and
	/// converts each segment to the specified numeric type <typeparamref name="T"/>. Ensure that all segments of the input
	/// string are valid representations of the numeric type <typeparamref name="T"/> to avoid exceptions.</remarks>
	/// <typeparam name="T">The numeric type to which each segment will be converted. Must implement <see cref="System.Numerics.INumber{T}"/>.</typeparam>
	/// <param name="s">The input string to be split and converted into numeric values.</param>
	/// <param name="separator">The string used to separate segments in the input string. If <see langword="null"/>, whitespace is used as the
	/// default separator.</param>
	/// <returns>An <see cref="IEnumerable{T}"/> containing the numeric values parsed from the segments of the input string.</returns>
	public static IEnumerable<T> AsNumbers<T>(this string s, string? separator) where T : INumber<T> =>
		s.TrimmedSplit(separator).Select(s => s.As<T>());

	/// <summary>
	/// Converts a delimited string into a sequence of numeric values of the specified type.
	/// </summary>
	/// <remarks>This method trims the input string, splits it by the specified separator, and converts each
	/// resulting substring into the specified numeric type <typeparamref name="T"/>. If any substring cannot be converted,
	/// an exception may be thrown depending on the implementation of the <c>As&lt;T&gt;</c> method.</remarks>
	/// <typeparam name="T">The numeric type to which each delimited value will be converted. Must implement <see cref="INumber{T}"/>.</typeparam>
	/// <param name="s">The input string containing delimited numeric values.</param>
	/// <param name="separator">The character used to separate values in the input string.</param>
	/// <returns>An <see cref="IEnumerable{T}"/> containing the numeric values parsed from the input string.</returns>
	public static IEnumerable<T> AsNumbers<T>(this string s, char separator) where T : INumber<T> =>
		s.TrimmedSplit(separator).Select(s => s.As<T>());

	/// <summary>
	/// Converts the substrings of the specified string, separated by the given characters, into a sequence of numeric
	/// values of the specified type.
	/// </summary>
	/// <remarks>This method trims the input string before splitting it using the specified separators. Each
	/// resulting substring is then converted to the specified numeric type <typeparamref name="T"/>.</remarks>
	/// <typeparam name="T">The numeric type to which each substring will be converted. Must implement <see
	/// cref="System.Numerics.INumber{T}"/>.</typeparam>
	/// <param name="s">The input string to be split and converted into numeric values.</param>
	/// <param name="separator">An array of characters that delimit the substrings in the input string.</param>
	/// <returns>An <see cref="IEnumerable{T}"/> containing the numeric values parsed from the substrings of the input string.</returns>
	[OverloadResolutionPriority(2)]
	public static IEnumerable<T> AsNumbers<T>(this string s, char[] separator) where T : INumber<T> =>
		s.TrimmedSplit(separator).Select(s => s.As<T>());

	/// <summary>
	/// Converts the segments of the specified string into a sequence of numeric values of type <typeparamref name="T"/>.
	/// </summary>
	/// <remarks>This method splits the input string into segments using the specified or default separators, trims
	/// each segment, and converts it to the specified numeric type <typeparamref name="T"/>. The method assumes that all
	/// segments are valid representations of the numeric type.</remarks>
	/// <typeparam name="T">The numeric type to which each segment will be converted. Must implement <see cref="System.Numerics.INumber{T}"/>.</typeparam>
	/// <param name="s">The input string to be split and converted into numeric values.</param>
	/// <param name="separator">An array of strings that delimit the segments of the input string. If <see langword="null"/>, a default set of
	/// separators is used.</param>
	/// <returns>An <see cref="IEnumerable{T}"/> containing the numeric values parsed from the segments of the input string.</returns>
	[OverloadResolutionPriority(1)]
	public static IEnumerable<T> AsNumbers<T>(this string s, string[]? separator = null) where T : INumber<T> =>
		separator is null
		? s.TrimmedSplit(DefaultSeparators).Select(s => s.As<T>())
		: s.TrimmedSplit(separator).Select(s => s.As<T>());

	/// <summary>
	/// Converts a sequence of strings into a sequence of numeric sequences of type <typeparamref name="T"/>.
	/// </summary>
	/// <remarks>This method uses the <see cref="INumber{T}"/> interface to convert each string into a sequence of
	/// numbers of type <typeparamref name="T"/>. Ensure that the input strings are in a format compatible with the numeric
	/// type <typeparamref name="T"/>.</remarks>
	/// <typeparam name="T">The numeric type to which the strings will be converted. Must implement <see cref="INumber{T}"/>.</typeparam>
	/// <param name="s">The sequence of strings to be converted. Each string in the sequence is expected to represent a sequence of
	/// numbers.</param>
	/// <returns>A sequence of numeric sequences, where each inner sequence corresponds to the numeric representation of a string in
	/// the input sequence.</returns>
	public static IEnumerable<IEnumerable<T>> AsNumbers<T>(this IEnumerable<string> s) where T : INumber<T> =>
		s.Select(x => x.AsNumbers<T>());

	/// <summary>
	/// Splits the input string into substrings based on the specified separators and converts each substring to an
	/// integer.
	/// </summary>
	/// <remarks>This method uses the <see cref="int.Parse(string)"/> method to convert substrings to integers. 
	/// Ensure that the input string contains valid integer representations to avoid exceptions.</remarks>
	/// <param name="s">The input string to be split and converted. Cannot be <see langword="null"/>.</param>
	/// <param name="separator">An array of strings that delimit the substrings in the input string. If <see langword="null"/>, whitespace is used
	/// as the default separator.</param>
	/// <returns>An <see cref="IEnumerable{T}"/> of integers parsed from the substrings of the input string.  If the input string is
	/// empty or contains no valid integers, the returned sequence will be empty.</returns>
	public static IEnumerable<int> AsInts(this string s, string[]? separator = null) =>
		s.AsNumbers<int>(separator);

	/// <summary>
	/// Converts the numeric substrings in the specified string to a sequence of <see langword="long"/> values.
	/// </summary>
	/// <param name="s">The input string containing numeric substrings to convert.</param>
	/// <param name="separator">An optional array of strings that delimit the substrings in the input string. If <see langword="null"/>, whitespace
	/// characters are used as the default delimiters.</param>
	/// <returns>An <see cref="IEnumerable{T}"/> of <see langword="long"/> values parsed from the numeric substrings in the input
	/// string.</returns>
	public static IEnumerable<long> AsLongs(this string s, string[]? separator = null) =>
		s.AsNumbers<long>(separator);



}