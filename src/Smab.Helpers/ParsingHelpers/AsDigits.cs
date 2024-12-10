using System.Numerics;

namespace Smab.Helpers;
public static partial class ParsingHelpers {

	public static IEnumerable<T> AsDigits<T>(this string s, IFormatProvider? provider = null) where T : INumber<T> =>
		s.Select(x => T.Parse($"{x}", provider));

	public static IEnumerable<IEnumerable<T>> AsDigits<T>(this IEnumerable<string> s, IFormatProvider? provider = null) where T : INumber<T> =>
		s.Select(x => x.AsDigits<T>(provider));


	public static IEnumerable<T> AsDigitsOrDefaults<T>(this string s, T? defaultValue, IFormatProvider? provider = null) where T : INumber<T> =>
		s.Select(x => char.IsAsciiDigit(x) ? T.Parse($"{x}", provider) : defaultValue ?? T.Zero);

	public static IEnumerable<IEnumerable<T>> AsDigitsOrDefaults<T>(this IEnumerable<string> s, T? defaultValue, IFormatProvider? provider = null) where T : INumber<T> =>
		s.Select(x => x.AsDigitsOrDefaults<T>(defaultValue, provider));

}
