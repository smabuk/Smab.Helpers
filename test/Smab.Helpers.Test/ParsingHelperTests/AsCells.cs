namespace Smab.Helpers.Test.ParsingHelperTests;
public class AsCells {

	[Fact]
	public void AsCells_With_Matches() {
		const string input = """
			..#...*...
			...*...#..
			#.........
			.....*....
			""";

		IEnumerable<Cell<char>> expected = [new(2, 0, '#'), new(6, 0, '*'), new(3, 1, '*'), new(7, 1, '#'), new(0, 2, '#'), new(5, 3, '*')];

		List<Cell<char>> cells = [.. input.AsCells(['#', '*'])];
		cells.ShouldBe(expected);

		cells = [.. input.Split(Environment.NewLine).AsCells(['#', '*'])];
		cells.ShouldBe(expected);

		cells = [.. input.Replace('.', ' ').AsCells()];
		cells.ShouldBe(expected);
	}
}
