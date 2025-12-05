
namespace Smab.Helpers.Tests.GridHelperTests;

public partial class GetAdjacent {

	[Theory]
	[InlineData(0, 0, false, 2)]
	[InlineData(0, 0, true, 3)]
	[InlineData(1, 1, false, 4)]
	[InlineData(1, 1, true, 8)]
	public void GetAdjacentCells_Should_Have(int X, int Y, bool includeDiagonals, int expected) {
		(char, int)[] input = new (char, int)[26];
		for (int i = 0; i < input.GetUpperBound(0); i++) {
			input[i] = new((char)(65 + i), i + 1);
		}
		(char, int)[,] array = input.To2dArray(5);
		IEnumerable<Cell<(char, int)>> points = array.GetAdjacentCells((X, Y), includeDiagonals: includeDiagonals);
		points.Count().ShouldBe(expected);
	}

	[Theory]
	[InlineData(0, 0, false, 1)]
	[InlineData(1, 1, false, 3)]
	[InlineData(1, 1, true, 6)]
	public void GetAdjacentCells_Should_Not_Have(int X, int Y, bool includeDiagonals, int expected) {
		(char, int)[] input = new (char, int)[26];
		for (int i = 0; i < input.GetUpperBound(0); i++) {
			input[i] = new((char)(65 + i), i + 1);
		}
		(char, int)[,] array = input.To2dArray(5);
		IEnumerable<Cell<(char, int)>> points = array.GetAdjacentCells((X, Y), includeDiagonals: includeDiagonals, exclude: [ArrayHelpers.RIGHT, ArrayHelpers.NORTH_EAST]);
		points.Count().ShouldBe(expected);
	}

	[Theory]
	[InlineData(0, 0, 2)]
	[InlineData(1, 1, 4)]
	public void GetCornerCells_Should_Have(int X, int Y, int expected) {
		(char, int)[] input = new (char, int)[26];
		for (int i = 0; i < input.GetUpperBound(0); i++) {
			input[i] = new((char)(65 + i), i + 1);
		}
		(char, int)[,] array = input.To2dArray(5);
		IEnumerable<Cell<(char, int)>> points = array.GetCornerCells((X, Y));
		points.Count().ShouldBe(expected);
	}

}

