namespace Smab.Helpers.Tests.GridHelperTests;

public class PrintAsString {

	[Theory]
	[InlineData(new int[] { 1, 2, 3, 4, 5, 6 }
		, 3, 2, 2
		, " 1 2 3")]
	[InlineData(new int[] { 1, 2, 3, 4, 5, 6 }
		, 2, 3, 4
		, "   1   2")]
	public void PrintAsStringArray_Int_Should_Have_Shape(int[] input, int cols, int? rows, int width, string expected) {
		string[] actual = input.To2dArray(cols, rows).PrintAsStringArray(width).ToArray();
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
		List<string> actual = input.To2dArray(cols, rows).PrintAsStringList(width);
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
		string actual = input.To2dArray(cols, rows).PrintAsString(width);
		Assert.Equal(expected, actual);
	}
}
