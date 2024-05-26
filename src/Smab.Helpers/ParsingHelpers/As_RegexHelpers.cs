using System.Numerics;
using System.Text.RegularExpressions;

namespace Smab.Helpers;

public static partial class ParsingHelpers {

	public static string As(this Match match, string groupName)
		=> match.Groups[groupName].Value;

	public static string As(this Match match, int index)
		=> match.Groups[index].Value;

	public static IEnumerable<T> As<T>(this MatchCollection matches) where T : INumber<T>
		=> matches.Select(match => T.TryParse(match.Value, null, out T? value) switch { true => value, false => throw new InvalidCastException() });

	public static IEnumerable<T> As<T>(this GroupCollection groups) where T : INumber<T>
		=> groups.Values.Select(group => T.TryParse(group.Value, null, out T? value) switch { true => value, false => throw new InvalidCastException() });

	public static T As<T>(this Match match) where T : INumber<T>
		=> T.TryParse(match.Value, null, out T? value) switch { true => value, false => throw new InvalidCastException() };

	public static T As<T>(this Match match, string groupName, T? defaultIfInvalid = default) where T : INumber<T>
		=> T.TryParse(match.Groups[groupName].Value, null, out T? value) switch { true => value, false => defaultIfInvalid ?? T.Zero };

	public static T As<T>(this Match match, int index, T? defaultIfInvalid = default) where T : INumber<T>
		=> T.TryParse(match.Groups[index].Value, null, out T? value) switch { true => value, false => defaultIfInvalid ?? T.Zero };
}
