namespace Smab.Helpers;

public static partial class LinqHelpers {

	extension<TSource>(IEnumerable<TSource> items) {
		/// <summary>
		/// Splits the sequence into chunks, starting a new chunk each time the specified predicate returns true for an
		/// element.
		/// </summary>
		/// <remarks>The element for which the predicate returns true is not included in any chunk. The method yields
		/// only non-empty chunks. Enumeration is deferred and performed lazily.</remarks>
		/// <param name="predicate">A function that determines whether a new chunk should be started based on the current element. If the predicate
		/// returns true, the current chunk ends and a new chunk begins.</param>
		/// <returns>An enumerable collection of lists, where each list contains consecutive elements between predicate matches. Each
		/// chunk contains elements for which the predicate returned false, and a new chunk starts after each element for
		/// which the predicate returns true.</returns>
		public IEnumerable<List<TSource>> SplitBy(Func<TSource, bool> predicate) {
			List<TSource> currentChunk = [];

			foreach (TSource item in items) {
				if (predicate(item)) {
					if (currentChunk.Count > 0) {
						yield return currentChunk;
						currentChunk = [];
					}
				} else {
					currentChunk.Add(item);
				}
			}

			if (currentChunk.Count > 0) {
				yield return currentChunk;
			}
		}

		/// <summary>
		/// Splits the source sequence into chunks, starting a new chunk each time an element matches the specified predicate,
		/// and projects each non-matching element using the provided conversion function.
		/// </summary>
		/// <remarks>Elements for which the predicate returns <see langword="true"/> are not included in any chunk.
		/// The method yields only non-empty chunks. The order of elements within each chunk is preserved from the source
		/// sequence.</remarks>
		/// <typeparam name="TOut">The type of the elements in each chunk after conversion.</typeparam>
		/// <param name="predicate">A function that determines whether the current element should start a new chunk. If the predicate returns <see
		/// langword="true"/>, a new chunk is started.</param>
		/// <param name="conversion">A function that projects each element that does not start a new chunk into the output type <typeparamref
		/// name="TOut"/>.</param>
		/// <returns>An enumerable collection of lists, where each list contains the converted elements between predicate matches. Each
		/// chunk is yielded when a new chunk is started or at the end of the sequence.</returns>
		public IEnumerable<List<TOut>> SplitBy<TOut>(Func<TSource, bool> predicate, Func<TSource, TOut> conversion) {
			List<TOut> currentChunk = [];

			foreach (TSource item in items) {
				if (predicate(item)) {
					if (currentChunk.Count > 0) {
						yield return currentChunk;
						currentChunk = [];
					}
				} else {
					currentChunk.Add(conversion(item));
				}
			}

			if (currentChunk.Count > 0) {
				yield return currentChunk;
			}
		}
	}

	extension(IEnumerable<string?> items) {
		/// <summary>
		/// Splits the collection of strings into chunks, using empty or whitespace-only strings as delimiters.
		/// </summary>
		/// <remarks>Empty or whitespace-only strings act as boundaries between chunks. Leading, trailing, or
		/// consecutive empty entries will result in skipped or empty chunks being omitted from the result.</remarks>
		/// <returns>An enumerable sequence of lists, each containing consecutive non-empty strings separated by empty or
		/// whitespace-only entries. The sequence will not contain empty lists.</returns>
		public IEnumerable<List<string>> SplitByEmpty() => items.SplitBy(string.IsNullOrWhiteSpace).OfType<List<string>>();
	}

}
