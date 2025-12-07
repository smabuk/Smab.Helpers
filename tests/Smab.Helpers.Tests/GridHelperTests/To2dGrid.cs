namespace Smab.Helpers.Tests.GridHelperTests;

public class To2dGrid {
	[Theory]
	[InlineData(new int[] { 1, 2, 3, 4, 5, 6 }, 2, 3, 2, 3, 6)]
	[InlineData(new int[] { 1, 2, 3, 4, 5, 6 }, 3, 2, 3, 2, 6)]
	[InlineData(new int[] { 1, 2, 3, 4, 5, 6, 7, 8 }, 3, null, 3, 3, 9)]
	[InlineData(new int[] { 1, 2, 3, 4, 5, 6, 7, 8 }, 5, null, 5, 2, 10)]
	public void To2dGrid_FromIEnumerableT_Should_Have_Shape(
		int[] input,
		int cols,
		int? rows,
		int expectedCols,
		int expectedRows,
		int expectedLength) {
		Grid<int> grid = input.To2dGrid(cols, rows);

		grid.ColsCount.ShouldBe(expectedCols);
		grid.RowsCount.ShouldBe(expectedRows);
		grid.InternalCells.Length.ShouldBe(expectedLength);
		grid.InternalCells.ColsCount().ShouldBe(expectedCols);
		grid.InternalCells.RowsCount().ShouldBe(expectedRows);
	}

	[Fact]
	public void To2dGrid_FromIEnumerableT_Should_Contain_Values() {
		int[] input = [1, 2, 3, 4, 5, 6];
		Grid<int> grid = input.To2dGrid(2, 3);

		grid[0, 0].ShouldBe(1);
		grid[1, 0].ShouldBe(2);
		grid[0, 1].ShouldBe(3);
		grid[1, 1].ShouldBe(4);
		grid[0, 2].ShouldBe(5);
		grid[1, 2].ShouldBe(6);
	}

	[Fact]
	public void To2dGrid_FromIEnumerableT_Should_Support_Indexing() {
		int[] input = [1, 2, 3, 4, 5, 6, 7, 8, 9];
		Grid<int> grid = input.To2dGrid(3, 3);

		grid[(1, 1)].ShouldBe(5);
		grid[new Point(2, 2)].ShouldBe(9);

		grid[(1, 1)] = 50;
		grid[1, 1].ShouldBe(50);
	}

	[Fact]
	public void To2dGrid_FromIEnumerableOfIEnumerableT_Should_Have_Shape() {
		Grid<int> grid = TestData.GetIEnumerableTestData().To2dGrid();

		grid.ColsCount.ShouldBe(10);
		grid.RowsCount.ShouldBe(5);
		grid.InternalCells.Length.ShouldBe(50);
	}

	[Fact]
	public void To2dGrid_FromIEnumerableOfIEnumerableT_Should_Contain_Values() {
		Grid<int> grid = TestData.GetIEnumerableTestData().To2dGrid();

		grid[0, 0].ShouldBe(1);
		grid[3, 3].ShouldBe(34);
		grid[3, 1].ShouldBe(14);
		grid[4, 2].ShouldBe(25);
		grid[6, 3].ShouldBe(37);
		grid[9, 4].ShouldBe(50);
	}

	[Fact]
	public void To2dGrid_FromStrings_Should_Have_Shape() {
		string[] input = ["1234567890", "abcdefghij", "0987654321", "zyxwvutsrq"];
		Grid<char> grid = input.To2dGrid();

		grid.ColsCount.ShouldBe(10);
		grid.RowsCount.ShouldBe(4);
		grid.InternalCells.Length.ShouldBe(40);
	}

	[Fact]
	public void To2dGrid_FromStrings_Should_Contain_Values() {
		string[] input = ["1234567890", "abcdefghij", "0987654321", "zyxwvutsrq"];
		Grid<char> grid = input.To2dGrid();

		grid[0, 0].ShouldBe('1');
		grid[5, 3].ShouldBe('u');
		grid[3, 1].ShouldBe('d');
		grid[4, 2].ShouldBe('6');
		grid[6, 3].ShouldBe('t');
		grid[9, 0].ShouldBe('0');
		grid[0, 3].ShouldBe('z');
	}

	[Fact]
	public void To2dGrid_FromPoints_Should_Have_Shape() {
		Point[] input = [new(1, 3), new(2, 4), new(3, 6)];
		Grid<char> grid = input.To2dGrid(initial: ' ', value: '#');

		grid.ColsCount.ShouldBe(4);
		grid.RowsCount.ShouldBe(7);
		grid.InternalCells.Length.ShouldBe(28);
	}

	[Fact]
	public void To2dGrid_FromPoints_Should_Contain_Values() {
		Point[] input = [new(1, 3), new(2, 4), new(3, 6)];
		Grid<char> grid = input.To2dGrid(initial: ' ', value: '#');

		grid[0, 0].ShouldBe(' ');
		grid[3, 5].ShouldBe(' ');
		grid[1, 3].ShouldBe('#');
		grid[2, 4].ShouldBe('#');
		grid[3, 6].ShouldBe('#');
	}

	[Fact]
	public void To2dGrid_FromPoints_WithNegatives_Should_Normalize() {
		Point[] input = [new(1, -3), new(2, 4), new(3, 6)];
		Grid<char> grid = input.To2dGrid(initial: ' ', value: '#');

		grid.ColsCount.ShouldBe(4);
		grid.RowsCount.ShouldBe(10);
		grid.InternalCells.Length.ShouldBe(40);

		grid[0, 0].ShouldBe(' ');
		grid[3, 3].ShouldBe(' ');
		grid[1, 0].ShouldBe('#');
		grid[2, 7].ShouldBe('#');
		grid[3, 9].ShouldBe('#');
	}

	[Fact]
	public void To2dGrid_FromPoints_WithDifferentTypes() {
		Point[] input = [new(0, 0), new(2, 2), new(1, 1)];
		Grid<int> grid = input.To2dGrid(initial: 0, value: 42);

		grid.ColsCount.ShouldBe(3);
		grid.RowsCount.ShouldBe(3);

		grid[0, 0].ShouldBe(42);
		grid[1, 1].ShouldBe(42);
		grid[2, 2].ShouldBe(42);
		grid[0, 1].ShouldBe(0);
		grid[1, 0].ShouldBe(0);
	}

	[Fact]
	public void To2dGrid_Should_Support_Grid_Extension_Methods() {
		int[] input = [1, 2, 3, 4, 5, 6, 7, 8, 9];
		Grid<int> grid = input.To2dGrid(3, 3);

		grid.IsInBounds(0, 0).ShouldBeTrue();
		grid.IsInBounds(2, 2).ShouldBeTrue();
		grid.IsInBounds(3, 3).ShouldBeFalse();
		grid.IsOutOfBounds(-1, 0).ShouldBeTrue();

		grid.ColsMin.ShouldBe(0);
		grid.ColsMax.ShouldBe(2);
		grid.RowsMin.ShouldBe(0);
		grid.RowsMax.ShouldBe(2);
	}

	[Fact]
	public void To2dGrid_Should_Support_ToArray_Conversion() {
		int[] input = [1, 2, 3, 4, 5, 6];
		Grid<int> grid = input.To2dGrid(2, 3);

		int[,] array = grid.ToArray();

		array.Length.ShouldBe(6);
		array.ColsCount().ShouldBe(2);
		array.RowsCount().ShouldBe(3);
		array[0, 0].ShouldBe(1);
		array[1, 2].ShouldBe(6);
	}

	[Fact]
	public void To2dGrid_WithTuples_Should_Have_Shape() {
		(char, int)[] input = [('A', 1), ('B', 2), ('C', 3), ('D', 4), ('E', 5), ('F', 6)];
		Grid<(char, int)> grid = input.To2dGrid(2, 3);

		grid.ColsCount.ShouldBe(2);
		grid.RowsCount.ShouldBe(3);
		grid[0, 0].ShouldBe(('A', 1));
		grid[1, 2].ShouldBe(('F', 6));
	}

	[Fact]
	public void To2dGrid_Should_Support_Row_And_Col_Access() {
		int[] input = [1, 2, 3, 4, 5, 6, 7, 8, 9];
		Grid<int> grid = input.To2dGrid(3, 3);

		List<int> row1 = [.. grid.Row(1)];
		row1.ShouldBe([4, 5, 6]);

		List<int> col2 = [.. grid.Col(2)];
		col2.ShouldBe([3, 6, 9]);
	}

	public static class TestData {
		public static IEnumerable<IEnumerable<int>> GetIEnumerableTestData() {
			for (int r = 0; r < 50; r += 10) {
				yield return [r + 1, r + 2, r + 3, r + 4, r + 5, r + 6, r + 7, r + 8, r + 9, r + 10];
			}
		}
	}
}

