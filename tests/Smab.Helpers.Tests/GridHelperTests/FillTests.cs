namespace Smab.Helpers.Tests.GridHelperTests;

public class FillTests {
	[Fact]
	public void Fill_ShouldCreateNewArrayWithAllElementsSetToValue() {
		int[,] original = new int[3, 3] {
			{ 1, 2, 3 },
			{ 4, 5, 6 },
			{ 7, 8, 9 }
		};

		int[,] result = original.Fill(0);

		for (int i = 0; i < 3; i++) {
			for (int j = 0; j < 3; j++) {
				result[i, j].ShouldBe(0);
			}
		}
	}

	[Fact]
	public void Fill_ShouldNotModifyOriginalArray() {
		int[,] original = new int[3, 3] {
			{ 1, 2, 3 },
			{ 4, 5, 6 },
			{ 7, 8, 9 }
		};
		int[,] originalCopy = (int[,])original.Clone();

		int[,] result = original.Fill(0);

		for (int i = 0; i < 3; i++) {
			for (int j = 0; j < 3; j++) {
				original[i, j].ShouldBe(originalCopy[i, j]);
			}
		}
	}

	[Fact]
	public void Fill_WithStrings_ShouldFillCorrectly() {
		string[,] original = new string[2, 2] {
			{ "a", "b" },
			{ "c", "d" }
		};

		string[,] result = original.Fill("x");

		result[0, 0].ShouldBe("x");
		result[0, 1].ShouldBe("x");
		result[1, 0].ShouldBe("x");
		result[1, 1].ShouldBe("x");
	}

	[Fact]
	public void Fill_WithDifferentValue_ShouldFillAllElements() {
		int[,] original = new int[2, 3] {
			{ 0, 0, 0 },
			{ 0, 0, 0 }
		};

		int[,] result = original.Fill(99);

		for (int i = 0; i < 2; i++) {
			for (int j = 0; j < 3; j++) {
				result[i, j].ShouldBe(99);
			}
		}
	}

	[Fact]
	public void FillInPlace_ShouldModifyOriginalArray() {
		int[,] array = new int[3, 3] {
			{ 1, 2, 3 },
			{ 4, 5, 6 },
			{ 7, 8, 9 }
		};

		array.FillInPlace(0);

		for (int i = 0; i < 3; i++) {
			for (int j = 0; j < 3; j++) {
				array[i, j].ShouldBe(0);
			}
		}
	}

	[Fact]
	public void FillInPlace_WithStrings_ShouldModifyOriginalArray() {
		string[,] array = new string[2, 2] {
			{ "a", "b" },
			{ "c", "d" }
		};

		array.FillInPlace("x");

		array[0, 0].ShouldBe("x");
		array[0, 1].ShouldBe("x");
		array[1, 0].ShouldBe("x");
		array[1, 1].ShouldBe("x");
	}

	[Fact]
	public void FillInPlace_WithDifferentValue_ShouldFillAllElements() {
		int[,] array = new int[2, 3] {
			{ 0, 0, 0 },
			{ 0, 0, 0 }
		};

		array.FillInPlace(42);

		for (int i = 0; i < 2; i++) {
			for (int j = 0; j < 3; j++) {
				array[i, j].ShouldBe(42);
			}
		}
	}

	[Fact]
	public void Fill_ShouldPreserveArrayDimensions() {
		int[,] original = new int[4, 5];

		int[,] result = original.Fill(1);

		result.GetLength(0).ShouldBe(4);
		result.GetLength(1).ShouldBe(5);
	}

	[Fact]
	public void FillInPlace_ShouldPreserveArrayDimensions() {
		int[,] array = new int[4, 5];

		array.FillInPlace(1);

		array.GetLength(0).ShouldBe(4);
		array.GetLength(1).ShouldBe(5);
	}

	[Fact]
	public void Fill_WithSingleElementArray_ShouldWork() {
		int[,] original = new int[1, 1] { { 5 } };

		int[,] result = original.Fill(10);

		result[0, 0].ShouldBe(10);
		original[0, 0].ShouldBe(5);
	}

	[Fact]
	public void FillInPlace_WithSingleElementArray_ShouldWork() {
		int[,] array = new int[1, 1] { { 5 } };

		array.FillInPlace(10);

		array[0, 0].ShouldBe(10);
	}
}
