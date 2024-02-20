namespace Smab.Helpers.Tests.MiscHelperTests;
public class NonEmptyStringTests {

	[Theory]
	[InlineData("abc",     "abc")]
	[InlineData(" abc",    "abc")]
	[InlineData("\tabc",   "abc")]
	[InlineData("\tabc\t", "abc")]
	[InlineData("\tabc\nabc\n", "abc\nabc")]
	public void NonEmptyString_ShouldBe_Valid(string value, string expected) {
		((string)new NonEmptyString(value)).ShouldBe(expected);
	}

	[Theory]
	[InlineData("")]
	[InlineData("    ")]
	[InlineData("\t\n")]
	public void NonEmptyString_ShouldThrow_ArgumentNullException(string value) {
		Should.Throw<ArgumentNullException>(() => new NonEmptyString(value))
		.Message
			.ShouldEndWith("Value (Parameter 'Value cannot be null or white space')");
	}
}
