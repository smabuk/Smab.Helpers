namespace Smab.Helpers.Tests.IoHelperTests;

public class RemoveBlankLineFromEnd {
	[Theory]
	[InlineData(new string[] { "Line 1", "" }, new string[] { "Line 1" })]
	[InlineData(new string[] { "Line 1", "Line 2" }, new string[] { "Line 1", "Line 2" })]
	[InlineData(null, new string[0])]
	public void Should_RemoveBlankLineFromEnd_IfLineIsEmpty(string[]? input, string[] expected) {
		input.RemoveBlankLineFromEnd().ShouldBe(expected);
	}
}
