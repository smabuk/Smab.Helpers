namespace Smab.Helpers.Tests.GridHelperTests;

public class PointTests {
	[Theory]
	[InlineData("0,0", 0, 0)]
	[InlineData("(8,9)", 8, 9)]
	[InlineData("  8 , -6  ", 8, -6)]
	public void Point_Parses(string parseString, int p1x, int p1y) {
		Point actual = Point.Parse(parseString);
		actual.X.ShouldBe(p1x);
		actual.Y.ShouldBe(p1y);
	}

	[Theory]
	[InlineData(0, 0, 1, 1, 1, 1)]
	[InlineData(8, 9, 12, 4, 20, 13)]
	[InlineData(8, 9, -12, -4, -4, 5)]
	public void PointAddition(int p1x, int p1y, int p2x, int p2y, int expectedX, int expectedY) {
		Point actual = new Point(p1x, p1y) + new Point(p2x, p2y);
		Assert.Equal(new Point(expectedX, expectedY), actual);
	}

	[Theory]
	[InlineData(0, 0, 1, 1, -1, -1)]
	[InlineData(8, 9, 12, 4, -4, 5)]
	[InlineData(8, 9, -12, -4, 20, 13)]
	public void PointSubtraction(int p1x, int p1y, int p2x, int p2y, int expectedX, int expectedY) {
		Point actual = new Point(p1x, p1y) - new Point(p2x, p2y);
		Assert.Equal(new Point(expectedX, expectedY), actual);
	}

	[Theory]
	[InlineData(0, 0, 0, 0, false)]
	[InlineData(0, 0, 1, 1, false)]
	[InlineData(1, 0, 0, 0, true)]
	[InlineData(8, 9, 12, 4, true)]
	[InlineData(8, 9, -12, -4, true)]
	public void PointComparison_P1_GT_P2(int p1x, int p1y, int p2x, int p2y, bool expected) {
		Point p1 = new(p1x, p1y);
		Point p2 = new(p2x, p2y);

		bool actual = p1 > p2;
		Assert.Equal(actual, expected);
	}

	[Theory]
	[InlineData(0, 0, 0, 0, false)]
	[InlineData(0, 0, 1, 1, true)]
	[InlineData(1, 0, 0, 0, false)]
	[InlineData(8, 9, 12, 4, false)]
	[InlineData(8, 9, -12, -4, false)]
	public void PointComparison_P2_LT_P1(int p1x, int p1y, int p2x, int p2y, bool expected) {
		Point p1 = new(p1x, p1y);
		Point p2 = new(p2x, p2y);

		bool actual = p1 < p2;
		Assert.Equal(actual, expected);
	}

	[Theory]
	[InlineData(0, 0, 0, 0, true)]
	[InlineData(0, 0, 1, 1, false)]
	[InlineData(1, 0, 0, 0, true)]
	[InlineData(8, 9, 12, 4, true)]
	[InlineData(8, 9, -12, -4, true)]
	public void PointComparison_P1_GTE_P2(int p1x, int p1y, int p2x, int p2y, bool expected) {
		Point p1 = new(p1x, p1y);
		Point p2 = new(p2x, p2y);

		bool actual = p1 >= p2;
		Assert.Equal(actual, expected);
	}

	[Fact]
	public void PointOrdering() {
		List<Point> points = [
			new( 1,  0),
			new( 3,  1),
			new(-4, -2),
			new( 2,  6),
			new( 4,  1),
			new( 1, -3)];

		List<Point> actual = [.. points.Order()];

		actual[0].ShouldBe(points[5]);
		actual[1].ShouldBe(points[2]);
		actual[2].ShouldBe(points[0]);
		actual[3].ShouldBe(points[1]);
		actual[4].ShouldBe(points[4]);
		actual[5].ShouldBe(points[3]);
	}

	[Theory]
	[InlineData(0, 0, 0, 0)]
	[InlineData(8, 9, 9, 8)]
	[InlineData(-5, 6, 6, -5)]
	public void PointTranspose(int p1x, int p1y, int expectedX, int expectedY) {
		Point actual = new Point(p1x, p1y).Transpose();
		Assert.Equal(new Point(expectedX, expectedY), actual);
	}

	[Theory]
	[InlineData(0, 0, 1, 1, 1, 1)]
	[InlineData(8, 9, 12, 4, 20, 13)]
	[InlineData(8, 9, -12, -4, -4, 5)]
	public void PointAddition_WithTuples(int p1x, int p1y, int p2x, int p2y, int expectedX, int expectedY) {
		Point actual = new Point(p1x, p1y) + (p2x, p2y);
		Assert.Equal(new Point(expectedX, expectedY), actual);
		actual = (p1x, p1y) + new Point(p2x, p2y);
		Assert.Equal(new Point(expectedX, expectedY), actual);
	}

	[Fact]
	public void PointDirections() {
		Point point = new(3, 3);
		Assert.Equal((3, 2), point.MoveNorth());
		Assert.Equal((3, 4), point.MoveSouth());
		Assert.Equal((2, 3), point.MoveWest());
		Assert.Equal((4, 3), point.MoveEast());
		Assert.Equal((8, 3), point.MoveEast(5));

		List<Point> list = [.. point.Adjacent()];
		Assert.Equal(4, list.Count);
		Assert.Collection(list,
			item => Assert.Equal((3, 2), item),
			item => Assert.Equal((3, 4), item),
			item => Assert.Equal((4, 3), item),
			item => Assert.Equal((2, 3), item)
		);

		list = [.. point.DiagonallyAdjacent()];
		Assert.Equal(4, list.Count);
		Assert.Collection(list,
			item => Assert.Equal((2, 2), item),
			item => Assert.Equal((4, 2), item),
			item => Assert.Equal((2, 4), item),
			item => Assert.Equal((4, 4), item)
		);

		list = [.. point.AllAdjacent()];
		Assert.Equal(8, list.Count);
		Assert.Collection(list,
			item => Assert.Equal((3, 2), item),
			item => Assert.Equal((3, 4), item),
			item => Assert.Equal((4, 3), item),
			item => Assert.Equal((2, 3), item),
			item => Assert.Equal((2, 2), item),
			item => Assert.Equal((4, 2), item),
			item => Assert.Equal((2, 4), item),
			item => Assert.Equal((4, 4), item)
		);

	}

	[Fact]
	public void Point_Constants() {
		(Point.Zero is (0, 0)).ShouldBeTrue();
		(Point.One is (1, 1)).ShouldBeTrue();
		(Point.UnitX is (1, 0)).ShouldBeTrue();
		(Point.UnitY is (0, 1)).ShouldBeTrue();
		Point point = new(Point.One);
		point.ShouldBe(Point.One);
	}

	[Theory]
	[InlineData(4, 6, 2, 2, 2, 3)]
	[InlineData(10, 20, 2, 5, 5, 4)]
	[InlineData(10, 20, 5, 2, 2, 10)]
	[InlineData(12, 8, 4, 4, 3, 2)]
	public void PointDivision_ExactDivision(int p1x, int p1y, int p2x, int p2y, int expectedX, int expectedY) {
		Point actual = new Point(p1x, p1y) / new Point(p2x, p2y);
		Assert.Equal(new Point(expectedX, expectedY), actual);
	}

	[Theory]
	[InlineData(10, 20, 2, 5, 10)]
	[InlineData(12, 9, 3, 4, 3)]
	[InlineData(100, 50, 10, 10, 5)]
	public void PointDivision_ByScalar(int p1x, int p1y, int divisor, int expectedX, int expectedY) {
		Point actual = new Point(p1x, p1y) / divisor;
		Assert.Equal(new Point(expectedX, expectedY), actual);
	}

	[Fact]
	public void PointDivision_ThrowsOnDivideByZero() {
		Point p = new(10, 20);
		Assert.Throws<DivideByZeroException>(() => p / 0);
		Assert.Throws<DivideByZeroException>(() => p / new Point(5, 0));
		Assert.Throws<DivideByZeroException>(() => p / new Point(0, 5));
		Assert.Throws<DivideByZeroException>(() => p / (5, 0));
		Assert.Throws<DivideByZeroException>(() => (10, 20) / new Point(0, 5));
	}

	[Fact]
	public void PointDivision_ThrowsOnNonIntegerResult() {
		Point p = new(10, 20);
		Assert.Throws<ArgumentException>(() => p / 3);
		Assert.Throws<ArgumentException>(() => p / new Point(3, 4));
		Assert.Throws<ArgumentException>(() => new Point(7, 9) / 2);
		Assert.Throws<ArgumentException>(() => (10, 21) / new Point(2, 4));
	}

	[Theory]
	[InlineData(0, 0, 2, 2, 0, 0)]
	[InlineData(8, 9, 12, 4, 96, 36)]
	[InlineData(8, 9, -12, -4, -96, -36)]
	public void PointMultiplication(int p1x, int p1y, int p2x, int p2y, int expectedX, int expectedY) {
		Point actual = new Point(p1x, p1y) * new Point(p2x, p2y);
		Assert.Equal(new Point(expectedX, expectedY), actual);
	}

	[Theory]
	[InlineData(5, 7, 3, 15, 21)]
	[InlineData(2, 3, -2, -4, -6)]
	public void PointMultiplication_ByScalar(int px, int py, int scalar, int expectedX, int expectedY) {
		Point p = new(px, py);
		Point actual1 = p * scalar;
		Point actual2 = scalar * p;
		Assert.Equal(new Point(expectedX, expectedY), actual1);
		Assert.Equal(new Point(expectedX, expectedY), actual2);
	}

	[Theory]
	[InlineData(10, 9, 3, 1, 0)]
	[InlineData(8, 9, 5, 3, 4)]
	[InlineData(-7, 6, 3, -1, 0)]
	public void PointModulo(int p1x, int p1y, int divisor, int expectedX, int expectedY) {
		Point actual = new Point(p1x, p1y) % divisor;
		Assert.Equal(new Point(expectedX, expectedY), actual);
	}

	[Fact]
	public void PointNegation() {
		Point p = new(5, -3);
		Point actual = -p;
		Assert.Equal(new Point(-5, 3), actual);
	}

	[Fact]
	public void Point_DirectionalProperties() {
		Point point = new(5, 5);

		Assert.Equal((6, 5), point.Right);
		Assert.Equal((4, 5), point.Left);
		Assert.Equal((5, 4), point.Up);
		Assert.Equal((5, 6), point.Down);

		Assert.Equal((6, 5), point.East);
		Assert.Equal((4, 5), point.West);
		Assert.Equal((5, 4), point.North);
		Assert.Equal((5, 6), point.South);

		Assert.Equal((4, 4), point.UpLeft);
		Assert.Equal((6, 4), point.UpRight);
		Assert.Equal((6, 6), point.DownLeft);
		Assert.Equal((4, 6), point.DownRight);

		Assert.Equal((4, 4), point.NorthWest);
		Assert.Equal((6, 4), point.NorthEast);
		Assert.Equal((4, 6), point.SouthEast);
		Assert.Equal((6, 6), point.SouthWest);
	}

	[Theory]
	[InlineData(5, 5, 2, 7, 5)]
	[InlineData(5, 5, 3, 8, 5)]
	public void Point_MoveWithDistance(int px, int py, int distance, int expectedX, int expectedY) {
		Point point = new(px, py);
		Assert.Equal((expectedX, py), point.MoveRight(distance));
		Assert.Equal((expectedX, py), point.MoveEast(distance));
	}

	[Fact]
	public void Point_MoveUp_And_Down() {
		Point point = new(5, 5);
		Assert.Equal((5, 3), point.MoveUp(2));
		Assert.Equal((5, 8), point.MoveDown(3));
	}

	[Fact]
	public void Point_MoveLeft_And_Right() {
		Point point = new(5, 5);
		Assert.Equal((3, 5), point.MoveLeft(2));
		Assert.Equal((8, 5), point.MoveRight(3));
	}

	[Fact]
	public void Point_Move_WithDirection() {
		Point point = new(5, 5);
		Assert.Equal((5, 3), point.Move(Direction.North, 2));
		Assert.Equal((5, 7), point.Move(Direction.South, 2));
		Assert.Equal((3, 5), point.Move(Direction.West, 2));
		Assert.Equal((7, 5), point.Move(Direction.East, 2));
	}

	[Fact]
	public void Point_Translate() {
		Point point = new(5, 5);
		Assert.Equal((7, 5), point.Translate(Direction.East, 2));
		Assert.Equal((5, 3), point.Translate(Direction.North, 2));
		Assert.Equal((7, 3), point.Translate(Direction.NorthEast, 2));
	}

	[Theory]
	[InlineData(5, -3, 5, 3)]
	[InlineData(-5, 3, 5, 3)]
	[InlineData(-5, -3, 5, 3)]
	[InlineData(0, 0, 0, 0)]
	public void Point_Abs(int px, int py, int expectedX, int expectedY) {
		Point point = new(px, py);
		Point actual = point.Abs();
		Assert.Equal(new Point(expectedX, expectedY), actual);
	}

	[Theory]
	[InlineData(3, 4, 5, 6, 5, 6)]
	[InlineData(5, 2, 3, 8, 5, 8)]
	[InlineData(-1, -2, 1, 0, 1, 0)]
	public void Point_Max(int p1x, int p1y, int p2x, int p2y, int expectedX, int expectedY) {
		Point p1 = new(p1x, p1y);
		Point p2 = new(p2x, p2y);
		Point actual = p1.Max(p2);
		Assert.Equal(new Point(expectedX, expectedY), actual);
	}

	[Theory]
	[InlineData(3, 4, 5, 6, 3, 4)]
	[InlineData(5, 2, 3, 8, 3, 2)]
	[InlineData(-1, -2, 1, 0, -1, -2)]
	public void Point_Min(int p1x, int p1y, int p2x, int p2y, int expectedX, int expectedY) {
		Point p1 = new(p1x, p1y);
		Point p2 = new(p2x, p2y);
		Point actual = p1.Min(p2);
		Assert.Equal(new Point(expectedX, expectedY), actual);
	}

	[Fact]
	public void Point_ColAndRow_Properties() {
		Point point = new(7, 3);
		Assert.Equal(7, point.Col);
		Assert.Equal(3, point.Row);
	}

	[Fact]
	public void Point_Deconstruct() {
		Point point = new(7, 3);
		var (x, y) = point;
		Assert.Equal(7, x);
		Assert.Equal(3, y);
	}

	[Fact]
	public void Point_ImplicitConversionToTuple() {
		Point point = new(7, 3);
		(int x, int y) tuple = point;
		Assert.Equal(7, tuple.x);
		Assert.Equal(3, tuple.y);
	}

}
