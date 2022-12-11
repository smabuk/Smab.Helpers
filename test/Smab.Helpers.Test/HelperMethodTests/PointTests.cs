namespace Smab.Helpers.Test.HelperMethodTests;

public class PointTests
{
	[Theory]
	[InlineData(0, 0, 1, 1, 1, 1)]
	[InlineData(8, 9, 12, 4, 20, 13)]
	[InlineData(8, 9, -12, -4, -4, 5)]
	public void PointAddition(int p1x, int p1y, int p2x, int p2y, int expectedX, int expectedY)
	{
		Point actual = new Point(p1x, p1y) + new Point(p2x, p2y);
		Assert.Equal(new Point(expectedX, expectedY), actual);
	}

	[Theory]
	[InlineData(0, 0, 1, 1, 1, 1)]
	[InlineData(8, 9, 12, 4, 20, 13)]
	[InlineData(8, 9, -12, -4, -4, 5)]
	public void PointAddition_WithTuples(int p1x, int p1y, int p2x, int p2y, int expectedX, int expectedY)
	{
		Point actual = new Point(p1x, p1y) + (p2x, p2y);
		Assert.Equal(new Point(expectedX, expectedY), actual);
		actual = (p1x, p1y) + new Point(p2x, p2y);
		Assert.Equal(new Point(expectedX, expectedY), actual);
	}

}
