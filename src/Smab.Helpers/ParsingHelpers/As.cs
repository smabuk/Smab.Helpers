using System.Numerics;

namespace Smab.Helpers;
public static partial class ParsingHelpers {
	public static IEnumerable<T> As<T>(this IEnumerable<string> s, T defaultIfInvalid = default!, IFormatProvider? provider = null) where T : IParsable<T>
		=> s.Select(s => s.As(defaultIfInvalid, provider));
	public static T As<T>(this string s, T defaultIfInvalid = default!, IFormatProvider? provider = null) where T : IParsable<T>
		=> T.TryParse(s, provider, out T? value) switch { true => value, false => defaultIfInvalid };
	public static IEnumerable<T> As<T>(this string s, char[]? separator, IFormatProvider? provider = null) where T : INumber<T>
		=> s.TrimmedSplit(separator).Select(s => T.Parse(s, provider));
	public static IEnumerable<T> As<T>(this string s, char separator) where T : INumber<T> =>
		s.As<T>((char[])[separator]);
	public static IEnumerable<T> As<T>(this string s, string[]? separator, IFormatProvider? provider = null) where T : INumber<T>
		=> s.TrimmedSplit(separator).Select(s => T.Parse(s, provider));
	public static IEnumerable<T> As<T>(this string s, string separator) where T : INumber<T> =>
		s.As<T>((string[])[separator]);
}
