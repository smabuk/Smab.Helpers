namespace Smab.Helpers.Tests.GridHelperTests;

public class RowsAndColumns {
	[Fact]
	public void ColAsString() {
		char[,] input = """
			#.#
			##.
			"""
			.Split(Environment.NewLine)
			.To2dArray();

		input.ColAsString(0).ShouldBe("##");
		input.ColAsString(1).ShouldBe(".#");
		input.ColAsString(2).ShouldBe("#.");

		input.ColsAsStrings().ToList()[0].ShouldBe("##");
		input.ColsAsStrings().ToList()[1].ShouldBe(".#");
		input.ColsAsStrings().ToList()[2].ShouldBe("#.");
	}


	[Fact]
	public void RowAsString() {
		string[] input = [.."""
			#.#
			##.
			"""
			.Split(Environment.NewLine)];

		char[,] array = input.To2dArray();
		array.RowAsString(0).ShouldBe("#.#");
		array.RowAsString(1).ShouldBe("##.");

		input.RowAsString(0).ShouldBe("#.#");
		input.RowAsString(1).ShouldBe("##.");

		array.RowsAsStrings().ToList()[0].ShouldBe("#.#");
		array.RowsAsStrings().ToList()[1].ShouldBe("##.");
	}

	[Theory]
	[InlineData(0, 0, true)]
	[InlineData(11, 12, true)]
	[InlineData(99, 199, true)]
	[InlineData(100, 12, false)]
	[InlineData(12, 200, false)]
	[InlineData(-1, 0, false)]
	public void InBounds_ShouldBe(int x, int y, bool expected) {
		char[,] array = new char[100, 200]; // 0-99, 0-199

		array.IsInBounds(x, y).ShouldBe(expected);
		if (array.IsInBounds(x, y)) {
			Should.NotThrow(() => _ = array[x, y]);
		} else {
			Should.Throw<IndexOutOfRangeException>(() => _ = array[x, y])
			.Message
				.ShouldEndWith("Index was outside the bounds of the array.");
		}
		array.IsInBounds(new Point(x, y)).ShouldBe(expected);
	}

	[Theory]
	[InlineData(0, 0, false)]
	[InlineData(11, 12, false)]
	[InlineData(99, 199, false)]
	[InlineData(100, 12, true)]
	[InlineData(12, 200, true)]
	[InlineData(-1, 0, true)]
	public void OutOfBounds_ShouldBe(int x, int y, bool expected) {
		char[,] array = new char[100, 200]; // 0-99, 0-199

		array.IsOutOfBounds(x, y).ShouldBe(expected);
		if (array.IsOutOfBounds(x, y)) {
			Should.Throw<IndexOutOfRangeException>(() => _ = array[x, y])
			.Message
				.ShouldEndWith("Index was outside the bounds of the array.");
		} else {
			Should.NotThrow(() => _ = array[x, y]);
		}
		array.IsOutOfBounds(new Point(x, y)).ShouldBe(expected);
	}
}
