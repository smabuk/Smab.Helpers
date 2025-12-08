namespace Smab.Helpers.Tests.AlgorithmHelperTests;

public partial class AlgorithmHelperTests {
	[Theory]
	[InlineData(0, 0, 3, 4, 5.0)]
	[InlineData(1, 2, 4, 6, 5.0)]
	[InlineData(0, 0, 1, 1, 1.4142135623730951)]
	[InlineData(100, 200, 385, 3424, 3236.5724153801966)]
	public void EuclideanDistance_Points_ShouldBe(int x1, int y1, int x2, int y2, double expected) {

		Point point1 = new(x1, y1);
		Point point2 = new(x2, y2);
		double actual = point1.EuclideanDistance(point2);
		actual.ShouldBe(expected, 0.0000001);
	}

	[Theory]
	[InlineData(0, 0, 3, 4, 5.0)]
	[InlineData(1, 2, 4, 6, 5.0)]
	[InlineData(0, 0, 1, 1, 1.4142135623730951)]
	[InlineData(100, 200, 385, 3424, 3236.5724153801966)]
	public void EuclideanDistance_Ints_ShouldBe(int x1, int y1, int x2, int y2, double expected) {

		double actual = (x1, y1).EuclideanDistance((x2, y2));
		actual.ShouldBe(expected, 0.0000001);
	}

	[Theory]
	[InlineData(0, 0, 3, 4, 5.0)]
	[InlineData(1, 2, 4, 6, 5.0)]
	[InlineData(0, 0, 1, 1, 1.4142135623730951)]
	[InlineData(100, 200, 385, 3424, 3236.5724153801966)]
	public void EuclideanDistance_Longs_ShouldBe(long x1, long y1, long x2, long y2, double expected) {

		double actual = (x1, y1).EuclideanDistance((x2, y2));
		actual.ShouldBe(expected, 0.0000001);
	}

	[Theory]
	[InlineData(0.0, 0.0, 3.0, 4.0, 5.0)]
	[InlineData(1.5, 2.5, 4.5, 6.5, 5.0)]
	[InlineData(0.0, 0.0, 1.0, 1.0, 1.4142135623730951)]
	public void EuclideanDistance_Doubles_ShouldBe(double x1, double y1, double x2, double y2, double expected) {

		double actual = (x1, y1).EuclideanDistance((x2, y2));
		actual.ShouldBe(expected, 0.0000001);
	}

	[Theory]
	[InlineData(0, 0, 3, 4, 5.0)]
	[InlineData(1, 2, 4, 6, 5.0)]
	[InlineData(0, 0, 1, 1, 1.4142135623730951)]
	[InlineData(100, 200, 385, 3424, 3236.5724153801966)]
	public void EuclideanDistance_Pairs_ShouldBe(long x1, long y1, long x2, long y2, double expected) {

		IEnumerable<(long, long)> pairs = [(x1, y1), (x2, y2)];
		double actual = pairs.EuclideanDistance();
		actual.ShouldBe(expected, 0.0000001);
	}

	[Fact]
	public void EuclideanDistance_Pairs_Of_Points_ShouldBe() {
		List<Point> points = [new(0, 0), new(3, 4), new(10, 10), new(20, 20), new(0, 5), new(12, 0)];

		IEnumerable<IEnumerable<Point>> pairs = points.Chunk(2);
		List<double> actual = [.. pairs.EuclideanDistances()];
		actual[0].ShouldBe(5.0, 0.0000001);
		actual[1].ShouldBe(14.142135623730951, 0.0000001);
		actual[2].ShouldBe(13.0, 0.0000001);
		pairs.First().EuclideanDistance().ShouldBe(5.0, 0.0000001);
	}

	[Fact]
	public void EuclideanDistance_Should_Throw() {

		IEnumerable<(long, long)> pairs = [(1, 2), (3, 4), (5, 6)];
		Should.Throw<InvalidOperationException>(() => pairs.EuclideanDistance())
		.Message
			.ShouldEndWith("You have 3 elements and there must be exactly 2.");

		IEnumerable<Point> pair = [new(1, 2), new(3, 4), new(5, 6)];
		Should.Throw<InvalidOperationException>(() => pair.EuclideanDistance())
		.Message
			.ShouldEndWith("You have 3 elements and there must be exactly 2.");
	}

	// 3d

	[Theory]
	[InlineData(0, 0, 0, 3, 4, 0, 5.0)]
	[InlineData(0, 0, 0, 1, 1, 1, 1.7320508075688772)]
	[InlineData(1, 2, 3, 4, 5, 6, 5.196152422706632)]
	[InlineData(100, 200, 385, 3424, 888, 999, 3449.5385198603017)]
	public void EuclideanDistance_Points3d_ShouldBe(int x1, int y1, int z1, int x2, int y2, int z2, double expected) {

		Point3d point1 = new(x1, y1, z1);
		Point3d point2 = new(x2, y2, z2);
		double actual = point1.EuclideanDistance(point2);
		actual.ShouldBe(expected, 0.0000001);
	}

	[Theory]
	[InlineData(0, 0, 0, 3, 4, 0, 5.0)]
	[InlineData(0, 0, 0, 1, 1, 1, 1.7320508075688772)]
	[InlineData(1, 2, 3, 4, 5, 6, 5.196152422706632)]
	[InlineData(100, 200, 385, 3424, 888, 999, 3449.5385198603017)]
	public void EuclideanDistance_Ints3d_ShouldBe(int x1, int y1, int z1, int x2, int y2, int z2, double expected) {

		double actual = (x1, y1, z1).EuclideanDistance((x2, y2, z2));
		actual.ShouldBe(expected, 0.0000001);
	}

	[Theory]
	[InlineData(0, 0, 0, 3, 4, 0, 5.0)]
	[InlineData(0, 0, 0, 1, 1, 1, 1.7320508075688772)]
	[InlineData(1, 2, 3, 4, 5, 6, 5.196152422706632)]
	public void EuclideanDistance_Longs3d_ShouldBe(long x1, long y1, long z1, long x2, long y2, long z2, double expected) {

		double actual = (x1, y1, z1).EuclideanDistance((x2, y2, z2));
		actual.ShouldBe(expected, 0.0000001);
	}

	[Theory]
	[InlineData(0.0, 0.0, 0.0, 3.0, 4.0, 0.0, 5.0)]
	[InlineData(0.0, 0.0, 0.0, 1.0, 1.0, 1.0, 1.7320508075688772)]
	[InlineData(1.5, 2.5, 3.5, 4.5, 6.5, 9.5, 7.810249675906654)]
	public void EuclideanDistance_Doubles3d_ShouldBe(double x1, double y1, double z1, double x2, double y2, double z2, double expected) {

		double actual = (x1, y1, z1).EuclideanDistance((x2, y2, z2));
		actual.ShouldBe(expected, 0.0000001);
	}

	[Theory]
	[InlineData(0, 0, 0, 3, 4, 0, 5.0)]
	[InlineData(0, 0, 0, 1, 1, 1, 1.7320508075688772)]
	[InlineData(1, 2, 3, 4, 5, 6, 5.196152422706632)]
	public void EuclideanDistance_Pairs3d_ShouldBe(long x1, long y1, long z1, long x2, long y2, long z2, double expected) {

		IEnumerable<(long, long, long)> pairs = [(x1, y1, z1), (x2, y2, z2)];
		double actual = pairs.EuclideanDistance();
		actual.ShouldBe(expected, 0.0000001);
	}

	[Fact]
	public void EuclideanDistance_Pairs_Of_Points3d_ShouldBe() {
		List<Point3d> points = [new(0, 0, 0), new(3, 4, 0), new(1, 1, 1), new(4, 5, 6), new(10, 0, 0), new(0, 10, 0)];

		IEnumerable<IEnumerable<Point3d>> pairs = points.Chunk(2);
		List<double> actual = [.. pairs.EuclideanDistances()];
		actual[0].ShouldBe(5.0, 0.0000001);
		actual[1].ShouldBe(7.0710678118654755, 0.0000001);
		actual[2].ShouldBe(14.142135623730951, 0.0000001);
		pairs.First().EuclideanDistance().ShouldBe(5.0, 0.0000001);
	}

	[Fact]
	public void EuclideanDistance3d_Should_Throw() {

		IEnumerable<(long, long, long)> pairs = [(1, 2, 3), (4, 5, 6), (7, 8, 9)];
		Should.Throw<InvalidOperationException>(() => pairs.EuclideanDistance())
		.Message
			.ShouldEndWith("You have 3 elements and there must be exactly 2.");

		IEnumerable<Point3d> pair = [new(1, 2, 3), new(4, 5, 6), new(7, 8, 9)];
		Should.Throw<InvalidOperationException>(() => pair.EuclideanDistance())
		.Message
			.ShouldEndWith("You have 3 elements and there must be exactly 2.");
	}
}
