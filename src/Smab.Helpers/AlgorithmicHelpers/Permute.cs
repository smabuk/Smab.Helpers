namespace Smab.Helpers;

public static partial class AlgorithmicHelpers {

	extension<T>(IEnumerable<T> elements) {
		/// <summary>
		/// LINQ for generating all possible permutations
		/// https://codereview.stackexchange.com/questions/226804/linq-for-generating-all-possible-permutations
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="elements"></param>
		/// <returns></returns>
		public IEnumerable<T[]> Permute() {
			return permute([.. elements], []);
			IEnumerable<T[]> permute(IEnumerable<T> remainder, IEnumerable<T> prefix) =>
				!remainder.Any() ? [[.. prefix]] :
				remainder.SelectMany((c, i) => permute(
					[.. remainder.Take(i), .. remainder.Skip(i + 1)],
					prefix.Append(c)));
		}

		public IEnumerable<T[]> Permute(int k) {
			return elements.Combinations(k).SelectMany(p => p.Permute());
		}
	}
}
