namespace Smab.Helpers.Test.HelperMethodTests;
public class RangeTests {
	[Theory]
	[InlineData(0,   0, 1,  1, false, 0,  0)]
	[InlineData(1,  15, 4,  9, true,  4,  9)]
	[InlineData(1,  15, 4, 39, true,  4, 15)]
	[InlineData(12, 39, 4, 18, true, 12, 18)]
	[InlineData(39, 12, 4, 18, true, 12, 18)]
	public void Range_DoesItOverlap(int r1Start, int r1End, int r2Start, int r2End, bool expectedResult, int expectedStart, int expectedEnd) {

		bool result = Range.TryGetOverlap(new Range(r1Start, r1End), new Range(r2Start, r2End), out Range actual);
		result.ShouldBe(expectedResult);
		if (result) {
			actual.ShouldBe(new Range(expectedStart, expectedEnd));
		}
	}

	[Theory]
	[InlineData(0,   0)]
	[InlineData(1,  15)]
	[InlineData(12, 39)]
	[InlineData(39, 12)]
	public void Range_FromTuple(int start, int end) {

		(int Start, int End) rangeTuple = (start, end);
		Range actual = new(rangeTuple);

		actual.Start.ShouldBe(start);
		actual.End.ShouldBe(end);
	}

	[Theory]
	[InlineData(0,   0)]
	[InlineData(1,  15)]
	[InlineData(12, 39)]
	[InlineData(39, 12)]
	public void Tuple_FromRange(int start, int end) {

		(int actualStart, int actualEnd) = new Range(start, end);

		actualStart.ShouldBe(start);
		actualEnd.ShouldBe(end);
	}
}
