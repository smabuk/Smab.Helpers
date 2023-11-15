namespace Smab.Helpers.Test.HelperMethodTests;

public class ParsingHelperTests {
	[Theory]
	[InlineData("1", 1)]
	[InlineData("23", 23)]
	[InlineData("-46", -46)]
	[InlineData("", 0)]
	[InlineData("xyz", 0)]
	public void AsInt_ShouldBe(string input, int expected) {
		int actual = input.AsInt();
		Assert.Equal(expected, actual);
	}

	[Theory]
	[InlineData("#", 1)]
	[InlineData("#..#", 9)]
	public void AsIntFromBinary_ShouldBe(string input, int expected) {
		int actual = input.AsIntFromBinary();
		Assert.Equal(expected, actual);
	}

	[Theory]
	[InlineData("█", 1)]
	[InlineData("█  █", 9)]
	public void AsIntFromBinary_WithReplacements_ShouldBe(string input, int expected) {
		int actual = input.AsIntFromBinary(' ', '█');
		Assert.Equal(expected, actual);
	}

	[Theory]
	[InlineData("1", -99, 1)]
	[InlineData("23", -99, 23)]
	[InlineData("-46", -99, -46)]
	[InlineData("", -99, -99)]
	[InlineData("xyz", -99, -99)]
	public void AsInt__WithDefault_ShouldBe(string input, int defaultValue, int expected) {
		int actual = input.AsInt(defaultValue);
		Assert.Equal(expected, actual);
	}

	[Theory]
	[InlineData(new string[] { "1", "2", "3" }, new int[] { 1, 2, 3, })]
	public void AsInts_ShouldBe(string[] input, int[] expected) {
		int[] actual = ParsingHelpers.AsInts(input).ToArray();
		Assert.Equal(expected, actual);
	}
	[Theory]
	[InlineData(new string[] { "1", "2", "3" }, new int[] { 1, 2, 3, })]
	[InlineData(new string[] { "3", "2", "1" }, new int[] { 3, 2, 1, })]
	public void AsInts_ShouldBe_AsExtensionMethod(string[] input, int[] expected) {
		int[] actual = input.AsInts().ToArray();
		Assert.Equal(expected, actual);
	}

	[Theory]
	[InlineData("1", 1)]
	[InlineData("23", 23)]
	[InlineData("-46", -46)]
	[InlineData("", 0)]
	[InlineData("xyz", 0)]
	public void AsLong_ShouldBe(string input, long expected) {
		long actual = input.AsInt();
		Assert.Equal(expected, actual);
	}

	[Theory]
	[InlineData("1", -99, 1)]
	[InlineData("23", -99, 23)]
	[InlineData("-46", -99, -46)]
	[InlineData("", -99, -99)]
	[InlineData("xyz", -99, -99)]
	public void AsLong__WithDefault_ShouldBe(string input, long defaultValue, long expected) {
		long actual = input.AsLong(defaultValue);
		Assert.Equal(expected, actual);
	}

	[Theory]
	[InlineData(new string[] { "1", "2", "3" }, new long[] { 1, 2, 3, })]
	public void AsLongs_ShouldBe(string[] input, long[] expected) {
		long[] actual = ParsingHelpers.AsLongs(input).ToArray();
		Assert.Equal(expected, actual);
	}
	[Theory]
	[InlineData(new string[] { "1", "2", "3" }, new long[] { 1, 2, 3, })]
	[InlineData(new string[] { "3", "2", "1" }, new long[] { 3, 2, 1, })]
	public void AsLongs_ShouldBe_AsExtensionMethod(string[] input, long[] expected) {
		long[] actual = input.AsLongs().ToArray();
		Assert.Equal(expected, actual);
	}
}
