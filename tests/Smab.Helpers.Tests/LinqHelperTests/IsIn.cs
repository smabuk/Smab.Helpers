namespace Smab.Helpers.Tests.LinqHelperTests;

public class IsIn {
	private static readonly IEnumerable<int> ints = [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11];
	private static readonly IEnumerable<double> doubles = [1.0, 2.0, 3.0, 4.0];

	[Theory]
	[InlineData(1, true)]
	[InlineData(5, true)]
	[InlineData(15, false)]
	[InlineData(-1, false)]
	public void IsIn_Ints_Should_Return(int value, bool expected) {
		value.IsIn(ints).ShouldBe(expected);
	}

	[Theory]
	[InlineData(1.0, true)]
	[InlineData(2.0, true)]
	[InlineData(4.0, true)]
	[InlineData(5.0, false)]
	[InlineData(1.00001, false)]
	public void IsIn_String_Should_Return(double value, bool expected) {
		value.IsIn(doubles).ShouldBe(expected);
	}
}
