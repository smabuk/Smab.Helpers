namespace Smab.Helpers;
//
// Modified from https://source.dot.net/#System.Linq/System/Linq/Contains.cs in .NET 8.0
//
public static partial class LinqHelpers {
	/// <summary>
	/// Determines whether the specified sequence does not contain a specified value.
	/// </summary>
	/// <typeparam name="TSource">The type of the elements in the sequence.</typeparam>
	/// <param name="source">The sequence to search.</param>
	/// <param name="value">The value to locate in the sequence.</param>
	/// <returns><see langword="true"/> if the sequence does not contain the specified value; otherwise, <see langword="false"/>.</returns>
	public static bool DoesNotContain<TSource>(this IEnumerable<TSource> source, TSource value) =>
		source is ICollection<TSource> collection ? !collection.Contains(value) :
		DoesNotContain(source, value, null);

	/// <summary>
	/// Determines whether the specified value is not present in the sequence.
	/// </summary>
	/// <remarks>This method performs a linear search of the sequence. If a custom <paramref name="comparer"/> is
	/// provided, it is used to compare elements; otherwise, the default equality comparer for <typeparamref
	/// name="TSource"/> is used.</remarks>
	/// <typeparam name="TSource">The type of the elements in the sequence.</typeparam>
	/// <param name="source">The sequence to search. Cannot be <see langword="null"/> or empty.</param>
	/// <param name="value">The value to locate in the sequence.</param>
	/// <param name="comparer">An optional equality comparer to use for comparing elements. If <see langword="null"/>, the default equality
	/// comparer for <typeparamref name="TSource"/> is used.</param>
	/// <returns><see langword="true"/> if the specified value is not found in the sequence; otherwise, <see langword="false"/>.</returns>
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
