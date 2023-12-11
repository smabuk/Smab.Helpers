namespace Smab.Helpers.Test.ParsingHelperTests;
public class AsPoints {

	[Fact]
	public void AsPoints_With_Match() {
		const string input = """
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
