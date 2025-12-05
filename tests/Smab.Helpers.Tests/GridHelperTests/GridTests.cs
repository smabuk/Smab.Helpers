namespace Smab.Helpers.Tests.GridHelperTests;

public class GridTests {
	[Fact]
	public void Constructor_ShouldCreateGridWithSpecifiedDimensions() {
		Grid<int> grid = new(3, 4);

		grid.ColsCount.ShouldBe(3);
		grid.RowsCount.ShouldBe(4);
	}

	[Fact]
	public void Indexer_ShouldGetAndSetValues() {
		Grid<int> grid = new(3, 3);

		grid[1, 2] = 42;

		grid[1, 2].ShouldBe(42);
	}

	[Fact]
	public void DimensionProperties_ShouldReturnCorrectValues() {
		Grid<int> grid = new(5, 7);

		grid.ColsCount.ShouldBe(5);
		grid.RowsCount.ShouldBe(7);
		grid.ColsMin.ShouldBe(0);
		grid.RowsMin.ShouldBe(0);
		grid.ColsMax.ShouldBe(4);
		grid.RowsMax.ShouldBe(6);
		grid.XMin.ShouldBe(0);
		grid.YMin.ShouldBe(0);
		grid.XMax.ShouldBe(4);
		grid.YMax.ShouldBe(6);
	}

	[Fact]
	public void GetValue_WithCoordinates_ShouldReturnCorrectValue() {
		Grid<string> grid = new(3, 3);
		grid[1, 2] = "test";

		string result = grid.GetValue(1, 2);

		result.ShouldBe("test");
	}

	[Fact]
	public void GetValue_WithTuple_ShouldReturnCorrectValue() {
		Grid<string> grid = new(3, 3);
		grid[1, 2] = "test";

		string result = grid.GetValue((1, 2));

		result.ShouldBe("test");
	}

	[Fact]
	public void GetValue_WithPoint_ShouldReturnCorrectValue() {
		Grid<string> grid = new(3, 3);
		grid[1, 2] = "test";

		string result = grid.GetValue(new Point(1, 2));

		result.ShouldBe("test");
	}

	[Fact]
	public void TryGetValue_WithValidCoordinates_ShouldReturnTrueAndValue() {
		Grid<int> grid = new(3, 3);
		grid[1, 2] = 42;

		bool success = grid.TryGetValue(1, 2, out int value);

		success.ShouldBeTrue();
		value.ShouldBe(42);
	}

	[Fact]
	public void TryGetValue_WithInvalidCoordinates_ShouldReturnFalse() {
		Grid<int> grid = new(3, 3);

		bool success = grid.TryGetValue(5, 5, out int value);

		success.ShouldBeFalse();
		value.ShouldBe(default);
	}

	[Fact]
	public void SetValue_WithCoordinates_ShouldSetValue() {
		Grid<int> grid = new(3, 3);

		grid.SetValue(42, 1, 2);

		grid[1, 2].ShouldBe(42);
	}

	[Fact]
	public void SetValue_WithTuple_ShouldSetValue() {
		Grid<int> grid = new(3, 3);

		grid.SetValue(42, (1, 2));

		grid[1, 2].ShouldBe(42);
	}

	[Fact]
	public void SetValue_WithPoint_ShouldSetValue() {
		Grid<int> grid = new(3, 3);

		grid.SetValue(42, new Point(1, 2));

		grid[1, 2].ShouldBe(42);
	}

	[Fact]
	public void TrySetValue_WithValidCoordinates_ShouldReturnTrueAndSetValue() {
		Grid<int> grid = new(3, 3);

		bool success = grid.TrySetValue(1, 2, 42);

		success.ShouldBeTrue();
		grid[1, 2].ShouldBe(42);
	}

	[Fact]
	public void TrySetValue_WithInvalidCoordinates_ShouldReturnFalse() {
		Grid<int> grid = new(3, 3);

		bool success = grid.TrySetValue(5, 5, 42);

		success.ShouldBeFalse();
	}

	[Fact]
	public void IsInBounds_WithValidCoordinates_ShouldReturnTrue() {
		Grid<int> grid = new(3, 3);

		grid.IsInBounds(1, 2).ShouldBeTrue();
		grid.IsInBounds(0, 0).ShouldBeTrue();
		grid.IsInBounds(2, 2).ShouldBeTrue();
	}

	[Fact]
	public void IsInBounds_WithInvalidCoordinates_ShouldReturnFalse() {
		Grid<int> grid = new(3, 3);

		grid.IsInBounds(-1, 0).ShouldBeFalse();
		grid.IsInBounds(0, -1).ShouldBeFalse();
		grid.IsInBounds(3, 0).ShouldBeFalse();
		grid.IsInBounds(0, 3).ShouldBeFalse();
	}

	[Fact]
	public void IsOutOfBounds_ShouldReturnOppositeOfIsInBounds() {
		Grid<int> grid = new(3, 3);

		grid.IsOutOfBounds(1, 2).ShouldBeFalse();
		grid.IsOutOfBounds(5, 5).ShouldBeTrue();
	}

	[Fact]
	public void ColIndexes_ShouldReturnAllColumnIndexes() {
		Grid<int> grid = new(3, 2);

		List<int> indexes = [.. grid.ColIndexes()];

		indexes.ShouldBe([0, 1, 2]);
	}

	[Fact]
	public void RowIndexes_ShouldReturnAllRowIndexes() {
		Grid<int> grid = new(3, 2);

		List<int> indexes = [.. grid.RowIndexes()];

		indexes.ShouldBe([0, 1]);
	}

	[Fact]
	public void Indexes_ShouldReturnAllIndexPairs() {
		Grid<int> grid = new(2, 2);

		List<(int X, int Y)> indexes = [.. grid.Indexes()];

		indexes.Count.ShouldBe(4);
		indexes.ShouldContain((0, 0));
		indexes.ShouldContain((1, 0));
		indexes.ShouldContain((0, 1));
		indexes.ShouldContain((1, 1));
	}

	[Fact]
	public void IndexesColRow_ShouldReturnAllIndexPairs() {
		Grid<int> grid = new(2, 2);

		List<(int Col, int Row)> indexes = [.. grid.IndexesColRow()];

		indexes.Count.ShouldBe(4);
		indexes[0].ShouldBe((0, 0));
		indexes[1].ShouldBe((1, 0));
		indexes[2].ShouldBe((0, 1));
		indexes[3].ShouldBe((1, 1));
	}

	[Fact]
	public void Col_ShouldReturnSpecifiedColumn() {
		Grid<int> grid = new(3, 3);
		grid[0, 0] = 1; grid[0, 1] = 2; grid[0, 2] = 3;
		grid[1, 0] = 4; grid[1, 1] = 5; grid[1, 2] = 6;
		grid[2, 0] = 7; grid[2, 1] = 8; grid[2, 2] = 9;

		List<int> column = [.. grid.Col(1)];

		column.ShouldBe([4, 5, 6]);
	}

	[Fact]
	public void Cols_ShouldReturnAllColumns() {
		Grid<int> grid = new(2, 2);
		grid[0, 0] = 1; grid[0, 1] = 2;
		grid[1, 0] = 3; grid[1, 1] = 4;

		List<List<int>> columns = [.. grid.Cols().Select(c => c.ToList())];

		columns.Count.ShouldBe(2);
		columns[0].ShouldBe([1, 2]);
		columns[1].ShouldBe([3, 4]);
	}

	[Fact]
	public void Row_ShouldReturnSpecifiedRow() {
		Grid<int> grid = new(3, 3);
		grid[0, 0] = 1; grid[1, 0] = 2; grid[2, 0] = 3;
		grid[0, 1] = 4; grid[1, 1] = 5; grid[2, 1] = 6;
		grid[0, 2] = 7; grid[1, 2] = 8; grid[2, 2] = 9;

		List<int> row = [.. grid.Row(1)];

		row.ShouldBe([4, 5, 6]);
	}

	[Fact]
	public void GetRows_ShouldReturnAllRows() {
		Grid<int> grid = new(2, 2);
		grid[0, 0] = 1; grid[1, 0] = 2;
		grid[0, 1] = 3; grid[1, 1] = 4;

		List<List<int>> rows = [.. grid.GetRows().Select(r => r.ToList())];

		rows.Count.ShouldBe(2);
		rows[0].ShouldBe([1, 2]);
		rows[1].ShouldBe([3, 4]);
	}

	[Fact]
	public void ForEachCell_ShouldReturnAllCellsWithCoordinates() {
		Grid<int> grid = new(2, 2);
		grid[0, 0] = 1; grid[1, 0] = 2;
		grid[0, 1] = 3; grid[1, 1] = 4;

		List<Cell<int>> cells = [.. grid.ForEachCell()];

		cells.Count.ShouldBe(4);
		cells[0].ShouldBe(new Cell<int>(0, 0, 1));
		cells[1].ShouldBe(new Cell<int>(1, 0, 2));
		cells[2].ShouldBe(new Cell<int>(0, 1, 3));
		cells[3].ShouldBe(new Cell<int>(1, 1, 4));
	}

	[Fact]
	public void Copy_ShouldCreateShallowCopy() {
		Grid<int> original = new(2, 2);
		original[0, 0] = 1; original[1, 0] = 2;
		original[0, 1] = 3; original[1, 1] = 4;

		Grid<int> copy = original.Copy();

		copy[0, 0].ShouldBe(1);
		copy[1, 1].ShouldBe(4);
		copy[0, 0] = 99;
		original[0, 0].ShouldBe(1); // Original should not be affected
	}

	[Fact]
	public void Fill_ShouldCreateNewGridWithAllElementsSetToValue() {
		Grid<int> original = new(3, 3);
		original[1, 1] = 42;

		Grid<int> filled = original.Fill(0);

		filled.ForEachCell().All(c => c.Value == 0).ShouldBeTrue();
		original[1, 1].ShouldBe(42); // Original should not be affected
	}

	[Fact]
	public void FillInPlace_ShouldModifyGridInPlace() {
		Grid<int> grid = new(3, 3);
		grid[1, 1] = 42;

		grid.FillInPlace(0);

		grid.ForEachCell().All(c => c.Value == 0).ShouldBeTrue();
	}

	[Fact]
	public void Replace_ShouldCreateNewGridWithReplacedValues() {
		Grid<int> original = new(3, 3);
		original.FillInPlace(1);
		original[1, 1] = 2;

		Grid<int> replaced = original.Replace(1, 9);

		replaced[0, 0].ShouldBe(9);
		replaced[1, 1].ShouldBe(2);
		original[0, 0].ShouldBe(1); // Original should not be affected
	}

	[Fact]
	public void ReplaceInPlace_ShouldModifyGridInPlace() {
		Grid<int> grid = new(3, 3);
		grid.FillInPlace(1);
		grid[1, 1] = 2;

		grid.ReplaceInPlace(1, 9);

		grid[0, 0].ShouldBe(9);
		grid[1, 1].ShouldBe(2);
	}

	[Fact]
	public void Transpose_ShouldSwapRowsAndColumns() {
		Grid<int> original = new(2, 3);
		original[0, 0] = 1; original[1, 0] = 2;
		original[0, 1] = 3; original[1, 1] = 4;
		original[0, 2] = 5; original[1, 2] = 6;

		Grid<int> transposed = original.Transpose();

		transposed.ColsCount.ShouldBe(3);
		transposed.RowsCount.ShouldBe(2);
		transposed[0, 0].ShouldBe(1);
		transposed[0, 1].ShouldBe(2);
		transposed[1, 0].ShouldBe(3);
		transposed[1, 1].ShouldBe(4);
		transposed[2, 0].ShouldBe(5);
		transposed[2, 1].ShouldBe(6);
	}

	[Fact]
	public void Rotate_0Degrees_ShouldReturnIdenticalGrid() {
		Grid<int> original = new(2, 2);
		original[0, 0] = 1; original[1, 0] = 2;
		original[0, 1] = 3; original[1, 1] = 4;

		Grid<int> rotated = original.Rotate(0);

		rotated[0, 0].ShouldBe(1);
		rotated[1, 0].ShouldBe(2);
		rotated[0, 1].ShouldBe(3);
		rotated[1, 1].ShouldBe(4);
	}

	[Fact]
	public void Rotate_90Degrees_ShouldRotateClockwise() {
		Grid<int> original = new(2, 2);
		original[0, 0] = 1; original[1, 0] = 2;
		original[0, 1] = 3; original[1, 1] = 4;

		Grid<int> rotated = original.Rotate(90);

		rotated.ColsCount.ShouldBe(2);
		rotated.RowsCount.ShouldBe(2);
		rotated[0, 0].ShouldBe(3);
		rotated[1, 0].ShouldBe(1);
		rotated[0, 1].ShouldBe(4);
		rotated[1, 1].ShouldBe(2);
	}

	[Fact]
	public void Rotate_180Degrees_ShouldRotate180() {
		Grid<int> original = new(2, 2);
		original[0, 0] = 1; original[1, 0] = 2;
		original[0, 1] = 3; original[1, 1] = 4;

		Grid<int> rotated = original.Rotate(180);

		rotated[0, 0].ShouldBe(4);
		rotated[1, 0].ShouldBe(3);
		rotated[0, 1].ShouldBe(2);
		rotated[1, 1].ShouldBe(1);
	}

	[Fact]
	public void Rotate_270Degrees_ShouldRotateCounterClockwise() {
		Grid<int> original = new(2, 2);
		original[0, 0] = 1; original[1, 0] = 2;
		original[0, 1] = 3; original[1, 1] = 4;

		Grid<int> rotated = original.Rotate(270);

		rotated[0, 0].ShouldBe(2);
		rotated[1, 0].ShouldBe(4);
		rotated[0, 1].ShouldBe(1);
		rotated[1, 1].ShouldBe(3);
	}

	[Fact]
	public void FlipHorizontally_ShouldReverseColumns() {
		Grid<int> original = new(3, 2);
		original[0, 0] = 1; original[1, 0] = 2; original[2, 0] = 3;
		original[0, 1] = 4; original[1, 1] = 5; original[2, 1] = 6;

		Grid<int> flipped = original.FlipHorizontally();

		flipped[0, 0].ShouldBe(3);
		flipped[1, 0].ShouldBe(2);
		flipped[2, 0].ShouldBe(1);
		flipped[0, 1].ShouldBe(6);
		flipped[1, 1].ShouldBe(5);
		flipped[2, 1].ShouldBe(4);
	}

	[Fact]
	public void FlipVertically_ShouldReverseRows() {
		Grid<int> original = new(2, 3);
		original[0, 0] = 1; original[1, 0] = 2;
		original[0, 1] = 3; original[1, 1] = 4;
		original[0, 2] = 5; original[1, 2] = 6;

		Grid<int> flipped = original.FlipVertically();

		flipped[0, 0].ShouldBe(5);
		flipped[1, 0].ShouldBe(6);
		flipped[0, 1].ShouldBe(3);
		flipped[1, 1].ShouldBe(4);
		flipped[0, 2].ShouldBe(1);
		flipped[1, 2].ShouldBe(2);
	}

	[Fact]
	public void SubGrid_ShouldExtractSubGrid() {
		Grid<int> original = new(4, 4);
		for (int i = 0; i < 4; i++) {
			for (int j = 0; j < 4; j++) {
				original[i, j] = i * 10 + j;
			}
		}

		Grid<int> subGrid = original.SubGrid(1, 1, 2, 2);

		subGrid.ColsCount.ShouldBe(2);
		subGrid.RowsCount.ShouldBe(2);
		subGrid[0, 0].ShouldBe(11);
		subGrid[1, 0].ShouldBe(21);
		subGrid[0, 1].ShouldBe(12);
		subGrid[1, 1].ShouldBe(22);
	}

	[Fact]
	public void SubGrid_WithPoint_ShouldExtractSubGrid() {
		Grid<int> original = new(4, 4);
		for (int i = 0; i < 4; i++) {
			for (int j = 0; j < 4; j++) {
				original[i, j] = i * 10 + j;
			}
		}

		Grid<int> subGrid = original.SubGrid(new Point(1, 1), 2, 2);

		subGrid[0, 0].ShouldBe(11);
		subGrid[1, 1].ShouldBe(22);
	}

	[Fact]
	public void SubGrid_WithOutOfBounds_ShouldUseInitValue() {
		Grid<int> original = new(2, 2);
		original.FillInPlace(5);

		Grid<int> subGrid = original.SubGrid(1, 1, 3, 3, -1);

		subGrid[0, 0].ShouldBe(5);
		subGrid[1, 0].ShouldBe(-1);
		subGrid[0, 1].ShouldBe(-1);
		subGrid[2, 2].ShouldBe(-1);
	}

	[Fact]
	public void ToArray_ShouldReturnUnderlyingArray() {
		Grid<int> grid = new(2, 2);
		grid[0, 0] = 1; grid[1, 0] = 2;
		grid[0, 1] = 3; grid[1, 1] = 4;

		int[,] array = grid.ToArray();

		array[0, 0].ShouldBe(1);
		array[1, 1].ShouldBe(4);
		array[1, 0] = 99;
		grid[1, 0].ShouldBe(99); // Should affect grid since it's the same underlying array
	}
}
