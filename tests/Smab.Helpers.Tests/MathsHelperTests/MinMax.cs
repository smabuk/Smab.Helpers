namespace Smab.Helpers.Tests.MathsHelperTests;

public class MinMax {
	[Theory]
	[InlineData((int[])[2, 3], 2, 3)]
	[InlineData((int[])[2, 3, 4, 5, 6, 7, 8], 2, 8)]
	[InlineData((int[])[2, 3, 4, -8, 6, 7, 8], -8, 8)]
	[InlineData((int[])[11, 3, 4, -8, 6, 7, 333], -8, 333)]
	public void MinMax_OfInts_ShouldBe(int[] numbers, int expectedMin, int expectedMax) {
		numbers.MinMax().ShouldBe((expectedMin, expectedMax));
		numbers.MinMax().ShouldBe((expectedMin, expectedMax));
	}

	[Theory]
	[InlineData(50_000_000_000L, 12L, 12L, 50_000_000_000L)]
	public void MinMax_OfLongs_ShouldBe(long number1, long number2, long expectedMin, long expectedMax) {
		number1.MinMax(number2).ShouldBe((expectedMin, expectedMax));
		number1.MinMax(number2).ShouldBe((expectedMin, expectedMax));
	}

	[Fact]
	public void MinMax_Of_Points() {
		Point point = new(1, 23);
		point.MinMax().ShouldBe((1, 23));

		Point[] points = [new Point(2, 3), new Point(3, 4), new Point(5, 6), new Point(7, 8)];
		points.MinMax().ShouldBe((2, 8));

		int min;
		int max;
		points = [];
		Should.Throw<InvalidOperationException>(() => (min, max) = points.MinMax())
		.Message
			.ShouldEndWith("Sequence contains no elements");
	}
}
