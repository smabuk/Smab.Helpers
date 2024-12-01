namespace Smab.Helpers.Tests.ParsingHelperTests;
public class AsBinaryFrom {

	[Theory]
	[InlineData("123a", "0001001000111010")]
	[InlineData("0000", "0000000000000000")]
	public void AsBinaryFromHex_ShouldBe(string hexValue, string binaryValue) {
		hexValue.AsBinaryFromHex().ShouldBe(binaryValue);

	}

	[Theory]
	[InlineData("1234", "0001001000110100")]
	[InlineData("0000", "0000000000000000")]
	public void AsBinaryFromOctal_ShouldBe(string value, string binaryValue) {
		value.AsBinaryFromOctal().ShouldBe(binaryValue);

	}

	[Fact]
	public void AsBinaryFromHex_Array_Should_Append() {
		string[] hexValues = ["123a", "000"];
		hexValues.AsBinaryFromHex().ShouldBe("0001001000111010000000000000");

	}
}
