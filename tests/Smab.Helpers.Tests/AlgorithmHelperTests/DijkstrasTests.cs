namespace Smab.Helpers.Tests.AlgorithmHelperTests;

public class DijkstrasTests {
	[Fact]
	public void DijkstrasBasedOnCellValue_WithSimpleGrid_ShouldFindShortestPath() {
		int[,] grid = new int[3, 3] {
			{ 1, 1, 1 },
			{ 1, 1, 1 },
			{ 1, 1, 1 }
		};
		Point start = new(0, 0);
		Point end = new(2, 2);

		Dictionary<Point, int> costs = AlgorithmicHelpers.DijkstrasBasedOnCellValue(grid, start, end);

		costs[start].ShouldBe(0);
		costs[end].ShouldBe(4); // 4 steps each costing 1
	}

	[Fact]
	public void DijkstrasBasedOnCellValue_StartEqualsEnd_ShouldHaveZeroCost() {
		int[,] grid = new int[3, 3] {
			{ 1, 1, 1 },
			{ 1, 1, 1 },
			{ 1, 1, 1 }
		};
		Point start = new(1, 1);
		Point end = new(1, 1);

		Dictionary<Point, int> costs = AlgorithmicHelpers.DijkstrasBasedOnCellValue(grid, start, end);

		costs[start].ShouldBe(0);
	}

	[Fact]
	public void DijkstrasBasedOnCellValue_WithDifferentCosts_ShouldFindOptimalPath() {
		int[,] grid = new int[3, 3] {
			{ 1, 5, 1 },
			{ 1, 5, 1 },
			{ 1, 1, 1 }
		};
		Point start = new(0, 0);
		Point end = new(2, 2);

		Dictionary<Point, int> costs = AlgorithmicHelpers.DijkstrasBasedOnCellValue(grid, start, end);

		costs[start].ShouldBe(0);
		costs.ShouldContainKey(end);
		// Should go around the high-cost cells
	}

	[Fact]
	public void DijkstrasBasedOnCellValue_WithStraightPath_ShouldCalculateCorrectCost() {
		int[,] grid = new int[1, 5] {
			{ 1, 2, 3, 4, 5 }
		};
		Point start = new(0, 0);
		Point end = new(0, 4);

		Dictionary<Point, int> costs = AlgorithmicHelpers.DijkstrasBasedOnCellValue(grid, start, end);

		costs[start].ShouldBe(0);
		costs.ShouldContainKey(end);
		costs[end].ShouldBe(14); // Sum of cells except start, including end
	}

	[Fact]
	public void DijkstrasBasedOnCellValue_WithLongType_ShouldWork() {
		long[,] grid = new long[3, 3] {
			{ 1L, 1L, 1L },
			{ 1L, 1L, 1L },
			{ 1L, 1L, 1L }
		};
		Point start = new(0, 0);
		Point end = new(2, 2);

		Dictionary<Point, long> costs = AlgorithmicHelpers.DijkstrasBasedOnCellValue(grid, start, end);

		costs[start].ShouldBe(0L);
		costs[end].ShouldBe(4L);
	}

	[Fact]
	public void DijkstrasBasedOnCellValue_WithDoubleType_ShouldWork() {
		double[,] grid = new double[3, 3] {
			{ 1.5, 1.5, 1.5 },
			{ 1.5, 1.5, 1.5 },
			{ 1.5, 1.5, 1.5 }
		};
		Point start = new(0, 0);
		Point end = new(2, 2);

		Dictionary<Point, double> costs = AlgorithmicHelpers.DijkstrasBasedOnCellValue(grid, start, end);

		costs[start].ShouldBe(0.0);
		costs[end].ShouldBe(6.0, 0.0001); // 4 steps each costing 1.5
	}

	[Fact]
	public void DijkstrasBasedOnCellValue_ShouldVisitAdjacentCellsOnly() {
		int[,] grid = new int[3, 3] {
			{ 1, 1, 1 },
			{ 1, 1, 1 },
			{ 1, 1, 1 }
		};
		Point start = new(1, 1);
		Point end = new(0, 0);

		Dictionary<Point, int> costs = AlgorithmicHelpers.DijkstrasBasedOnCellValue(grid, start, end);

		costs[start].ShouldBe(0);
		costs[new Point(0, 0)].ShouldBe(2); // Two steps to reach corner from center
	}

	[Fact]
	public void DijkstrasBasedOnCellValue_WithLargerGrid_ShouldCalculateCorrectly() {
		int[,] grid = new int[5, 5];
		for (int i = 0; i < 5; i++) {
			for (int j = 0; j < 5; j++) {
				grid[i, j] = 1;
			}
		}
		Point start = new(0, 0);
		Point end = new(4, 4);

		Dictionary<Point, int> costs = AlgorithmicHelpers.DijkstrasBasedOnCellValue(grid, start, end);

		costs[start].ShouldBe(0);
		costs[end].ShouldBe(8); // Minimum 8 steps to reach opposite corner
	}

	[Fact]
	public void DijkstrasBasedOnCellValue_ShouldIncludeStartInCosts() {
		int[,] grid = new int[2, 2] {
			{ 1, 1 },
			{ 1, 1 }
		};
		Point start = new(0, 0);
		Point end = new(1, 1);

		Dictionary<Point, int> costs = AlgorithmicHelpers.DijkstrasBasedOnCellValue(grid, start, end);

		costs.ShouldContainKey(start);
		costs[start].ShouldBe(0);
	}
}
