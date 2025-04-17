namespace Smab.Helpers;

public static partial class LinqHelpers {
	/// <summary>
	/// Filters a sequence of values based on a predicate, returning elements for which the predicate is <see
	/// langword="false"/>.
	/// </summary>
	/// <remarks>This method is the inverse of <see cref="Enumerable.Where{TSource}(IEnumerable{TSource},
	/// Func{TSource, bool})"/>. It evaluates the predicate for each element in the source sequence and excludes elements
	/// for which the predicate returns <see langword="true"/>.</remarks>
	/// <typeparam name="TSource">The type of the elements in the source sequence.</typeparam>
	/// <param name="source">The sequence of elements to filter. Cannot be <see langword="null"/>.</param>
	/// <param name="predicate">A function to test each element for a condition. Elements for which the predicate returns <see langword="false"/>
	/// are included in the result.</param>
	/// <returns>An <see cref="IEnumerable{T}"/> that contains elements from the input sequence that do not satisfy the condition
	/// specified by the predicate.</returns>
	public static IEnumerable<TSource> NotWhere<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
		=> source.Where(x => !predicate(x));
}
