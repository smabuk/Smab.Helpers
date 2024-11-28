namespace Smab.Helpers;

public static partial class LinqHelpers {
	public static void ForEach<T>(this IEnumerable<T> items, Action<T> action) {
		foreach (T? item in items) {
			action(item);
		}
	}

	public static IEnumerable<T> ForEachContinue<T>(this IEnumerable<T> items, Action<T> action) {
		foreach (T? item in items) {
			action(item);
			yield return item;
		}
	}
}
