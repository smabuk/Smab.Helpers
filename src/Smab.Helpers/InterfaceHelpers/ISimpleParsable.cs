namespace Smab.Helpers;
public interface ISimpleParsable<TSelf> : IParsable<TSelf> where TSelf: IParsable<TSelf> {

	/// <summary>
	/// Converts the string representation of a value to its <typeparamref name="TSelf"/> equivalent.
	/// </summary>
	/// <param name="s">The string representation of the value to convert. This cannot be <see langword="null"/> or empty.</param>
	/// <param name="provider">An object that provides culture-specific formatting information, or <see langword="null"/> to use the current
	/// culture.</param>
	/// <returns>An instance of <typeparamref name="TSelf"/> that is equivalent to the value specified in <paramref name="s"/>.</returns>
	static new abstract TSelf Parse(string s, IFormatProvider? provider);

	/// <summary>
	/// Attempts to parse the specified string into a value of the current type.
	/// </summary>
	/// <remarks>This method does not throw an exception if parsing fails. Instead, it returns <see
	/// langword="false"/> and sets <paramref name="result"/> to its default value.</remarks>
	/// <param name="s">The string to parse. This parameter cannot be <see langword="null"/> if parsing is expected to succeed.</param>
	/// <param name="provider">An object that provides culture-specific formatting information for parsing <paramref name="s"/>. This parameter
	/// can be <see langword="null"/> to use the current culture.</param>
	/// <param name="result">When this method returns, contains the parsed value if the operation was successful; otherwise, contains the
	/// default value for the type.</param>
	/// <returns><see langword="true"/> if <paramref name="s"/> was successfully parsed; otherwise, <see langword="false"/>.</returns>
	[SuppressMessage("Style", "IDE0060:Remove unused parameter", Justification = "Overriding for simplicity")]
	static new bool TryParse([NotNullWhen(true)] string? s, IFormatProvider? provider, [MaybeNullWhen(false)] out TSelf result) {
		result = default!;
		try {
			result = TSelf.Parse(s ?? "", null);
		} catch (Exception) {
			return false;
		}
		return true;
	}
}
