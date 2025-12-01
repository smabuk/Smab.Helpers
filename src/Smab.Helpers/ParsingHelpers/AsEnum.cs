namespace Smab.Helpers;
public static partial class ParsingHelpers {

	extension(ReadOnlySpan<char> s) {
		/// <summary>
		/// Converts the specified <see cref="ReadOnlySpan{T}"/> of characters to the corresponding enumeration value of type
		/// <typeparamref name="T"/>.
		/// </summary>
		/// <remarks>The comparison is case-insensitive. Use this method to parse a span of characters into an
		/// enumeration value when performance is critical.</remarks>
		/// <typeparam name="T">The enumeration type to which the span will be converted. Must be a value type that is an enumeration.</typeparam>
		/// <param name="s">The span of characters representing the name or numeric value of one or more constants in the enumeration
		/// <typeparamref name="T"/>.</param>
		/// <returns>The enumeration value of type <typeparamref name="T"/> that corresponds to the specified span of characters.</returns>
		public T AsEnum<T>() where T : struct => Enum.Parse<T>(s, true);

		/// <summary>
		/// Converts the specified <see cref="ReadOnlySpan{T}"/> of characters to the corresponding enumeration value.
		/// </summary>
		/// <remarks>The comparison is case-insensitive. If the span does not represent a valid value of the enumeration
		/// type <typeparamref name="T"/>,  the method returns <paramref name="TDefault"/>.</remarks>
		/// <typeparam name="T">The enumeration type to convert to. Must be a value type that is an enumeration.</typeparam>
		/// <param name="s">The span of characters to parse as an enumeration value.</param>
		/// <param name="TDefault">The default value to return if the conversion fails. Defaults to the default value of <typeparamref name="T"/>.</param>
		/// <returns>The enumeration value of type <typeparamref name="T"/> that corresponds to the parsed span of characters,  or
		/// <paramref name="TDefault"/> if the conversion fails.</returns>
		public T AsEnumOrDefault<T>(T TDefault = default) where T : struct =>
			Enum.TryParse<T>(s, true, out T result)
			? result
			: TDefault;
	}

	extension(string s) {
		/// <summary>
		/// Converts the specified string to the corresponding enumeration value of type <typeparamref name="T"/>.
		/// </summary>
		/// <remarks>This method performs a case-insensitive comparison when parsing the string. Ensure that the input
		/// string matches a valid enumeration value of type <typeparamref name="T"/>.</remarks>
		/// <typeparam name="T">The enumeration type to convert the string to. Must be a non-nullable value type.</typeparam>
		/// <param name="s">The string representation of the enumeration value to convert. The comparison is case-insensitive.</param>
		/// <returns>The enumeration value of type <typeparamref name="T"/> that corresponds to the specified string.</returns>
		public T AsEnum<T>() where T : struct => Enum.Parse<T>(s, true);

		/// <summary>
		/// Converts the specified string to the corresponding enumeration value of type <typeparamref name="T"/>.
		/// </summary>
		/// <typeparam name="T">The enumeration type to which the string is converted. Must be a value type that is an enumeration.</typeparam>
		/// <param name="s">The string representation of the enumeration value to convert. The comparison is case-insensitive.</param>
		/// <param name="TDefault">The default value to return if the conversion fails. Defaults to the default value of <typeparamref name="T"/>.</param>
		/// <returns>The enumeration value of type <typeparamref name="T"/> that corresponds to the specified string,  or <paramref
		/// name="TDefault"/> if the conversion fails.</returns>
		public T AsEnumOrDefault<T>(T TDefault = default) where T : struct =>
			Enum.TryParse<T>(s, true, out T result)
			? result
			: TDefault;
	}

	extension(char c) {
		/// <summary>
		/// Converts the current value to the specified enumeration type using a case-insensitive match.
		/// </summary>
		/// <remarks>Throws an exception if the current value does not match any member of the specified enumeration
		/// type. The conversion is performed using a case-insensitive comparison.</remarks>
		/// <typeparam name="T">The enumeration type to convert the value to. Must be a value type that represents an enum.</typeparam>
		/// <returns>The value of type <typeparamref name="T"/> that corresponds to the current value.</returns>
		public T AsEnum<T>() where T : struct => Enum.Parse<T>(c.ToString(), true);

		/// <summary>
		/// Attempts to convert the current value to the specified enumeration type. Returns the default value if the
		/// conversion fails.
		/// </summary>
		/// <remarks>The conversion is case-insensitive. This method is useful when parsing values that may not always
		/// correspond to a valid enumeration member.</remarks>
		/// <typeparam name="T">The enumeration type to convert to. Must be a value type that represents an enum.</typeparam>
		/// <param name="TDefault">The value to return if the conversion is unsuccessful. Defaults to the default value of the enumeration type.</param>
		/// <returns>The converted value of type <typeparamref name="T"/> if the conversion succeeds; otherwise, <paramref
		/// name="TDefault"/>.</returns>
		public T AsEnumOrDefault<T>(T TDefault = default) where T : struct =>
			Enum.TryParse<T>(c.ToString(), true, out T result)
			? result
			: TDefault;
	}
}
