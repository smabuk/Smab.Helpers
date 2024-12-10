using System.Numerics;

namespace Smab.Helpers;
public static partial class ParsingHelpers {

	public static IEnumerable<T> AsDigits<T>(this string s, IFormatProvider? provider = null) where T : INumber<T> =>
		s.Select(x => T.Parse($"{x}", provider));

	public static IEnumerable<T> AsDigits<T>(this IEnumerable<string> s, IFormatProvider? provider = null) where T : INumber<T> =>
		s.Select(x => T.Parse($"{x}", provider));



	public static IEnumerable<T> AsDigitsOrDefault<T>(this string s, T? defaultValue, IFormatProvider? provider = null) where T : INumber<T> {
		for (int i = 0; i < s.Length; i++) {
			if (T.TryParse($"{s[i]}", provider, out T? value)) {
				yield return value;
			} else {
				yield return defaultValue ?? T.Zero;
			}
		}
	}
}
