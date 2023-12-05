namespace Smab.Helpers;

public static class ParsingHelpers {

	public static IEnumerable<int> AsDigits(this string input) =>
		input.Select(x => int.Parse($"{x}"));



	public static IEnumerable<string> SplitBy(this string input, string[]? separator = null, StringSplitOptions options = StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries) =>
		input.Split(separator, options);



	public static IEnumerable<T> As<T>(this IEnumerable<string> input, T defaultIfInvalid = default!, IFormatProvider? provider = null) where T : IParsable<T> =>
		input.Select(i => i.As(defaultIfInvalid, provider));




	public static IEnumerable<int> AsInts(this IEnumerable<string> input) =>
	input.Select(int.Parse);

	public static IEnumerable<int> AsInts(this string input, char[]? separator = null) =>
		input.Split(separator, StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries).Select(int.Parse);

	public static IEnumerable<int> AsInts(this string input, string[]? separator) =>
	input.Split(separator, StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries).Select(int.Parse);

	public static IEnumerable<int> AsInts(this string input, char separator) =>
		input.AsInts(new char[] { separator });

	public static IEnumerable<int> AsInts(this string input, string separator) =>
		input.AsInts(new string[] { separator });




	public static IEnumerable<long> AsLongs(this IEnumerable<string> input) =>
	input.Select(long.Parse);

	public static IEnumerable<long> AsLongs(this string input, string[]? separator = null) =>
		input.Split(separator, StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries).Select(long.Parse);

	
	
	
	public static IEnumerable<Point> AsPoints(this IEnumerable<string> input) =>
		input.Select(i => i.Split(",")).Select(x => new Point(x[0].AsInt(), x[1].AsInt()));

	/// <summary>
	/// Returns Points from an input of (int x,int y) tuples
	/// </summary>
	/// <param name="input"></param>
	/// <returns>IEnumerable<Point></returns>
	public static IEnumerable<Point> AsPoints(this IEnumerable<(int x, int y)> input) =>
		input.Select(p => new Point(X: p.x, Y: p.y));

	
	
	
	public static T As<T>(this string input, T defaultIfInvalid = default!, IFormatProvider? provider = null) where T : IParsable<T> =>
		T.TryParse(input, provider, out T? value) switch { true => value, false => defaultIfInvalid };

	
	
	public static string AsBinaryFromHex(this string input)
		=> String.Join(
			String.Empty,
			input.Select(c => Convert.ToString(Convert.ToInt32(c.ToString(), 16), 2).PadLeft(4, '0')));

	public static string AsBinaryFromHex(this IEnumerable<string> input)
		=> String.Join(String.Empty, input.Select(AsBinaryFromHex));

	
	
	
	public static int AsInt(this string input, int defaultIfInvalid = 0)
		=>   int.TryParse(input, out int value) switch { true => value, false => defaultIfInvalid };

	
	
	
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

