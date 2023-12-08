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
		s.As<T>([separator]);
	public static IEnumerable<T> As<T>(this string s, string[]? separator, IFormatProvider? provider = null) where T : INumber<T>
		=> s.TrimmedSplit(separator).Select(s => T.Parse(s, provider));
	public static IEnumerable<T> AsNumbers<T>(this string s, string separator) where T : INumber<T> =>
		s.As<T>(new string[] { separator });



	[Obsolete("AsInts is deprecated, please use As instead.")]
	public static IEnumerable<int> AsInts(this IEnumerable<string> input) =>
	input.Select(int.Parse);

	[Obsolete("AsInts is deprecated, please use As instead.")]
	public static IEnumerable<int> AsInts(this string input, char[]? separator = null) =>
		input.Split(separator, StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries).Select(int.Parse);

	[Obsolete("AsInts is deprecated, please use As instead.")]
	public static IEnumerable<int> AsInts(this string input, string[]? separator) =>
	input.Split(separator, StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries).Select(int.Parse);

	[Obsolete("AsInts is deprecated, please use As instead.")]
	public static IEnumerable<int> AsInts(this string input, char separator) =>
		input.AsInts(new char[] { separator });

	[Obsolete("AsInts is deprecated, please use As instead.")]
	public static IEnumerable<int> AsInts(this string input, string separator) =>
		input.AsInts(new string[] { separator });




	[Obsolete("AsLongs is deprecated, please use As instead.")]
	public static IEnumerable<long> AsLongs(this IEnumerable<string> input) =>
	input.Select(long.Parse);

	[Obsolete("AsLongs is deprecated, please use As instead.")]
	public static IEnumerable<long> AsLongs(this string input, string[]? separator = null) =>
		input.Split(separator, StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries).Select(long.Parse);

	
	
	
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




	[Obsolete("AsInt is deprecated, please use As instead.")]
	public static int AsInt(this string input, int defaultIfInvalid = 0)
		=>   int.TryParse(input, out int value) switch { true => value, false => defaultIfInvalid };




	[Obsolete("AsLong is deprecated, please use As instead.")]
	public static long AsLong(this string input, long defaultIfInvalid = 0)
		=> long.TryParse(input, out long value) switch { true => value, false => defaultIfInvalid };

	
	
	
	public static int AsIntFromBinary(this string input, char zeroChar = '.', char oneChar = '#')
		=> Convert.ToInt32(input.Replace(zeroChar, '0').Replace(oneChar, '1'), 2);

	
	
	
	public static long AsLongFromBinary(this string input, char zeroChar = '.', char oneChar = '#')
		=> Convert.ToInt64(input.Replace(zeroChar, '0').Replace(oneChar, '1'), 2);




	// Regex Parsing Helpers
	public static IEnumerable<int> MatchesAsInts(this System.Text.RegularExpressions.MatchCollection matches) =>
		matches.Select(match => int.TryParse(match.Value, out int value) switch { true => value, false => throw new InvalidCastException() });

	public static int MatchAsInt(this System.Text.RegularExpressions.Match match) =>
		int.TryParse(match.Value, out int value) switch { true => value, false => throw new InvalidCastException() };

	public static IEnumerable<int> GroupsAsInts(this System.Text.RegularExpressions.GroupCollection groups) =>
		groups.Values.Select(group => int.TryParse(group.Value, out int value) switch { true => value, false => throw new InvalidCastException() });

	public static int GroupAsInt(this System.Text.RegularExpressions.Match match, string groupName, int defaultIfInvalid = 0)
		=> int.TryParse(match.Groups[groupName].Value, out int value) switch { true => value, false => defaultIfInvalid };

	public static int GroupAsInt(this System.Text.RegularExpressions.Match match, int index, int defaultIfInvalid = 0)
		=> int.TryParse(match.Groups[index].Value, out int value) switch { true => value, false => defaultIfInvalid };
}

