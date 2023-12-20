namespace Smab.Helpers;

public static partial class ArrayHelpers {

	public static bool DoesNotContain<TSource>(this IEnumerable<TSource> source, TSource value) =>
		  !Enumerable.Contains(source, value, null);

	public static bool DoesNotContain<TSource>(this IEnumerable<TSource> source, TSource value, IEqualityComparer<TSource>? comparer) =>
		 !Enumerable.Contains(source, value, comparer);

}

