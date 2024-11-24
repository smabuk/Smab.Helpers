namespace Smab.Helpers.Tests.GridHelperTests;
public class SubArray(ITestOutputHelper testOutputHelper) {

	private static readonly char[,] INPUT_ARRAY = """
		A.B.1
		CD..2
		E.FG.
		HIJ.3
		""".Split(Environment.NewLine).To2dArray();

	[Theory]
	[InlineData(0, 0, 3, 3, '.', """
		A.B
		CD.
		E.F
		""")]
	[InlineData(1, 1, 3, 3, '.', """
		D..
		.FG
		IJ.
		""")]
	[InlineData(3, 0, 3, 3, 'X', """
		.1X
		.2X
		G.X
		""")]
	public void SubArray_2dArray(int topLeftX, int topLeftY, int cols, int rows, char fill, string expected) {
		char[,] array = INPUT_ARRAY.SubArray(topLeftX, topLeftY, cols, rows, fill);
		string actual = string.Join(Environment.NewLine, array.AsStrings());
		actual.ShouldBe(expected);

		Point topLeft = new(topLeftX, topLeftY);
		array = INPUT_ARRAY.SubArray(topLeft, cols, rows, fill);
		actual = string.Join(Environment.NewLine, array.AsStrings());
		actual.ShouldBe(expected);

		Point bottomRight = topLeft + new Point(cols - 1, rows - 1);
		array = INPUT_ARRAY.SubArray(topLeft, bottomRight, fill);
		actual = string.Join(Environment.NewLine, array.AsStrings());
		actual.ShouldBe(expected);
	}
}
