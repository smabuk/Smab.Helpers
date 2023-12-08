using System.Numerics;

namespace Smab.Helpers;

public static class ParsingHelpers {

	public static IEnumerable<T> AsDigits<T>(this string s, IFormatProvider? provider = null) where T : INumber<T> =>
		s.Select(x => T.Parse($"{x}", provider));
	public static IEnumerable<T> AsDigits<T>(this IEnumerable<string> s, IFormatProvider? provider = null) where T : INumber<T> =>
		s.Select(x => T.Parse($"{x}", provider));




	public static string[] TrimmedSplit(this string s, string? separator = null) =>
		s.Split(separator, StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);

	public static string[] TrimmedSplit(this string s, char[]? separator) =>
		s.Split(separator, StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);

	public static string[] TrimmedSplit(this string s, char separator)
		=> s.Split(separator, StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);

	public static string[] TrimmedSplit(this string s, char separator, int count)
		=> s.Split(separator, count, StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);

	public static string[] TrimmedSplit(this string s, char[]? separator, int count)
		=> s.Split(separator, count, StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);

	public static string[] TrimmedSplit(this string s, string[]? separator)
		=> s.Split(separator, StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);

	public static string[] TrimmedSplit(this string s, string? separator, int count)
		=> s.Split(separator, count, StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);

	public static string[] TrimmedSplit(this string s, string[]? separator, int count)
		=> s.Split(separator, count, StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);





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


	

	
	public static IEnumerable<Point> AsPoints(this IEnumerable<string> input) =>
		input.Select(i => i.Split(",")).Select(x => new Point(x[0].As<int>(), x[1].As<int>()));

	/// <summary>
	/// Returns Points from an input of (int x,int y) tuples
	/// </summary>
	/// <param name="input"></param>
	/// <returns>IEnumerable<Point></returns>
	public static IEnumerable<Point> AsPoints(this IEnumerable<(int x, int y)> input) =>
		input.Select(p => new Point(X: p.x, Y: p.y));

	
	
	
	
	public static string AsBinaryFromHex(this string input)
		=> string.Join(
			string.Empty,
			input.Select(c => Convert.ToString(Convert.ToInt32(c.ToString(), 16), 2).PadLeft(4, '0')));

	public static string AsBinaryFromHex(this IEnumerable<string> input)
		=> string.Join(string.Empty, input.Select(AsBinaryFromHex));




	public static T FromBinary<T>(this string input, char zeroChar = '.', char oneChar = '#') where T : INumber<T> {
		if (typeof(T) == typeof(int)) {
			return T.CreateChecked(Convert.ToInt32(input.Replace(zeroChar, '0').Replace(oneChar, '1'), 2));
		} else {
			return T.CreateChecked(Convert.ToInt64(input.Replace(zeroChar, '0').Replace(oneChar, '1'), 2));
		}
	}



	// Regex Parsing Helpers
	public static IEnumerable<T> As<T>(this System.Text.RegularExpressions.MatchCollection matches) where T : INumber<T>
		=> matches.Select(match => T.TryParse(match.Value, null, out T? value) switch { true => value, false => throw new InvalidCastException() });

	public static T As<T>(this System.Text.RegularExpressions.Match match) where T : INumber<T>
		=> T.TryParse(match.Value, null, out T? value) switch { true => value, false => throw new InvalidCastException() };

	public static IEnumerable<T> As<T>(this System.Text.RegularExpressions.GroupCollection groups) where T : INumber<T>
		=> groups.Values.Select(group => T.TryParse(group.Value, null, out T? value) switch { true => value, false => throw new InvalidCastException() });

	public static T As<T>(this System.Text.RegularExpressions.Match match, string groupName, T? defaultIfInvalid = default) where T : INumber<T>
		=> T.TryParse(match.Groups[groupName].Value, null, out T? value) switch { true => value, false => defaultIfInvalid ?? T.Zero };

	public static T As<T>(this System.Text.RegularExpressions.Match match, int index, T? defaultIfInvalid = default) where T : INumber<T>
		=> T.TryParse(match.Groups[index].Value, null, out T? value) switch { true => value, false => defaultIfInvalid ?? T.Zero };
}

