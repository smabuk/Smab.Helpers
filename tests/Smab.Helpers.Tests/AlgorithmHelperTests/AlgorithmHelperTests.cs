namespace Smab.Helpers.Tests.AlgorithmHelperTests;

public partial class AlgorithmHelperTests(ITestOutputHelper testOutputHelper) {
	[Theory]
	[InlineData((int[])[2, 3], 0, 1)]
	[InlineData((int[])[2, 3], 1, 2)]
	[InlineData((int[])[2, 3, 4], 1, 3)]
	[InlineData((int[])[2, 3], 2, 1)]
	[InlineData((int[])[2, 3, 4], 2, 3)]
	[InlineData((int[])[2, 3, 4, 5, 6, 7, 8], 3, 35)]
	public void Combinations_k_of_n_ShouldBe(int[] numbers, int k, int expectedCount) {
		List<int[]> actual = [.. numbers.Combinations(k)];

		testOutputHelper.WriteLine($"Combinations: {k} from {numbers.Length} [{string.Join(',', numbers)}]");
		foreach (int[] combination in actual) {
			testOutputHelper.WriteLine(string.Join(",", combination));
		}

		actual.Count.ShouldBe(expectedCount);
	}

	[Theory]
	[InlineData((int[])[1, 2, 3], 2)]
	[InlineData((int[])[1, 2, 3, 4], 2)]
	[InlineData((int[])[1, 2, 3, 4, 5], 3)]
	public void Combinations_ShouldNotContainDuplicateElements(int[] numbers, int k) {
		List<int[]> actual = [.. numbers.Combinations(k)];

		testOutputHelper.WriteLine($"Combinations: {k} from {numbers.Length} [{string.Join(',', numbers)}]");
		foreach (int[] combination in actual) {
			testOutputHelper.WriteLine(string.Join(",", combination));
			// Each combination should have all unique elements
			combination.Distinct().Count().ShouldBe(k);
		}
	}

	[Fact]
	public void Combinations_WithKGreaterThanN_ShouldReturnEmpty() {
		int[] numbers = [1, 2, 3];
		List<int[]> actual = [.. numbers.Combinations(5)];

		actual.Count.ShouldBe(0);
	}

	[Fact]
	public void Combinations_WithEmptySequence_ShouldReturnEmpty() {
		int[] numbers = [];
		List<int[]> actual = [.. numbers.Combinations(1)];

		actual.Count.ShouldBe(0);
	}

	[Theory]
	[InlineData((int[])[1, 2], 2, 3)]
	[InlineData((int[])[1, 2, 3], 2, 6)]
	[InlineData((int[])[1, 2, 3], 3, 10)]
	[InlineData((int[])[1, 2, 3, 4], 2, 10)]
	public void CombinationsWithReplacement_k_of_n_ShouldBe(int[] numbers, int k, int expectedCount) {
		List<int[]> actual = [.. numbers.CombinationsWithReplacement(k)];

		testOutputHelper.WriteLine($"Combinations with replacement: {k} from {numbers.Length} [{string.Join(',', numbers)}]");
		foreach (int[] combination in actual) {
			testOutputHelper.WriteLine(string.Join(",", combination));
		}

		actual.Count.ShouldBe(expectedCount);
	}

	[Theory]
	[InlineData((int[])[1, 2, 3], 2)]
	[InlineData((int[])[1, 2, 3, 4], 3)]
	public void CombinationsWithReplacement_ShouldAllowDuplicateElements(int[] numbers, int k) {
		List<int[]> actual = [.. numbers.CombinationsWithReplacement(k)];

		testOutputHelper.WriteLine($"Combinations with replacement: {k} from {numbers.Length} [{string.Join(',', numbers)}]");

		// Should contain at least one combination with duplicate elements
		bool hasDuplicates = actual.Any(combo => combo.Distinct().Count() < k);
		hasDuplicates.ShouldBeTrue();

		foreach (int[] combination in actual) {
			testOutputHelper.WriteLine(string.Join(",", combination));
		}
	}

	[Fact]
	public void CombinationsWithReplacement_WithKZero_ShouldReturnEmptyArray() {
		int[] numbers = [1, 2, 3];
		List<int[]> actual = [.. numbers.CombinationsWithReplacement(0)];

		actual.Count.ShouldBe(1);
		actual[0].Length.ShouldBe(0);
	}

	[Fact]
	public void CombinationsWithReplacement_WithEmptySequence_ShouldReturnEmpty() {
		int[] numbers = [];
		List<int[]> actual = [.. numbers.CombinationsWithReplacement(2)];

		actual.Count.ShouldBe(0);
	}

	[Fact]
	public void CombinationsWithReplacement_ShouldIncludeAllSameElement() {
		int[] numbers = [1, 2, 3];
		List<int[]> actual = [.. numbers.CombinationsWithReplacement(2)];

		// Should include (1,1), (2,2), (3,3)
		int[] expected11 = [1, 1];
		int[] expected22 = [2, 2];
		int[] expected33 = [3, 3];

		actual.ShouldContain(combo => combo.SequenceEqual(expected11));
		actual.ShouldContain(combo => combo.SequenceEqual(expected22));
		actual.ShouldContain(combo => combo.SequenceEqual(expected33));
	}

	[Theory]
	[InlineData((int[])[2, 3], 2)]
	[InlineData((int[])[2, 3, 4], 6)]
	[InlineData((int[])[2, 3, 4, 5, 6, 7, 8], 5040)]
	public void Permutations_ShouldBe(int[] numbers, int expectedCount) {
		List<int[]> actual = [.. numbers.Permute()];

		testOutputHelper.WriteLine($"Permutations of [{string.Join(',', numbers)}]");
		foreach (IEnumerable<int> combination in actual) {
			testOutputHelper.WriteLine(string.Join(",", combination));
		}

		actual.Count.ShouldBe(expectedCount);
	}
	[Theory]
	[InlineData((int[])[2, 3], 0, 1)]
	[InlineData((int[])[2, 3], 1, 2)]
	[InlineData((int[])[2, 3, 4], 1, 3)]
	[InlineData((int[])[2, 3], 2, 2)]
	[InlineData((int[])[2, 3, 4], 2, 6)]
	[InlineData((int[])[2, 3, 4, 5, 6, 7, 8], 3, 210)]
	public void Permutations_k_of_n_ShouldBe(int[] numbers, int k, int expectedCount) {
		List<int[]> actual = [.. numbers.Permute(k)];

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


	[Theory]
	[InlineData(0, 10, 5)] // Predicate matches a midpoint
	[InlineData(0, 10, 0)] // Predicate matches the start
	[InlineData(0, 10, 9)] // Predicate matches the end
	public void TryBinaryChop_ShouldFindMatchingElement(int start, int end, int target) {
		bool found = AlgorithmicHelpers.TryBinaryChop(
			start: start,
			end: end,
			predicate: x => x == target,
			out int result
		);

		found.ShouldBeTrue();
		result.ShouldBe(target);
	}

	[Theory]
	[InlineData(0, 10, 5)] // Predicate matches a midpoint
	[InlineData(0, 10, 0)] // Predicate matches the start
	[InlineData(0, 10, 9)] // Predicate matches the end
	public void TryBinaryChop_WithRange_ShouldFindMatchingElement(int start, int end, int target) {
		bool found = new Range(start, end).TryBinaryChop(
			predicate: x => x == target,
			out int result
		);

		found.ShouldBeTrue();
		result.ShouldBe(target);
	}

	[Theory]
	[InlineData(0, 10, 5)] // Predicate matches a midpoint
	[InlineData(0, 10, 0)] // Predicate matches the start
	[InlineData(0, 10, 9)] // Predicate matches the end
	public void TryBinaryChop_WithLongRange_ShouldFindMatchingElement(long start, long end, long target) {
		bool found = new LongRange(start, end).TryBinaryChop(
			predicate: x => x == target,
			out long result
		);

		found.ShouldBeTrue();
		result.ShouldBe(target);
	}

	[Theory]
	[InlineData(0, 10, 11)] // Target is outside the range
	[InlineData(0, 10, -1)] // Target is below the range
	public void TryBinaryChop_ShouldReturnFalse_WhenNoMatch(int start, int end, int target) {
		bool found = AlgorithmicHelpers.TryBinaryChop(
			start: start,
			end: end,
			predicate: x => x == target,
			out int result
		);

		found.ShouldBeFalse();
		result.ShouldBe(default);
	}

	[Theory]
	[InlineData(0, 10, 5)] // First element greater than or equal to 5
	[InlineData(0, 10, 0)] // First element greater than or equal to 0
	[InlineData(0, 10, 9)] // First element greater than or equal to 9
	public void TryBinaryChop_ShouldFindFirstElementMatchingPredicate(int start, int end, int threshold) {
		bool found = AlgorithmicHelpers.TryBinaryChop(
			start: start,
			end: end,
			predicate: x => x >= threshold,
			out int result
		);

		found.ShouldBeTrue();
		result.ShouldBe(threshold);
	}

	[Fact]
	public void TryBinaryChop_ShouldHandleEmptyRange() {
		bool found = AlgorithmicHelpers.TryBinaryChop(
			start: 5,
			end: 5,
			predicate: x => x == 5,
			out int result
		);

		found.ShouldBeFalse();
		result.ShouldBe(default);
	}

	[Fact]
	public void TryBinaryChop_ShouldHandleSingleElementRange() {
		bool found = AlgorithmicHelpers.TryBinaryChop(
			start: 5,
			end: 6,
			predicate: x => x == 5,
			out int result
		);

		found.ShouldBeTrue();
		result.ShouldBe(5);
	}

}
