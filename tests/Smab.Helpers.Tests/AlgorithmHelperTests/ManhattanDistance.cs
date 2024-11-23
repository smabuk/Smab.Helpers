namespace Smab.Helpers.Tests.AlgorithmHelperTests;
public partial class AlgorithmHelperTests {
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
		List<Point> points = [new(1, 4), new(87, 32), new(43, -2), new(12, 5), new(-88, 4), new(3, 9)];

		IEnumerable<IEnumerable<Point>> pairs = points.Chunk(2);
		List<long> actual = [.. pairs.ManhattanDistances()];
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

	// 3d

	[Theory]
	[InlineData(1, 2, 3, 4, 5, 6, 5)]
	[InlineData(100, 200, 385, 3424, 888, 999, 3620)]
	public void ManhattanDistance_Points3d_ShouldBe(int x1, int y1, int x2, int y2, int z1, int z2, int expected) {

		Point3d point1 = new(x1, y1, z1);
		Point3d point2 = new(x2, y2, z2);
		long actual = point1.ManhattanDistance(point2);
		actual.ShouldBe(expected);
	}
}
