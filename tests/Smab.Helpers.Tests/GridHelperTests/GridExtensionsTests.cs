namespace Smab.Helpers.Tests.GridHelperTests;

public class GridExtensionsTests {
	// ========================================
	// Feature 1: Enumerable Tests
	// ========================================

	[Fact]
	public void GetEnumerator_ShouldIterateThroughAllElements() {
		Grid<int> grid = new(3, 2);
		grid[0, 0] = 1;
		grid[1, 0] = 2;
		grid[2, 0] = 3;
		grid[0, 1] = 4;
		grid[1, 1] = 5;
		grid[2, 1] = 6;

		List<int> values = [];
		foreach (int value in grid) {
			values.Add(value);
		}

		values.Count.ShouldBe(6);
		values.ShouldContain(1);
		values.ShouldContain(6);
	}

	[Fact]
	public void Values_ShouldReturnAllValues() {
		Grid<int> grid = new(2, 2);
		grid[0, 0] = 10;
		grid[1, 0] = 20;
		grid[0, 1] = 30;
		grid[1, 1] = 40;

		List<int> values = [.. grid.Values()];

		values.Count.ShouldBe(4);
		values.ShouldContain(10);
		values.ShouldContain(40);
	}

	[Fact]
	public void Grid_WithLINQ_ShouldWork() {
		Grid<int> grid = new(3, 3);
		grid.FillInPlace(5);
		grid[1, 1] = 10;

		int sum = grid.Sum();
		int maxValue = Enumerable.Max(grid);
		int count = grid.Count(x => x == 5);

		sum.ShouldBe(50);
		maxValue.ShouldBe(10);
		count.ShouldBe(8);
	}

	// ========================================
	// Feature 2: Edges and Corners Tests
	// ========================================

	[Fact]
	public void TopEdge_ShouldReturnFirstRow() {
		Grid<int> grid = new(3, 3);
		for (int i = 0; i < 3; i++) {
			for (int j = 0; j < 3; j++) {
				grid[i, j] = i * 10 + j;
			}
		}

		List<int> topEdge = [.. grid.TopEdge()];

		topEdge.ShouldBe([0, 10, 20]);
	}

	[Fact]
	public void BottomEdge_ShouldReturnLastRow() {
		Grid<int> grid = new(3, 3);
		for (int i = 0; i < 3; i++) {
			for (int j = 0; j < 3; j++) {
				grid[i, j] = i * 10 + j;
			}
		}

		List<int> bottomEdge = [.. grid.BottomEdge()];

		bottomEdge.ShouldBe([2, 12, 22]);
	}

	[Fact]
	public void LeftEdge_ShouldReturnFirstColumn() {
		Grid<int> grid = new(3, 3);
		for (int i = 0; i < 3; i++) {
			for (int j = 0; j < 3; j++) {
				grid[i, j] = i * 10 + j;
			}
		}

		List<int> leftEdge = [.. grid.LeftEdge()];

		leftEdge.ShouldBe([0, 1, 2]);
	}

	[Fact]
	public void RightEdge_ShouldReturnLastColumn() {
		Grid<int> grid = new(3, 3);
		for (int i = 0; i < 3; i++) {
			for (int j = 0; j < 3; j++) {
				grid[i, j] = i * 10 + j;
			}
		}

		List<int> rightEdge = [.. grid.RightEdge()];

		rightEdge.ShouldBe([20, 21, 22]);
	}

	[Fact]
	public void Edges_ShouldReturnClockwiseEdges() {
		Grid<int> grid = new(3, 3);
		for (int i = 0; i < 3; i++) {
			for (int j = 0; j < 3; j++) {
				grid[i, j] = i * 10 + j;
			}
		}

		List<int> edges = [.. grid.Edges()];

		// Clockwise: top (0,10,20), right excluding top corner (21,22), 
		// bottom reversed excluding right corner (12,2), left reversed excluding corners (1)
		edges.ShouldBe([0, 10, 20, 21, 22, 12, 2, 1]);
	}

	[Fact]
	public void Edges_OnSingleRowGrid_ShouldReturnAllElements() {
		Grid<int> grid = new(4, 1);
		grid[0, 0] = 1;
		grid[1, 0] = 2;
		grid[2, 0] = 3;
		grid[3, 0] = 4;

		List<int> edges = [.. grid.Edges()];

		edges.ShouldBe([1, 2, 3, 4]);
	}

	[Fact]
	public void Edges_OnSingleColumnGrid_ShouldReturnAllElements() {
		Grid<int> grid = new(1, 4);
		grid[0, 0] = 1;
		grid[0, 1] = 2;
		grid[0, 2] = 3;
		grid[0, 3] = 4;

		List<int> edges = [.. grid.Edges()];

		edges.ShouldBe([1, 2, 3, 4]);
	}

	[Fact]
	public void TopLeft_ShouldReturnTopLeftCorner() {
		Grid<int> grid = new(3, 3);
		grid[0, 0] = 99;

		grid.TopLeft().ShouldBe(99);
	}

	[Fact]
	public void TopRight_ShouldReturnTopRightCorner() {
		Grid<int> grid = new(3, 3);
		grid[2, 0] = 88;

		grid.TopRight().ShouldBe(88);
	}

	[Fact]
	public void BottomLeft_ShouldReturnBottomLeftCorner() {
		Grid<int> grid = new(3, 3);
		grid[0, 2] = 77;

		grid.BottomLeft().ShouldBe(77);
	}

	[Fact]
	public void BottomRight_ShouldReturnBottomRightCorner() {
		Grid<int> grid = new(3, 3);
		grid[2, 2] = 66;

		grid.BottomRight().ShouldBe(66);
	}

	[Fact]
	public void Corners_ShouldReturnAllFourCorners() {
		Grid<int> grid = new(3, 3);
		grid[0, 0] = 1;
		grid[2, 0] = 2;
		grid[2, 2] = 3;
		grid[0, 2] = 4;

		List<int> corners = [.. grid.Corners()];

		corners.ShouldBe([1, 2, 3, 4]);
	}

	// ========================================
	// Feature 2: Edges for Arrays Tests
	// ========================================

	[Fact]
	public void Array_Edges_ShouldReturnClockwiseEdges() {
		int[,] array = new int[3, 3];
		for (int i = 0; i < 3; i++) {
			for (int j = 0; j < 3; j++) {
				array[i, j] = i * 10 + j;
			}
		}

		List<int> edges = [.. array.Edges()];

		edges.ShouldBe([0, 10, 20, 21, 22, 12, 2, 1]);
	}

	[Fact]
	public void Array_Corners_ShouldReturnAllFourCorners() {
		int[,] array = new int[3, 3];
		array[0, 0] = 1;
		array[2, 0] = 2;
		array[2, 2] = 3;
		array[0, 2] = 4;

		List<int> corners = [.. array.Corners()];

		corners.ShouldBe([1, 2, 3, 4]);
	}

	// ========================================
	// Feature 3: Construction Tests
	// ========================================

	[Fact]
	public void ToGrid_ShouldConvertArrayToGrid() {
		int[,] array = new int[2, 2];
		array[0, 0] = 1;
		array[1, 0] = 2;
		array[0, 1] = 3;
		array[1, 1] = 4;

		Grid<int> grid = ArrayHelpers.ToGrid(array);

		grid.ColsCount.ShouldBe(2);
		grid.RowsCount.ShouldBe(2);
		grid[0, 0].ShouldBe(1);
		grid[1, 1].ShouldBe(4);
	}

	[Fact]
	public void ToGrid_ShouldCreateIndependentCopy() {
		int[,] array = new int[2, 2];
		array[0, 0] = 1;

		Grid<int> grid = ArrayHelpers.ToGrid(array);
		grid[0, 0] = 99;

		array[0, 0].ShouldBe(1);
	}

	[Fact]
	public void FromRows_ShouldCreateGridFromRows() {
		int[][] rows = [
			[1, 2, 3],
			[4, 5, 6]
		];

		Grid<int> grid = ArrayHelpers.FromRows(rows);

		grid.ColsCount.ShouldBe(3);
		grid.RowsCount.ShouldBe(2);
		grid[0, 0].ShouldBe(1);
		grid[2, 0].ShouldBe(3);
		grid[0, 1].ShouldBe(4);
		grid[2, 1].ShouldBe(6);
	}

	[Fact]
	public void FromRows_WithInconsistentLengths_ShouldThrow() {
		int[][] rows = [
			[1, 2, 3],
			[4, 5]
		];

		Should.Throw<ArgumentException>(() => ArrayHelpers.FromRows(rows));
	}

	[Fact]
	public void FromRows_WithEmptyCollection_ShouldReturnEmptyGrid() {
		int[][] rows = [];

		Grid<int> grid = ArrayHelpers.FromRows(rows);

		grid.ColsCount.ShouldBe(0);
		grid.RowsCount.ShouldBe(0);
	}

	[Fact]
	public void FromColumns_ShouldCreateGridFromColumns() {
		int[][] columns = [
			[1, 2],
			[3, 4],
			[5, 6]
		];

		Grid<int> grid = ArrayHelpers.FromColumns(columns);

		grid.ColsCount.ShouldBe(3);
		grid.RowsCount.ShouldBe(2);
		grid[0, 0].ShouldBe(1);
		grid[0, 1].ShouldBe(2);
		grid[1, 0].ShouldBe(3);
		grid[2, 1].ShouldBe(6);
	}

	[Fact]
	public void FromColumns_WithInconsistentLengths_ShouldThrow() {
		int[][] columns = [
			[1, 2, 3],
			[4, 5]
		];

		Should.Throw<ArgumentException>(() => ArrayHelpers.FromColumns(columns));
	}

	[Fact]
	public void CreateGrid_ShouldInitializeWithFunction() {
		Grid<int> grid = ArrayHelpers.CreateGrid(3, 2, (col, row) => col * 10 + row);

		grid.ColsCount.ShouldBe(3);
		grid.RowsCount.ShouldBe(2);
		grid[0, 0].ShouldBe(0);
		grid[1, 0].ShouldBe(10);
		grid[2, 1].ShouldBe(21);
	}

	[Fact]
	public void CreateGrid_WithCustomFunction_ShouldWork() {
		Grid<string> grid = ArrayHelpers.CreateGrid(2, 2, (col, row) => $"({col},{row})");

		grid[0, 0].ShouldBe("(0,0)");
		grid[1, 1].ShouldBe("(1,1)");
	}

	// ========================================
	// Feature 4: Transform Tests
	// ========================================

	[Fact]
	public void Map_WithSimpleSelector_ShouldTransformAllElements() {
		Grid<int> grid = new(2, 2);
		grid[0, 0] = 1;
		grid[1, 0] = 2;
		grid[0, 1] = 3;
		grid[1, 1] = 4;

		Grid<int> result = grid.Map(x => x * 10);

		result[0, 0].ShouldBe(10);
		result[1, 0].ShouldBe(20);
		result[0, 1].ShouldBe(30);
		result[1, 1].ShouldBe(40);
	}

	[Fact]
	public void Map_WithTypeConversion_ShouldWork() {
		Grid<int> grid = new(2, 2);
		grid[0, 0] = 1;
		grid[1, 0] = 2;
		grid[0, 1] = 3;
		grid[1, 1] = 4;

		Grid<string> result = grid.Map(x => $"Value{x}");

		result[0, 0].ShouldBe("Value1");
		result[1, 1].ShouldBe("Value4");
	}

	[Fact]
	public void Map_WithCoordinateSelector_ShouldIncludePosition() {
		Grid<int> grid = new(2, 2);
		grid.FillInPlace(0);

		Grid<int> result = grid.Map((col, row, value) => col * 10 + row);

		result[0, 0].ShouldBe(0);
		result[1, 0].ShouldBe(10);
		result[0, 1].ShouldBe(1);
		result[1, 1].ShouldBe(11);
	}

	[Fact]
	public void Map_ShouldNotModifyOriginal() {
		Grid<int> original = new(2, 2);
		original.FillInPlace(5);

		Grid<int> mapped = original.Map(x => x * 2);

		original[0, 0].ShouldBe(5);
		mapped[0, 0].ShouldBe(10);
	}

	[Fact]
	public void Aggregate_ShouldAccumulateValues() {
		Grid<int> grid = new(2, 2);
		grid[0, 0] = 1;
		grid[1, 0] = 2;
		grid[0, 1] = 3;
		grid[1, 1] = 4;

		int sum = grid.Aggregate(0, (acc, val) => acc + val);

		sum.ShouldBe(10);
	}

	[Fact]
	public void Aggregate_WithStringConcatenation_ShouldWork() {
		Grid<char> grid = new(2, 2);
		grid[0, 0] = 'A';
		grid[1, 0] = 'B';
		grid[0, 1] = 'C';
		grid[1, 1] = 'D';

		string result = grid.Aggregate("", (acc, val) => acc + val);

		result.ShouldContain('A');
		result.ShouldContain('D');
		result.Length.ShouldBe(4);
	}

	[Fact]
	public void Array_Map_ShouldTransformAllElements() {
		int[,] array = new int[2, 2];
		array[0, 0] = 1;
		array[1, 0] = 2;
		array[0, 1] = 3;
		array[1, 1] = 4;

		int[,] result = array.Map(x => x * 10);

		result[0, 0].ShouldBe(10);
		result[1, 1].ShouldBe(40);
	}

	[Fact]
	public void Array_Map_WithCoordinateSelector_ShouldWork() {
		int[,] array = new int[2, 2];

		int[,] result = array.Map((col, row, value) => col * 10 + row);

		result[0, 0].ShouldBe(0);
		result[1, 0].ShouldBe(10);
		result[1, 1].ShouldBe(11);
	}

	// ========================================
	// Feature 5: Search Tests
	// ========================================

	[Fact]
	public void Find_WithValue_ShouldReturnFirstOccurrence() {
		Grid<int> grid = new(3, 3);
		grid.FillInPlace(0);
		grid[1, 1] = 42;
		grid[2, 2] = 42;

		(int col, int row)? position = grid.Find(42);

		position.ShouldNotBeNull();
		position.Value.col.ShouldBe(1);
		position.Value.row.ShouldBe(1);
	}

	[Fact]
	public void Find_WithNonExistentValue_ShouldReturnNull() {
		Grid<int> grid = new(3, 3);
		grid.FillInPlace(0);

		(int col, int row)? position = grid.Find(42);

		position.ShouldBeNull();
	}

	[Fact]
	public void FindAll_WithValue_ShouldReturnAllOccurrences() {
		Grid<int> grid = new(3, 3);
		grid.FillInPlace(0);
		grid[0, 0] = 42;
		grid[1, 1] = 42;
		grid[2, 2] = 42;

		List<(int col, int row)> positions = [.. grid.FindAll(42)];

		positions.Count.ShouldBe(3);
		positions.ShouldContain((0, 0));
		positions.ShouldContain((1, 1));
		positions.ShouldContain((2, 2));
	}

	[Fact]
	public void Contains_WithExistingValue_ShouldReturnTrue() {
		Grid<int> grid = new(3, 3);
		grid.FillInPlace(0);
		grid[1, 1] = 42;

		grid.Contains(42).ShouldBeTrue();
	}

	[Fact]
	public void Contains_WithNonExistentValue_ShouldReturnFalse() {
		Grid<int> grid = new(3, 3);
		grid.FillInPlace(0);

		grid.Contains(42).ShouldBeFalse();
	}

	[Fact]
	public void Find_WithPredicate_ShouldReturnFirstMatch() {
		Grid<int> grid = new(3, 3);
		for (int i = 0; i < 3; i++) {
			for (int j = 0; j < 3; j++) {
				grid[i, j] = i * 10 + j;
			}
		}

		(int col, int row)? position = grid.Find(x => x > 15);

		position.ShouldNotBeNull();
		position.Value.col.ShouldBe(2);
		position.Value.row.ShouldBe(0);
	}

	[Fact]
	public void FindAll_WithPredicate_ShouldReturnAllMatches() {
		Grid<int> grid = new(3, 3);
		for (int i = 0; i < 3; i++) {
			for (int j = 0; j < 3; j++) {
				grid[i, j] = i * 10 + j;
			}
		}

		List<(int col, int row)> positions = [.. grid.FindAll(x => x >= 20)];

		positions.Count.ShouldBe(3);
		positions.ShouldContain((2, 0));
		positions.ShouldContain((2, 1));
		positions.ShouldContain((2, 2));
	}

	[Fact]
	public void Any_WithMatchingPredicate_ShouldReturnTrue() {
		Grid<int> grid = new(3, 3);
		grid.FillInPlace(5);
		grid[1, 1] = 10;

		grid.Any(x => x == 10).ShouldBeTrue();
	}

	[Fact]
	public void Any_WithNonMatchingPredicate_ShouldReturnFalse() {
		Grid<int> grid = new(3, 3);
		grid.FillInPlace(5);

		grid.Any(x => x == 10).ShouldBeFalse();
	}

	[Fact]
	public void All_WhenAllMatch_ShouldReturnTrue() {
		Grid<int> grid = new(3, 3);
		grid.FillInPlace(5);

		grid.All(x => x == 5).ShouldBeTrue();
	}

	[Fact]
	public void All_WhenNotAllMatch_ShouldReturnFalse() {
		Grid<int> grid = new(3, 3);
		grid.FillInPlace(5);
		grid[1, 1] = 10;

		grid.All(x => x == 5).ShouldBeFalse();
	}

	[Fact]
	public void Count_WithPredicate_ShouldReturnMatchingCount() {
		Grid<int> grid = new(3, 3);
		grid.FillInPlace(5);
		grid[0, 0] = 10;
		grid[1, 1] = 10;
		grid[2, 2] = 10;

		int count = grid.Count(x => x == 10);

		count.ShouldBe(3);
	}

	[Fact]
	public void Array_Find_WithValue_ShouldWork() {
		int[,] array = new int[3, 3];
		array[1, 1] = 42;

		(int col, int row)? position = array.Find(42);

		position.ShouldNotBeNull();
		position.Value.col.ShouldBe(1);
		position.Value.row.ShouldBe(1);
	}

	[Fact]
	public void Array_FindAll_WithPredicate_ShouldWork() {
		int[,] array = new int[3, 3];
		array[0, 0] = 10;
		array[1, 1] = 20;
		array[2, 2] = 30;

		List<(int col, int row)> positions = [.. array.FindAll(x => x >= 20)];

		positions.Count.ShouldBe(2);
		positions.ShouldContain((1, 1));
		positions.ShouldContain((2, 2));
	}

	// ========================================
	// Feature 6: Neighbors Tests
	// ========================================

	[Fact]
	public void GetNeighbors_WithoutDiagonals_ShouldReturnCardinalNeighbors() {
		Grid<int> grid = new(3, 3);
		for (int i = 0; i < 3; i++) {
			for (int j = 0; j < 3; j++) {
				grid[i, j] = i * 10 + j;
			}
		}

		List<int> neighbors = [.. grid.GetNeighbors(1, 1, includeDiagonals: false)];

		neighbors.Count.ShouldBe(4);
		neighbors.ShouldContain(10); // North
		neighbors.ShouldContain(21); // East
		neighbors.ShouldContain(12); // South
		neighbors.ShouldContain(1);  // West
	}

	[Fact]
	public void GetNeighbors_WithDiagonals_ShouldReturnAllEightNeighbors() {
		Grid<int> grid = new(3, 3);
		for (int i = 0; i < 3; i++) {
			for (int j = 0; j < 3; j++) {
				grid[i, j] = i * 10 + j;
			}
		}

		List<int> neighbors = [.. grid.GetNeighbors(1, 1, includeDiagonals: true)];

		neighbors.Count.ShouldBe(8);
		neighbors.ShouldContain(0);  // NW
		neighbors.ShouldContain(10); // N
		neighbors.ShouldContain(20); // NE
		neighbors.ShouldContain(21); // E
		neighbors.ShouldContain(22); // SE
		neighbors.ShouldContain(12); // S
		neighbors.ShouldContain(2);  // SW
		neighbors.ShouldContain(1);  // W
	}

	[Fact]
	public void GetNeighbors_AtEdge_ShouldReturnOnlyValidNeighbors() {
		Grid<int> grid = new(3, 3);
		for (int i = 0; i < 3; i++) {
			for (int j = 0; j < 3; j++) {
				grid[i, j] = i * 10 + j;
			}
		}

		List<int> neighbors = [.. grid.GetNeighbors(0, 0, includeDiagonals: false)];

		neighbors.Count.ShouldBe(2);
		neighbors.ShouldContain(10); // East
		neighbors.ShouldContain(1);  // South
	}

	[Fact]
	public void GetNeighbors_AtCorner_WithDiagonals_ShouldReturnThreeNeighbors() {
		Grid<int> grid = new(3, 3);
		for (int i = 0; i < 3; i++) {
			for (int j = 0; j < 3; j++) {
				grid[i, j] = i * 10 + j;
			}
		}

		List<int> neighbors = [.. grid.GetNeighbors(0, 0, includeDiagonals: true)];

		neighbors.Count.ShouldBe(3);
		neighbors.ShouldContain(10); // E
		neighbors.ShouldContain(1);  // S
		neighbors.ShouldContain(11); // SE
	}

	[Fact]
	public void GetNeighborsWithCoords_ShouldReturnNeighborsAndPositions() {
		Grid<int> grid = new(3, 3);
		for (int i = 0; i < 3; i++) {
			for (int j = 0; j < 3; j++) {
				grid[i, j] = i * 10 + j;
			}
		}

		List<(int col, int row, int value)> neighbors = [.. grid.GetNeighborsWithCoords(1, 1, includeDiagonals: false)];

		neighbors.Count.ShouldBe(4);
		neighbors.ShouldContain((1, 0, 10)); // North
		neighbors.ShouldContain((2, 1, 21)); // East
		neighbors.ShouldContain((1, 2, 12)); // South
		neighbors.ShouldContain((0, 1, 1));  // West
	}

	[Fact]
	public void GetNorth_ShouldReturnNorthNeighbor() {
		Grid<int> grid = new(3, 3);
		grid[1, 0] = 99;

		int? north = grid.GetNorth(1, 1);

		north.ShouldBe(99);
	}

	[Fact]
	public void GetNorth_AtTopEdge_ShouldReturnDefault() {
		Grid<int> grid = new(3, 3);

		int? north = grid.GetNorth(1, 0);

		north.ShouldBe(default(int));
	}

	[Fact]
	public void GetSouth_ShouldReturnSouthNeighbor() {
		Grid<int> grid = new(3, 3);
		grid[1, 2] = 88;

		int? south = grid.GetSouth(1, 1);

		south.ShouldBe(88);
	}

	[Fact]
	public void GetEast_ShouldReturnEastNeighbor() {
		Grid<int> grid = new(3, 3);
		grid[2, 1] = 77;

		int? east = grid.GetEast(1, 1);

		east.ShouldBe(77);
	}

	[Fact]
	public void GetWest_ShouldReturnWestNeighbor() {
		Grid<int> grid = new(3, 3);
		grid[0, 1] = 66;

		int? west = grid.GetWest(1, 1);

		west.ShouldBe(66);
	}

	[Fact]
	public void GetCardinalNeighbors_ShouldReturnNeighborsWithDirections() {
		Grid<int> grid = new(3, 3);
		for (int i = 0; i < 3; i++) {
			for (int j = 0; j < 3; j++) {
				grid[i, j] = i * 10 + j;
			}
		}

		List<(string direction, int col, int row, int value)> neighbors = [.. grid.GetCardinalNeighbors(1, 1)];

		neighbors.Count.ShouldBe(4);
		neighbors.ShouldContain(("N", 1, 0, 10));
		neighbors.ShouldContain(("E", 2, 1, 21));
		neighbors.ShouldContain(("S", 1, 2, 12));
		neighbors.ShouldContain(("W", 0, 1, 1));
	}

	[Fact]
	public void Array_GetNeighbors_ShouldWork() {
		int[,] array = new int[3, 3];
		for (int i = 0; i < 3; i++) {
			for (int j = 0; j < 3; j++) {
				array[i, j] = i * 10 + j;
			}
		}

		List<int> neighbors = [.. array.GetNeighbors(1, 1, includeDiagonals: false)];

		neighbors.Count.ShouldBe(4);
		neighbors.ShouldContain(10);
		neighbors.ShouldContain(21);
	}

	// ========================================
	// Mathematical Operations Tests
	// ========================================

	[Fact]
	public void Sum_WithIntGrid_ShouldReturnSum() {
		Grid<int> grid = new(3, 3);
		grid.FillInPlace(5);
		grid[1, 1] = 10;

		int sum = grid.Sum();

		sum.ShouldBe(50);
	}

	[Fact]
	public void Sum_WithLongGrid_ShouldReturnSum() {
		Grid<long> grid = new(2, 2);
		grid[0, 0] = 100L;
		grid[1, 0] = 200L;
		grid[0, 1] = 300L;
		grid[1, 1] = 400L;

		long sum = grid.Sum();

		sum.ShouldBe(1000L);
	}

	[Fact]
	public void Sum_WithDoubleGrid_ShouldReturnSum() {
		Grid<double> grid = new(2, 2);
		grid[0, 0] = 1.5;
		grid[1, 0] = 2.5;
		grid[0, 1] = 3.5;
		grid[1, 1] = 4.5;

		double sum = grid.Sum();

		sum.ShouldBe(12.0);
	}

	[Fact]
	public void Sum_WithDecimalGrid_ShouldReturnSum() {
		Grid<decimal> grid = new(2, 2);
		grid[0, 0] = 10.5m;
		grid[1, 0] = 20.5m;
		grid[0, 1] = 30.5m;
		grid[1, 1] = 40.5m;

		decimal sum = grid.Sum();

		sum.ShouldBe(102.0m);
	}

	[Fact]
	public void Sum_WithFloatGrid_ShouldReturnSum() {
		Grid<float> grid = new(2, 2);
		grid[0, 0] = 1.5f;
		grid[1, 0] = 2.5f;
		grid[0, 1] = 3.5f;
		grid[1, 1] = 4.5f;

		float sum = grid.Sum();

		sum.ShouldBe(12.0f);
	}

	[Fact]
	public void Array_Sum_WithIntArray_ShouldReturnSum() {
		int[,] array = new int[2, 2];
		array[0, 0] = 1;
		array[1, 0] = 2;
		array[0, 1] = 3;
		array[1, 1] = 4;

		int sum = array.Sum();

		sum.ShouldBe(10);
	}

	[Fact]
	public void Array_Sum_WithDoubleArray_ShouldReturnSum() {
		double[,] array = new double[2, 2];
		array[0, 0] = 1.5;
		array[1, 0] = 2.5;
		array[0, 1] = 3.5;
		array[1, 1] = 4.5;

		double sum = array.Sum();

		sum.ShouldBe(12.0);
	}

	[Fact]
	public void Min_WithIntGrid_ShouldReturnMinimum() {
		Grid<int> grid = new(3, 3);
		grid.FillInPlace(10);
		grid[1, 1] = 5;
		grid[2, 2] = 3;

		int min = grid.Min();

		min.ShouldBe(3);
	}

	[Fact]
	public void Min_WithDoubleGrid_ShouldReturnMinimum() {
		Grid<double> grid = new(2, 2);
		grid[0, 0] = 5.5;
		grid[1, 0] = 2.3;
		grid[0, 1] = 7.1;
		grid[1, 1] = 1.9;

		double min = grid.Min();

		min.ShouldBe(1.9);
	}

	[Fact]
	public void Min_WithEmptyGrid_ShouldThrow() {
		Grid<int> grid = new(0, 0);

		Should.Throw<InvalidOperationException>(() => grid.Min());
	}

	[Fact]
	public void Max_WithIntGrid_ShouldReturnMaximum() {
		Grid<int> grid = new(3, 3);
		grid.FillInPlace(5);
		grid[1, 1] = 10;
		grid[2, 2] = 15;

		int max = grid.Max();

		max.ShouldBe(15);
	}

	[Fact]
	public void Max_WithDoubleGrid_ShouldReturnMaximum() {
		Grid<double> grid = new(2, 2);
		grid[0, 0] = 5.5;
		grid[1, 0] = 2.3;
		grid[0, 1] = 7.1;
		grid[1, 1] = 1.9;

		double max = grid.Max();

		max.ShouldBe(7.1);
	}

	[Fact]
	public void Max_WithEmptyGrid_ShouldThrow() {
		Grid<int> grid = new(0, 0);

		Should.Throw<InvalidOperationException>(() => grid.Max());
	}

	[Fact]
	public void Average_WithIntGrid_ShouldReturnAverage() {
		Grid<int> grid = new(2, 2);
		grid[0, 0] = 2;
		grid[1, 0] = 4;
		grid[0, 1] = 6;
		grid[1, 1] = 8;

		int average = grid.Average();

		average.ShouldBe(5);
	}

	[Fact]
	public void Average_WithDoubleGrid_ShouldReturnAverage() {
		Grid<double> grid = new(2, 2);
		grid[0, 0] = 1.0;
		grid[1, 0] = 2.0;
		grid[0, 1] = 3.0;
		grid[1, 1] = 4.0;

		double average = grid.Average();

		average.ShouldBe(2.5);
	}

	[Fact]
	public void Average_WithDecimalGrid_ShouldReturnAverage() {
		Grid<decimal> grid = new(2, 2);
		grid[0, 0] = 10.0m;
		grid[1, 0] = 20.0m;
		grid[0, 1] = 30.0m;
		grid[1, 1] = 40.0m;

		decimal average = grid.Average();

		average.ShouldBe(25.0m);
	}

	[Fact]
	public void Average_WithEmptyGrid_ShouldThrow() {
		Grid<int> grid = new(0, 0);

		Should.Throw<InvalidOperationException>(() => grid.Average());
	}

	[Fact]
	public void Array_Min_WithIntArray_ShouldReturnMinimum() {
		int[,] array = new int[2, 2];
		array[0, 0] = 5;
		array[1, 0] = 2;
		array[0, 1] = 8;
		array[1, 1] = 1;

		int min = array.Min();

		min.ShouldBe(1);
	}

	[Fact]
	public void Array_Max_WithIntArray_ShouldReturnMaximum() {
		int[,] array = new int[2, 2];
		array[0, 0] = 5;
		array[1, 0] = 2;
		array[0, 1] = 8;
		array[1, 1] = 1;

		int max = array.Max();

		max.ShouldBe(8);
	}

	[Fact]
	public void Array_Average_WithDoubleArray_ShouldReturnAverage() {
		double[,] array = new double[2, 2];
		array[0, 0] = 2.0;
		array[1, 0] = 4.0;
		array[0, 1] = 6.0;
		array[1, 1] = 8.0;

		double average = array.Average();

		average.ShouldBe(5.0);
	}

	[Fact]
	public void Array_Min_WithEmptyArray_ShouldThrow() {
		int[,] array = new int[0, 0];

		Should.Throw<InvalidOperationException>(() => array.Min());
	}

	[Fact]
	public void Array_Max_WithEmptyArray_ShouldThrow() {
		int[,] array = new int[0, 0];

		Should.Throw<InvalidOperationException>(() => array.Max());
	}

	[Fact]
	public void Array_Average_WithEmptyArray_ShouldThrow() {
		int[,] array = new int[0, 0];

		Should.Throw<InvalidOperationException>(() => array.Average());
	}

	// ========================================
	// Feature 7: Concatenation Tests
	// ========================================

	[Fact]
	public void ConcatRight_ShouldCombineGridsHorizontally() {
		Grid<int> left = new(2, 2);
		left[0, 0] = 1;
		left[1, 0] = 2;
		left[0, 1] = 3;
		left[1, 1] = 4;

		Grid<int> right = new(2, 2);
		right[0, 0] = 5;
		right[1, 0] = 6;
		right[0, 1] = 7;
		right[1, 1] = 8;

		Grid<int> combined = left.ConcatRight(right);

		combined.ColsCount.ShouldBe(4);
		combined.RowsCount.ShouldBe(2);
		combined[0, 0].ShouldBe(1);
		combined[1, 0].ShouldBe(2);
		combined[2, 0].ShouldBe(5);
		combined[3, 0].ShouldBe(6);
		combined[0, 1].ShouldBe(3);
		combined[3, 1].ShouldBe(8);
	}

	[Fact]
	public void ConcatRight_WithMismatchedRows_ShouldThrow() {
		Grid<int> left = new(2, 2);
		Grid<int> right = new(2, 3);

		Should.Throw<ArgumentException>(() => left.ConcatRight(right));
	}

	[Fact]
	public void ConcatBottom_ShouldCombineGridsVertically() {
		Grid<int> top = new(2, 2);
		top[0, 0] = 1;
		top[1, 0] = 2;
		top[0, 1] = 3;
		top[1, 1] = 4;

		Grid<int> bottom = new(2, 2);
		bottom[0, 0] = 5;
		bottom[1, 0] = 6;
		bottom[0, 1] = 7;
		bottom[1, 1] = 8;

		Grid<int> combined = top.ConcatBottom(bottom);

		combined.ColsCount.ShouldBe(2);
		combined.RowsCount.ShouldBe(4);
		combined[0, 0].ShouldBe(1);
		combined[1, 0].ShouldBe(2);
		combined[0, 1].ShouldBe(3);
		combined[1, 1].ShouldBe(4);
		combined[0, 2].ShouldBe(5);
		combined[1, 2].ShouldBe(6);
		combined[0, 3].ShouldBe(7);
		combined[1, 3].ShouldBe(8);
	}

	[Fact]
	public void ConcatBottom_WithMismatchedColumns_ShouldThrow() {
		Grid<int> top = new(2, 2);
		Grid<int> bottom = new(3, 2);

		Should.Throw<ArgumentException>(() => top.ConcatBottom(bottom));
	}

	[Fact]
	public void ConcatRight_WithDifferentSizes_ShouldWork() {
		Grid<int> left = new(1, 3);
		left[0, 0] = 1;
		left[0, 1] = 2;
		left[0, 2] = 3;

		Grid<int> right = new(2, 3);
		right[0, 0] = 4;
		right[1, 0] = 5;
		right[0, 1] = 6;
		right[1, 1] = 7;
		right[0, 2] = 8;
		right[1, 2] = 9;

		Grid<int> combined = left.ConcatRight(right);

		combined.ColsCount.ShouldBe(3);
		combined.RowsCount.ShouldBe(3);
		combined[0, 0].ShouldBe(1);
		combined[1, 0].ShouldBe(4);
		combined[2, 2].ShouldBe(9);
	}

	[Fact]
	public void Array_ConcatRight_ShouldWork() {
		int[,] left = new int[2, 2];
		left[0, 0] = 1;
		left[1, 0] = 2;
		left[0, 1] = 3;
		left[1, 1] = 4;

		int[,] right = new int[1, 2];
		right[0, 0] = 5;
		right[0, 1] = 6;

		int[,] combined = left.ConcatRight(right);

		combined.GetLength(0).ShouldBe(3);
		combined.GetLength(1).ShouldBe(2);
		combined[0, 0].ShouldBe(1);
		combined[2, 0].ShouldBe(5);
		combined[2, 1].ShouldBe(6);
	}

	[Fact]
	public void Array_ConcatBottom_ShouldWork() {
		int[,] top = new int[2, 2];
		top[0, 0] = 1;
		top[1, 0] = 2;
		top[0, 1] = 3;
		top[1, 1] = 4;

		int[,] bottom = new int[2, 1];
		bottom[0, 0] = 5;
		bottom[1, 0] = 6;

		int[,] combined = top.ConcatBottom(bottom);

		combined.GetLength(0).ShouldBe(2);
		combined.GetLength(1).ShouldBe(3);
		combined[0, 0].ShouldBe(1);
		combined[0, 2].ShouldBe(5);
		combined[1, 2].ShouldBe(6);
	}
}
