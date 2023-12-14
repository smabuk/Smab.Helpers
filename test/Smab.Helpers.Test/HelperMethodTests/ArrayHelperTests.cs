using Xunit.Abstractions;

namespace Smab.Helpers.Test.HelperMethodTests;

public class ArrayHelperTests(ITestOutputHelper testOutputHelper) {
	[Theory]
	[InlineData(new int[] { 1, 2, 3, 4, 5, 6 }
		, 2, 3
		, 2, 3, 6)]
	[InlineData(new int[] { 1, 2, 3, 4, 5, 6 }
		, 3, 2
		, 3, 2, 6)]
	[InlineData(new int[] { 1, 2, 3, 4, 5, 6, 7, 8 }
		, 3, null
		, 3, 3, 9)]
	[InlineData(new int[] { 1, 2, 3, 4, 5, 6, 7, 8 }
		, 5, null
		, 5, 2, 10)]
	public void To2dArray_Int_Should_Have_Shape(int[] input, int cols, int? rows,
		int expectedCols, int expectedRows, int expectedLength) {
		int[,] array = input.To2dArray<int>(cols, rows);
		Assert.Equal(expectedLength, array.Length);
		Assert.Equal(expectedCols, array.GetUpperBound(0) + 1);
		Assert.Equal(expectedRows, array.GetUpperBound(1) + 1);
		Assert.Equal(expectedCols, array.NoOfColumns());
		Assert.Equal(expectedRows, array.NoOfRows());
	}

	[Fact]
	public void Create2dArray_ShouldBe() {
		char[,] array = ArrayHelpers.Create2dArray<char>(5, 10, 'x');
		Assert.Equal(5, array.GetUpperBound(0) + 1);
		Assert.Equal(10, array.GetUpperBound(1) + 1);
		Assert.Equal('x', array[0,0]);
		Assert.Equal('x', array[3,5]);
	}

	[Fact]
	public void To2dArray_String_To_Char() {
		string[] input = ["1234567890", "abcdefghij", "0987654321", "zyxwvutsrq"];
		char[,] array = input.To2dArray();
		Assert.Equal(40, array.Length);
		Assert.Equal(10, array.GetUpperBound(0) + 1);
		Assert.Equal( 4, array.GetUpperBound(1) + 1);
		Assert.Equal('1', array[0,0]);
		Assert.Equal('u', array[5,3]);
		Assert.Equal('d', array[3,1]);
		Assert.Equal('6', array[4,2]);
		Assert.Equal('t', array[6,3]);
	}

	[Fact]
	public void To2dArray_IEnumerableOf_IEnumerableOfT() {
		List<List<int>> inputOfT = [];
		for (int r = 0; r < 50; r+=10) {
			List<int> expectedRow = [r+1, r+2, r+3, r+4, r+5, r+6, r+7, r+8, r+9, r+10];
			inputOfT.Add(expectedRow);
		}

		int[,] array = inputOfT.To2dArray();

		Assert.Equal(50, array.Length);
		Assert.Equal(10, array.GetUpperBound(0) + 1);
		Assert.Equal( 5, array.GetUpperBound(1) + 1);
		Assert.Equal( 1, array[0,0]);
		Assert.Equal(34, array[3,3]);
		Assert.Equal(14, array[3,1]);
		Assert.Equal(25, array[4,2]);
		Assert.Equal(37, array[6,3]);
	}

	[Fact]
	public void To2dArray_Points_To_Char() {
		Point[] input = { new Point(1, 3), new Point(2, 4), new Point(3, 6) };
		char[,] array = input.To2dArray<char>(initial:' ', value: '#');
		Assert.Equal(28, array.Length);
		Assert.Equal(4, array.GetUpperBound(0) + 1);
		Assert.Equal(7, array.GetUpperBound(1) + 1);
		Assert.Equal(' ', array[0,0]);
		Assert.Equal(' ', array[3,5]);
		Assert.Equal('#', array[1,3]);
		Assert.Equal('#', array[2,4]);
		Assert.Equal('#', array[3,6]);
	}

	[Fact]
	public void To2dArray_Points_With_Negatives_To_Char() {
		Point[] input = { new Point(1, -3), new Point(2, 4), new Point(3, 6) };
		char[,] array = input.To2dArray<char>(initial:' ', value: '#');
		Assert.Equal(40, array.Length);
		Assert.Equal(4, array.GetUpperBound(0) + 1);
		Assert.Equal(10, array.GetUpperBound(1) + 1);
		Assert.Equal(' ', array[0,0]);
		Assert.Equal(' ', array[3,3]);
		Assert.Equal('#', array[1,0]);
		Assert.Equal('#', array[2,7]);
		Assert.Equal('#', array[3,9]);
	}

	[Fact]
	public void To2dArray_Tuple_Should_HaveShape() {
		(char, int)[] input = new (char, int)[8];
		for (int i = 0; i < input.GetUpperBound(0); i++) {
			input[i] = new((char)(65 + i), i + 1);
		}
		(char, int)[,] array = input.To2dArray<(char, int)>(4, 2);
		Assert.Equal(8, array.Length);
		Assert.Equal(4, array.GetUpperBound(0) + 1);
		Assert.Equal(2, array.GetUpperBound(1) + 1);
		Assert.Equal(('E', 5), array[0, 1]);

		Array.Clear(array);
		array = input.To2dArray<(char, int)>(2);
		Assert.Equal(8, array.Length);
		Assert.Equal(2, array.GetUpperBound(0) + 1);
		Assert.Equal(4, array.GetUpperBound(1) + 1);
		Assert.Equal(('C', 3), array[0, 1]);

		Array.Clear(array);
		array = input.To2dArray<(char, int)>(3);
		Assert.Equal(9, array.Length);
		Assert.Equal(3, array.GetUpperBound(0) + 1);
		Assert.Equal(3, array.GetUpperBound(1) + 1);
		Assert.Equal(('G', 7), array[0, 2]);
	}

	[Fact]
	public void Walk2dArray_Should_Walk_Across_Then_Down() {
		Point expectedPoint;
		(char, int)[] input = new (char, int)[26];
		for (int i = 0; i < input.GetUpperBound(0); i++) {
			input[i] = new((char)(65 + i), i + 1);
		}
		(char, int)[,] array = input.To2dArray<(char, int)>(5);
		expectedPoint = array.Walk2dArray().Select(p => new Point(p.X, p.Y)).Skip(7).First();
		Assert.Equal((2, 1), expectedPoint);
		(int x, int y, (char, int) value) = array.Walk2dArrayWithValues().Skip(7).First();
		Assert.Equal(2, x);
		Assert.Equal(1, y);
		Assert.Equal('H', value.Item1);
		Assert.Equal(8, value.Item2);
	}

	[Theory]
	[InlineData(0, 0, false, 2)]
	[InlineData(0, 0, true, 3)]
	[InlineData(1, 1, false, 4)]
	[InlineData(1, 1, true, 8)]
	public void GetAdjacentCells_Should_Have(int X, int Y, bool includeDiagonals, int expected) {
		(char, int)[] input = new (char, int)[26];
		for (int i = 0; i < input.GetUpperBound(0); i++) {
			input[i] = new((char)(65 + i), i + 1);
		}
		(char, int)[,] array = input.To2dArray<(char, int)>(5);
		var points = array.GetAdjacentCells((X, Y), includeDiagonals: includeDiagonals);
		Assert.Equal(points.Count(), expected);
	}

	[Theory]
	[InlineData(new int[] { 1, 2, 3, 4, 5, 6 }
		, 3, 2, 2
		, " 1 2 3")]
	[InlineData(new int[] { 1, 2, 3, 4, 5, 6 }
		, 2, 3, 4
		, "   1   2")]
	public void PrintAsStringArray_Int_Should_Have_Shape(int[] input, int cols, int? rows, int width, string expected) {
		string[] actual = input.To2dArray<int>(cols, rows).PrintAsStringArray<int>(width).ToArray();
		Assert.Equal(expected, actual[0]);
	}


	[Theory]
	[InlineData(new int[] { 1, 2, 3, 4, 5, 6 }
		, 3, 2, 2
		, " 1 2 3")]
	[InlineData(new int[] { 1, 2, 3, 4, 5, 6 }
		, 2, 3, 4
		, "   1   2")]
	public void PrintAsStringList_Int_Should_Have_Shape(int[] input, int cols, int? rows, int width, string expected) {
		List<string> actual = input.To2dArray<int>(cols, rows).PrintAsStringList<int>(width);
		Assert.Equal(expected, actual[0]);
	}

	[Theory]
	[InlineData(new int[] { 1, 2, 3, 4, 5, 6 }
		, 3, 2, 2
		, """
		 1 2 3
		 4 5 6
		""")]
	[InlineData(new int[] { 1, 2, 3, 4, 5, 6 }
		, 2, 3, 4
		, """
		   1   2
		   3   4
		   5   6
		""")]
	public void PrintAsString_Int_Should_Have_Shape(int[] input, int cols, int? rows, int width, string expected) {
		string actual = input.To2dArray<int>(cols, rows).PrintAsString<int>(width);
		Assert.Equal(expected, actual);
	}

	[Theory]
	[InlineData(new int[] { 2, 5, 4, 4, 4, 4, 3, 2, 2, 2 }, 3.2)]
	[InlineData(new int[] { 5 }, 5)]
	public void Should_Find_Mean(int[] input, double expected) {
		double actual = AverageHelpers.Mean<int>(input);
		Assert.Equal(expected, actual);
	}

	[Theory]
	[InlineData(new int[] { 2, 5, 4, 4, 4, 4, 3, 2, 2, 2 }, 3.5)]
	[InlineData(new int[] { 5, 1, 3 }, 3)]
	public void Should_Find_Median(int[] input, double expected) {
		double actual = AverageHelpers.MedianAsDouble<int>(input);
		Assert.Equal(expected, actual);
	}

	[Theory]
	[InlineData(new int[] { 1, 5, 4, 4, 4, 4, 3, 2, 2, 2 }, new int[] { 4 })]
	[InlineData(new int[] { 2, 5, 4, 4, 4, 4, 3, 2, 2, 2 }, new int[] { 2, 4 })]
	[InlineData(new int[] { 5, 1, 3 }, new int[] { 5, 1, 3 })]
	public void Should_Find_Mode(int[] input, int[] expected) {
		int[] actual = AverageHelpers.Modes(input).ToArray();
		Assert.Equal(expected, actual);
	}

	[Fact]
	public void Transpose_2dArray() {
		char[,] input = """
			# #
			## 
			"""
			.Split(Environment.NewLine)
			.To2dArray();

		char[,] actual = input.Transpose();
		actual.GetUpperBound(0).ShouldBe(1);
		actual.GetUpperBound(1).ShouldBe(2);
		actual[0,0].ShouldBe('#');
		actual[1,0].ShouldBe('#');
		actual[0,1].ShouldBe(' ');
		actual[1,1].ShouldBe('#');
		actual[0,2].ShouldBe('#');
		actual[1,2].ShouldBe(' ');
	}


	[Fact]
	public void Transpose_Strings() {
		List<string> actual = [.."""
			#.#
			##.
			"""
			.Split(Environment.NewLine)
			.Transpose()];

		actual[0].Length.ShouldBe(2);
		actual.Count.ShouldBe(3);
		actual[0].ShouldBe("##");
		actual[1].ShouldBe(".#");
		actual[2].ShouldBe("#.");
	}

	[Fact]
	public void Rotate_String() {
		string input = """
			A.B.1
			CD..2
			E.FG.
			HIJ.3
			""";

		testOutputHelper.WriteLine("Rotate 0   - testing");
		string actual = input.Rotate(0);
		actual.ShouldBe(input);
		testOutputHelper.WriteLine("Rotate 0   - passed");

		testOutputHelper.WriteLine("Rotate 90  - testing");
		actual = input.Rotate(90);
		actual.ShouldBe("""
				HECA
				I.D.
				JF.B
				.G..
				3.21
				""");
		testOutputHelper.WriteLine("Rotate 90  - passed");

		testOutputHelper.WriteLine("Rotate 180 - testing");
		actual = input.Rotate(180);
		actual.ShouldBe("""
				3.JIH
				.GF.E
				2..DC
				1.B.A
				""");
		testOutputHelper.WriteLine("Rotate 180 - passed");

		testOutputHelper.WriteLine("Rotate 270 - testing");
		actual = input.Rotate(270);
		actual.ShouldBe("""
				12.3
				..G.
				B.FJ
				.D.I
				ACEH
				""");
		testOutputHelper.WriteLine("Rotate 270 - passed");

		testOutputHelper.WriteLine("Rotate -90 - testing");
		actual = input.Rotate(-90);
		actual.ShouldBe("""
				12.3
				..G.
				B.FJ
				.D.I
				ACEH
				""");
		testOutputHelper.WriteLine("Rotate -90 - passed");
	}


	[Fact]
	public void Rotate_2dArray() {
		string input = """
			A.B.1
			CD..2
			E.FG.
			HIJ.3
			""";

		testOutputHelper.WriteLine("Rotate 0   - testing");
		char[,] actual = input.Split(Environment.NewLine).To2dArray().Rotate(0);
		actual.PrintAsString(0).ShouldBe(input);
		testOutputHelper.WriteLine("Rotate 0   - passed");

		testOutputHelper.WriteLine("Rotate 90  - testing");
		actual = input.Split(Environment.NewLine).To2dArray().Rotate(90);
		actual.PrintAsString(0)
			.ShouldBe("""
				HECA
				I.D.
				JF.B
				.G..
				3.21
				""");
		testOutputHelper.WriteLine("Rotate 90  - passed");

		testOutputHelper.WriteLine("Rotate 180 - testing");
		actual = input.Split(Environment.NewLine).To2dArray().Rotate(180);
		actual.PrintAsString(0)
			.ShouldBe("""
				3.JIH
				.GF.E
				2..DC
				1.B.A
				""");
		testOutputHelper.WriteLine("Rotate 180 - passed");

		testOutputHelper.WriteLine("Rotate 270 - testing");
		actual = input.Split(Environment.NewLine).To2dArray().Rotate(270);
		actual.PrintAsString(0)
			.ShouldBe("""
				12.3
				..G.
				B.FJ
				.D.I
				ACEH
				""");
		testOutputHelper.WriteLine("Rotate 270 - passed");

		testOutputHelper.WriteLine("Rotate -90 - testing");
		actual = input.Split(Environment.NewLine).To2dArray().Rotate(-90);
		actual.PrintAsString(0)
			.ShouldBe("""
				12.3
				..G.
				B.FJ
				.D.I
				ACEH
				""");
		testOutputHelper.WriteLine("Rotate -90 - passed");
	}


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
		char[,] input = """
			#.#
			##.
			"""
			.Split(Environment.NewLine)
			.To2dArray();

		input.RowAsString(0).ShouldBe("#.#");
		input.RowAsString(1).ShouldBe("##.");

		input.RowsAsStrings().ToList()[0].ShouldBe("#.#");
		input.RowsAsStrings().ToList()[1].ShouldBe("##.");
	}

	[Theory]
	[InlineData(0,    0, true)]
	[InlineData(11,  12, true)]
	[InlineData(99, 199, true)]
	[InlineData(100, 12, false)]
	[InlineData(12, 200, false)]
	[InlineData(-1,   0, false)]
	public void InBounds_ShouldBe(int x, int y, bool expected) {
		char[,] array = new char[100, 200]; // 0-99, 0-199

		array.InBounds(x, y).ShouldBe(expected);
		if (array.InBounds(x, y)) {
			Should.NotThrow(() => _ = array[x, y]);
		} else {
			Should.Throw<IndexOutOfRangeException>(() => _ = array[x, y])
			.Message
				.ShouldEndWith("Index was outside the bounds of the array.");
		}
	}

	[Theory]
	[InlineData(0,    0, false)]
	[InlineData(11,  12, false)]
	[InlineData(99, 199, false)]
	[InlineData(100, 12, true)]
	[InlineData(12, 200, true)]
	[InlineData(-1,   0, true)]
	public void OutOfBounds_ShouldBe(int x, int y, bool expected) {
		char[,] array = new char[100, 200]; // 0-99, 0-199

		array.OutOfBounds(x, y).ShouldBe(expected);
		if (array.OutOfBounds(x, y)) {
			Should.Throw<IndexOutOfRangeException>(() => _ = array[x, y])
			.Message
				.ShouldEndWith("Index was outside the bounds of the array.");
		} else {
			Should.NotThrow(() => _ = array[x, y]);
		}
	}
}
