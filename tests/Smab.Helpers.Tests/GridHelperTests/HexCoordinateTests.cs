namespace Smab.Helpers.Tests.GridHelperTests;

public class HexCoordinateTests {
	[Theory]
	[InlineData(0, 0, 0, 0)]
	[InlineData(1, -1, 0, 1)]
	[InlineData(2, -1, -1, 2)]
	[InlineData(3, -2, -1, 3)]
	[InlineData(-1, 1, 0, 1)]
	[InlineData(-2, 1, 1, 2)]
	public void Distance_ShouldCalculateCorrectly(int x, int y, int z, int expectedDistance) {
		HexCoordinate coord = new(x, y, z);

		int distance = coord.Distance;

		distance.ShouldBe(expectedDistance);
	}

	[Fact]
	public void Step_North_ShouldMoveCorrectly() {
		HexCoordinate start = new(0, 0, 0);

		HexCoordinate result = start.Step(HexDirection.N);

		result.X.ShouldBe(0);
		result.Y.ShouldBe(1);
		result.Z.ShouldBe(-1);
	}

	[Fact]
	public void Step_South_ShouldMoveCorrectly() {
		HexCoordinate start = new(0, 0, 0);

		HexCoordinate result = start.Step(HexDirection.S);

		result.X.ShouldBe(0);
		result.Y.ShouldBe(-1);
		result.Z.ShouldBe(1);
	}

	[Fact]
	public void Step_NorthEast_ShouldMoveCorrectly() {
		HexCoordinate start = new(0, 0, 0);

		HexCoordinate result = start.Step(HexDirection.NE);

		result.X.ShouldBe(1);
		result.Y.ShouldBe(0);
		result.Z.ShouldBe(-1);
	}

	[Fact]
	public void Step_SouthWest_ShouldMoveCorrectly() {
		HexCoordinate start = new(0, 0, 0);

		HexCoordinate result = start.Step(HexDirection.SW);

		result.X.ShouldBe(-1);
		result.Y.ShouldBe(0);
		result.Z.ShouldBe(1);
	}

	[Fact]
	public void Step_NorthWest_ShouldMoveCorrectly() {
		HexCoordinate start = new(0, 0, 0);

		HexCoordinate result = start.Step(HexDirection.NW);

		result.X.ShouldBe(-1);
		result.Y.ShouldBe(1);
		result.Z.ShouldBe(0);
	}

	[Fact]
	public void Step_SouthEast_ShouldMoveCorrectly() {
		HexCoordinate start = new(0, 0, 0);

		HexCoordinate result = start.Step(HexDirection.SE);

		result.X.ShouldBe(1);
		result.Y.ShouldBe(-1);
		result.Z.ShouldBe(0);
	}

	[Theory]
	[InlineData(HexDirection.N, 2, 0, 2, -2)]
	[InlineData(HexDirection.S, 3, 0, -3, 3)]
	[InlineData(HexDirection.NE, 4, 4, 0, -4)]
	[InlineData(HexDirection.SW, 5, -5, 0, 5)]
	[InlineData(HexDirection.NW, 2, -2, 2, 0)]
	[InlineData(HexDirection.SE, 3, 3, -3, 0)]
	public void Step_WithDistance_ShouldMoveCorrectly(HexDirection direction, int distance, int expectedX, int expectedY, int expectedZ) {
		HexCoordinate start = new(0, 0, 0);

		HexCoordinate result = start.Step(direction, distance);

		result.X.ShouldBe(expectedX);
		result.Y.ShouldBe(expectedY);
		result.Z.ShouldBe(expectedZ);
	}

	[Theory]
	[InlineData(0, 0, 0)]
	[InlineData(1, -1, 0)]
	[InlineData(5, -3, -2)]
	[InlineData(-1, 1, 0)]
	[InlineData(-5, 3, 2)]
	public void CoordinateInvariant_XPlusYPlusZ_ShouldAlwaysBeZero(int x, int y, int z) {
		HexCoordinate coord = new(x, y, z);

		int sum = coord.X + coord.Y + coord.Z;

		sum.ShouldBe(0);
	}

	[Fact]
	public void Step_AfterMultipleSteps_ShouldMaintainCoordinateInvariant() {
		HexCoordinate coord = new(0, 0, 0);

		coord = coord.Step(HexDirection.N)
					 .Step(HexDirection.NE)
					 .Step(HexDirection.SE)
					 .Step(HexDirection.S)
					 .Step(HexDirection.SW)
					 .Step(HexDirection.NW);

		int sum = coord.X + coord.Y + coord.Z;
		sum.ShouldBe(0);
	}

	[Fact]
	public void Step_InvalidDirection_ShouldThrowNotImplementedException() {
		HexCoordinate coord = new(0, 0, 0);

		Should.Throw<NotImplementedException>(() => coord.Step(HexDirection.None));
	}

	[Fact]
	public void Step_OppositeDirections_ShouldReturnToOrigin() {
		HexCoordinate start = new(0, 0, 0);

		HexCoordinate result = start.Step(HexDirection.N, 5).Step(HexDirection.S, 5);

		result.X.ShouldBe(0);
		result.Y.ShouldBe(0);
		result.Z.ShouldBe(0);
	}
}
