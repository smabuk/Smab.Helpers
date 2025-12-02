namespace Smab.Helpers.Tests.MathsHelperTests;

public partial class Pow10Tests(ITestOutputHelper testOutputHelper) {
	[Theory]
	[InlineData(0, 1L)]
	[InlineData(1, 10L)]
	[InlineData(2, 100L)]
	[InlineData(3, 1_000L)]
	[InlineData(4, 10_000L)]
	[InlineData(5, 100_000L)]
	[InlineData(6, 1_000_000L)]
	[InlineData(7, 10_000_000L)]
	[InlineData(8, 100_000_000L)]
	[InlineData(9, 1_000_000_000L)]
	[InlineData(10, 10_000_000_000L)]
	[InlineData(11, 100_000_000_000L)]
	[InlineData(12, 1_000_000_000_000L)]
	[InlineData(13, 10_000_000_000_000L)]
	[InlineData(14, 100_000_000_000_000L)]
	[InlineData(15, 1_000_000_000_000_000L)]
	[InlineData(16, 10_000_000_000_000_000L)]
	[InlineData(17, 100_000_000_000_000_000L)]
	[InlineData(18, 1_000_000_000_000_000_000L)]
	public void Pow10_WithValidExponent_ShouldReturnCorrectValue(int exponent, long expected) {
		long actual = exponent.Pow10;

		testOutputHelper.WriteLine($"10^{exponent} = {actual}");

		actual.ShouldBe(expected);
		MathsHelpers.Pow10[exponent].ShouldBe(expected);
	}

	[Theory]
	[InlineData(19)]
	[InlineData(20)]
	[InlineData(25)]
	[InlineData(30)]
	public void Pow10_WithLargeExponent_ShouldThrowOverflowException(int exponent) {
		testOutputHelper.WriteLine($"Testing 10^{exponent} - should throw OverflowException");

		Should.Throw<OverflowException>(() => exponent.Pow10);
	}

	[Theory]
	[InlineData(-1)]
	[InlineData(-5)]
	[InlineData(-10)]
	public void Pow10_WithNegativeExponent_ShouldThrowArgumentOutOfRangeException(int exponent) {
		testOutputHelper.WriteLine($"Testing 10^{exponent} - should throw ArgumentOutOfRangeException");

		Should.Throw<ArgumentOutOfRangeException>(() => exponent.Pow10);
	}
}
