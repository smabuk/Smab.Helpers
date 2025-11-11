namespace Smab.Helpers.Tests.MathsHelperTests;

public class LongRangeTests {
    [Fact]
    public void Length_ShouldBeCorrect() {
        LongRange range = new(10, 20);
        range.Length.ShouldBe(11);
    }

    [Fact]
    public void LowerAndUpper_ShouldBeCorrect() {
        LongRange range = new(20, 10);
        range.Lower.ShouldBe(10);
        range.Upper.ShouldBe(20);
    }

    [Fact]
    public void Values_ShouldEnumerateAllValues() {
        LongRange range = new(3, 6);
        List<long> values = new(range.Values);
        values.ShouldBe(new List<long> { 3, 4, 5, 6 });
    }

    [Theory]
    [InlineData(0, 10, 5, 15, true, 5, 10)]
    [InlineData(0, 10, 11, 20, false, 0, 0)]
    [InlineData(10, 0, 5, 15, true, 5, 10)] // inverted range
    public void TryGetOverlap_ShouldReturnExpected(
        long start1, long end1, long start2, long end2, bool expectedResult, long expectedOverlapStart, long expectedOverlapEnd) {

        LongRange range1 = new(start1, end1);
        LongRange range2 = new(start2, end2);

        bool result = LongRange.TryGetOverlap(range1, range2, out LongRange overlap);

        result.ShouldBe(expectedResult);
        if (expectedResult) {
            overlap.Start.ShouldBe(expectedOverlapStart);
            overlap.End.ShouldBe(expectedOverlapEnd);
        }
    }

    [Fact]
    public void Construction_FromTuple_ShouldWork() {
        (long Start, long End) tuple = (5, 10);
        LongRange range = new(tuple);
        range.Start.ShouldBe(5);
        range.End.ShouldBe(10);
    }

    [Fact]
    public void Deconstruct_ShouldReturnStartAndEnd() {
        LongRange range = new(7, 13);
        range.Deconstruct(out long start, out long end);
        start.ShouldBe(7);
        end.ShouldBe(13);
    }
}
