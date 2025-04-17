namespace Smab.Helpers;

public static partial class MathsHelpers {
	/// <summary>
	/// Returns the values occurring the most times
	/// </summary>
	/// <typeparam name="T"></typeparam>
	/// <param name="array"></param>
	/// <returns></returns>
	public static IEnumerable<T> Modes<T>(this T[] array) {
		(T Key, int Count)[] counts = [.. array
			.GroupBy(x => x)
			.Select(g => (g.Key, Count: g.Count()))];

		int maxCount = counts.Max(c => c.Count);

		IEnumerable<T>? modes = counts
			.Where(m => m.Count == maxCount)
			.Select(item => item.Key);

		foreach (T item in modes) {
			yield return item;
		}
	}

}
