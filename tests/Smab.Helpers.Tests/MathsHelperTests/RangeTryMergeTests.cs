namespace Smab.Helpers.Tests.MathsHelperTests;

public class RangeTryMergeTests {
	[Theory]
	[InlineData(0, 10, 5, 15, true, 0, 15)] // overlapping ranges
	[InlineData(0, 10, 0, 10, true, 0, 10)] // identical ranges
	[InlineData(0, 10, 11, 20, true, 0, 20)] // adjacent ranges (touching)
	[InlineData(0, 10, 12, 20, false, 0, 0)] // non-overlapping, non-adjacent
	[InlineData(5, 15, 0, 10, true, 0, 15)] // overlapping ranges reversed
	[InlineData(10, 0, 5, 15, true, 0, 15)] // inverted first range
	[InlineData(0, 10, 15, 5, true, 0, 15)] // inverted second range
	[InlineData(-10, -5, -8, 0, true, -10, 0)] // negative ranges overlapping
	[InlineData(-10, -5, -4, 0, true, -10, 0)] // negative ranges adjacent
	[InlineData(-10, -5, -3, 0, false, 0, 0)] // negative ranges non-adjacent
	[InlineData(0, 5, 6, 10, true, 0, 10)] // adjacent (first ends, second starts)
	[InlineData(6, 10, 0, 5, true, 0, 10)] // adjacent (reversed order)
	public void TryMerge_IntTuples_ShouldReturnExpected(
		int start1, int end1, int start2, int end2, bool expectedResult, int expectedMergedStart, int expectedMergedEnd) {

		(int Start, int End) range1 = (start1, end1);
		(int Start, int End) range2 = (start2, end2);

		bool result = range1.TryMerge(range2, out (int Start, int End) mergedRange);

		result.ShouldBe(expectedResult);
		if (expectedResult) {
			if (expectedMergedStart > expectedMergedEnd) {
				mergedRange.Start.ShouldBe(expectedMergedEnd);
				mergedRange.End.ShouldBe(expectedMergedStart);
			} else {
				mergedRange.Start.ShouldBe(expectedMergedStart);
				mergedRange.End.ShouldBe(expectedMergedEnd);
			}
		}
	}

	[Theory]
	[InlineData(0.0, 10.0, 5.0, 15.0, true, 0.0, 15.0)] // overlapping ranges
	[InlineData(0.0, 10.0, 11.0, 20.0, true, 0.0, 20.0)] // adjacent ranges
	[InlineData(0.0, 10.0, 12.0, 20.0, false, 0.0, 0.0)] // non-overlapping, non-adjacent
	[InlineData(-10.0, -5.0, -8.0, 0.0, true, -10.0, 0.0)] // negative ranges overlapping
	[InlineData(0.5, 10.5, 11.5, 20.5, true, 0.5, 20.5)] // decimal adjacent ranges
	[InlineData(0.5, 10.5, 12.5, 20.5, false, 0.0, 0.0)] // decimal non-adjacent ranges
	public void TryMerge_DoubleTuples_ShouldReturnExpected(
		double start1, double end1, double start2, double end2, bool expectedResult, double expectedMergedStart, double expectedMergedEnd) {

		(double Start, double End) range1 = (start1, end1);
		(double Start, double End) range2 = (start2, end2);

		bool result = range1.TryMerge(range2, out (double Start, double End) mergedRange);

		result.ShouldBe(expectedResult);
		if (expectedResult) {
			mergedRange.Start.ShouldBe(expectedMergedStart);
			mergedRange.End.ShouldBe(expectedMergedEnd);
		}
	}

	[Theory]
	[InlineData(0, 10, 5, 15, true, 0, 15)] // overlapping ranges
	[InlineData(0, 10, 0, 10, true, 0, 10)] // identical ranges
	[InlineData(0, 10, 11, 20, true, 0, 20)] // adjacent ranges
	[InlineData(0, 10, 12, 20, false, 0, 0)] // non-overlapping, non-adjacent
	[InlineData(5, 15, 0, 10, true, 0, 15)] // overlapping ranges reversed
	[InlineData(0, 5, 6, 10, true, 0, 10)] // adjacent (first ends, second starts)
	public void TryMerge_Range_ShouldReturnExpected(
		int start1, int end1, int start2, int end2, bool expectedResult, int expectedMergedStart, int expectedMergedEnd) {

		Range range1 = new(start1, end1);
		Range range2 = new(start2, end2);

		bool result = range1.TryMerge(range2, out Range mergedRange);

		result.ShouldBe(expectedResult);
		if (expectedResult) {
			Range expected = new(expectedMergedStart, expectedMergedEnd);
			mergedRange.ShouldBe(expected);
		}
	}

	[Fact]
	public void TryMerge_IntTuples_WhenNotMergeable_ShouldReturnFalse() {
		(int Start, int End) range1 = (0, 10);
		(int Start, int End) range2 = (20, 30);

		bool result = range1.TryMerge(range2, out (int Start, int End) _);

		result.ShouldBe(false);
	}

	[Fact]
	public void TryMerge_DoubleTuples_WhenNotMergeable_ShouldReturnFalse() {
		(double Start, double End) range1 = (0.0, 10.0);
		(double Start, double End) range2 = (20.0, 30.0);

		bool result = range1.TryMerge(range2, out (double Start, double End) _);

		result.ShouldBe(false);
	}

	[Fact]
	public void TryMerge_Range_WhenNotMergeable_ShouldReturnFalse() {
		Range range1 = new(0, 10);
		Range range2 = new(20, 30);

		bool result = range1.TryMerge(range2, out Range _);

		result.ShouldBe(false);
	}

	[Fact]
	public void TryMerge_IntTuples_WhenIdentical_ShouldReturnSameRange() {
		(int Start, int End) range1 = (5, 15);
		(int Start, int End) range2 = (5, 15);

		bool result = range1.TryMerge(range2, out (int Start, int End) mergedRange);

		result.ShouldBe(true);
		mergedRange.Start.ShouldBe(5);
		mergedRange.End.ShouldBe(15);
	}

	[Fact]
	public void TryMerge_IntTuples_WhenOneContainsOther_ShouldReturnLargerRange() {
		(int Start, int End) range1 = (0, 20);
		(int Start, int End) range2 = (5, 15);

		bool result = range1.TryMerge(range2, out (int Start, int End) mergedRange);

		result.ShouldBe(true);
		mergedRange.Start.ShouldBe(0);
		mergedRange.End.ShouldBe(20);
	}

	[Fact]
	public void TryMerge_LongTuples_OverlappingRanges_ShouldMerge() {
		(long Start, long End) range1 = (1000000000000L, 2000000000000L);
		(long Start, long End) range2 = (1500000000000L, 2500000000000L);

		bool result = range1.TryMerge(range2, out (long Start, long End) mergedRange);

		result.ShouldBe(true);
		mergedRange.Start.ShouldBe(1000000000000L);
		mergedRange.End.ShouldBe(2500000000000L);
	}

	[Fact]
	public void TryMerge_LongTuples_AdjacentRanges_ShouldMerge() {
		(long Start, long End) range1 = (0L, 10L);
		(long Start, long End) range2 = (11L, 20L);

		bool result = range1.TryMerge(range2, out (long Start, long End) mergedRange);

		result.ShouldBe(true);
		mergedRange.Start.ShouldBe(0L);
		mergedRange.End.ShouldBe(20L);
	}

	[Fact]
	public void TryMerge_LongTuples_NonAdjacentRanges_ShouldNotMerge() {
		(long Start, long End) range1 = (0L, 10L);
		(long Start, long End) range2 = (20L, 30L);

		bool result = range1.TryMerge(range2, out (long Start, long End) _);

		result.ShouldBe(false);
	}

	[Fact]
	public void TryMerge_DoubleTuples_InvertedRanges_ShouldMerge() {
		(double Start, double End) range1 = (15.0, 5.0);
		(double Start, double End) range2 = (0.0, 10.0);

		bool result = range1.TryMerge(range2, out (double Start, double End) mergedRange);

		result.ShouldBe(true);
		mergedRange.Start.ShouldBe(0.0);
		mergedRange.End.ShouldBe(15.0);
	}

	[Fact]
	public void TryMerge_Range_InvertedRanges_ShouldMerge() {
		Range range1 = new(15, 5);
		Range range2 = new(0, 10);

		bool result = range1.TryMerge(range2, out Range mergedRange);

		result.ShouldBe(true);
		mergedRange.ShouldBe(new Range(0, 15));
	}

	[Fact]
	public void TryMerge_IntTuples_SinglePointRanges_Adjacent_ShouldMerge() {
		(int Start, int End) range1 = (5, 5);
		(int Start, int End) range2 = (6, 6);

		bool result = range1.TryMerge(range2, out (int Start, int End) mergedRange);

		result.ShouldBe(true);
		mergedRange.Start.ShouldBe(5);
		mergedRange.End.ShouldBe(6);
	}

	[Fact]
	public void TryMerge_IntTuples_SinglePointRanges_NonAdjacent_ShouldNotMerge() {
		(int Start, int End) range1 = (5, 5);
		(int Start, int End) range2 = (7, 7);

		bool result = range1.TryMerge(range2, out (int Start, int End) _);

		result.ShouldBe(false);
	}

	[Fact]
	public void TryMerge_LongRange_OverlappingRanges_ShouldMerge() {
		LongRange range1 = new(0, 10);
		LongRange range2 = new(5, 15);

		bool result = range1.TryMerge(range2, out LongRange mergedRange);

		result.ShouldBe(true);
		mergedRange.Start.ShouldBe(0);
		mergedRange.End.ShouldBe(15);
	}

	[Fact]
	public void TryMerge_LongRange_AdjacentRanges_ShouldMerge() {
		LongRange range1 = new(0, 10);
		LongRange range2 = new(11, 20);

		bool result = range1.TryMerge(range2, out LongRange mergedRange);

		result.ShouldBe(true);
		mergedRange.Start.ShouldBe(0);
		mergedRange.End.ShouldBe(20);
	}

	[Fact]
	public void TryMerge_LongRange_NonAdjacentRanges_ShouldNotMerge() {
		LongRange range1 = new(0, 10);
		LongRange range2 = new(20, 30);

		bool result = range1.TryMerge(range2, out LongRange _);

		result.ShouldBe(false);
	}

	[Fact]
	public void TryMerge_LongRange_LargeValues_ShouldMerge() {
		LongRange range1 = new(1000000000000L, 2000000000000L);
		LongRange range2 = new(1500000000000L, 2500000000000L);

		bool result = range1.TryMerge(range2, out LongRange mergedRange);

		result.ShouldBe(true);
		mergedRange.Start.ShouldBe(1000000000000L);
		mergedRange.End.ShouldBe(2500000000000L);
	}
}
