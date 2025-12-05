namespace Smab.Helpers.Tests.GridHelperTests;

public class Diagonals {

	private static readonly char[,] INPUT_ARRAY = """
		ABCDE
		FGHIJ
		KLMNO
		PQRST
		UVWXY
		Z0123
		""".Split(Environment.NewLine).To2dArray();

	[Theory]
	[InlineData(0, "E")]
	[InlineData(1, "DJ")]
	[InlineData(2, "CIO")]
	[InlineData(3, "BHNT")]
	[InlineData(4, "AGMSY")]
	[InlineData(5, "FLRX3")]
	[InlineData(6, "KQW2")]
	[InlineData(7, "PV1")]
	[InlineData(8, "U0")]
	[InlineData(9, "Z")]
	public void DiagonalsSouthEast_AtIndex_ShouldBe(int index, string expected) {
		IEnumerable<char> actual = [.. INPUT_ARRAY.DiagonalsSouthEast(index)];
		actual.ShouldBe([.. expected]);
	}

	[Theory]
	[InlineData(0, "A")]
	[InlineData(1, "BF")]
	[InlineData(2, "CGK")]
	[InlineData(3, "DHLP")]
	[InlineData(4, "EIMQU")]
	[InlineData(5, "JNRVZ")]
	[InlineData(6, "OSW0")]
	[InlineData(7, "TX1")]
	[InlineData(8, "Y2")]
	[InlineData(9, "3")]
	public void DiagonalsSouthWest_AtIndex_ShouldBe(int index, string expected) {
		IEnumerable<char> actual = [.. INPUT_ARRAY.DiagonalsSouthWest(index)];
		actual.ShouldBe([.. expected]);
	}

	private static readonly char[,] SQUARE_INPUT_ARRAY = """
		ABCDE
		FGHIJ
		KLMNO
		PQRST
		UVWXY
		""".Split(Environment.NewLine).To2dArray();

	[Fact]
	public void DiagonalsSouthEast_ShouldBe() {
		List<IEnumerable<char>> actual = [.. SQUARE_INPUT_ARRAY.DiagonalsSouthEast()];

		actual.Count.ShouldBe(9);
		actual[0].ShouldBe(['E']);
		actual[1].ShouldBe(['D', 'J']);
		actual[2].ShouldBe(['C', 'I', 'O']);
		actual[3].ShouldBe(['B', 'H', 'N', 'T']);
		actual[4].ShouldBe(['A', 'G', 'M', 'S', 'Y']);
		actual[5].ShouldBe(['F', 'L', 'R', 'X']);
		actual[6].ShouldBe(['K', 'Q', 'W']);
		actual[7].ShouldBe(['P', 'V']);
		actual[8].ShouldBe(['U']);
	}

	[Fact]
	public void DiagonalsSouthWest_ShouldBe() {
		List<IEnumerable<char>> actual = [.. SQUARE_INPUT_ARRAY.DiagonalsSouthWest()];

		actual.Count.ShouldBe(9);
		actual[0].ShouldBe(['A']);
		actual[1].ShouldBe(['B', 'F']);
		actual[2].ShouldBe(['C', 'G', 'K']);
		actual[3].ShouldBe(['D', 'H', 'L', 'P']);
		actual[4].ShouldBe(['E', 'I', 'M', 'Q', 'U']);
		actual[5].ShouldBe(['J', 'N', 'R', 'V']);
		actual[6].ShouldBe(['O', 'S', 'W']);
		actual[7].ShouldBe(['T', 'X']);
		actual[8].ShouldBe(['Y']);
	}


	[Theory]
	[InlineData(0, "A")]
	[InlineData(1, "BF")]
	[InlineData(2, "CGK")]
	[InlineData(3, "DHLP")]
	[InlineData(4, "EIMQU")]
	[InlineData(5, "JNRVZ")]
	[InlineData(6, "OSW0")]
	[InlineData(7, "TX1")]
	[InlineData(8, "Y2")]
	[InlineData(9, "3")]
	public void DiagonalsSouthWestAsStrings_ShouldBe(int index, string expected) {
		List<string> actual = [.. INPUT_ARRAY.DiagonalsSouthWestAsStrings()];
		actual[index].ShouldBe(expected);
	}

	private static readonly Grid<char> GRID_INPUT = """
		ABCDE
		FGHIJ
		KLMNO
		PQRST
		UVWXY
		Z0123
		""".Split(Environment.NewLine).To2dGrid();

	[Theory]
	[InlineData(0, "E")]
	[InlineData(1, "DJ")]
	[InlineData(2, "CIO")]
	[InlineData(3, "BHNT")]
	[InlineData(4, "AGMSY")]
	[InlineData(5, "FLRX3")]
	[InlineData(6, "KQW2")]
	[InlineData(7, "PV1")]
	[InlineData(8, "U0")]
	[InlineData(9, "Z")]
	public void Grid_DiagonalsSouthEast_AtIndex_ShouldBe(int index, string expected) {
		IEnumerable<char> actual = [.. GRID_INPUT.DiagonalsSouthEast(index)];
		actual.ShouldBe([.. expected]);
	}

	[Theory]
	[InlineData(0, "A")]
	[InlineData(1, "BF")]
	[InlineData(2, "CGK")]
	[InlineData(3, "DHLP")]
	[InlineData(4, "EIMQU")]
	[InlineData(5, "JNRVZ")]
	[InlineData(6, "OSW0")]
	[InlineData(7, "TX1")]
	[InlineData(8, "Y2")]
	[InlineData(9, "3")]
	public void Grid_DiagonalsSouthWest_AtIndex_ShouldBe(int index, string expected) {
		IEnumerable<char> actual = [.. GRID_INPUT.DiagonalsSouthWest(index)];
		actual.ShouldBe([.. expected]);
	}

	private static readonly Grid<char> SQUARE_GRID_INPUT = """
		ABCDE
		FGHIJ
		KLMNO
		PQRST
		UVWXY
		""".Split(Environment.NewLine).To2dGrid();

	[Fact]
	public void Grid_DiagonalsSouthEast_ShouldBe() {
		List<IEnumerable<char>> actual = [.. SQUARE_GRID_INPUT.DiagonalsSouthEast()];

		actual.Count.ShouldBe(9);
		actual[0].ShouldBe(['E']);
		actual[1].ShouldBe(['D', 'J']);
		actual[2].ShouldBe(['C', 'I', 'O']);
		actual[3].ShouldBe(['B', 'H', 'N', 'T']);
		actual[4].ShouldBe(['A', 'G', 'M', 'S', 'Y']);
		actual[5].ShouldBe(['F', 'L', 'R', 'X']);
		actual[6].ShouldBe(['K', 'Q', 'W']);
		actual[7].ShouldBe(['P', 'V']);
		actual[8].ShouldBe(['U']);
	}

	[Fact]
	public void Grid_DiagonalsSouthWest_ShouldBe() {
		List<IEnumerable<char>> actual = [.. SQUARE_GRID_INPUT.DiagonalsSouthWest()];

		actual.Count.ShouldBe(9);
		actual[0].ShouldBe(['A']);
		actual[1].ShouldBe(['B', 'F']);
		actual[2].ShouldBe(['C', 'G', 'K']);
		actual[3].ShouldBe(['D', 'H', 'L', 'P']);
		actual[4].ShouldBe(['E', 'I', 'M', 'Q', 'U']);
		actual[5].ShouldBe(['J', 'N', 'R', 'V']);
		actual[6].ShouldBe(['O', 'S', 'W']);
		actual[7].ShouldBe(['T', 'X']);
		actual[8].ShouldBe(['Y']);
	}
}
