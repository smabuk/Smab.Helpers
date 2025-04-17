namespace Smab.Helpers;
public static partial class ParsingHelpers {

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
	public static T AsEnum<T>(this ReadOnlySpan<char> s) where T : struct => Enum.Parse<T>(s, true);

	/// <summary>
	/// Converts the specified string to the corresponding enumeration value of type <typeparamref name="T"/>.
	/// </summary>
	/// <remarks>This method performs a case-insensitive comparison when parsing the string. Ensure that the input
	/// string matches a valid enumeration value of type <typeparamref name="T"/>.</remarks>
	/// <typeparam name="T">The enumeration type to convert the string to. Must be a non-nullable value type.</typeparam>
	/// <param name="s">The string representation of the enumeration value to convert. The comparison is case-insensitive.</param>
	/// <returns>The enumeration value of type <typeparamref name="T"/> that corresponds to the specified string.</returns>
	public static T AsEnum<T>(this string s) where T : struct => Enum.Parse<T>(s, true);
	
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
	public static T AsEnumOrDefault<T>(this ReadOnlySpan<char> s, T TDefault = default) where T : struct => 
		Enum.TryParse<T>(s, true, out T result)
		? result
		: TDefault;

	/// <summary>
	/// Converts the specified string to the corresponding enumeration value of type <typeparamref name="T"/>.
	/// </summary>
	/// <typeparam name="T">The enumeration type to which the string is converted. Must be a value type that is an enumeration.</typeparam>
	/// <param name="s">The string representation of the enumeration value to convert. The comparison is case-insensitive.</param>
	/// <param name="TDefault">The default value to return if the conversion fails. Defaults to the default value of <typeparamref name="T"/>.</param>
	/// <returns>The enumeration value of type <typeparamref name="T"/> that corresponds to the specified string,  or <paramref
	/// name="TDefault"/> if the conversion fails.</returns>
	public static T AsEnumOrDefault<T>(this string s, T TDefault = default) where T : struct => 
		Enum.TryParse<T>(s, true, out T result)
		? result
		: TDefault;
}
