namespace Smab.Helpers;

public static partial class AlgorithmicHelpers {

	/// <summary>
	/// LINQ for generating all possible permutations
	/// https://codereview.stackexchange.com/questions/226804/linq-for-generating-all-possible-permutations
	/// </summary>
	/// <typeparam name="T"></typeparam>
	/// <param name="source"></param>
	/// <returns></returns>
	public static IEnumerable<T[]> Permute<T>(this IEnumerable<T> source) {
		return permute(source.ToArray(), Enumerable.Empty<T>());
		IEnumerable<T[]> permute(IEnumerable<T> remainder, IEnumerable<T> prefix) =>
			!remainder.Any() ? new[] { prefix.ToArray() } :
			remainder.SelectMany((c, i) => permute(
				remainder.Take(i).Concat(remainder.Skip(i + 1)).ToArray(),
				prefix.Append(c)));
	}
}
