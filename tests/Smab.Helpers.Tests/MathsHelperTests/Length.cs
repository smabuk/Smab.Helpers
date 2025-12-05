namespace Smab.Helpers.Tests.MathsHelperTests;

public class Length {
	[Theory]
	[InlineData(0, 1)]
	[InlineData(11, 2)]
	[InlineData(222, 3)]
	[InlineData(4444444, 7)]
	[InlineData(987, 3)]
	public void Length_Int_ShouldBe(int number, int expected) {
		number.Length.ShouldBe(expected);
	}

	[Theory]
	[InlineData(0, 1)]
	[InlineData(11, 2)]
	[InlineData(222, 3)]
	[InlineData(4444444, 7)]
	[InlineData(012345678, 8)]
	[InlineData(123456789012345678, 18)]
	public void Length_Long_ShouldBe(long number, int expected) {
		number.Length.ShouldBe(expected);
	}

	[Theory]
	[InlineData(-4444444)]
	public void Length_Long_Negative_ShouldBe(long number) {
		Should.Throw<ArgumentOutOfRangeException>(() => number.Length);
	}
}
