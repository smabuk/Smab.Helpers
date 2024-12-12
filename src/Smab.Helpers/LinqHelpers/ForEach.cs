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

	public static IEnumerable<TResult> ForEach<T, TResult>(this IEnumerable<T> items, Func<T, TResult> action) {
		foreach (T? item in items) {
			yield return action(item);
		}
	}
}
