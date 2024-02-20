namespace Smab.Helpers.Tests.ParsingHelperTests;
public partial class FromBinaryAs {
	[Theory]
	[InlineData("#", 1)]
	[InlineData("#..#", 9)]
	public void FromBinaryAs_ShouldBe(string input, int expected) {
		int actual = input.FromBinaryAs<int>();
		Assert.Equal(expected, actual);
	}

	[Theory]
	[InlineData("█", 1)]
	[InlineData("█  █", 9)]
	public void FromBinaryAs_WithReplacements_ShouldBe(string input, int expected) {
		int actual = input.FromBinaryAs<int>(' ', '█');
		Assert.Equal(expected, actual);
	}

}
