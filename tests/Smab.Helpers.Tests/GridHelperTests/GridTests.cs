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
		grid[0, 0] = 1;
		grid[0, 1] = 2;
		grid[0, 2] = 3;
		grid[1, 0] = 4;
		grid[1, 1] = 5;
		grid[1, 2] = 6;
		grid[2, 0] = 7;
		grid[2, 1] = 8;
		grid[2, 2] = 9;

		List<int> column = [.. grid.Col(1)];

		column.ShouldBe([4, 5, 6]);
	}

	[Fact]
	public void Cols_ShouldReturnAllColumns() {
		Grid<int> grid = new(2, 2);
		grid[0, 0] = 1;
		grid[0, 1] = 2;
		grid[1, 0] = 3;
		grid[1, 1] = 4;

		List<List<int>> columns = [.. grid.Cols().Select(c => c.ToList())];

		columns.Count.ShouldBe(2);
		columns[0].ShouldBe([1, 2]);
		columns[1].ShouldBe([3, 4]);
	}

	[Fact]
	public void Row_ShouldReturnSpecifiedRow() {
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

		List<int> row = [.. grid.Row(1)];

		row.ShouldBe([4, 5, 6]);
	}

	[Fact]
	public void GetRows_ShouldReturnAllRows() {
		Grid<int> grid = new(2, 2);
		grid[0, 0] = 1;
		grid[1, 0] = 2;
		grid[0, 1] = 3;
		grid[1, 1] = 4;

		List<List<int>> rows = [.. grid.GetRows().Select(r => r.ToList())];

		rows.Count.ShouldBe(2);
		rows[0].ShouldBe([1, 2]);
		rows[1].ShouldBe([3, 4]);
	}

	[Fact]
	public void ForEachCell_ShouldReturnAllCellsWithCoordinates() {
		Grid<int> grid = new(2, 2);
		grid[0, 0] = 1;
		grid[1, 0] = 2;
		grid[0, 1] = 3;
		grid[1, 1] = 4;

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
		original[0, 0] = 1;
		original[1, 0] = 2;
		original[0, 1] = 3;
		original[1, 1] = 4;

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
		original[0, 0] = 1;
		original[1, 0] = 2;
		original[0, 1] = 3;
		original[1, 1] = 4;
		original[0, 2] = 5;
		original[1, 2] = 6;

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
		original[0, 0] = 1;
		original[1, 0] = 2;
		original[0, 1] = 3;
		original[1, 1] = 4;

		Grid<int> rotated = original.Rotate(0);

		rotated[0, 0].ShouldBe(1);
		rotated[1, 0].ShouldBe(2);
		rotated[0, 1].ShouldBe(3);
		rotated[1, 1].ShouldBe(4);
	}

	[Fact]
	public void Rotate_90Degrees_ShouldRotateClockwise() {
		Grid<int> original = new(2, 2);
		original[0, 0] = 1;
		original[1, 0] = 2;
		original[0, 1] = 3;
		original[1, 1] = 4;

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
		original[0, 0] = 1;
		original[1, 0] = 2;
		original[0, 1] = 3;
		original[1, 1] = 4;

		Grid<int> rotated = original.Rotate(180);

		rotated[0, 0].ShouldBe(4);
		rotated[1, 0].ShouldBe(3);
		rotated[0, 1].ShouldBe(2);
		rotated[1, 1].ShouldBe(1);
	}

	[Fact]
	public void Rotate_270Degrees_ShouldRotateCounterClockwise() {
		Grid<int> original = new(2, 2);
		original[0, 0] = 1;
		original[1, 0] = 2;
		original[0, 1] = 3;
		original[1, 1] = 4;

		Grid<int> rotated = original.Rotate(270);

		rotated[0, 0].ShouldBe(2);
		rotated[1, 0].ShouldBe(4);
		rotated[0, 1].ShouldBe(1);
		rotated[1, 1].ShouldBe(3);
	}

	[Fact]
	public void FlipHorizontally_ShouldReverseColumns() {
		Grid<int> original = new(3, 2);
		original[0, 0] = 1;
		original[1, 0] = 2;
		original[2, 0] = 3;
		original[0, 1] = 4;
		original[1, 1] = 5;
		original[2, 1] = 6;

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
		original[0, 0] = 1;
		original[1, 0] = 2;
		original[0, 1] = 3;
		original[1, 1] = 4;
		original[0, 2] = 5;
		original[1, 2] = 6;

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
		grid[0, 0] = 1;
		grid[1, 0] = 2;
		grid[0, 1] = 3;
		grid[1, 1] = 4;

		int[,] array = grid.ToArray();

		array[0, 0].ShouldBe(1);
		array[1, 1].ShouldBe(4);
		array[1, 0] = 99;
		grid[1, 0].ShouldBe(99); // Should affect grid since it's the same underlying array
	}

	[Fact]
	public void RangeIndexer_ShouldExtractSubGrid() {
		Grid<int> original = new(4, 4);
		for (int i = 0; i < 4; i++) {
			for (int j = 0; j < 4; j++) {
				original[i, j] = i * 10 + j;
			}
		}

		Grid<int> subGrid = original[1..3, 1..3];

		subGrid.ColsCount.ShouldBe(2);
		subGrid.RowsCount.ShouldBe(2);
		subGrid[0, 0].ShouldBe(11);
		subGrid[1, 0].ShouldBe(21);
		subGrid[0, 1].ShouldBe(12);
		subGrid[1, 1].ShouldBe(22);
	}

	[Fact]
	public void RangeIndexer_WithOpenEndRange_ShouldExtractToEnd() {
		Grid<int> original = new(4, 3);
		for (int i = 0; i < 4; i++) {
			for (int j = 0; j < 3; j++) {
				original[i, j] = i * 10 + j;
			}
		}

		Grid<int> subGrid = original[2.., 1..];

		subGrid.ColsCount.ShouldBe(2);
		subGrid.RowsCount.ShouldBe(2);
		subGrid[0, 0].ShouldBe(21);
		subGrid[1, 0].ShouldBe(31);
		subGrid[0, 1].ShouldBe(22);
		subGrid[1, 1].ShouldBe(32);
	}

	[Fact]
	public void RangeIndexer_WithOpenStartRange_ShouldExtractFromStart() {
		Grid<int> original = new(4, 3);
		for (int i = 0; i < 4; i++) {
			for (int j = 0; j < 3; j++) {
				original[i, j] = i * 10 + j;
			}
		}

		Grid<int> subGrid = original[..2, ..2];

		subGrid.ColsCount.ShouldBe(2);
		subGrid.RowsCount.ShouldBe(2);
		subGrid[0, 0].ShouldBe(0);
		subGrid[1, 0].ShouldBe(10);
		subGrid[0, 1].ShouldBe(1);
		subGrid[1, 1].ShouldBe(11);
	}

	[Fact]
	public void RangeIndexer_WithFullRange_ShouldCopyEntireGrid() {
		Grid<int> original = new(2, 2);
		original[0, 0] = 1;
		original[1, 0] = 2;
		original[0, 1] = 3;
		original[1, 1] = 4;

		Grid<int> subGrid = original[.., ..];

		subGrid.ColsCount.ShouldBe(2);
		subGrid.RowsCount.ShouldBe(2);
		subGrid[0, 0].ShouldBe(1);
		subGrid[1, 0].ShouldBe(2);
		subGrid[0, 1].ShouldBe(3);
		subGrid[1, 1].ShouldBe(4);
		subGrid[0, 0] = 99;
		original[0, 0].ShouldBe(1); // Original should not be affected
	}

	[Fact]
	public void RangeIndexer_WithHatOperator_ShouldExtractFromEnd() {
		Grid<int> original = new(4, 4);
		for (int i = 0; i < 4; i++) {
			for (int j = 0; j < 4; j++) {
				original[i, j] = i * 10 + j;
			}
		}

		Grid<int> subGrid = original[^2.., ^2..];

		subGrid.ColsCount.ShouldBe(2);
		subGrid.RowsCount.ShouldBe(2);
		subGrid[0, 0].ShouldBe(22);
		subGrid[1, 0].ShouldBe(32);
		subGrid[0, 1].ShouldBe(23);
		subGrid[1, 1].ShouldBe(33);
	}

	[Fact]
	public void RangeIndexer_WithMixedRanges_ShouldExtractCorrectRegion() {
		Grid<int> original = new(5, 5);
		for (int i = 0; i < 5; i++) {
			for (int j = 0; j < 5; j++) {
				original[i, j] = i * 10 + j;
			}
		}

		Grid<int> subGrid = original[1..^1, ..3];

		subGrid.ColsCount.ShouldBe(3);
		subGrid.RowsCount.ShouldBe(3);
		subGrid[0, 0].ShouldBe(10);
		subGrid[1, 0].ShouldBe(20);
		subGrid[2, 0].ShouldBe(30);
		subGrid[0, 2].ShouldBe(12);
		subGrid[2, 2].ShouldBe(32);
	}

	[Fact]
	public void RangeIndexer_WithSingleElementRange_ShouldExtractOneByOneGrid() {
		Grid<int> original = new(3, 3);
		for (int i = 0; i < 3; i++) {
			for (int j = 0; j < 3; j++) {
				original[i, j] = i * 10 + j;
			}
		}

		Grid<int> subGrid = original[1..2, 1..2];

		subGrid.ColsCount.ShouldBe(1);
		subGrid.RowsCount.ShouldBe(1);
		subGrid[0, 0].ShouldBe(11);
	}

	[Fact]
	public void IndexRangeIndexer_ShouldReturnColumnSlice() {
		Grid<int> original = new(4, 4);
		for (int i = 0; i < 4; i++) {
			for (int j = 0; j < 4; j++) {
				original[i, j] = i * 10 + j;
			}
		}

		List<int> slice = [.. original[1, 1..3]];

		slice.Count.ShouldBe(2);
		slice[0].ShouldBe(11);
		slice[1].ShouldBe(12);
	}

	[Fact]
	public void IndexRangeIndexer_WithOpenRange_ShouldReturnEntireColumn() {
		Grid<int> original = new(3, 4);
		for (int i = 0; i < 3; i++) {
			for (int j = 0; j < 4; j++) {
				original[i, j] = i * 10 + j;
			}
		}

		List<int> slice = [.. original[2, ..]];

		slice.Count.ShouldBe(4);
		slice.ShouldBe([20, 21, 22, 23]);
	}

	[Fact]
	public void IndexRangeIndexer_WithHatOperator_ShouldReturnColumnSliceFromEnd() {
		Grid<int> original = new(3, 4);
		for (int i = 0; i < 3; i++) {
			for (int j = 0; j < 4; j++) {
				original[i, j] = i * 10 + j;
			}
		}

		List<int> slice = [.. original[1, ^2..]];

		slice.Count.ShouldBe(2);
		slice.ShouldBe([12, 13]);
	}

	[Fact]
	public void IndexRangeIndexer_WithIndexFromEnd_ShouldWorkCorrectly() {
		Grid<int> original = new(4, 5);
		for (int i = 0; i < 4; i++) {
			for (int j = 0; j < 5; j++) {
				original[i, j] = i * 10 + j;
			}
		}

		List<int> slice = [.. original[^1, 1..4]];

		slice.Count.ShouldBe(3);
		slice.ShouldBe([31, 32, 33]);
	}

	[Fact]
	public void RangeIndexIndexer_ShouldReturnRowSlice() {
		Grid<int> original = new(4, 4);
		for (int i = 0; i < 4; i++) {
			for (int j = 0; j < 4; j++) {
				original[i, j] = i * 10 + j;
			}
		}

		List<int> slice = [.. original[1..3, 1]];

		slice.Count.ShouldBe(2);
		slice[0].ShouldBe(11);
		slice[1].ShouldBe(21);
	}

	[Fact]
	public void RangeIndexIndexer_WithOpenRange_ShouldReturnEntireRow() {
		Grid<int> original = new(4, 3);
		for (int i = 0; i < 4; i++) {
			for (int j = 0; j < 3; j++) {
				original[i, j] = i * 10 + j;
			}
		}

		List<int> slice = [.. original[.., 2]];

		slice.Count.ShouldBe(4);
		slice.ShouldBe([2, 12, 22, 32]);
	}

	[Fact]
	public void RangeIndexIndexer_WithHatOperator_ShouldReturnRowSliceFromEnd() {
		Grid<int> original = new(5, 3);
		for (int i = 0; i < 5; i++) {
			for (int j = 0; j < 3; j++) {
				original[i, j] = i * 10 + j;
			}
		}

		List<int> slice = [.. original[^3.., 1]];

		slice.Count.ShouldBe(3);
		slice.ShouldBe([21, 31, 41]);
	}

	[Fact]
	public void RangeIndexIndexer_WithIndexFromEnd_ShouldWorkCorrectly() {
		Grid<int> original = new(5, 4);
		for (int i = 0; i < 5; i++) {
			for (int j = 0; j < 4; j++) {
				original[i, j] = i * 10 + j;
			}
		}

		List<int> slice = [.. original[1..4, ^2]];

		slice.Count.ShouldBe(3);
		slice.ShouldBe([12, 22, 32]);
	}

	[Fact]
	public void IndexIndexIndexer_ShouldGetValue() {
		Grid<int> grid = new(4, 4);
		for (int i = 0; i < 4; i++) {
			for (int j = 0; j < 4; j++) {
				grid[i, j] = i * 10 + j;
			}
		}

		grid[^1, ^1].ShouldBe(33);
		grid[^2, ^3].ShouldBe(21);
		grid[^4, ^4].ShouldBe(0);
	}

	[Fact]
	public void IndexIndexIndexer_ShouldSetValue() {
		Grid<int> grid = new(4, 4);

		grid[^1, ^1] = 99;
		grid[^2, ^3] = 88;
		grid[^4, ^4] = 77;

		grid[3, 3].ShouldBe(99);
		grid[2, 1].ShouldBe(88);
		grid[0, 0].ShouldBe(77);
	}

	[Fact]
	public void IntIndexIndexer_ShouldGetValue() {
		Grid<int> grid = new(4, 4);
		for (int i = 0; i < 4; i++) {
			for (int j = 0; j < 4; j++) {
				grid[i, j] = i * 10 + j;
			}
		}

		grid[1, ^1].ShouldBe(13);
		grid[2, ^2].ShouldBe(22);
		grid[0, ^3].ShouldBe(1);
	}

	[Fact]
	public void IntIndexIndexer_ShouldSetValue() {
		Grid<int> grid = new(4, 4);

		grid[1, ^1] = 99;
		grid[2, ^2] = 88;
		grid[0, ^4] = 77;

		grid[1, 3].ShouldBe(99);
		grid[2, 2].ShouldBe(88);
		grid[0, 0].ShouldBe(77);
	}

	[Fact]
	public void IndexIntIndexer_ShouldGetValue() {
		Grid<int> grid = new(4, 4);
		for (int i = 0; i < 4; i++) {
			for (int j = 0; j < 4; j++) {
				grid[i, j] = i * 10 + j;
			}
		}

		grid[^1, 2].ShouldBe(32);
		grid[^2, 1].ShouldBe(21);
		grid[^3, 0].ShouldBe(10);
	}

	[Fact]
	public void IndexIntIndexer_ShouldSetValue() {
		Grid<int> grid = new(4, 4);

		grid[^1, 2] = 99;
		grid[^2, 1] = 88;
		grid[^4, 0] = 77;

		grid[3, 2].ShouldBe(99);
		grid[2, 1].ShouldBe(88);
		grid[0, 0].ShouldBe(77);
	}

	[Fact]
	public void IndexIndexers_WithMixedAccess_ShouldWorkCorrectly() {
		Grid<int> grid = new(5, 5);
		for (int i = 0; i < 5; i++) {
			for (int j = 0; j < 5; j++) {
				grid[i, j] = i * 10 + j;
			}
		}

		grid[^1, ^1].ShouldBe(44);
		grid[2, ^1].ShouldBe(24);
		grid[^1, 2].ShouldBe(42);
		grid[1, 1].ShouldBe(11);
	}

	[Fact]
	public void RangeRangeIndexer_SetWithMatchingGrid_ShouldCopyValues() {
		Grid<int> original = new(5, 5);
		for (int i = 0; i < 5; i++) {
			for (int j = 0; j < 5; j++) {
				original[i, j] = 0;
			}
		}

		Grid<int> source = new(2, 2);
		source[0, 0] = 11;
		source[1, 0] = 21;
		source[0, 1] = 12;
		source[1, 1] = 22;

		original[1..3, 1..3] = source;

		original[1, 1].ShouldBe(11);
		original[2, 1].ShouldBe(21);
		original[1, 2].ShouldBe(12);
		original[2, 2].ShouldBe(22);
		original[0, 0].ShouldBe(0);
		original[3, 3].ShouldBe(0);
	}

	[Fact]
	public void RangeRangeIndexer_SetWithSingleValueGrid_ShouldFillRange() {
		Grid<int> grid = new(5, 5);
		for (int i = 0; i < 5; i++) {
			for (int j = 0; j < 5; j++) {
				grid[i, j] = 0;
			}
		}

		Grid<int> fillValue = new(1, 1);
		fillValue[0, 0] = 99;

		grid[1..4, 1..3] = fillValue;

		grid[1, 1].ShouldBe(99);
		grid[2, 1].ShouldBe(99);
		grid[3, 1].ShouldBe(99);
		grid[1, 2].ShouldBe(99);
		grid[3, 2].ShouldBe(99);
		grid[0, 0].ShouldBe(0);
		grid[4, 4].ShouldBe(0);
	}

	[Fact]
	public void RangeRangeIndexer_SetWithMismatchedGrid_ShouldThrow() {
		Grid<int> grid = new(5, 5);
		Grid<int> wrongSize = new(3, 3);

		Should.Throw<ArgumentException>(() => grid[1..3, 1..3] = wrongSize);
	}

	[Fact]
	public void IndexRangeIndexer_SetWithMatchingCollection_ShouldSetValues() {
		Grid<int> grid = new(3, 4);
		for (int i = 0; i < 3; i++) {
			for (int j = 0; j < 4; j++) {
				grid[i, j] = 0;
			}
		}

		grid[1, 1..3] = new[] { 10, 20 };

		grid[1, 1].ShouldBe(10);
		grid[1, 2].ShouldBe(20);
		grid[1, 0].ShouldBe(0);
		grid[1, 3].ShouldBe(0);
	}

	[Fact]
	public void IndexRangeIndexer_SetWithSingleValue_ShouldFillRange() {
		Grid<int> grid = new(3, 4);
		for (int i = 0; i < 3; i++) {
			for (int j = 0; j < 4; j++) {
				grid[i, j] = 0;
			}
		}

		grid[1, 1..4] = new[] { 99 };

		grid[1, 1].ShouldBe(99);
		grid[1, 2].ShouldBe(99);
		grid[1, 3].ShouldBe(99);
		grid[1, 0].ShouldBe(0);
	}

	[Fact]
	public void IndexRangeIndexer_SetWithIndexFromEnd_ShouldWork() {
		Grid<int> grid = new(3, 4);
		for (int i = 0; i < 3; i++) {
			for (int j = 0; j < 4; j++) {
				grid[i, j] = 0;
			}
		}

		grid[^1, ^2..] = new[] { 88, 99 };

		grid[2, 2].ShouldBe(88);
		grid[2, 3].ShouldBe(99);
		grid[2, 0].ShouldBe(0);
	}

	[Fact]
	public void IndexRangeIndexer_SetWithMismatchedCollection_ShouldThrow() {
		Grid<int> grid = new(3, 4);

		Should.Throw<ArgumentException>(() => grid[1, 1..3] = new[] { 1, 2, 3 });
	}

	[Fact]
	public void RangeIndexIndexer_SetWithMatchingCollection_ShouldSetValues() {
		Grid<int> grid = new(4, 3);
		for (int i = 0; i < 4; i++) {
			for (int j = 0; j < 3; j++) {
				grid[i, j] = 0;
			}
		}

		grid[1..3, 1] = new[] { 10, 20 };

		grid[1, 1].ShouldBe(10);
		grid[2, 1].ShouldBe(20);
		grid[0, 1].ShouldBe(0);
		grid[3, 1].ShouldBe(0);
	}

	[Fact]
	public void RangeIndexIndexer_SetWithSingleValue_ShouldFillRange() {
		Grid<int> grid = new(4, 3);
		for (int i = 0; i < 4; i++) {
			for (int j = 0; j < 3; j++) {
				grid[i, j] = 0;
			}
		}

		grid[1..4, 1] = new[] { 77 };

		grid[1, 1].ShouldBe(77);
		grid[2, 1].ShouldBe(77);
		grid[3, 1].ShouldBe(77);
		grid[0, 1].ShouldBe(0);
	}

	[Fact]
	public void RangeIndexIndexer_SetWithIndexFromEnd_ShouldWork() {
		Grid<int> grid = new(5, 3);
		for (int i = 0; i < 5; i++) {
			for (int j = 0; j < 3; j++) {
				grid[i, j] = 0;
			}
		}

		grid[^3.., ^1] = new[] { 11, 22, 33 };

		grid[2, 2].ShouldBe(11);
		grid[3, 2].ShouldBe(22);
		grid[4, 2].ShouldBe(33);
		grid[1, 2].ShouldBe(0);
	}

	[Fact]
	public void RangeIndexIndexer_SetWithMismatchedCollection_ShouldThrow() {
		Grid<int> grid = new(4, 3);

		Should.Throw<ArgumentException>(() => grid[1..3, 1] = new[] { 1, 2, 3 });
	}

	[Fact]
	public void RangeIndexers_SetWithList_ShouldWork() {
		Grid<int> grid = new(4, 4);
		for (int i = 0; i < 4; i++) {
			for (int j = 0; j < 4; j++) {
				grid[i, j] = 0;
			}
		}

		grid[1, 1..3] = new List<int> { 10, 20 };
		grid[1..3, 2] = new List<int> { 30, 40 };

		grid[1, 1].ShouldBe(10);
		grid[1, 2].ShouldBe(30);  // Overwritten by second assignment
		grid[2, 2].ShouldBe(40);
	}
}
