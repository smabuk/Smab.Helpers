namespace Smab.Helpers.Tests.GridHelperTests;

public class AsStrings {

	[Theory]
	[InlineData(new int[] { 1, 2, 3, 4, 5, 6 }
		, 3, 2
		, "123")]
	[InlineData(new int[] { 1, 2, 3, 4, 5, 6 }
		, 2, 3
		, "12")]
	public void AsStrings_Int_Should_Have_Shape(int[] input, int cols, int? rows, string expected) {
		string[] actual = [.. input.To2dArray(cols, rows).AsStrings()];
		Assert.Equal(expected, actual[0]);
	}

	[Theory]
	[InlineData(new int[] { 1, 2, 3, 4, 5, 6 }
		, 3, 2
		, """
		123
		456
		""")]
	[InlineData(new int[] { 1, 2, 3, 4, 5, 6 }
		, 2, 3
		, """
		12
		34
		56
		""")]
	public void AsString_Int_Should_Have_Shape(int[] input, int cols, int? rows, string expected) {
		string actual = input.To2dArray(cols, rows).AsStringWithNewLines();
		Assert.Equal(expected, actual);
	}

	[Theory]
	[InlineData("""123456""", 3, 2
		, """
		123
		456
		""")]
	[InlineData("""123456""", 2, 3
		, """
		12
		34
		56
		""")]
	public void AsString_String_Should_Have_Shape(string input, int cols, int? rows, string expected) {
		string actual = input.To2dArray(cols, rows).AsStringWithNewLines();
		Assert.Equal(expected, actual);
	}


	[Theory]
	[InlineData("""123456""", 3, 2
		, """
		12*
		4.6
		""")]
	[InlineData("""123456""", 2, 3
		, """
		12
		*4
		.6
		""")]
	public void AsString_Char_Should_Have_Replacements(string input, int cols, int? rows, string expected) {
		string actual = input.To2dArray(cols, rows).AsStringWithNewLines(replacements: [("3", "*"), ("5", ".")]);
		Assert.Equal(expected, actual);
	}

	[Theory]
	[InlineData("""123456""", 3, 2, """12*4.6""")]
	[InlineData("""123456""", 2, 3, """12*4.6""")]
	public void AsString_Char_Should_Be_Raw_String(string input, int cols, int? rows, string expected) {
		string actual = input.To2dArray(cols, rows).AsString(replacements: [("3", "*"), ("5", ".")]);
		Assert.Equal(expected, actual);
	}

}
