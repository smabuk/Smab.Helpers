namespace Smab.Helpers;

public static partial class AlgorithmicHelpers {

	extension<T>(IEnumerable<T> elements) {
		/// <summary>
		/// Generates all possible combinations of a specified size from the given sequence.
		/// </summary>
		/// <remarks>This method uses deferred execution. The combinations are generated lazily as the result is
		/// enumerated.</remarks>
		/// <typeparam name="T">The type of elements in the input sequence.</typeparam>
		/// <param name="elements">The sequence of elements to generate combinations from. Cannot be null.</param>
		/// <param name="k">The size of each combination. Must be non-negative and less than or equal to the number of elements in the
		/// sequence.</param>
		/// <returns>An <see cref="IEnumerable{T}"/> of combinations, where each combination is represented as an <see
		/// cref="IEnumerable{T}"/>. If <paramref name="k"/> is 0, a single empty combination is returned. If <paramref
		/// name="k"/> is greater than the number of elements, no combinations are returned.</returns>
		public IEnumerable<IEnumerable<T>> Combinations(int k) {
			return k == 0 ? [[]] :
			  elements.SelectMany((e, i) =>
				elements.Skip(i + 1)
						.Combinations(k - 1)
						.Select(c => (new[] { e })
						.Concat(c)));
		}
	}
}
