namespace Smab.Helpers.Tests.IoHelperTests;

public class StripTrailingBlankLineOrDefault {
	[Theory]
	[InlineData(new string[] { "Line 1", "" }, new string[] { "Line 1" })]
	[InlineData(new string[] { "Line 1", "Line 2" }, new string[] { "Line 1", "Line 2" })]
	[InlineData(null, new string[0])]
	public void Should_StripTrailingBlankLine_IfLineIsEmpty(string[]? input, string[] expected) {
		DataInputCleanup.StripTrailingBlankLineOrDefault(input).ShouldBe(expected);
		input.StripTrailingBlankLineOrDefault().ShouldBe(expected);
	}

	[Fact]
	public void Should_ReturnDefault_IfLineIsEmpty() {
		string? input = null;
		input.StripTrailingBlankLineOrDefault("empty").ShouldBe("empty");

		string[]? inputArray = null;
		inputArray.StripTrailingBlankLineOrDefault(["empty"]).ShouldBe(["empty"]);
	}
}
