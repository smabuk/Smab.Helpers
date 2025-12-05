namespace Smab.Helpers.Tests.GridHelperTests;

public class SetValue(ITestOutputHelper testOutputHelper) {
	[Fact]
	public void SetValue_With_X_and_Y_Should_Succeed() {
		// Arrange
		int[,] grid = new int[5, 5];
		int expectedValue = 42;
		int x = 2;
		int y = 3;

		// Act
		grid.SetValue(expectedValue, x, y);
		int actualValue = grid.GetValue<int>(x, y);

		// Assert
		actualValue.ShouldBe(expectedValue);
	}

	[Theory]
	[InlineData(0, 0, 10)]
	[InlineData(1, 1, 20)]
	[InlineData(2, 3, 30)]
	[InlineData(4, 4, 40)]
	public void SetValue_WithVariousCoordinates_ShouldStoreCorrectValue(int x, int y, int value) {
		// Arrange
		int[,] grid = new int[5, 5];

		// Act
		grid.SetValue(value, x, y);
		int actual = grid.GetValue<int>(x, y);

		// Assert
		testOutputHelper.WriteLine($"Set value {value} at ({x},{y})");
		actual.ShouldBe(value);
	}

	[Fact]
	public void SetValue_AtTopLeft_ShouldSucceed() {
		// Arrange
		string[,] grid = new string[3, 3];
		string expected = "TopLeft";

		// Act
		grid.SetValue<string>(expected, 0, 0);
		string actual = grid.GetValue<string>(0, 0);

		// Assert
		actual.ShouldBe(expected);
	}

	[Fact]
	public void SetValue_AtBottomRight_ShouldSucceed() {
		// Arrange
		string[,] grid = new string[3, 3];
		string expected = "BottomRight";

		// Act
		grid.SetValue(expected, 2, 2);
		string actual = grid.GetValue<string>(2, 2);

		// Assert
		actual.ShouldBe(expected);
	}

	[Fact]
	public void SetValue_MultipleTimes_ShouldOverwritePreviousValue() {
		// Arrange
		int[,] grid = new int[3, 3];
		int x = 1;
		int y = 1;

		// Act
		grid.SetValue(100, x, y);
		grid.SetValue(200, x, y);
		int actual = grid.GetValue<int>(x, y);

		// Assert
		actual.ShouldBe(200);
	}

	[Fact]
	public void SetValue_WithReferenceType_ShouldStoreReference() {
		// Arrange
		List<int>[,] grid = new List<int>[2, 2];
		List<int> expected = [1, 2, 3];

		// Act
		grid.SetValue(expected, 0, 0);
		List<int> actual = grid.GetValue<List<int>>(0, 0);

		// Assert
		actual.ShouldBe(expected);
		actual.ShouldBeSameAs(expected);
	}
}
