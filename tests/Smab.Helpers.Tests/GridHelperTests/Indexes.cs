using System.Collections;

namespace Smab.Helpers.Tests.GridHelperTests;

public class Indexes {
	[Fact]
	public void Indexes_Should_Travel_Across_Then_Down() {
		(char, int)[] input = new (char, int)[26];
		for (int i = 0; i < input.GetUpperBound(0); i++) {
			input[i] = new((char)(65 + i), i + 1);
		}
		(char, int)[,] array = input.To2dArray(5);
		IEnumerator<(int Col, int Row)> actualEnumerator = array.Indexes().GetEnumerator();
		for (int row = 0; row < array.RowsCount(); row++) {
			for (int col = 0; col < array.ColsCount(); col++) {
				_ = actualEnumerator.MoveNext();
				(int Col, int Row) actual = actualEnumerator.Current;
				actual.ShouldBe((col, row));
			}
		}
		array.Indexes().Count().ShouldBe(30);
		array.Indexes().First().ShouldBe((0, 0));
		array.Indexes().Last().ShouldBe((4, 5));
	}

	[Fact]
	public void Grid_Indexes_Should_Travel_Across_Then_Down() {
		(char, int)[] input = new (char, int)[26];
		for (int i = 0; i < input.GetUpperBound(0); i++) {
			input[i] = new((char)(65 + i), i + 1);
		}
		Grid<(char, int)> grid = input.To2dGrid(5);
		
		IEnumerator<(int X, int Y)> actualEnumerator = grid.Indexes().GetEnumerator();
		for (int row = 0; row < grid.RowsCount; row++) {
			for (int col = 0; col < grid.ColsCount; col++) {
				_ = actualEnumerator.MoveNext();
				(int X, int Y) actual = actualEnumerator.Current;
				actual.ShouldBe((col, row));
			}
		}
		grid.Indexes().Count().ShouldBe(30);
		grid.Indexes().First().ShouldBe((0, 0));
		grid.Indexes().Last().ShouldBe((4, 5));
	}

	[Fact]
	public void Grid_IndexesColRow_Should_Travel_Across_Then_Down() {
		int[] input = [1, 2, 3, 4, 5, 6];
		Grid<int> grid = input.To2dGrid(3, 2);
		
		List<(int Col, int Row)> indexes = [.. grid.IndexesColRow()];
		indexes.Count.ShouldBe(6);
		indexes[0].ShouldBe((0, 0));
		indexes[1].ShouldBe((1, 0));
		indexes[2].ShouldBe((2, 0));
		indexes[3].ShouldBe((0, 1));
		indexes[4].ShouldBe((1, 1));
		indexes[5].ShouldBe((2, 1));
	}
}
