using System.Numerics;
using System.Runtime.CompilerServices;

namespace Smab.Helpers;
public static partial class ParsingHelpers {
	private static readonly char[] DefaultSeparators = [',', '|', ' ', ':', ';', '~', '(', ')', '{', '}', '[', ']'];

	public static IEnumerable<T> AsNumbers<T>(this string s, string? separator) where T : INumber<T> =>
		s.TrimmedSplit(separator).Select(s => s.As<T>());

	public static IEnumerable<T> AsNumbers<T>(this string s, char separator) where T : INumber<T> =>
		s.TrimmedSplit(separator).Select(s => s.As<T>());

	[OverloadResolutionPriority(2)]
	public static IEnumerable<T> AsNumbers<T>(this string s, char[] separator) where T : INumber<T> =>
		s.TrimmedSplit(separator).Select(s => s.As<T>());

	[OverloadResolutionPriority(1)]
	public static IEnumerable<T> AsNumbers<T>(this string s, string[]? separator = null) where T : INumber<T> =>
		separator is null
		? s.TrimmedSplit(DefaultSeparators).Select(s => s.As<T>())
		: s.TrimmedSplit(separator).Select(s => s.As<T>());


	public static IEnumerable<IEnumerable<T>> AsNumbers<T>(this IEnumerable<string> s) where T : INumber<T> =>
		s.Select(x => x.AsNumbers<T>());

	public static IEnumerable<int> AsInts(this string s, string[]? separator = null) =>
		s.AsNumbers<int>(separator);
	public static IEnumerable<long> AsLongs(this string s, string[]? separator = null) =>
		s.AsNumbers<long>(separator);



}