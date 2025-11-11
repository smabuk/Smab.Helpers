namespace Smab.Helpers.Tests.GridHelperTests;

public class CubeTests {
	[Fact]
	public void Constructor_WithPositionAndValue_ShouldInitializeCorrectly() {
		Point3d position = new(1, 2, 3);
		int value = 42;

		Cube<int> cube = new(position, value);

		cube.Position.ShouldBe(position);
		cube.Value.ShouldBe(value);
		cube.X.ShouldBe(1);
		cube.Y.ShouldBe(2);
		cube.Z.ShouldBe(3);
	}

	[Fact]
	public void Constructor_WithCoordinatesAndValue_ShouldInitializeCorrectly() {
		Cube<int> cube = new(1, 2, 3, 42);

		cube.X.ShouldBe(1);
		cube.Y.ShouldBe(2);
		cube.Z.ShouldBe(3);
		cube.Value.ShouldBe(42);
	}

	[Fact]
	public void Constructor_WithTuple_ShouldInitializeCorrectly() {
		(int X, int Y, int Z, int Value) tuple = (1, 2, 3, 42);

		Cube<int> cube = new(tuple);

		cube.X.ShouldBe(1);
		cube.Y.ShouldBe(2);
		cube.Z.ShouldBe(3);
		cube.Value.ShouldBe(42);
	}

	[Fact]
	public void Deconstruct_ToPositionAndValue_ShouldWork() {
		Cube<int> cube = new(1, 2, 3, 42);

		(Point3d position, int value) = cube;

		position.X.ShouldBe(1);
		position.Y.ShouldBe(2);
		position.Z.ShouldBe(3);
		value.ShouldBe(42);
	}

	[Fact]
	public void Deconstruct_ToCoordinatesAndValue_ShouldWork() {
		Cube<int> cube = new(1, 2, 3, 42);

		cube.Deconstruct(out int x, out int y, out int z, out int value);

		x.ShouldBe(1);
		y.ShouldBe(2);
		z.ShouldBe(3);
		value.ShouldBe(42);
	}

	[Fact]
	public void ImplicitConversion_ToTuple_ShouldWork() {
		Cube<int> cube = new(1, 2, 3, 42);

		(int x, int y, int z, int value) tuple = cube;

		tuple.x.ShouldBe(1);
		tuple.y.ShouldBe(2);
		tuple.z.ShouldBe(3);
		tuple.value.ShouldBe(42);
	}

	[Fact]
	public void ImplicitConversion_ToValue_ShouldWork() {
		Cube<int> cube = new(1, 2, 3, 42);

		int value = cube;

		value.ShouldBe(42);
	}

	[Fact]
	public void ImplicitConversion_ToPoint3d_ShouldWork() {
		Cube<int> cube = new(1, 2, 3, 42);

		Point3d position = cube;

		position.X.ShouldBe(1);
		position.Y.ShouldBe(2);
		position.Z.ShouldBe(3);
	}

	[Fact]
	public void ImplicitConversion_ToCoordinateTuple_ShouldWork() {
		Cube<int> cube = new(1, 2, 3, 42);

		(int X, int Y, int Z) coordinates = cube;

		coordinates.X.ShouldBe(1);
		coordinates.Y.ShouldBe(2);
		coordinates.Z.ShouldBe(3);
	}

	[Fact]
	public void PropertyAccessors_ShouldReturnCorrectValues() {
		Cube<string> cube = new(5, 10, 15, "test");

		cube.X.ShouldBe(5);
		cube.Y.ShouldBe(10);
		cube.Z.ShouldBe(15);
		cube.Value.ShouldBe("test");
		cube.Position.X.ShouldBe(5);
		cube.Position.Y.ShouldBe(10);
		cube.Position.Z.ShouldBe(15);
	}

	[Fact]
	public void WithExpression_ShouldCreateNewInstanceWithModifiedValue() {
		Cube<int> original = new(1, 2, 3, 42);

		Cube<int> modified = original with { Value = 99 };

		modified.X.ShouldBe(1);
		modified.Y.ShouldBe(2);
		modified.Z.ShouldBe(3);
		modified.Value.ShouldBe(99);
		original.Value.ShouldBe(42);
	}

	[Fact]
	public void WithExpression_ShouldCreateNewInstanceWithModifiedPosition() {
		Cube<int> original = new(1, 2, 3, 42);
		Point3d newPosition = new(4, 5, 6);

		Cube<int> modified = original with { Position = newPosition };

		modified.X.ShouldBe(4);
		modified.Y.ShouldBe(5);
		modified.Z.ShouldBe(6);
		modified.Value.ShouldBe(42);
		original.Position.ShouldBe(new Point3d(1, 2, 3));
	}

	[Fact]
	public void Equality_WithSameValues_ShouldBeEqual() {
		Cube<int> cube1 = new(1, 2, 3, 42);
		Cube<int> cube2 = new(1, 2, 3, 42);

		cube1.ShouldBe(cube2);
	}

	[Fact]
	public void Equality_WithDifferentValues_ShouldNotBeEqual() {
		Cube<int> cube1 = new(1, 2, 3, 42);
		Cube<int> cube2 = new(1, 2, 3, 99);

		cube1.ShouldNotBe(cube2);
	}

	[Fact]
	public void Equality_WithDifferentPositions_ShouldNotBeEqual() {
		Cube<int> cube1 = new(1, 2, 3, 42);
		Cube<int> cube2 = new(4, 5, 6, 42);

		cube1.ShouldNotBe(cube2);
	}
}
