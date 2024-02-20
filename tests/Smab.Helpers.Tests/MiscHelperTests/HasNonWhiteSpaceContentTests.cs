namespace Smab.Helpers.Tests.MiscHelperTests;
public class HasNonWhiteSpaceContentTests {

	[Theory]
	[InlineData("abc")]
	[InlineData(" abc")]
	[InlineData("\tabc")]
	[InlineData("\tabc\t")]
	[InlineData("\tabc\nabc\n")]
	public void HasNonWhiteSpaceContent_ShouldBe_True(string? value) {
		value.HasNonWhiteSpaceContent().ShouldBeTrue();
	}

	[Theory]
	[InlineData(null)]
	[InlineData("")]
	[InlineData("    ")]
	[InlineData("\t\n")]
	public void HasNonWhiteSpaceContent_ShouldBe_False(string? value) {
		value.HasNonWhiteSpaceContent().ShouldBeFalse();
	}
}
