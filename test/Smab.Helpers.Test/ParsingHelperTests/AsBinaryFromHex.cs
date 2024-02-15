namespace Smab.Helpers.Test.ParsingHelperTests;
public class AsBinaryFromHex {

	[Theory]
	[InlineData("123a", "0001001000111010")]
	[InlineData("0000", "0000000000000000")]
	public void AsBinaryFromHex_ShouldBe(string hexValue, string binaryValue) {
		hexValue.AsBinaryFromHex().ShouldBe(binaryValue);

	}

	[Fact]
	public void AsBinaryFromHex_Array_Should_Append() {
		string[] hexValues = ["123a", "000"];
		hexValues.AsBinaryFromHex().ShouldBe("0001001000111010000000000000");

	}
}
