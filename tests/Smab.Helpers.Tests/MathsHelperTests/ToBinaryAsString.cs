namespace Smab.Helpers.Tests.MathsHelperTests;
public class ToBinaryAsString {
	[Theory]
	[InlineData(0, "0")]
	[InlineData(1, "1")]
	[InlineData(2, "10")]
	[InlineData(3, "11")]
	[InlineData(987, "1111011011")]
	public void ToBinaryAsString_Int_ShouldBe(int number, string expected) {
		number.ToBinaryAsString().ShouldBe(expected);
	}

	[Theory]
	[InlineData(0, "0")]
	[InlineData(1, "1")]
	[InlineData(2, "10")]
	[InlineData(3, "11")]
	[InlineData(987, "1111011011")]
	[InlineData(1111111111111111, "11111100101000110010110111000101010111000111000111")]
	public void ToBinaryAsString_Long_ShouldBe(long number, string expected) {
		number.ToBinaryAsString().ShouldBe(expected);
	}

	[Theory]
	[InlineData(0, "0")]
	[InlineData(1, "1")]
	[InlineData(2, "10")]
	[InlineData(3, "11")]
	[InlineData(987, "1111011011")]
	public void ToBinaryAsString_uint_ShouldBe(uint number, string expected) {
		number.ToBinaryAsString().ShouldBe(expected);
	}
}
