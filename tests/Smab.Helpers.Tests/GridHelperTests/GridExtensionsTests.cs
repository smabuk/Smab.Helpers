namespace Smab.Helpers.Tests.GridHelperTests;

public class GridExtensionsTests {
	// ========================================
	// Feature 1: Enumerable Tests
	// ========================================

	[Fact]
	public void GetEnumerator_ShouldIterateThroughAllElements() {
		Grid<int> grid = new(3, 2) {
			[0, 0] = 1,
			[1, 0] = 2,
			[2, 0] = 3,
			[0, 1] = 4,
			[1, 1] = 5,
			[2, 1] = 6
		};

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
		Grid<int> grid = new(2, 2) {
			[0, 0] = 10,
			[1, 0] = 20,
			[0, 1] = 30,
			[1, 1] = 40
		};

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
		Grid<int> grid = new(4, 1) {
			[0, 0] = 1,
			[1, 0] = 2,
			[2, 0] = 3,
			[3, 0] = 4
		};

		List<int> edges = [.. grid.Edges()];

		edges.ShouldBe([1, 2, 3, 4]);
	}

	[Fact]
	public void Edges_OnSingleColumnGrid_ShouldReturnAllElements() {
		Grid<int> grid = new(1, 4) {
			[0, 0] = 1,
			[0, 1] = 2,
			[0, 2] = 3,
			[0, 3] = 4
		};

		List<int> edges = [.. grid.Edges()];

		edges.ShouldBe([1, 2, 3, 4]);
	}

	[Fact]
	public void TopLeft_ShouldReturnTopLeftCorner() {
		Grid<int> grid = new(3, 3) {
			[0, 0] = 99
		};

		grid.TopLeft().ShouldBe(99);
	}

	[Fact]
	public void TopRight_ShouldReturnTopRightCorner() {
		Grid<int> grid = new(3, 3) {
			[2, 0] = 88
		};

		grid.TopRight().ShouldBe(88);
	}

	[Fact]
	public void BottomLeft_ShouldReturnBottomLeftCorner() {
		Grid<int> grid = new(3, 3) {
			[0, 2] = 77
		};

		grid.BottomLeft().ShouldBe(77);
	}

	[Fact]
	public void BottomRight_ShouldReturnBottomRightCorner() {
		Grid<int> grid = new(3, 3) {
			[2, 2] = 66
		};

		grid.BottomRight().ShouldBe(66);
	}

	[Fact]
	public void Corners_ShouldReturnAllFourCorners() {
		Grid<int> grid = new(3, 3) {
			[0, 0] = 1,
			[2, 0] = 2,
			[2, 2] = 3,
			[0, 2] = 4
		};

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

		Grid<int> grid = Grid<int>.CreateFromArray(array);

		grid.ColsCount.ShouldBe(2);
		grid.RowsCount.ShouldBe(2);
		grid[0, 0].ShouldBe(1);
		grid[1, 1].ShouldBe(4);
	}

	[Fact]
	public void ToGrid_ShouldCreateIndependentCopy() {
		int[,] array = new int[2, 2];
		array[0, 0] = 1;

		Grid<int> grid = Grid<int>.CreateFromArray(array);
		grid[0, 0] = 99;

		array[0, 0].ShouldBe(1);
	}

	[Fact]
	public void FromRows_ShouldCreateGridFromRows() {
		int[][] rows = [
			[1, 2, 3],
			[4, 5, 6]
		];

		Grid<int> grid = Grid<int>.CreateFromRows(rows);

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

		Should.Throw<ArgumentException>(() => Grid<int>.CreateFromRows(rows));
	}

	[Fact]
	public void FromRows_WithEmptyCollection_ShouldReturnEmptyGrid() {
		int[][] rows = [];

		Grid<int> grid = Grid<int>.CreateFromRows(rows);

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

		Grid<int> grid = Grid<int>.CreateFromColumns(columns);

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

		Should.Throw<ArgumentException>(() => Grid<int>.CreateFromColumns(columns));
	}

	[Fact]
	public void CreateGrid_ShouldInitializeWithFunction() {
		Grid<int> grid = Grid<int>.CreateGrid(3, 2, (col, row) => col * 10 + row);

		grid.ColsCount.ShouldBe(3);
		grid.RowsCount.ShouldBe(2);
		grid[0, 0].ShouldBe(0);
		grid[1, 0].ShouldBe(10);
		grid[2, 1].ShouldBe(21);
	}

	[Fact]
	public void CreateGrid_WithCustomFunction_ShouldWork() {
		Grid<string> grid = Grid<string>.CreateGrid(2, 2, (col, row) => $"({col},{row})");

		grid[0, 0].ShouldBe("(0,0)");
		grid[1, 1].ShouldBe("(1,1)");
	}

	// ========================================
	// Feature 4: Transform Tests
	// ========================================

	[Fact]
	public void Map_WithSimpleSelector_ShouldTransformAllElements() {
		Grid<int> grid = new(2, 2) {
			[0, 0] = 1,
			[1, 0] = 2,
			[0, 1] = 3,
			[1, 1] = 4
		};

		Grid<int> result = grid.Map(x => x * 10);

		result[0, 0].ShouldBe(10);
		result[1, 0].ShouldBe(20);
		result[0, 1].ShouldBe(30);
		result[1, 1].ShouldBe(40);
	}

	[Fact]
	public void Map_WithTypeConversion_ShouldWork() {
		Grid<int> grid = new(2, 2) {
			[0, 0] = 1,
			[1, 0] = 2,
			[0, 1] = 3,
			[1, 1] = 4
		};

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
		Grid<int> grid = new(2, 2) {
			[0, 0] = 1,
			[1, 0] = 2,
			[0, 1] = 3,
			[1, 1] = 4
		};

		int sum = grid.Aggregate(0, (acc, val) => acc + val);

		sum.ShouldBe(10);
	}

	[Fact]
	public void Aggregate_WithStringConcatenation_ShouldWork() {
		Grid<char> grid = new(2, 2) {
			[0, 0] = 'A',
			[1, 0] = 'B',
			[0, 1] = 'C',
			[1, 1] = 'D'
		};

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
	// Feature 6: Neighbours Tests
	// ========================================

	[Fact]
	public void GetNeighbours_WithoutDiagonals_ShouldReturnCardinalNeighbours() {
		Grid<int> grid = new(3, 3);
		for (int i = 0; i < 3; i++) {
			for (int j = 0; j < 3; j++) {
				grid[i, j] = i * 10 + j;
			}
		}

		List<int> neighbours = [.. grid.GetNeighbours(1, 1, includeDiagonals: false)];

		neighbours.Count.ShouldBe(4);
		neighbours.ShouldContain(10); // North
		neighbours.ShouldContain(21); // East
		neighbours.ShouldContain(12); // South
		neighbours.ShouldContain(1);  // West
	}

	[Fact]
	public void GetNeighbours_WithDiagonals_ShouldReturnAllEightNeighbours() {
		Grid<int> grid = new(3, 3);
		for (int i = 0; i < 3; i++) {
			for (int j = 0; j < 3; j++) {
				grid[i, j] = i * 10 + j;
			}
		}

		List<int> neighbours = [.. grid.GetNeighbours(1, 1, includeDiagonals: true)];

		neighbours.Count.ShouldBe(8);
		neighbours.ShouldContain(0);  // NW
		neighbours.ShouldContain(10); // N
		neighbours.ShouldContain(20); // NE
		neighbours.ShouldContain(21); // E
		neighbours.ShouldContain(22); // SE
		neighbours.ShouldContain(12); // S
		neighbours.ShouldContain(2);  // SW
		neighbours.ShouldContain(1);  // W
	}

	[Fact]
	public void GetNeighbours_AtEdge_ShouldReturnOnlyValidNeighbours() {
		Grid<int> grid = new(3, 3);
		for (int i = 0; i < 3; i++) {
			for (int j = 0; j < 3; j++) {
				grid[i, j] = i * 10 + j;
			}
		}

		List<int> neighbours = [.. grid.GetNeighbours(0, 0, includeDiagonals: false)];

		neighbours.Count.ShouldBe(2);
		neighbours.ShouldContain(10); // East
		neighbours.ShouldContain(1);  // South
	}

	[Fact]
	public void GetNeighbours_AtCorner_WithDiagonals_ShouldReturnThreeNeighbours() {
		Grid<int> grid = new(3, 3);
		for (int i = 0; i < 3; i++) {
			for (int j = 0; j < 3; j++) {
				grid[i, j] = i * 10 + j;
			}
		}

		List<int> neighbours = [.. grid.GetNeighbours(0, 0, includeDiagonals: true)];

		neighbours.Count.ShouldBe(3);
		neighbours.ShouldContain(10); // E
		neighbours.ShouldContain(1);  // S
		neighbours.ShouldContain(11); // SE
	}

	[Fact]
	public void GetNeighboursWithCoords_ShouldReturnNeighboursAndPositions() {
		Grid<int> grid = new(3, 3);
		for (int i = 0; i < 3; i++) {
			for (int j = 0; j < 3; j++) {
				grid[i, j] = i * 10 + j;
			}
		}

		List<(int col, int row, int value)> neighbours = [.. grid.GetNeighboursWithCoords(1, 1, includeDiagonals: false)];

		neighbours.Count.ShouldBe(4);
		neighbours.ShouldContain((1, 0, 10)); // North
		neighbours.ShouldContain((2, 1, 21)); // East
		neighbours.ShouldContain((1, 2, 12)); // South
		neighbours.ShouldContain((0, 1, 1));  // West
	}

	[Fact]
	public void GetNorth_ShouldReturnNorthNeighbour() {
		Grid<int> grid = new(3, 3) {
			[1, 0] = 99
		};

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
	public void GetSouth_ShouldReturnSouthNeighbour() {
		Grid<int> grid = new(3, 3) {
			[1, 2] = 88
		};

		int? south = grid.GetSouth(1, 1);

		south.ShouldBe(88);
	}

	[Fact]
	public void GetEast_ShouldReturnEastNeighbour() {
		Grid<int> grid = new(3, 3) {
			[2, 1] = 77
		};

		int? east = grid.GetEast(1, 1);

		east.ShouldBe(77);
	}

	[Fact]
	public void GetWest_ShouldReturnWestNeighbour() {
		Grid<int> grid = new(3, 3) {
			[0, 1] = 66
		};

		int? west = grid.GetWest(1, 1);

		west.ShouldBe(66);
	}

	[Fact]
	public void GetCardinalNeighbours_ShouldReturnNeighboursWithDirections() {
		Grid<int> grid = new(3, 3);
		for (int i = 0; i < 3; i++) {
			for (int j = 0; j < 3; j++) {
				grid[i, j] = i * 10 + j;
			}
		}

		List<(string direction, int col, int row, int value)> neighbours = [.. grid.GetCardinalNeighbours(1, 1)];

		neighbours.Count.ShouldBe(4);
		neighbours.ShouldContain(("N", 1, 0, 10));
		neighbours.ShouldContain(("E", 2, 1, 21));
		neighbours.ShouldContain(("S", 1, 2, 12));
		neighbours.ShouldContain(("W", 0, 1, 1));
	}

	[Fact]
	public void Array_GetNeighbours_ShouldWork() {
		int[,] array = new int[3, 3];
		for (int i = 0; i < 3; i++) {
			for (int j = 0; j < 3; j++) {
				array[i, j] = i * 10 + j;
			}
		}

		List<int> neighbours = [.. array.GetNeighbours(1, 1, includeDiagonals: false)];

		neighbours.Count.ShouldBe(4);
		neighbours.ShouldContain(10);
		neighbours.ShouldContain(21);
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
		Grid<long> grid = new(2, 2) {
			[0, 0] = 100L,
			[1, 0] = 200L,
			[0, 1] = 300L,
			[1, 1] = 400L
		};

		long sum = grid.Sum();

		sum.ShouldBe(1000L);
	}

	[Fact]
	public void Sum_WithDoubleGrid_ShouldReturnSum() {
		Grid<double> grid = new(2, 2) {
			[0, 0] = 1.5,
			[1, 0] = 2.5,
			[0, 1] = 3.5,
			[1, 1] = 4.5
		};

		double sum = grid.Sum();

		sum.ShouldBe(12.0);
	}

	[Fact]
	public void Sum_WithDecimalGrid_ShouldReturnSum() {
		Grid<decimal> grid = new(2, 2) {
			[0, 0] = 10.5m,
			[1, 0] = 20.5m,
			[0, 1] = 30.5m,
			[1, 1] = 40.5m
		};

		decimal sum = grid.Sum();

		sum.ShouldBe(102.0m);
	}

	[Fact]
	public void Sum_WithFloatGrid_ShouldReturnSum() {
		Grid<float> grid = new(2, 2) {
			[0, 0] = 1.5f,
			[1, 0] = 2.5f,
			[0, 1] = 3.5f,
			[1, 1] = 4.5f
		};

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
		Grid<double> grid = new(2, 2) {
			[0, 0] = 5.5,
			[1, 0] = 2.3,
			[0, 1] = 7.1,
			[1, 1] = 1.9
		};

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
		Grid<double> grid = new(2, 2) {
			[0, 0] = 5.5,
			[1, 0] = 2.3,
			[0, 1] = 7.1,
			[1, 1] = 1.9
		};

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
		Grid<int> grid = new(2, 2) {
			[0, 0] = 2,
			[1, 0] = 4,
			[0, 1] = 6,
			[1, 1] = 8
		};

		int average = grid.Average();

		average.ShouldBe(5);
	}

	[Fact]
	public void Average_WithDoubleGrid_ShouldReturnAverage() {
		Grid<double> grid = new(2, 2) {
			[0, 0] = 1.0,
			[1, 0] = 2.0,
			[0, 1] = 3.0,
			[1, 1] = 4.0
		};

		double average = grid.Average();

		average.ShouldBe(2.5);
	}

	[Fact]
	public void Average_WithDecimalGrid_ShouldReturnAverage() {
		Grid<decimal> grid = new(2, 2) {
			[0, 0] = 10.0m,
			[1, 0] = 20.0m,
			[0, 1] = 30.0m,
			[1, 1] = 40.0m
		};

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

	[Fact]
	public void ScalarMultiply_ShouldMultiplyAllElements() {
		Grid<int> grid = new(2, 2) {
			[0, 0] = 2,
			[1, 0] = 3,
			[0, 1] = 4,
			[1, 1] = 5
		};

		Grid<int> result = grid.ScalarMultiply(3);

		result[0, 0].ShouldBe(6);
		result[1, 0].ShouldBe(9);
		result[0, 1].ShouldBe(12);
		result[1, 1].ShouldBe(15);
	}

	[Fact]
	public void ScalarDivide_ShouldDivideAllElements() {
		Grid<int> grid = new(2, 2) {
			[0, 0] = 10,
			[1, 0] = 20,
			[0, 1] = 30,
			[1, 1] = 40
		};

		Grid<int> result = grid.ScalarDivide(10);

		result[0, 0].ShouldBe(1);
		result[1, 0].ShouldBe(2);
		result[0, 1].ShouldBe(3);
		result[1, 1].ShouldBe(4);
	}

	[Fact]
	public void ScalarAdd_ShouldAddToAllElements() {
		Grid<int> grid = new(2, 2) {
			[0, 0] = 1,
			[1, 0] = 2,
			[0, 1] = 3,
			[1, 1] = 4
		};

		Grid<int> result = grid.ScalarAdd(10);

		result[0, 0].ShouldBe(11);
		result[1, 0].ShouldBe(12);
		result[0, 1].ShouldBe(13);
		result[1, 1].ShouldBe(14);
	}

	[Fact]
	public void ScalarSubtract_ShouldSubtractFromAllElements() {
		Grid<int> grid = new(2, 2) {
			[0, 0] = 20,
			[1, 0] = 30,
			[0, 1] = 40,
			[1, 1] = 50
		};

		Grid<int> result = grid.ScalarSubtract(5);

		result[0, 0].ShouldBe(15);
		result[1, 0].ShouldBe(25);
		result[0, 1].ShouldBe(35);
		result[1, 1].ShouldBe(45);
	}

	[Fact]
	public void Add_ShouldAddCorrespondingElements() {
		Grid<int> grid1 = new(2, 2) {
			[0, 0] = 1,
			[1, 0] = 2,
			[0, 1] = 3,
			[1, 1] = 4
		};

		Grid<int> grid2 = new(2, 2) {
			[0, 0] = 10,
			[1, 0] = 20,
			[0, 1] = 30,
			[1, 1] = 40
		};

		Grid<int> result = grid1.Add(grid2);

		result[0, 0].ShouldBe(11);
		result[1, 0].ShouldBe(22);
		result[0, 1].ShouldBe(33);
		result[1, 1].ShouldBe(44);
	}

	[Fact]
	public void Add_WithDifferentDimensions_ShouldThrow() {
		Grid<int> grid1 = new(2, 2);
		Grid<int> grid2 = new(3, 2);

		Should.Throw<ArgumentException>(() => grid1.Add(grid2));
	}

	[Fact]
	public void Subtract_ShouldSubtractCorrespondingElements() {
		Grid<int> grid1 = new(2, 2) {
			[0, 0] = 10,
			[1, 0] = 20,
			[0, 1] = 30,
			[1, 1] = 40
		};

		Grid<int> grid2 = new(2, 2) {
			[0, 0] = 1,
			[1, 0] = 2,
			[0, 1] = 3,
			[1, 1] = 4
		};

		Grid<int> result = grid1.Subtract(grid2);

		result[0, 0].ShouldBe(9);
		result[1, 0].ShouldBe(18);
		result[0, 1].ShouldBe(27);
		result[1, 1].ShouldBe(36);
	}

	[Fact]
	public void Subtract_WithDifferentDimensions_ShouldThrow() {
		Grid<int> grid1 = new(2, 2);
		Grid<int> grid2 = new(2, 3);

		Should.Throw<ArgumentException>(() => grid1.Subtract(grid2));
	}

	[Fact]
	public void Multiply_ShouldMultiplyCorrespondingElements() {
		Grid<int> grid1 = new(2, 2) {
			[0, 0] = 2,
			[1, 0] = 3,
			[0, 1] = 4,
			[1, 1] = 5
		};

		Grid<int> grid2 = new(2, 2) {
			[0, 0] = 10,
			[1, 0] = 10,
			[0, 1] = 10,
			[1, 1] = 10
		};

		Grid<int> result = grid1.Multiply(grid2);

		result[0, 0].ShouldBe(20);
		result[1, 0].ShouldBe(30);
		result[0, 1].ShouldBe(40);
		result[1, 1].ShouldBe(50);
	}

	[Fact]
	public void Multiply_WithDifferentDimensions_ShouldThrow() {
		Grid<int> grid1 = new(2, 2);
		Grid<int> grid2 = new(3, 3);

		Should.Throw<ArgumentException>(() => grid1.Multiply(grid2));
	}

	[Fact]
	public void Divide_ShouldDivideCorrespondingElements() {
		Grid<int> grid1 = new(2, 2) {
			[0, 0] = 20,
			[1, 0] = 30,
			[0, 1] = 40,
			[1, 1] = 50
		};

		Grid<int> grid2 = new(2, 2) {
			[0, 0] = 2,
			[1, 0] = 3,
			[0, 1] = 4,
			[1, 1] = 5
		};

		Grid<int> result = grid1.Divide(grid2);

		result[0, 0].ShouldBe(10);
		result[1, 0].ShouldBe(10);
		result[0, 1].ShouldBe(10);
		result[1, 1].ShouldBe(10);
	}

	[Fact]
	public void Divide_WithDifferentDimensions_ShouldThrow() {
		Grid<int> grid1 = new(2, 2);
		Grid<int> grid2 = new(2, 3);

		Should.Throw<ArgumentException>(() => grid1.Divide(grid2));
	}

	[Fact]
	public void OperatorMultiply_WithScalar_ShouldWork() {
		Grid<int> grid = new(2, 2) {
			[0, 0] = 2,
			[1, 0] = 3,
			[0, 1] = 4,
			[1, 1] = 5
		};

		Grid<int> result = grid * 3;

		result[0, 0].ShouldBe(6);
		result[1, 1].ShouldBe(15);
	}

	[Fact]
	public void OperatorMultiply_WithScalarOnLeft_ShouldWork() {
		Grid<int> grid = new(2, 2) {
			[0, 0] = 2,
			[1, 0] = 3,
			[0, 1] = 4,
			[1, 1] = 5
		};

		Grid<int> result = 3 * grid;

		result[0, 0].ShouldBe(6);
		result[1, 1].ShouldBe(15);
	}

	[Fact]
	public void OperatorDivide_WithScalar_ShouldWork() {
		Grid<int> grid = new(2, 2) {
			[0, 0] = 10,
			[1, 0] = 20,
			[0, 1] = 30,
			[1, 1] = 40
		};

		Grid<int> result = grid / 10;

		result[0, 0].ShouldBe(1);
		result[1, 1].ShouldBe(4);
	}

	[Fact]
	public void OperatorAdd_WithScalar_ShouldWork() {
		Grid<int> grid = new(2, 2) {
			[0, 0] = 1,
			[1, 0] = 2,
			[0, 1] = 3,
			[1, 1] = 4
		};

		Grid<int> result = grid + 10;

		result[0, 0].ShouldBe(11);
		result[1, 1].ShouldBe(14);
	}

	[Fact]
	public void OperatorAdd_WithScalarOnLeft_ShouldWork() {
		Grid<int> grid = new(2, 2) {
			[0, 0] = 1,
			[1, 0] = 2,
			[0, 1] = 3,
			[1, 1] = 4
		};

		Grid<int> result = 10 + grid;

		result[0, 0].ShouldBe(11);
		result[1, 1].ShouldBe(14);
	}

	[Fact]
	public void OperatorSubtract_WithScalar_ShouldWork() {
		Grid<int> grid = new(2, 2) {
			[0, 0] = 20,
			[1, 0] = 30,
			[0, 1] = 40,
			[1, 1] = 50
		};

		Grid<int> result = grid - 5;

		result[0, 0].ShouldBe(15);
		result[1, 1].ShouldBe(45);
	}

	[Fact]
	public void OperatorAdd_WithTwoGrids_ShouldWork() {
		Grid<int> grid1 = new(2, 2) {
			[0, 0] = 1,
			[1, 0] = 2,
			[0, 1] = 3,
			[1, 1] = 4
		};

		Grid<int> grid2 = new(2, 2) {
			[0, 0] = 10,
			[1, 0] = 20,
			[0, 1] = 30,
			[1, 1] = 40
		};

		Grid<int> result = grid1 + grid2;

		result[0, 0].ShouldBe(11);
		result[1, 1].ShouldBe(44);
	}

	[Fact]
	public void OperatorSubtract_WithTwoGrids_ShouldWork() {
		Grid<int> grid1 = new(2, 2) {
			[0, 0] = 10,
			[1, 0] = 20,
			[0, 1] = 30,
			[1, 1] = 40
		};

		Grid<int> grid2 = new(2, 2) {
			[0, 0] = 1,
			[1, 0] = 2,
			[0, 1] = 3,
			[1, 1] = 4
		};

		Grid<int> result = grid1 - grid2;

		result[0, 0].ShouldBe(9);
		result[1, 1].ShouldBe(36);
	}

	[Fact]
	public void Array_ScalarMultiply_ShouldWork() {
		int[,] array = new int[2, 2];
		array[0, 0] = 2;
		array[1, 0] = 3;
		array[0, 1] = 4;
		array[1, 1] = 5;

		int[,] result = array.ScalarMultiply(2);

		result[0, 0].ShouldBe(4);
		result[1, 1].ShouldBe(10);
	}

	[Fact]
	public void Array_Add_ShouldWork() {
		int[,] array1 = new int[2, 2];
		array1[0, 0] = 1;
		array1[1, 0] = 2;
		array1[0, 1] = 3;
		array1[1, 1] = 4;

		int[,] array2 = new int[2, 2];
		array2[0, 0] = 10;
		array2[1, 0] = 20;
		array2[0, 1] = 30;
		array2[1, 1] = 40;

		int[,] result = array1.Add(array2);

		result[0, 0].ShouldBe(11);
		result[1, 1].ShouldBe(44);
	}

	[Fact]
	public void Array_Multiply_ShouldWork() {
		int[,] array1 = new int[2, 2];
		array1[0, 0] = 2;
		array1[1, 0] = 3;
		array1[0, 1] = 4;
		array1[1, 1] = 5;

		int[,] array2 = new int[2, 2];
		array2[0, 0] = 10;
		array2[1, 0] = 10;
		array2[0, 1] = 10;
		array2[1, 1] = 10;

		int[,] result = array1.Multiply(array2);

		result[0, 0].ShouldBe(20);
		result[1, 1].ShouldBe(50);
	}

	// ========================================
	// Feature 7: Concatenation Tests
	// ========================================

	[Fact]
	public void ConcatRight_ShouldCombineGridsHorizontally() {
		Grid<int> left = new(2, 2) {
			[0, 0] = 1,
			[1, 0] = 2,
			[0, 1] = 3,
			[1, 1] = 4
		};

		Grid<int> right = new(2, 2) {
			[0, 0] = 5,
			[1, 0] = 6,
			[0, 1] = 7,
			[1, 1] = 8
		};

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
		Grid<int> top = new(2, 2) {
			[0, 0] = 1,
			[1, 0] = 2,
			[0, 1] = 3,
			[1, 1] = 4
		};

		Grid<int> bottom = new(2, 2) {
			[0, 0] = 5,
			[1, 0] = 6,
			[0, 1] = 7,
			[1, 1] = 8
		};

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
		Grid<int> left = new(1, 3) {
			[0, 0] = 1,
			[0, 1] = 2,
			[0, 2] = 3
		};

		Grid<int> right = new(2, 3) {
			[0, 0] = 4,
			[1, 0] = 5,
			[0, 1] = 6,
			[1, 1] = 7,
			[0, 2] = 8,
			[1, 2] = 9
		};

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

	// ========================================
	// Row/Column Aggregation Tests
	// ========================================

	[Fact]
	public void RowSums_ShouldReturnSumForEachRow() {
		Grid<int> grid = new(3, 3) {
			[0, 0] = 1,
			[1, 0] = 2,
			[2, 0] = 3,
			[0, 1] = 4,
			[1, 1] = 5,
			[2, 1] = 6,
			[0, 2] = 7,
			[1, 2] = 8,
			[2, 2] = 9
		};

		List<int> rowSums = [.. grid.RowSums()];

		rowSums.Count.ShouldBe(3);
		rowSums[0].ShouldBe(6);  // 1 + 2 + 3
		rowSums[1].ShouldBe(15); // 4 + 5 + 6
		rowSums[2].ShouldBe(24); // 7 + 8 + 9
	}

	[Fact]
	public void RowSums_WithSingleColumn_ShouldReturnEachValue() {
		Grid<int> grid = new(1, 3) {
			[0, 0] = 5,
			[0, 1] = 10,
			[0, 2] = 15
		};

		List<int> rowSums = [.. grid.RowSums()];

		rowSums.ShouldBe([5, 10, 15]);
	}

	[Fact]
	public void RowSums_WithZeroColumns_ShouldReturnZeros() {
		Grid<int> grid = new(0, 3);

		List<int> rowSums = [.. grid.RowSums()];

		rowSums.Count.ShouldBe(3);
		rowSums.All(x => x == 0).ShouldBeTrue();
	}

	[Fact]
	public void ColSums_ShouldReturnSumForEachColumn() {
		Grid<int> grid = new(3, 3) {
			[0, 0] = 1,
			[1, 0] = 2,
			[2, 0] = 3,
			[0, 1] = 4,
			[1, 1] = 5,
			[2, 1] = 6,
			[0, 2] = 7,
			[1, 2] = 8,
			[2, 2] = 9
		};

		List<int> colSums = [.. grid.ColSums()];

		colSums.Count.ShouldBe(3);
		colSums[0].ShouldBe(12); // 1 + 4 + 7
		colSums[1].ShouldBe(15); // 2 + 5 + 8
		colSums[2].ShouldBe(18); // 3 + 6 + 9
	}

	[Fact]
	public void ColSums_WithSingleRow_ShouldReturnEachValue() {
		Grid<int> grid = new(3, 1) {
			[0, 0] = 5,
			[1, 0] = 10,
			[2, 0] = 15
		};

		List<int> colSums = [.. grid.ColSums()];

		colSums.ShouldBe([5, 10, 15]);
	}

	[Fact]
	public void ColSums_WithZeroRows_ShouldReturnZeros() {
		Grid<int> grid = new(3, 0);

		List<int> colSums = [.. grid.ColSums()];

		colSums.Count.ShouldBe(3);
		colSums.All(x => x == 0).ShouldBeTrue();
	}

	[Fact]
	public void RowAverages_ShouldReturnAverageForEachRow() {
		Grid<double> grid = new(3, 2) {
			[0, 0] = 1.0,
			[1, 0] = 2.0,
			[2, 0] = 3.0,
			[0, 1] = 4.0,
			[1, 1] = 5.0,
			[2, 1] = 6.0
		};

		List<double> rowAverages = [.. grid.RowAverages()];

		rowAverages.Count.ShouldBe(2);
		rowAverages[0].ShouldBe(2.0); // (1 + 2 + 3) / 3
		rowAverages[1].ShouldBe(5.0); // (4 + 5 + 6) / 3
	}

	[Fact]
	public void RowAverages_WithZeroColumns_ShouldThrow() {
		Grid<int> grid = new(0, 3);

		Should.Throw<InvalidOperationException>(() => grid.RowAverages().ToList());
	}

	[Fact]
	public void ColAverages_ShouldReturnAverageForEachColumn() {
		Grid<double> grid = new(2, 3) {
			[0, 0] = 1.0,
			[1, 0] = 4.0,
			[0, 1] = 2.0,
			[1, 1] = 5.0,
			[0, 2] = 3.0,
			[1, 2] = 6.0
		};

		List<double> colAverages = [.. grid.ColAverages()];

		colAverages.Count.ShouldBe(2);
		colAverages[0].ShouldBe(2.0); // (1 + 2 + 3) / 3
		colAverages[1].ShouldBe(5.0); // (4 + 5 + 6) / 3
	}

	[Fact]
	public void ColAverages_WithZeroRows_ShouldThrow() {
		Grid<int> grid = new(3, 0);

		Should.Throw<InvalidOperationException>(() => grid.ColAverages().ToList());
	}

	[Fact]
	public void RowMins_ShouldReturnMinimumForEachRow() {
		Grid<int> grid = new(3, 3) {
			[0, 0] = 5,
			[1, 0] = 2,
			[2, 0] = 8,
			[0, 1] = 1,
			[1, 1] = 9,
			[2, 1] = 3,
			[0, 2] = 7,
			[1, 2] = 4,
			[2, 2] = 6
		};

		List<int> rowMins = [.. grid.RowMins()];

		rowMins.Count.ShouldBe(3);
		rowMins[0].ShouldBe(2); // min(5, 2, 8)
		rowMins[1].ShouldBe(1); // min(1, 9, 3)
		rowMins[2].ShouldBe(4); // min(7, 4, 6)
	}

	[Fact]
	public void RowMins_WithZeroColumns_ShouldThrow() {
		Grid<int> grid = new(0, 3);

		Should.Throw<InvalidOperationException>(() => grid.RowMins().ToList());
	}

	[Fact]
	public void RowMaxs_ShouldReturnMaximumForEachRow() {
		Grid<int> grid = new(3, 3) {
			[0, 0] = 5,
			[1, 0] = 2,
			[2, 0] = 8,
			[0, 1] = 1,
			[1, 1] = 9,
			[2, 1] = 3,
			[0, 2] = 7,
			[1, 2] = 4,
			[2, 2] = 6
		};

		List<int> rowMaxs = [.. grid.RowMaxs()];

		rowMaxs.Count.ShouldBe(3);
		rowMaxs[0].ShouldBe(8); // max(5, 2, 8)
		rowMaxs[1].ShouldBe(9); // max(1, 9, 3)
		rowMaxs[2].ShouldBe(7); // max(7, 4, 6)
	}

	[Fact]
	public void RowMaxs_WithZeroColumns_ShouldThrow() {
		Grid<int> grid = new(0, 3);

		Should.Throw<InvalidOperationException>(() => grid.RowMaxs().ToList());
	}

	[Fact]
	public void ColMins_ShouldReturnMinimumForEachColumn() {
		Grid<int> grid = new(3, 3) {
			[0, 0] = 5,
			[1, 0] = 2,
			[2, 0] = 8,
			[0, 1] = 1,
			[1, 1] = 9,
			[2, 1] = 3,
			[0, 2] = 7,
			[1, 2] = 4,
			[2, 2] = 6
		};

		List<int> colMins = [.. grid.ColMins()];

		colMins.Count.ShouldBe(3);
		colMins[0].ShouldBe(1); // min(5, 1, 7)
		colMins[1].ShouldBe(2); // min(2, 9, 4)
		colMins[2].ShouldBe(3); // min(8, 3, 6)
	}

	[Fact]
	public void ColMins_WithZeroRows_ShouldThrow() {
		Grid<int> grid = new(3, 0);

		Should.Throw<InvalidOperationException>(() => grid.ColMins().ToList());
	}

	[Fact]
	public void ColMaxs_ShouldReturnMaximumForEachColumn() {
		Grid<int> grid = new(3, 3) {
			[0, 0] = 5,
			[1, 0] = 2,
			[2, 0] = 8,
			[0, 1] = 1,
			[1, 1] = 9,
			[2, 1] = 3,
			[0, 2] = 7,
			[1, 2] = 4,
			[2, 2] = 6
		};

		List<int> colMaxs = [.. grid.ColMaxs()];

		colMaxs.Count.ShouldBe(3);
		colMaxs[0].ShouldBe(7); // max(5, 1, 7)
		colMaxs[1].ShouldBe(9); // max(2, 9, 4)
		colMaxs[2].ShouldBe(8); // max(8, 3, 6)
	}

	[Fact]
	public void ColMaxs_WithZeroRows_ShouldThrow() {
		Grid<int> grid = new(3, 0);

		Should.Throw<InvalidOperationException>(() => grid.ColMaxs().ToList());
	}

	[Fact]
	public void RowSums_WithDoubleGrid_ShouldWork() {
		Grid<double> grid = new(2, 2) {
			[0, 0] = 1.5,
			[1, 0] = 2.5,
			[0, 1] = 3.5,
			[1, 1] = 4.5
		};

		List<double> rowSums = [.. grid.RowSums()];

		rowSums[0].ShouldBe(4.0);
		rowSums[1].ShouldBe(8.0);
	}

	[Fact]
	public void ColSums_WithDecimalGrid_ShouldWork() {
		Grid<decimal> grid = new(2, 2) {
			[0, 0] = 10.5m,
			[1, 0] = 20.5m,
			[0, 1] = 30.5m,
			[1, 1] = 40.5m
		};

		List<decimal> colSums = [.. grid.ColSums()];

		colSums[0].ShouldBe(41.0m);
		colSums[1].ShouldBe(61.0m);
	}

	// ========================================
	// Cumulative Operations Tests
	// ========================================

	[Fact]
	public void CumulativeSum_ShouldReturnRunningSum() {
		Grid<int> grid = new(3, 2) {
			[0, 0] = 1,
			[1, 0] = 2,
			[2, 0] = 3,
			[0, 1] = 4,
			[1, 1] = 5,
			[2, 1] = 6
		};

		Grid<int> result = grid.CumulativeSum();

		result.ColsCount.ShouldBe(3);
		result.RowsCount.ShouldBe(2);
		result[0, 0].ShouldBe(1);  // 1
		result[1, 0].ShouldBe(3);  // 1 + 2
		result[2, 0].ShouldBe(6);  // 1 + 2 + 3
		result[0, 1].ShouldBe(10); // 1 + 2 + 3 + 4
		result[1, 1].ShouldBe(15); // 1 + 2 + 3 + 4 + 5
		result[2, 1].ShouldBe(21); // 1 + 2 + 3 + 4 + 5 + 6
	}

	[Fact]
	public void CumulativeSum_WithDoubleGrid_ShouldWork() {
		Grid<double> grid = new(2, 2) {
			[0, 0] = 1.5,
			[1, 0] = 2.5,
			[0, 1] = 3.5,
			[1, 1] = 4.5
		};

		Grid<double> result = grid.CumulativeSum();

		result[0, 0].ShouldBe(1.5);
		result[1, 0].ShouldBe(4.0);
		result[0, 1].ShouldBe(7.5);
		result[1, 1].ShouldBe(12.0);
	}

	[Fact]
	public void CumulativeSum_WithSingleElement_ShouldReturnSameValue() {
		Grid<int> grid = new(1, 1) {
			[0, 0] = 42
		};

		Grid<int> result = grid.CumulativeSum();

		result[0, 0].ShouldBe(42);
	}

	[Fact]
	public void CumulativeSum_WithEmptyGrid_ShouldReturnEmptyGrid() {
		Grid<int> grid = new(0, 0);

		Grid<int> result = grid.CumulativeSum();

		result.ColsCount.ShouldBe(0);
		result.RowsCount.ShouldBe(0);
	}

	[Fact]
	public void CumulativeProduct_ShouldReturnRunningProduct() {
		Grid<int> grid = new(3, 2) {
			[0, 0] = 1,
			[1, 0] = 2,
			[2, 0] = 3,
			[0, 1] = 4,
			[1, 1] = 5,
			[2, 1] = 6
		};

		Grid<int> result = grid.CumulativeProduct();

		result.ColsCount.ShouldBe(3);
		result.RowsCount.ShouldBe(2);
		result[0, 0].ShouldBe(1);    // 1
		result[1, 0].ShouldBe(2);    // 1 * 2
		result[2, 0].ShouldBe(6);    // 1 * 2 * 3
		result[0, 1].ShouldBe(24);   // 1 * 2 * 3 * 4
		result[1, 1].ShouldBe(120);  // 1 * 2 * 3 * 4 * 5
		result[2, 1].ShouldBe(720);  // 1 * 2 * 3 * 4 * 5 * 6
	}

	[Fact]
	public void CumulativeProduct_WithDoubleGrid_ShouldWork() {
		Grid<double> grid = new(2, 2) {
			[0, 0] = 2.0,
			[1, 0] = 3.0,
			[0, 1] = 4.0,
			[1, 1] = 5.0
		};

		Grid<double> result = grid.CumulativeProduct();

		result[0, 0].ShouldBe(2.0);
		result[1, 0].ShouldBe(6.0);
		result[0, 1].ShouldBe(24.0);
		result[1, 1].ShouldBe(120.0);
	}

	[Fact]
	public void CumulativeProduct_WithSingleElement_ShouldReturnSameValue() {
		Grid<int> grid = new(1, 1) {
			[0, 0] = 7
		};

		Grid<int> result = grid.CumulativeProduct();

		result[0, 0].ShouldBe(7);
	}

	[Fact]
	public void CumulativeProduct_WithEmptyGrid_ShouldReturnEmptyGrid() {
		Grid<int> grid = new(0, 0);

		Grid<int> result = grid.CumulativeProduct();

		result.ColsCount.ShouldBe(0);
		result.RowsCount.ShouldBe(0);
	}

	[Fact]
	public void CumulativeProduct_WithZero_ShouldMaintainZero() {
		Grid<int> grid = new(3, 1) {
			[0, 0] = 2,
			[1, 0] = 0,
			[2, 0] = 5
		};

		Grid<int> result = grid.CumulativeProduct();

		result[0, 0].ShouldBe(2);
		result[1, 0].ShouldBe(0);
		result[2, 0].ShouldBe(0);
	}

	[Fact]
	public void CumulativeSum_ShouldNotModifyOriginal() {
		Grid<int> original = new(2, 2) {
			[0, 0] = 1,
			[1, 0] = 2,
			[0, 1] = 3,
			[1, 1] = 4
		};

		Grid<int> cumulative = original.CumulativeSum();

		original[0, 0].ShouldBe(1);
		original[1, 1].ShouldBe(4);
		cumulative[1, 1].ShouldBe(10);
	}

	[Fact]
	public void CumulativeProduct_ShouldNotModifyOriginal() {
		Grid<int> original = new(2, 2) {
			[0, 0] = 2,
			[1, 0] = 3,
			[0, 1] = 4,
			[1, 1] = 5
		};

		Grid<int> cumulative = original.CumulativeProduct();

		original[0, 0].ShouldBe(2);
		original[1, 1].ShouldBe(5);
		cumulative[1, 1].ShouldBe(120);
	}
}
