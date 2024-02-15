namespace Smab.Helpers.Test.MathsHelperTests;
public class Transpose {
	[Fact]
	public void Transpose_Should() {
		IEnumerable<Point> points   = [new(1, 3), new(2, 4), new(-4, -5), new(1, 1)];
		IEnumerable<Point> expected = [new(3, 1), new(4, 2), new(-5, -4), new(1, 1)];

		points.Transpose().ShouldBe(expected);
	}

	[Fact]
	public void Transpose_OfType_Should() {
		new Point(0, 1).Transpose().ShouldBe(new Point(1, 0));
		(0, 1).Transpose<int>().ShouldBe((1, 0));
		("a", "b").Transpose<string>().ShouldBe(("b", "a"));
	}
}
