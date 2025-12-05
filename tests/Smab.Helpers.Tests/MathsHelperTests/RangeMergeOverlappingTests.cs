namespace Smab.Helpers.Tests.MathsHelperTests;

public class RangeMergeOverlappingTests {
	[Fact]
	public void MergeOverlapping_IntTuples_EmptyList_ShouldReturnEmptyList() {
		List<(int Start, int End)> ranges = [];

		List<(int Start, int End)> result = ranges.MergeOverlapping();

		result.ShouldBeEmpty();
	}

	[Fact]
	public void MergeOverlapping_IntTuples_SingleRange_ShouldReturnSameRange() {
		List<(int Start, int End)> ranges = [(5, 10)];

		List<(int Start, int End)> result = ranges.MergeOverlapping();

		result.Count.ShouldBe(1);
		result[0].Start.ShouldBe(5);
		result[0].End.ShouldBe(10);
	}

	[Fact]
	public void MergeOverlapping_IntTuples_TwoOverlappingRanges_ShouldMerge() {
		List<(int Start, int End)> ranges = [(0, 10), (5, 15)];

		List<(int Start, int End)> result = ranges.MergeOverlapping();

		result.Count.ShouldBe(1);
		result[0].Start.ShouldBe(0);
		result[0].End.ShouldBe(15);
	}

	[Fact]
	public void MergeOverlapping_IntTuples_TwoAdjacentRanges_ShouldMerge() {
		List<(int Start, int End)> ranges = [(0, 10), (11, 20)];

		List<(int Start, int End)> result = ranges.MergeOverlapping();

		result.Count.ShouldBe(1);
		result[0].Start.ShouldBe(0);
		result[0].End.ShouldBe(20);
	}

	[Fact]
	public void MergeOverlapping_IntTuples_TwoNonOverlappingRanges_ShouldNotMerge() {
		List<(int Start, int End)> ranges = [(0, 10), (20, 30)];

		List<(int Start, int End)> result = ranges.MergeOverlapping();

		result.Count.ShouldBe(2);
		result[0].Start.ShouldBe(0);
		result[0].End.ShouldBe(10);
		result[1].Start.ShouldBe(20);
		result[1].End.ShouldBe(30);
	}

	[Fact]
	public void MergeOverlapping_IntTuples_MultipleOverlappingRanges_ShouldMergeAll() {
		List<(int Start, int End)> ranges = [(0, 10), (5, 15), (12, 20), (18, 25)];

		List<(int Start, int End)> result = ranges.MergeOverlapping();

		result.Count.ShouldBe(1);
		result[0].Start.ShouldBe(0);
		result[0].End.ShouldBe(25);
	}

	[Fact]
	public void MergeOverlapping_IntTuples_MixedOverlappingAndNonOverlapping_ShouldMergeCorrectly() {
		List<(int Start, int End)> ranges = [(0, 10), (5, 15), (20, 30), (25, 35)];

		List<(int Start, int End)> result = ranges.MergeOverlapping();

		result.Count.ShouldBe(2);
		result[0].Start.ShouldBe(0);
		result[0].End.ShouldBe(15);
		result[1].Start.ShouldBe(20);
		result[1].End.ShouldBe(35);
	}

	[Fact]
	public void MergeOverlapping_IntTuples_UnsortedRanges_ShouldSortAndMerge() {
		List<(int Start, int End)> ranges = [(20, 30), (0, 10), (5, 15)];

		List<(int Start, int End)> result = ranges.MergeOverlapping();

		result.Count.ShouldBe(2);
		result[0].Start.ShouldBe(0);
		result[0].End.ShouldBe(15);
		result[1].Start.ShouldBe(20);
		result[1].End.ShouldBe(30);
	}

	[Fact]
	public void MergeOverlapping_IntTuples_IdenticalRanges_ShouldReturnSingleRange() {
		List<(int Start, int End)> ranges = [(5, 10), (5, 10), (5, 10)];

		List<(int Start, int End)> result = ranges.MergeOverlapping();

		result.Count.ShouldBe(1);
		result[0].Start.ShouldBe(5);
		result[0].End.ShouldBe(10);
	}

	[Fact]
	public void MergeOverlapping_IntTuples_OneRangeContainsOthers_ShouldReturnSingleRange() {
		List<(int Start, int End)> ranges = [(0, 30), (5, 10), (15, 20), (22, 28)];

		List<(int Start, int End)> result = ranges.MergeOverlapping();

		result.Count.ShouldBe(1);
		result[0].Start.ShouldBe(0);
		result[0].End.ShouldBe(30);
	}

	[Fact]
	public void MergeOverlapping_IntTuples_NegativeRanges_ShouldMergeCorrectly() {
		List<(int Start, int End)> ranges = [(-20, -10), (-15, -5), (0, 10)];

		List<(int Start, int End)> result = ranges.MergeOverlapping();

		result.Count.ShouldBe(2);
		result[0].Start.ShouldBe(-20);
		result[0].End.ShouldBe(-5);
		result[1].Start.ShouldBe(0);
		result[1].End.ShouldBe(10);
	}

	[Fact]
	public void MergeOverlapping_DoubleTuples_OverlappingRanges_ShouldMerge() {
		List<(double Start, double End)> ranges = [(0.0, 10.0), (5.0, 15.0), (12.0, 20.0)];

		List<(double Start, double End)> result = ranges.MergeOverlapping();

		result.Count.ShouldBe(1);
		result[0].Start.ShouldBe(0.0);
		result[0].End.ShouldBe(20.0);
	}

	[Fact]
	public void MergeOverlapping_DoubleTuples_AdjacentRanges_ShouldMerge() {
		List<(double Start, double End)> ranges = [(0.0, 10.0), (11.0, 20.0)];

		List<(double Start, double End)> result = ranges.MergeOverlapping();

		result.Count.ShouldBe(1);
		result[0].Start.ShouldBe(0.0);
		result[0].End.ShouldBe(20.0);
	}

	[Fact]
	public void MergeOverlapping_DoubleTuples_NonOverlappingRanges_ShouldNotMerge() {
		List<(double Start, double End)> ranges = [(0.0, 10.0), (20.0, 30.0)];

		List<(double Start, double End)> result = ranges.MergeOverlapping();

		result.Count.ShouldBe(2);
		result[0].Start.ShouldBe(0.0);
		result[0].End.ShouldBe(10.0);
		result[1].Start.ShouldBe(20.0);
		result[1].End.ShouldBe(30.0);
	}

	[Fact]
	public void MergeOverlapping_Range_EmptyList_ShouldReturnEmptyList() {
		List<Range> ranges = [];

		List<Range> result = ranges.MergeOverlapping();

		result.ShouldBeEmpty();
	}

	[Fact]
	public void MergeOverlapping_Range_SingleRange_ShouldReturnSameRange() {
		List<Range> ranges = [new Range(5, 10)];

		List<Range> result = ranges.MergeOverlapping();

		result.Count.ShouldBe(1);
		result[0].ShouldBe(new Range(5, 10));
	}

	[Fact]
	public void MergeOverlapping_Range_TwoOverlappingRanges_ShouldMerge() {
		List<Range> ranges = [new Range(0, 10), new Range(5, 15)];

		List<Range> result = ranges.MergeOverlapping();

		result.Count.ShouldBe(1);
		result[0].ShouldBe(new Range(0, 15));
	}

	[Fact]
	public void MergeOverlapping_Range_TwoAdjacentRanges_ShouldMerge() {
		List<Range> ranges = [new Range(0, 10), new Range(11, 20)];

		List<Range> result = ranges.MergeOverlapping();

		result.Count.ShouldBe(1);
		result[0].ShouldBe(new Range(0, 20));
	}

	[Fact]
	public void MergeOverlapping_Range_TwoNonOverlappingRanges_ShouldNotMerge() {
		List<Range> ranges = [new Range(0, 10), new Range(20, 30)];

		List<Range> result = ranges.MergeOverlapping();

		result.Count.ShouldBe(2);
		result[0].ShouldBe(new Range(0, 10));
		result[1].ShouldBe(new Range(20, 30));
	}

	[Fact]
	public void MergeOverlapping_Range_MultipleOverlappingRanges_ShouldMergeAll() {
		List<Range> ranges = [new Range(0, 10), new Range(5, 15), new Range(12, 20), new Range(18, 25)];

		List<Range> result = ranges.MergeOverlapping();

		result.Count.ShouldBe(1);
		result[0].ShouldBe(new Range(0, 25));
	}

	[Fact]
	public void MergeOverlapping_Range_UnsortedRanges_ShouldSortAndMerge() {
		List<Range> ranges = [new Range(20, 30), new Range(0, 10), new Range(5, 15)];

		List<Range> result = ranges.MergeOverlapping();

		result.Count.ShouldBe(2);
		result[0].ShouldBe(new Range(0, 15));
		result[1].ShouldBe(new Range(20, 30));
	}

	[Fact]
	public void MergeOverlapping_LongRange_EmptyList_ShouldReturnEmptyList() {
		List<LongRange> ranges = [];

		List<LongRange> result = ranges.MergeOverlapping();

		result.ShouldBeEmpty();
	}

	[Fact]
	public void MergeOverlapping_LongRange_SingleRange_ShouldReturnSameRange() {
		List<LongRange> ranges = [new LongRange(5, 10)];

		List<LongRange> result = ranges.MergeOverlapping();

		result.Count.ShouldBe(1);
		result[0].Start.ShouldBe(5);
		result[0].End.ShouldBe(10);
	}

	[Fact]
	public void MergeOverlapping_LongRange_TwoOverlappingRanges_ShouldMerge() {
		List<LongRange> ranges = [new LongRange(0, 10), new LongRange(5, 15)];

		List<LongRange> result = ranges.MergeOverlapping();

		result.Count.ShouldBe(1);
		result[0].Start.ShouldBe(0);
		result[0].End.ShouldBe(15);
	}

	[Fact]
	public void MergeOverlapping_LongRange_TwoAdjacentRanges_ShouldMerge() {
		List<LongRange> ranges = [new LongRange(0, 10), new LongRange(11, 20)];

		List<LongRange> result = ranges.MergeOverlapping();

		result.Count.ShouldBe(1);
		result[0].Start.ShouldBe(0);
		result[0].End.ShouldBe(20);
	}

	[Fact]
	public void MergeOverlapping_LongRange_TwoNonOverlappingRanges_ShouldNotMerge() {
		List<LongRange> ranges = [new LongRange(0, 10), new LongRange(20, 30)];

		List<LongRange> result = ranges.MergeOverlapping();

		result.Count.ShouldBe(2);
		result[0].Start.ShouldBe(0);
		result[0].End.ShouldBe(10);
		result[1].Start.ShouldBe(20);
		result[1].End.ShouldBe(30);
	}

	[Fact]
	public void MergeOverlapping_LongRange_MultipleOverlappingRanges_ShouldMergeAll() {
		List<LongRange> ranges = [new LongRange(0, 10), new LongRange(5, 15), new LongRange(12, 20), new LongRange(18, 25)];

		List<LongRange> result = ranges.MergeOverlapping();

		result.Count.ShouldBe(1);
		result[0].Start.ShouldBe(0);
		result[0].End.ShouldBe(25);
	}

	[Fact]
	public void MergeOverlapping_LongRange_UnsortedRanges_ShouldSortAndMerge() {
		List<LongRange> ranges = [new LongRange(20, 30), new LongRange(0, 10), new LongRange(5, 15)];

		List<LongRange> result = ranges.MergeOverlapping();

		result.Count.ShouldBe(2);
		result[0].Start.ShouldBe(0);
		result[0].End.ShouldBe(15);
		result[1].Start.ShouldBe(20);
		result[1].End.ShouldBe(30);
	}

	[Fact]
	public void MergeOverlapping_LongRange_LargeValues_ShouldMergeCorrectly() {
		List<LongRange> ranges = [
			new LongRange(1000000000000, 2000000000000),
			new LongRange(1500000000000, 2500000000000),
			new LongRange(3000000000000, 4000000000000)
		];

		List<LongRange> result = ranges.MergeOverlapping();

		result.Count.ShouldBe(2);
		result[0].Start.ShouldBe(1000000000000);
		result[0].End.ShouldBe(2500000000000);
		result[1].Start.ShouldBe(3000000000000);
		result[1].End.ShouldBe(4000000000000);
	}

	[Fact]
	public void MergeOverlapping_LongRange_NegativeRanges_ShouldMergeCorrectly() {
		List<LongRange> ranges = [new LongRange(-20, -10), new LongRange(-15, -5), new LongRange(0, 10)];

		List<LongRange> result = ranges.MergeOverlapping();

		result.Count.ShouldBe(2);
		result[0].Start.ShouldBe(-20);
		result[0].End.ShouldBe(-5);
		result[1].Start.ShouldBe(0);
		result[1].End.ShouldBe(10);
	}

	[Fact]
	public void MergeOverlapping_DoubleTuples_EmptyList_ShouldReturnEmptyList() {
		List<(double Start, double End)> ranges = [];

		List<(double Start, double End)> result = ranges.MergeOverlapping();

		result.ShouldBeEmpty();
	}

	[Fact]
	public void MergeOverlapping_DoubleTuples_SingleRange_ShouldReturnSameRange() {
		List<(double Start, double End)> ranges = [(5.5, 10.5)];

		List<(double Start, double End)> result = ranges.MergeOverlapping();

		result.Count.ShouldBe(1);
		result[0].Start.ShouldBe(5.5);
		result[0].End.ShouldBe(10.5);
	}

	[Fact]
	public void MergeOverlapping_DoubleTuples_MixedOverlappingAndNonOverlapping_ShouldMergeCorrectly() {
		List<(double Start, double End)> ranges = [(0.0, 10.0), (5.0, 15.0), (20.0, 30.0), (25.0, 35.0)];

		List<(double Start, double End)> result = ranges.MergeOverlapping();

		result.Count.ShouldBe(2);
		result[0].Start.ShouldBe(0.0);
		result[0].End.ShouldBe(15.0);
		result[1].Start.ShouldBe(20.0);
		result[1].End.ShouldBe(35.0);
	}

	[Fact]
	public void MergeOverlapping_Range_IdenticalRanges_ShouldReturnSingleRange() {
		List<Range> ranges = [new Range(5, 10), new Range(5, 10), new Range(5, 10)];

		List<Range> result = ranges.MergeOverlapping();

		result.Count.ShouldBe(1);
		result[0].ShouldBe(new Range(5, 10));
	}

	[Fact]
	public void MergeOverlapping_Range_OneRangeContainsOthers_ShouldReturnSingleRange() {
		List<Range> ranges = [new Range(0, 30), new Range(5, 10), new Range(15, 20)];

		List<Range> result = ranges.MergeOverlapping();

		result.Count.ShouldBe(1);
		result[0].ShouldBe(new Range(0, 30));
	}

	[Fact]
	public void MergeOverlapping_LongRange_IdenticalRanges_ShouldReturnSingleRange() {
		List<LongRange> ranges = [new LongRange(5, 10), new LongRange(5, 10)];

		List<LongRange> result = ranges.MergeOverlapping();

		result.Count.ShouldBe(1);
		result[0].Start.ShouldBe(5);
		result[0].End.ShouldBe(10);
	}

	[Fact]
	public void MergeOverlapping_LongRange_ComplexScenario_ShouldMergeCorrectly() {
		List<LongRange> ranges = [
			new LongRange(0, 5),
			new LongRange(7, 10),
			new LongRange(12, 15),
			new LongRange(14, 20),
			new LongRange(22, 25),
			new LongRange(30, 35)
		];

		List<LongRange> result = ranges.MergeOverlapping();

		result.Count.ShouldBe(5);
		result[0].Start.ShouldBe(0);
		result[0].End.ShouldBe(5);
		result[1].Start.ShouldBe(7);
		result[1].End.ShouldBe(10);
		result[2].Start.ShouldBe(12);
		result[2].End.ShouldBe(20);
		result[3].Start.ShouldBe(22);
		result[3].End.ShouldBe(25);
		result[4].Start.ShouldBe(30);
		result[4].End.ShouldBe(35);
	}

	[Fact]
	public void MergeOverlapping_IntTuples_AllAdjacentRanges_ShouldMergeIntoOne() {
		List<(int Start, int End)> ranges = [(0, 5), (6, 10), (11, 15), (16, 20)];

		List<(int Start, int End)> result = ranges.MergeOverlapping();

		result.Count.ShouldBe(1);
		result[0].Start.ShouldBe(0);
		result[0].End.ShouldBe(20);
	}

	[Fact]
	public void MergeOverlapping_LongRange_SingleValueRanges_AdjacentAndOverlapping_ShouldMerge() {
		List<LongRange> ranges = [new LongRange(5, 5), new LongRange(6, 6), new LongRange(7, 7)];

		List<LongRange> result = ranges.MergeOverlapping();

		result.Count.ShouldBe(1);
		result[0].Start.ShouldBe(5);
		result[0].End.ShouldBe(7);
	}
}
