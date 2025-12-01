namespace Smab.Helpers.Tests.MathsHelperTests;

public class RangeGetOverlapTests {
	[Theory]
	[InlineData(0, 10, 5, 15, true, 5, 10)]
	[InlineData(0, 10, 0, 10, true, 0, 10)]
	[InlineData(0, 10, 11, 20, false, 0, 0)]
	[InlineData(5, 15, 0, 10, true, 5, 10)]
	[InlineData(10, 0, 5, 15, true, 5, 10)] // inverted range
	[InlineData(-10, -5, -8, 0, true, -8, -5)]
	[InlineData(0, 10, 20, 30, false, 0, 0)]
	public void TryGetOverlap_IntTuples_ShouldReturnExpected(
		int start1, int end1, int start2, int end2, bool expectedResult, int expectedOverlapStart, int expectedOverlapEnd) {

		(int Start, int End) range1 = (start1, end1);
		(int Start, int End) range2 = (start2, end2);

		bool result = range1.TryGetOverlap(range2, out (int Start, int End) overlap);

		result.ShouldBe(expectedResult);
		if (expectedResult) {
			overlap.Start.ShouldBe(expectedOverlapStart);
			overlap.End.ShouldBe(expectedOverlapEnd);
		}
	}

	[Theory]
	[InlineData(0.0, 10.0, 5.0, 15.0, true, 5.0, 10.0)]
	[InlineData(0.0, 10.0, 11.0, 20.0, false, 0.0, 0.0)]
	[InlineData(-10.0, -5.0, -8.0, 0.0, true, -8.0, -5.0)]
	public void TryGetOverlap_DoubleTuples_ShouldReturnExpected(
		double start1, double end1, double start2, double end2, bool expectedResult, double expectedOverlapStart, double expectedOverlapEnd) {

		(double Start, double End) range1 = (start1, end1);
		(double Start, double End) range2 = (start2, end2);

		bool result = range1.TryGetOverlap(range2, out (double Start, double End) overlap);

		result.ShouldBe(expectedResult);
		if (expectedResult) {
			overlap.Start.ShouldBe(expectedOverlapStart);
			overlap.End.ShouldBe(expectedOverlapEnd);
		}
	}

	[Fact]
	public void GetOverlap_ShouldThrow_WhenNoOverlap() {
		(int Start, int End) range1 = (0, 10);
		(int Start, int End) range2 = (20, 30);

		Should.Throw<ArgumentOutOfRangeException>(() => range1.GetOverlap(range2));
	}

	[Fact]
	public void GetOverlap_ShouldReturnOverlap_WhenRangesOverlap() {
		(int Start, int End) range1 = (0, 10);
		(int Start, int End) range2 = (5, 15);

		(int Start, int End) = range1.GetOverlap(range2);

		Start.ShouldBe(5);
		End.ShouldBe(10);
	}
}
