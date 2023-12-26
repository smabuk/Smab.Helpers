using System.Diagnostics.CodeAnalysis;

namespace Smab.Helpers;
public interface ISimpleParsable<TSelf> : IParsable<TSelf> where TSelf: IParsable<TSelf> {

	//
	// Summary:
	//     Parses a string into a value.
	//
	// Parameters:
	//   s:
	//     The string to parse.
	//
	//   provider:
	//     An object that provides culture-specific formatting information about s.
	//
	// Returns:
	//     The result of parsing s.
	//
	// Exceptions:
	//   T:System.ArgumentNullException:
	//     s is null.
	//
	//   T:System.FormatException:
	//     s is not in the correct format.
	//
	//   T:System.OverflowException:
	//     s is not representable by TSelf.
	static new abstract TSelf Parse(string s, IFormatProvider? provider);
	//
	// Summary:
	//     Tries to parse a string into a value.
	//
	// Parameters:
	//   s:
	//     The string to parse.
	//
	//   provider:
	//     An object that provides culture-specific formatting information about s.
	//
	//   result:
	//     When this method returns, contains the result of successfully parsing s or an
	//     undefined value on failure.
	//
	// Returns:
	//     true if s was successfully parsed; otherwise, false.
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
