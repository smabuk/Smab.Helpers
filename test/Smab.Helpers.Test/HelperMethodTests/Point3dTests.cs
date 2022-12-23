namespace Smab.Helpers.Test.HelperMethodTests;

public class Point3dTests {
	[Theory]
	[InlineData(0, 0, 0, 1, 1, 1, 1, 1, 1)]
	[InlineData(8, 9, 3, 12, 4, 7, 20, 13, 10)]
	[InlineData(8, 9, 3, -12, -4, -7, -4, 5, -4)]
	public void Point3dAddition(int p1x, int p1y, int p1z, int p2x, int p2y, int p2z, int expectedX, int expectedY, int expectedZ) {
		Point3d actual = new Point3d(p1x, p1y, p1z) + new Point3d(p2x, p2y, p2z);
		Assert.Equal(new Point3d(expectedX, expectedY, expectedZ), actual);
	}

	[Theory]
	[InlineData(0, 0, 0, 1, 1, 1, 1, 1, 1)]
	[InlineData(8, 9, 3, 12, 4, 7, 20, 13, 10)]
	[InlineData(8, 9, 3, -12, -4, -7, -4, 5, -4)]
	public void Point3dAddition_WithTuples(int p1x, int p1y, int p1z, int p2x, int p2y, int p2z, int expectedX, int expectedY, int expectedZ) {
		Point3d actual = new Point3d(p1x, p1y, p1z) + (p2x, p2y, p2z);
		Assert.Equal(new Point3d(expectedX, expectedY, expectedZ), actual);
		actual = (p1x, p1y, p1z) + new Point3d(p2x, p2y, p2z);
		Assert.Equal(new Point3d(expectedX, expectedY, expectedZ), actual);
	}

	[Fact]
	public void Point3dDirections() {
		Point3d Point3d = new(3, 3, 3);
		Assert.Equal((3, 2, 3), Point3d.North());
		Assert.Equal((3, 4, 3), Point3d.South());
		Assert.Equal((2, 3, 3), Point3d.West());
		Assert.Equal((4, 3, 3), Point3d.East());
		Assert.Equal((3, 3, 2), Point3d.Front());
		Assert.Equal((3, 3, 4), Point3d.Back());

		List<Point3d> list = Point3d.Adjacent().ToList();
		Assert.Equal(6, list.Count);
		Assert.Collection(list,
			item => Assert.Equal((3, 2, 3), item),
			item => Assert.Equal((3, 4, 3), item),
			item => Assert.Equal((2, 3, 3), item),
			item => Assert.Equal((4, 3, 3), item),
			item => Assert.Equal((3, 3, 2), item),
			item => Assert.Equal((3, 3, 4), item)
		);

		list = Point3d.AllAdjacent().ToList();
		Assert.Equal(26, list.Count);
		Assert.Collection(list,
			item => Assert.Equal((2, 2, 2), item),
			item => Assert.Equal((3, 2, 2), item),
			item => Assert.Equal((4, 2, 2), item),
			item => Assert.Equal((2, 3, 2), item),
			item => Assert.Equal((3, 3, 2), item),
			item => Assert.Equal((4, 3, 2), item),
			item => Assert.Equal((2, 4, 2), item),
			item => Assert.Equal((3, 4, 2), item),
			item => Assert.Equal((4, 4, 2), item),
			item => Assert.Equal((2, 2, 3), item),
			item => Assert.Equal((3, 2, 3), item),
			item => Assert.Equal((4, 2, 3), item),
			item => Assert.Equal((2, 3, 3), item),
			item => Assert.Equal((4, 3, 3), item),
			item => Assert.Equal((2, 4, 3), item),
			item => Assert.Equal((3, 4, 3), item),
			item => Assert.Equal((4, 4, 3), item),
			item => Assert.Equal((2, 2, 4), item),
			item => Assert.Equal((3, 2, 4), item),
			item => Assert.Equal((4, 2, 4), item),
			item => Assert.Equal((2, 3, 4), item),
			item => Assert.Equal((3, 3, 4), item),
			item => Assert.Equal((4, 3, 4), item),
			item => Assert.Equal((2, 4, 4), item),
			item => Assert.Equal((3, 4, 4), item),
			item => Assert.Equal((4, 4, 4), item)
		);

	}

}
