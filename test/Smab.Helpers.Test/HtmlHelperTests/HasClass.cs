namespace Smab.Helpers.Test.HtmlHelperTests;
public class HasClass {
	private const string classList = "one two three four";

	[Theory]
	[InlineData("one",  true)]
	[InlineData("two",  true)]
	[InlineData("four", true)]
	[InlineData("five", false)]
	[InlineData("tw",   false)]
	[InlineData(" ",    false)]
	public void HasClass_ShouldBe(string hasClass, bool expected) {
		classList.HasClass(hasClass).ShouldBe(expected);
	}
}
