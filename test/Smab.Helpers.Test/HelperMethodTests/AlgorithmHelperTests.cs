namespace Smab.Helpers.Test.HelperMethodTests;
public class AlgorithmHelperTests {
	[Theory]
	[InlineData((int[])[2, 3], 6)]
	[InlineData((int[])[2, 3, 4, 5, 6, 7, 8], 840)]
	public void LowestCommonMultiple_OfInts_ShouldBe(int[] numbers, long expected) {
		long actual = numbers.LowestCommonMultiple();
		actual.ShouldBe(expected);
	}
	[Theory]
	[InlineData((long[])[2, 3], 6)]
	[InlineData((long[])[2, 3, 4, 5, 6, 7, 8], 840)]
	public void LowestCommonMultiple_OfLongs_ShouldBe(long[] numbers, long expected) {
		long actual = numbers.LowestCommonMultiple();
		actual.ShouldBe(expected);
	}
}
