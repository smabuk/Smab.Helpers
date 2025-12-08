namespace Smab.Helpers;

public static partial class AlgorithmicHelpers {

	extension<T>(IEnumerable<T> elements) {
		/// <summary>
		/// Generates all possible permutations using an optimized iterative algorithm
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="elements"></param>
		/// <returns></returns>
		public IEnumerable<T[]> Permute() {
			T[] array = [.. elements];
			int n = array.Length;

			if (n == 0) {
				yield return [];
				yield break;
			}

			// Yield first permutation
			T[] result = new T[n];
			Array.Copy(array, result, n);
			yield return result;

			// Heap's algorithm for generating permutations
			int[] c = new int[n];

			int i = 0;
			while (i < n) {
				if (c[i] < i) {
					if ((i & 1) == 0) {
						// i is even: swap first element
						(array[0], array[i]) = (array[i], array[0]);
					} else {
						// i is odd: swap c[i] element
						(array[c[i]], array[i]) = (array[i], array[c[i]]);
					}

					result = new T[n];
					Array.Copy(array, result, n);
					yield return result;

					c[i]++;
					i = 0;
				} else {
					c[i] = 0;
					i++;
				}
			}
		}

		/// <summary>
		/// Generates permutations of size k from the collection
		/// </summary>
		public IEnumerable<T[]> Permute(int k) {
			return elements.Combinations(k).SelectMany(p => p.Permute());
		}
	}
}
