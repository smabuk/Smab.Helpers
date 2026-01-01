namespace Smab.Helpers;

public static partial class AlgorithmicHelpers {
	extension<T>(IEnumerable<T> numbers) where T : INumber<T> {
		public T LowestCommonMultiple() => numbers.Aggregate(LowestCommonMultipleOf2Numbers);
	}

	extension<T>(T a) where T : INumber<T> {
		/// <summary>
		/// In arithmetic and number theory, the least common multiple, lowest common multiple, or smallest common
		/// multiple of two integers a and b, usually denoted by lcm(a, b), is the smallest positive integer that
		/// is divisible by both a and b.[1][2] Since division of integers by zero is undefined, this definition
		/// has meaning only if a and b are both different from zero.[3] However, some authors define lcm(a, 0) as
		/// 0 for all a, since 0 is the only common multiple of a and 0
		/// </summary>
		/// <see cref="https://en.wikipedia.org/wiki/Lowest_common_multiple"/>
		/// <typeparam name="T"></typeparam>
		/// <param name="a"></param>
		/// <param name="b"></param>
		/// <returns></returns>
		public T LowestCommonMultipleOf2Numbers(T b) => T.Abs(a * b) / GreatestCommonDivisor(a, b);
		public T GreatestCommonDivisor(T b) => b == T.Zero ? a : GreatestCommonDivisor(b, a % b);
	}

	extension(IEnumerable<int> numbers) {
		public long LowestCommonMultiple() => numbers.Select(n => (long)n).Aggregate(LowestCommonMultipleOf2Numbers);
	}
}
