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
		Assert.Equal((3, 2), point.North());
		Assert.Equal((3, 4), point.South());
		Assert.Equal((2, 3), point.West());
		Assert.Equal((4, 3), point.East());
		Assert.Equal((8, 3), point.East(5));

		List<Point> list = point.Adjacent().ToList();
		Assert.Equal(4, list.Count);
		Assert.Collection(list,
			item => Assert.Equal((3, 2), item),
			item => Assert.Equal((3, 4), item),
			item => Assert.Equal((2, 3), item),
			item => Assert.Equal((4, 3), item)
		);

		list = point.DiagonallyAdjacent().ToList();
		Assert.Equal(4, list.Count);
		Assert.Collection(list,
			item => Assert.Equal((4, 2), item),
			item => Assert.Equal((4, 4), item),
			item => Assert.Equal((2, 4), item),
			item => Assert.Equal((2, 2), item)
		);

		list = point.AllAdjacent().ToList();
		Assert.Equal(8, list.Count);
		Assert.Collection(list,
			item => Assert.Equal((3, 2), item),
			item => Assert.Equal((4, 2), item),
			item => Assert.Equal((4, 3), item),
			item => Assert.Equal((4, 4), item),
			item => Assert.Equal((3, 4), item),
			item => Assert.Equal((2, 4), item),
			item => Assert.Equal((2, 3), item),
			item => Assert.Equal((2, 2), item)
		);

	}

	[Fact]
	public void Point_Constants() {
		(Point.Zero  is (0, 0)).ShouldBeTrue();
		(Point.One   is (1, 1)).ShouldBeTrue();
		(Point.UnitX is (1, 0)).ShouldBeTrue();
		(Point.UnitY is (0, 1)).ShouldBeTrue();
	}

}
