namespace Smab.Helpers;

public static partial class LinqHelpers {
	public static IEnumerable<TSource> NotWhere<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
		=> source.Where(x => !predicate(x));
}
