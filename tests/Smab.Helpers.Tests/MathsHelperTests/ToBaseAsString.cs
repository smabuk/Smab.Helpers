namespace Smab.Helpers.Tests.MathsHelperTests;
public class ToBaseAsString {
	[Theory]
	[InlineData(0, "0")]
	[InlineData(1, "1")]
	[InlineData(2, "2")]
	[InlineData(3, "10")]
	[InlineData(987, "1100120")]
	public void ToBaseAsString_3_Int_ShouldBe(int number, string expected) {
		number.ToBaseAsString(3).ShouldBe(expected);
	}

	[Theory]
	[InlineData(0, "0")]
	[InlineData(1, "1")]
	[InlineData(2, "2")]
	[InlineData(3, "10")]
	[InlineData(987, "1100120")]
	public void ToBaseAsString_3_UInt_ShouldBe(uint number, string expected) {
		number.ToBaseAsString(3).ShouldBe(expected);
	}

	[Theory]
	[InlineData(0, "0")]
	[InlineData(1, "1")]
	[InlineData(2, "2")]
	[InlineData(3, "10")]
	[InlineData(1111111111111111, "12101201010011222202021202201121")]
	public void ToBaseAsString_3_Long_ShouldBe(long number, string expected) {
		number.ToBaseAsString(3).ShouldBe(expected);
	}

	[Theory]
	[InlineData(0, 4, "0000")]
	[InlineData(1, 3, "001")]
	[InlineData(2, 8, "00000002")]
	[InlineData(3, 4, "0010")]
	[InlineData(987, 4, "1100120")]
	[InlineData(987, 10, "0001100120")]
	public void ToBaseAsString_3_With_Padding_ShouldBe(int number, int size, string expected) {
		number.ToBaseAsString(3, size).ShouldBe(expected);
	}

	[Theory]
	[InlineData(23, 2, "10111")]
	[InlineData(23, 3, "212")]
	[InlineData(23, 4, "113")]
	[InlineData(23, 5, "43")]
	[InlineData(23, 6, "35")]
	[InlineData(23, 7, "32")]
	[InlineData(23, 15, "18")]
	[InlineData(23, 16, "17")]
	public void ToBaseAsString_23_InBaseN_ShouldBe(int number, int baseNumber, string expected) {
		number.ToBaseAsString(baseNumber).ShouldBe(expected);
	}
}
