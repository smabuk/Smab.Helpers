using System.Numerics;

namespace Smab.Helpers;
public static partial class ParsingHelpers {

	public static IEnumerable<T> AsDigits<T>(this string s, IFormatProvider? provider = null) where T : INumber<T> =>
		s.Select(x => T.Parse($"{x}", provider));

	public static IEnumerable<T> AsDigits<T>(this IEnumerable<string> s, IFormatProvider? provider = null) where T : INumber<T> =>
		s.Select(x => T.Parse($"{x}", provider));



	public static IEnumerable<T> AsDigitsOrDefault<T>(this string s, T? defaultValue, IFormatProvider? provider = null) where T : INumber<T> =>
		s.Select(x => char.IsAsciiDigit(x) ? T.Parse($"{x}", provider) : defaultValue ?? T.Zero);
}
