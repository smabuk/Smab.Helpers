namespace Smab.Helpers.Tests.MathsHelperTests;
public class RangeTests {
	[Theory]
	[InlineData(0,   0, 1,  1, false, 0,  0)]
	[InlineData(1,   3, 3,  4, true,  3,  3)]
	[InlineData(1,  15, 4,  9, true,  4,  9)]
	[InlineData(1,  15, 4, 39, true,  4, 15)]
	[InlineData(12, 39, 4, 18, true, 12, 18)]
	[InlineData(39, 12, 4, 18, true, 12, 18)]
	public void Range_DoesItOverlap(int r1Start, int r1End, int r2Start, int r2End, bool expectedResult, int expectedStart, int expectedEnd) {

		Range expected = new(expectedStart, expectedEnd);
		Range range1   = new(r1Start, r1End);
		Range range2   = new(r2Start, r2End);

		bool result = range1.TryGetOverlap(range2, out Range actual);
		result.ShouldBe(expectedResult);
		if (result) {
			actual.ShouldBe(expected);
			range1.GetOverlap(range2).ShouldBe(expected);
		} else {
			Should.Throw<ArgumentOutOfRangeException>(() => range1.GetOverlap(range2))
				.Message
				.ShouldEndWith("Ranges do not overlap. (Parameter 'range')");
		}
	}

	[Theory]
	[InlineData(0,   0, 1,  1, false, 0,  0)]
	[InlineData(1,  15, 4,  9, true,  4,  9)]
	[InlineData(1,  15, 4, 39, true,  4, 15)]
	[InlineData(12, 39, 4, 18, true, 12, 18)]
	[InlineData(39, 12, 4, 18, true, 12, 18)]
	[InlineData(39L, 12L, 4L, 18L, true, 12L, 18L)]
	public void Tuple_DoesItOverlap(int r1Start, int r1End, int r2Start, int r2End, bool expectedResult, int expectedStart, int expectedEnd) {
		
		(int Start, int End) expected = new(expectedStart, expectedEnd);
		(int Start, int End) range1   = new(r1Start, r1End);
		(int Start, int End) range2   = new(r2Start, r2End);

		bool result = range1.TryGetOverlap(range2, out (int Start, int End) actual);
		result.ShouldBe(expectedResult);
		if (result) {
			actual.ShouldBe(expected);
			range1.GetOverlap(range2).ShouldBe(expected);
		} else {
			Should.Throw<ArgumentOutOfRangeException>(() => range1.GetOverlap(range2))
				.Message
				.ShouldEndWith("Ranges do not overlap. (Parameter 'range')");
		}
	}

	[Theory]
	[InlineData( 0L,   0L)]
	[InlineData( 1L,  15L)]
	[InlineData(12L,  39L)]
	[InlineData(39L,  12L)]
	public void LongRange_FromTuple(long start, long end) {

		(long Start, long End) rangeTuple = (start, end);
		LongRange actual = new(rangeTuple);

		actual.Start.ShouldBe(start);
		actual.End.ShouldBe(end);
	}

	[Theory]
	[InlineData(0,   0)]
	[InlineData(1,  15)]
	[InlineData(12, 39)]
	[InlineData(39, 12)]
	public void Tuple_FromLongRange(long start, long end) {

		(long actualStart, long actualEnd) = new LongRange(start, end);

		actualStart.ShouldBe(start);
		actualEnd.ShouldBe(end);
	}
}
