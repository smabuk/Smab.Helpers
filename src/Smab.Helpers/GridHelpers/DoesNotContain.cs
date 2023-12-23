namespace Smab.Helpers;

public static partial class ArrayHelpers {

	public static bool DoesNotContain<TSource>(this IEnumerable<TSource> source, TSource value) =>
		source is ICollection<TSource> collection ? !collection.Contains(value) :
		DoesNotContain(source, value, null);

	public static bool DoesNotContain<TSource>(this IEnumerable<TSource> source, TSource value, IEqualityComparer<TSource>? comparer) {

		ArgumentException.ThrowIfNullOrEmpty(nameof(source));

		if (comparer is null) {
			foreach (TSource element in source) {
				if (EqualityComparer<TSource>.Default.Equals(element, value)) // benefits from devirtualization and likely inlining
				{
					return false;
				}
			}
		} else {
			foreach (TSource element in source) {
				if (comparer.Equals(element, value)) {
					return false;
				}
			}
		}

		return true;
	}
}
