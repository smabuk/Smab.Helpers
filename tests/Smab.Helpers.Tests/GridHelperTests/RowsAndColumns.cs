namespace Smab.Helpers.Tests.GridHelperTests;

public class RowsAndColumns {
	[Fact]
	public void ColAsString() {
		char[,] input = """
			#.#
			##.
			"""
			.Split(Environment.NewLine)
			.To2dArray();

		input.ColAsString(0).ShouldBe("##");
		input.ColAsString(1).ShouldBe(".#");
		input.ColAsString(2).ShouldBe("#.");

		input.ColsAsStrings().ToList()[0].ShouldBe("##");
		input.ColsAsStrings().ToList()[1].ShouldBe(".#");
		input.ColsAsStrings().ToList()[2].ShouldBe("#.");
	}


	[Fact]
	public void RowAsString() {
		string[] input = [.."""
			#.#
			##.
			"""
			.Split(Environment.NewLine)];

		char[,] array = input.To2dArray();
		array.RowAsString(0).ShouldBe("#.#");
		array.RowAsString(1).ShouldBe("##.");

		input.RowAsString(0).ShouldBe("#.#");
		input.RowAsString(1).ShouldBe("##.");

		array.RowsAsStrings().ToList()[0].ShouldBe("#.#");
		array.RowsAsStrings().ToList()[1].ShouldBe("##.");
	}

	[Theory]
	[InlineData(0, 0, true)]
	[InlineData(11, 12, true)]
	[InlineData(99, 199, true)]
	[InlineData(100, 12, false)]
	[InlineData(12, 200, false)]
	[InlineData(-1, 0, false)]
	public void InBounds_ShouldBe(int x, int y, bool expected) {
		char[,] array = new char[100, 200]; // 0-99, 0-199

		array.IsInBounds(x, y).ShouldBe(expected);
		if (array.IsInBounds(x, y)) {
			Should.NotThrow(() => _ = array[x, y]);
		} else {
			Should.Throw<IndexOutOfRangeException>(() => _ = array[x, y])
			.Message
				.ShouldEndWith("Index was outside the bounds of the array.");
		}
		array.IsInBounds(new Point(x, y)).ShouldBe(expected);
	}

	[Theory]
	[InlineData(0, 0, false)]
	[InlineData(11, 12, false)]
	[InlineData(99, 199, false)]
	[InlineData(100, 12, true)]
	[InlineData(12, 200, true)]
	[InlineData(-1, 0, true)]
	public void OutOfBounds_ShouldBe(int x, int y, bool expected) {
		char[,] array = new char[100, 200]; // 0-99, 0-199

		array.IsOutOfBounds(x, y).ShouldBe(expected);
		if (array.IsOutOfBounds(x, y)) {
			Should.Throw<IndexOutOfRangeException>(() => _ = array[x, y])
			.Message
				.ShouldEndWith("Index was outside the bounds of the array.");
		} else {
			Should.NotThrow(() => _ = array[x, y]);
		}
		array.IsOutOfBounds(new Point(x, y)).ShouldBe(expected);
	}

	[Fact]
	public void Grid_ColAsString() {
		Grid<char> grid = """
			#.#
			##.
			"""
			.Split(Environment.NewLine)
			.To2dGrid();

		grid.ColAsString(0).ShouldBe("##");
		grid.ColAsString(1).ShouldBe(".#");
		grid.ColAsString(2).ShouldBe("#.");

		grid.ColsAsStrings().ToList()[0].ShouldBe("##");
		grid.ColsAsStrings().ToList()[1].ShouldBe(".#");
		grid.ColsAsStrings().ToList()[2].ShouldBe("#.");
	}

	[Fact]
	public void Grid_RowAsString() {
		Grid<char> grid = """
			#.#
			##.
			"""
			.Split(Environment.NewLine)
			.To2dGrid();

		grid.RowAsString(0).ShouldBe("#.#");
		grid.RowAsString(1).ShouldBe("##.");

		grid.RowsAsStrings().ToList()[0].ShouldBe("#.#");
		grid.RowsAsStrings().ToList()[1].ShouldBe("##.");
	}

	[Theory]
	[InlineData(0, 0, true)]
	[InlineData(11, 12, true)]
	[InlineData(99, 199, true)]
	[InlineData(100, 12, false)]
	[InlineData(12, 200, false)]
	[InlineData(-1, 0, false)]
	public void Grid_InBounds_ShouldBe(int x, int y, bool expected) {
		Grid<char> grid = new(100, 200); // 0-99, 0-199

		grid.IsInBounds(x, y).ShouldBe(expected);
		grid.IsInBounds((x, y)).ShouldBe(expected);
	}

	[Theory]
	[InlineData(0, 0, false)]
	[InlineData(11, 12, false)]
	[InlineData(99, 199, false)]
	[InlineData(100, 12, true)]
	[InlineData(12, 200, true)]
	[InlineData(-1, 0, true)]
	public void Grid_OutOfBounds_ShouldBe(int x, int y, bool expected) {
		Grid<char> grid = new(100, 200); // 0-99, 0-199

		grid.IsOutOfBounds(x, y).ShouldBe(expected);
		grid.IsOutOfBounds((x, y)).ShouldBe(expected);
	}

	[Fact]
	public void Grid_MinMax_Properties() {
		Grid<int> grid = new(50, 100);

		grid.ColsMin.ShouldBe(0);
		grid.RowsMin.ShouldBe(0);
		grid.ColsMax.ShouldBe(49);
		grid.RowsMax.ShouldBe(99);
		grid.XMin.ShouldBe(0);
		grid.YMin.ShouldBe(0);
		grid.XMax.ShouldBe(49);
		grid.YMax.ShouldBe(99);
	}

	[Fact]
	public void Grid_ColIndexes_And_RowIndexes() {
		Grid<int> grid = new(3, 2);

		grid.ColIndexes().ShouldBe([0, 1, 2]);
		grid.RowIndexes().ShouldBe([0, 1]);
		grid.XValues().ShouldBe([0, 1, 2]);
		grid.YValues().ShouldBe([0, 1]);
	}

	[Fact]
	public void Grid_Row_And_Col_Methods() {
		int[] input = [1, 2, 3, 4, 5, 6, 7, 8, 9];
		Grid<int> grid = input.To2dGrid(3, 3);

		List<int> row1 = [.. grid.Row(1)];
		row1.ShouldBe([4, 5, 6]);

		List<int> col2 = [.. grid.Col(2)];
		col2.ShouldBe([3, 6, 9]);

		grid.GetRows().Count().ShouldBe(3);
		grid.Cols().Count().ShouldBe(3);
	}
}
