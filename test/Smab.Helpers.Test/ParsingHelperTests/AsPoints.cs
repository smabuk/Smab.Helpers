namespace Smab.Helpers.Test.ParsingHelperTests;
public class AsPoints {

	[Fact]
	public void AsPoints_Tests() {
		string[] input = [
			"3,0",
			"7, 1",
			"    0,     2",
			];

		List<Point> points = [..input.AsPoints()];
		points.ShouldBe([new Point(3,0), new(7, 1), new(0, 2)]);
	}

	[Fact]
	public void AsPoints_With_Match() {
		string input = """
			...#......
			.......#..
			#.........
			..........
			""";

		List<Point> points = [..input.AsPoints('#')];
		points.ShouldBe([new Point(3,0), new(7, 1), new(0, 2)]);

		points = [..input.Split(Environment.NewLine).AsPoints('#')];
		points.ShouldBe([new Point(3,0), new(7, 1), new(0, 2)]);
	}

}
