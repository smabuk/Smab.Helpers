namespace Smab.Helpers.Test.MathsHelperTests;
public class IsInRange {

	[Theory]
	[InlineData(0, 0, 5, true)]
	[InlineData(1, 0, 5, true)]
	[InlineData(4, 0, 5, true)]
	[InlineData(-4, -5, -3, true)]
	[InlineData(5, 0, 5, false)] // range doesn't include max value
	[InlineData(1, 5, 0, false)] // min is greater than max
	[InlineData(0, 4, 5, false)]
	[InlineData(5, 4, 5, false)]
	[InlineData(-1, -5, -3, false)]
	public void IsInRange_Ints_ShouldBe(int value, int min, int max, bool expected) {
		value.IsInRange(min, max).ShouldBe(expected);
	}

	[Theory]
	[InlineData(0, 0, 5, true)]
	[InlineData(1, 0, 5, true)]
	[InlineData(4, 0, 5, true)]
	[InlineData(5, 0, 5, false)]
	[InlineData(0, 4, 5, false)]
	[InlineData(5, 4, 5, false)]
	[InlineData(5.0, 0, 5, false)]
	[InlineData(5.00000001, 0, 5, false)]
	[InlineData(4.99999999, 0, 5, true)]
	public void IsInRange_Doubles_ShouldBe(double value, double min, double max, bool expected) {
		value.IsInRange(min, max).ShouldBe(expected);
	}
}
