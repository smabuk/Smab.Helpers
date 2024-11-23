namespace Smab.Helpers.Tests.AlgorithmHelperTests;
public partial class AlgorithmHelperTests(ITestOutputHelper testOutputHelper) {
	[Theory]
	[InlineData((int[])[2, 3],    0, 1)]
	[InlineData((int[])[2, 3],    1, 2)]
	[InlineData((int[])[2, 3, 4], 1, 3)]
	[InlineData((int[])[2, 3],    2, 1)]
	[InlineData((int[])[2, 3, 4], 2, 3)]
	[InlineData((int[])[2, 3, 4, 5, 6, 7, 8], 3, 35)]
	public void Combinations_k_of_n_ShouldBe(int[] numbers, int k, int expectedCount) {
		List<IEnumerable<int>> actual = numbers.Combinations(k).ToList();

		testOutputHelper.WriteLine($"Combinations: {k} from {numbers.Length} [{string.Join(',', numbers)}]");
		foreach (IEnumerable<int> combination in actual) {
			testOutputHelper.WriteLine(string.Join(",", combination));
		}

		actual.Count.ShouldBe(expectedCount);
	}

	[Theory]
	[InlineData((int[])[2, 3],    2)]
	[InlineData((int[])[2, 3, 4], 6)]
	[InlineData((int[])[2, 3, 4, 5, 6, 7, 8], 5040)]
	public void Permutations_ShouldBe(int[] numbers, int expectedCount) {
		List<int[]> actual = numbers.Permute().ToList();

		testOutputHelper.WriteLine($"Permutations of [{string.Join(',', numbers)}]");
		foreach (IEnumerable<int> combination in actual) {
			testOutputHelper.WriteLine(string.Join(",", combination));
		}

		actual.Count.ShouldBe(expectedCount);
	}
	[Theory]
	[InlineData((int[])[2, 3],    0, 1)]
	[InlineData((int[])[2, 3],    1, 2)]
	[InlineData((int[])[2, 3, 4], 1, 3)]
	[InlineData((int[])[2, 3],    2, 2)]
	[InlineData((int[])[2, 3, 4], 2, 6)]
	[InlineData((int[])[2, 3, 4, 5, 6, 7, 8], 3, 210)]
	public void Permutations_k_of_n_ShouldBe(int[] numbers, int k, int expectedCount) {
		List<int[]> actual = numbers.Permute(k).ToList();

		testOutputHelper.WriteLine($"Permutations: {k} from {numbers.Length} [{string.Join(',', numbers)}]");
		foreach (IEnumerable<int> combination in actual) {
			testOutputHelper.WriteLine(string.Join(",", combination));
		}

		actual.Count.ShouldBe(expectedCount);
	}





	[Theory]
	[InlineData((int[])[2, 3], 6)]
	[InlineData((int[])[2, 3, 4, 5, 6, 7, 8], 840)]
	public void LowestCommonMultiple_OfInts_ShouldBe(int[] numbers, long expected) {
		long actual = numbers.LowestCommonMultiple();
		actual.ShouldBe(expected);
	}

	[Theory]
	[InlineData((long[])[2L, 3L], 6)]
	[InlineData((long[])[2, 3, 4, 5, 6, 7, 8], 840)]
	public void LowestCommonMultiple_OfLongs_ShouldBe(long[] numbers, long expected) {
		long actual = numbers.LowestCommonMultiple();
		actual.ShouldBe(expected);
	}

}
