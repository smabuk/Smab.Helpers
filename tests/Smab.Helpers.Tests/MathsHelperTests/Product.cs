namespace Smab.Helpers.Tests.MathsHelperTests;

public class Product {
	[Theory]
	[InlineData(new int[] { 2, 3, 4 }, 24)]
	[InlineData(new int[] { 1, 2, 3, 4, 5 }, 120)]
	[InlineData(new int[] { 5 }, 5)]
	[InlineData(new int[] { 10, 10, 10 }, 1000)]
	[InlineData(new int[] { -2, 3 }, -6)]
	[InlineData(new int[] { -2, -3 }, 6)]
	public void Product_OfInts_ShouldBe(int[] numbers, int expected) {
		numbers.Product().ShouldBe(expected);
	}

	[Theory]
	[InlineData(new long[] { 2L, 3L, 4L }, 24L)]
	[InlineData(new long[] { 1L, 2L, 3L, 4L, 5L }, 120L)]
	[InlineData(new long[] { 100_000L, 100_000L }, 10_000_000_000L)]
	public void Product_OfLongs_ShouldBe(long[] numbers, long expected) {
		numbers.Product().ShouldBe(expected);
	}

	[Theory]
	[InlineData(new double[] { 2.0, 3.0, 4.0 }, 24.0)]
	[InlineData(new double[] { 1.5, 2.0 }, 3.0)]
	[InlineData(new double[] { 0.5, 4.0 }, 2.0)]
	public void Product_OfDoubles_ShouldBe(double[] numbers, double expected) {
		numbers.Product().ShouldBe(expected);
	}

	[Fact]
	public void Product_WithConversion_IntsToLong_ShouldBe() {
		int[] numbers = [100_000, 100_000];
		long result = numbers.Product<int, long>();
		result.ShouldBe(10_000_000_000L);
	}

	[Fact]
	public void Product_WithConversion_IntsToDouble_ShouldBe() {
		int[] numbers = [2, 3, 4];
		double result = numbers.Product<int, double>();
		result.ShouldBe(24.0);
	}

	[Fact]
	public void Product_WithConversion_LargeIntsToLong_ShouldBe() {
		int[] numbers = [1000, 1000, 1000, 1000];
		long result = numbers.Product<int, long>();
		result.ShouldBe(1_000_000_000_000L);
	}

	[Fact]
	public void Product_OfEmptyCollection_ShouldReturnOne() {
		int[] numbers = [];
		numbers.Product().ShouldBe(1);
	}

	[Fact]
	public void Product_WithConversion_OfEmptyCollection_ShouldReturnOne() {
		int[] numbers = [];
		numbers.Product<int, long>().ShouldBe(1L);
	}

	[Fact]
	public void Product_OfEmptyDoubleCollection_ShouldReturnOne() {
		double[] numbers = [];
		numbers.Product().ShouldBe(1.0);
	}
}
