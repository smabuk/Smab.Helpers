namespace Smab.Helpers.Test.HelperMethodTests;
public class AlgorithmHelperTests(ITestOutputHelper testOutputHelper) {
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





	[Theory]
	[InlineData(1, 2, 3, 4, 4)]
	[InlineData(100, 200, 385, 3424, 3509)]
	public void ManhattanDistance_Points_ShouldBe(int x1, int y1, int x2, int y2, int expected) {

		Point point1 = new(x1, y1);
		Point point2 = new(x2, y2);
		long actual = point1.ManhattanDistance(point2);
		actual.ShouldBe(expected);
	}

	[Theory]
	[InlineData(1, 2, 3, 4, 4)]
	[InlineData(100, 200, 385, 3424, 3509)]
	public void ManhattanDistance_Ints_ShouldBe(int x1, int y1, int x2, int y2, int expected) {

		long actual = (x1, y1).ManhattanDistance((x2, y2));
		actual.ShouldBe(expected);
	}

	[Theory]
	[InlineData(1, 2, 3, 4, 4)]
	[InlineData(100, 200, 385, 3424, 3509)]
	public void ManhattanDistance_Longs_ShouldBe(long x1, long y1, long x2, long y2, long expected) {

		long actual = (x1, y1).ManhattanDistance((x2, y2));
		actual.ShouldBe(expected);
	}

	[Theory]
	[InlineData(1, 2, 3, 4, 4)]
	[InlineData(100, 200, 385, 3424, 3509)]
	public void ManhattanDistance_Pairs_ShouldBe(long x1, long y1, long x2, long y2, long expected) {

		IEnumerable<(long, long)> pairs = [(x1, y1), (x2, y2)];
		long actual = pairs.ToArray().ManhattanDistance();
		actual.ShouldBe(expected);
	}

	[Fact]
	public void ManhattanDistance_Pairs_Of_Points_ShouldBe() {
		List<Point> points = [new(1,4), new(87,32), new(43, -2), new(12, 5), new(-88, 4), new(3,9)];

		IEnumerable<IEnumerable<Point>> pairs = points.Chunk(2);
		List<long> actual = [..pairs.ManhattanDistances()];
		actual.ShouldBe([114, 38, 96]);
		pairs.First().ManhattanDistance().ShouldBe(114);
	}

	[Fact]
	public void ManhattanDistance_Should_Throw() {

		IEnumerable<(long, long)> pairs = [(1, 2), (3, 4), (5, 6)];
		Should.Throw<InvalidOperationException>(() => pairs.ToArray().ManhattanDistance())
		.Message
			.ShouldEndWith("You have 3 elements and there must be exactly 2.");

		IEnumerable<Point> pair = [new(1, 2), new(3, 4), new(5, 6)];
		Should.Throw<InvalidOperationException>(() => pairs.ToArray().ManhattanDistance())
		.Message
			.ShouldEndWith("You have 3 elements and there must be exactly 2.");
	}
}
