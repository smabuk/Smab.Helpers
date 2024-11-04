namespace Smab.Helpers.Tests.MathsHelperTests;
public class INumber {
	[Theory]
	[InlineData(1, false)]
	[InlineData(2, true)]
	[InlineData(0, true)]
	[InlineData(-1, false)]
	public void IsEven_Int_ShouldBe(int number, bool expected) {
		number.IsEven().ShouldBe(expected);
	}

	[Theory]
	[InlineData(1, true)]
	[InlineData(2, false)]
	[InlineData(0, false)]
	[InlineData(-1, true)]
	public void IsOdd_Int_ShouldBe(int number, bool expected) {
		number.IsOdd().ShouldBe(expected);
	}

	[Theory]
	[InlineData(1.0, true)]
	[InlineData(2.0, false)]
	[InlineData(0.0, false)]
	[InlineData(0.7, false)]
	[InlineData(-1.0, true)]
	public void IsOdd_Float_ShouldBe(float number, bool expected) {
		number.IsOdd().ShouldBe(expected);
	}
}
