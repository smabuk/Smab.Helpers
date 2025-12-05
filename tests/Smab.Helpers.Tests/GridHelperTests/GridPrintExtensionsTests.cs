namespace Smab.Helpers.Tests.GridHelperTests;

public class GridPrintExtensionsTests {
	[Fact]
	public void PrintAsString_ShouldFormatGridAsString() {
		Grid<int> grid = new(3, 2);
		grid[0, 0] = 1;
		grid[1, 0] = 2;
		grid[2, 0] = 3;
		grid[0, 1] = 4;
		grid[1, 1] = 5;
		grid[2, 1] = 6;

		string result = grid.PrintAsString();

		result.ShouldBe($"123{Environment.NewLine}456");
	}

	[Fact]
	public void PrintAsString_WithWidth_ShouldPadElements() {
		Grid<int> grid = new(2, 2);
		grid[0, 0] = 1;
		grid[1, 0] = 2;
		grid[0, 1] = 3;
		grid[1, 1] = 4;

		string result = grid.PrintAsString(width: 3);

		result.ShouldBe($"  1  2{Environment.NewLine}  3  4");
	}

	[Fact]
	public void PrintAsString_WithReplacements_ShouldApplyReplacements() {
		Grid<int> grid = new(2, 2);
		grid[0, 0] = 1;
		grid[1, 0] = 2;
		grid[0, 1] = 3;
		grid[1, 1] = 4;

		string result = grid.PrintAsString(0, [("1", "X"), ("4", "Y")]);

		result.ShouldBe($"X2{Environment.NewLine}3Y");
	}

	[Fact]
	public void PrintAsStringArray_ShouldReturnArrayOfStrings() {
		Grid<int> grid = new(2, 2);
		grid[0, 0] = 1;
		grid[1, 0] = 2;
		grid[0, 1] = 3;
		grid[1, 1] = 4;

		List<string> result = grid.PrintAsStringArray().ToList();

		result.Count.ShouldBe(2);
		result[0].ShouldBe("12");
		result[1].ShouldBe("34");
	}

	[Fact]
	public void PrintAsStringList_ShouldReturnListOfStrings() {
		Grid<int> grid = new(2, 2);
		grid[0, 0] = 1;
		grid[1, 0] = 2;
		grid[0, 1] = 3;
		grid[1, 1] = 4;

		List<string> result = grid.PrintAsStringList();

		result.Count.ShouldBe(2);
		result[0].ShouldBe("12");
		result[1].ShouldBe("34");
	}

	[Fact]
	public void AsStrings_ShouldReturnStringsForEachRow() {
		Grid<char> grid = new(3, 2);
		grid[0, 0] = 'a';
		grid[1, 0] = 'b';
		grid[2, 0] = 'c';
		grid[0, 1] = 'd';
		grid[1, 1] = 'e';
		grid[2, 1] = 'f';

		List<string> result = grid.AsStrings().ToList();

		result.Count.ShouldBe(2);
		result[0].ShouldBe("abc");
		result[1].ShouldBe("def");
	}

	[Fact]
	public void AsStrings_WithReplacements_ShouldApplyReplacements() {
		Grid<char> grid = new(3, 2);
		grid[0, 0] = 'a';
		grid[1, 0] = 'b';
		grid[2, 0] = 'c';
		grid[0, 1] = 'd';
		grid[1, 1] = 'e';
		grid[2, 1] = 'f';

		List<string> result = grid.AsStrings([("a", "X"), ("f", "Y")]).ToList();

		result[0].ShouldBe("Xbc");
		result[1].ShouldBe("deY");
	}

	[Fact]
	public void AsStringWithNewLines_ShouldJoinWithNewLines() {
		Grid<int> grid = new(2, 2);
		grid[0, 0] = 1;
		grid[1, 0] = 2;
		grid[0, 1] = 3;
		grid[1, 1] = 4;

		string result = grid.AsStringWithNewLines();

		result.ShouldBe($"12{Environment.NewLine}34");
	}

	[Fact]
	public void AsString_WithSeparator_ShouldJoinWithSeparator() {
		Grid<int> grid = new(2, 2);
		grid[0, 0] = 1;
		grid[1, 0] = 2;
		grid[0, 1] = 3;
		grid[1, 1] = 4;

		string result = grid.AsString(separator: "|");

		result.ShouldBe("12|34");
	}

	[Fact]
	public void RowAsString_ShouldReturnSpecifiedRow() {
		Grid<int> grid = new(3, 3);
		grid[0, 0] = 1;
		grid[1, 0] = 2;
		grid[2, 0] = 3;
		grid[0, 1] = 4;
		grid[1, 1] = 5;
		grid[2, 1] = 6;
		grid[0, 2] = 7;
		grid[1, 2] = 8;
		grid[2, 2] = 9;

		string result = grid.RowAsString(1);

		result.ShouldBe("456");
	}

	[Fact]
	public void RowAsString_WithSeparator_ShouldUseSeparator() {
		Grid<int> grid = new(3, 2);
		grid[0, 0] = 1;
		grid[1, 0] = 2;
		grid[2, 0] = 3;
		grid[0, 1] = 4;
		grid[1, 1] = 5;
		grid[2, 1] = 6;

		string result = grid.RowAsString(0, ',');

		result.ShouldBe("1,2,3");
	}

	[Fact]
	public void RowsAsStrings_ShouldReturnAllRows() {
		Grid<int> grid = new(2, 2);
		grid[0, 0] = 1;
		grid[1, 0] = 2;
		grid[0, 1] = 3;
		grid[1, 1] = 4;

		List<string> result = grid.RowsAsStrings().ToList();

		result.Count.ShouldBe(2);
		result[0].ShouldBe("12");
		result[1].ShouldBe("34");
	}

	[Fact]
	public void ColAsString_ShouldReturnSpecifiedColumn() {
		Grid<int> grid = new(3, 3);
		grid[0, 0] = 1;
		grid[1, 0] = 2;
		grid[2, 0] = 3;
		grid[0, 1] = 4;
		grid[1, 1] = 5;
		grid[2, 1] = 6;
		grid[0, 2] = 7;
		grid[1, 2] = 8;
		grid[2, 2] = 9;

		string result = grid.ColAsString(1);

		result.ShouldBe("258");
	}

	[Fact]
	public void ColAsString_WithSeparator_ShouldUseSeparator() {
		Grid<int> grid = new(2, 3);
		grid[0, 0] = 1;
		grid[1, 0] = 2;
		grid[0, 1] = 3;
		grid[1, 1] = 4;
		grid[0, 2] = 5;
		grid[1, 2] = 6;

		string result = grid.ColAsString(0, ',');

		result.ShouldBe("1,3,5");
	}

	[Fact]
	public void ColsAsStrings_ShouldReturnAllColumns() {
		Grid<int> grid = new(2, 2);
		grid[0, 0] = 1;
		grid[1, 0] = 2;
		grid[0, 1] = 3;
		grid[1, 1] = 4;

		List<string> result = grid.ColsAsStrings().ToList();

		result.Count.ShouldBe(2);
		result[0].ShouldBe("13");
		result[1].ShouldBe("24");
	}

	[Fact]
	public void PrintAsString_WithCharGrid_ShouldWorkCorrectly() {
		Grid<char> grid = new(3, 2);
		grid[0, 0] = '#';
		grid[1, 0] = '.';
		grid[2, 0] = '#';
		grid[0, 1] = '.';
		grid[1, 1] = '#';
		grid[2, 1] = '.';

		string result = grid.PrintAsString();

		result.ShouldBe($"#.#{Environment.NewLine}.#.");
	}

	[Fact]
	public void AsStrings_WithEmptyGrid_ShouldReturnEmptySequence() {
		Grid<int> grid = new(2, 0);

		List<string> result = grid.AsStrings().ToList();

		result.Count.ShouldBe(0);
	}

	[Fact]
	public void PrintAsString_WithSingleElementGrid_ShouldWorkCorrectly() {
		Grid<int> grid = new(1, 1);
		grid[0, 0] = 42;

		string result = grid.PrintAsString();

		result.ShouldBe("42");
	}
}
