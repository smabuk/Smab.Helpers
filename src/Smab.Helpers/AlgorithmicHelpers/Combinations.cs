namespace Smab.Helpers;

public static partial class AlgorithmicHelpers {

	extension<T>(IEnumerable<T> elements) {
		/// <summary>
		/// Generates all possible combinations of a specified size from the given sequence.
		/// Each element can appear at most once in each combination.
		/// </summary>
		/// <remarks>
		/// This method uses deferred execution with an optimized iterative algorithm.
		/// The combinations are generated lazily as the result is enumerated.
		/// Uses an index-based approach to avoid recursive overhead and minimize memory allocations.
		/// </remarks>
		/// <typeparam name="T">The type of elements in the input sequence.</typeparam>
		/// <param name="elements">The sequence of elements to generate combinations from. Cannot be null.</param>
		/// <param name="k">The size of each combination. Must be non-negative and less than or equal to the number of elements in the
		/// sequence.</param>
		/// <returns>An <see cref="IEnumerable{T}"/> of combinations, where each combination is represented as an array of <typeparamref name="T"/>
		/// If <paramref name="k"/> is 0, a single empty array is returned. If <paramref
		/// name="k"/> is greater than the number of elements, no combinations are returned.</returns>
		public IEnumerable<T[]> Combinations(int k) {
			if (k == 0) {
				yield return [];
				yield break;
			}

			T[] elementArray = elements as T[] ?? [.. elements];
			int n = elementArray.Length;

			if (k > n) {
				yield break;
			}

			int[] indices = new int[k];
			for (int i = 0; i < k; i++) {
				indices[i] = i;
			}

			while (true) {
				T[] combination = new T[k];
				for (int i = 0; i < k; i++) {
					combination[i] = elementArray[indices[i]];
				}
				yield return combination;

				// Find the rightmost index that can be incremented
				int pos = k - 1;
				while (pos >= 0 && indices[pos] == n - k + pos) {
					pos--;
				}

				if (pos < 0) {
					yield break;
				}

				// Increment and reset following indices
				indices[pos]++;
				for (int i = pos + 1; i < k; i++) {
					indices[i] = indices[i - 1] + 1;
				}
			}
		}

		/// <summary>
		/// Generates all possible combinations of a specified size from the given sequence,
		/// where elements can be repeated (combinations with replacement).
		/// </summary>
		/// <remarks>
		/// This method uses deferred execution with an optimized iterative algorithm.
		/// Unlike <see cref="Combinations"/>, the same element can appear multiple times in a single combination.
		/// For example, CombinationsWithReplacement(2) on [1,2,3] will include (1,1), (2,2), and (3,3).
		/// </remarks>
		/// <typeparam name="T">The type of elements in the input sequence.</typeparam>
		/// <param name="elements">The sequence of elements to generate combinations from. Cannot be null.</param>
		/// <param name="k">The size of each combination. Must be non-negative.</param>
		/// <returns>An <see cref="IEnumerable{T}"/> of combinations with replacement, where each combination is represented as an array of <typeparamref name="T"/>
		/// If <paramref name="k"/> is 0, a single empty array is returned.</returns>
		public IEnumerable<T[]> CombinationsWithReplacement(int k) {
			if (k == 0) {
				yield return [];
				yield break;
			}

			T[] elementArray = elements as T[] ?? [.. elements];
			int n = elementArray.Length;

			if (n == 0) {
				yield break;
			}

			int[] indices = new int[k];

			while (true) {
				T[] combination = new T[k];
				for (int i = 0; i < k; i++) {
					combination[i] = elementArray[indices[i]];
				}
				yield return combination;

				// Find the rightmost index that can be incremented
				int pos = k - 1;
				while (pos >= 0 && indices[pos] == n - 1) {
					pos--;
				}

				if (pos < 0) {
					yield break;
				}

				// Increment and set all following indices to the same value
				// (to maintain non-decreasing order)
				indices[pos]++;
				for (int i = pos + 1; i < k; i++) {
					indices[i] = indices[pos];
				}
			}
		}
	}
}
