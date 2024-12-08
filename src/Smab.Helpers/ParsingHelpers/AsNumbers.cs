using System.Numerics;

namespace Smab.Helpers;
public static partial class ParsingHelpers {

	public static IEnumerable<T> AsNumbers<T>(this string s, string? separator = ",") where T : INumber<T> =>
		s.TrimmedSplit(separator).Select(s => s.As<T>());

	public static IEnumerable<int> AsNumbers(this string s, string? separator = ",") =>
		s.TrimmedSplit(separator).Select(s => s.As<int>());

	public static IEnumerable<T> AsNumbers<T>(this string s, char separator) where T : INumber<T> =>
		s.TrimmedSplit(separator).Select(s => s.As<T>());

	public static IEnumerable<T> AsNumbers<T>(this string s, char[] separator) where T : INumber<T> =>
		s.TrimmedSplit(separator).Select(s => s.As<T>());

	public static IEnumerable<T> AsNumbers<T>(this string s, string[] separator) where T : INumber<T> =>
		s.TrimmedSplit(separator).Select(s => s.As<T>());
}