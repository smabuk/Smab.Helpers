namespace Smab.Helpers.Tests.GridHelperTests;
public class Create2dArray {
	[Fact]
	public void Create2dArray_ShouldBe() {
		char[,] array = ArrayHelpers.Create2dArray(5, 10, 'x');
		array.GetUpperBound(ArrayHelpers.COL_DIMENSION).ShouldBe(4);
		array.GetUpperBound(ArrayHelpers.ROW_DIMENSION).ShouldBe(9);
		array[0, 0].ShouldBe('x');
		array[3, 5].ShouldBe('x');
	}

	[Fact]
	public void Create2dArray_WithLowerBounds_ShouldBe() {
		char[,] array = ArrayHelpers.Create2dArray(5, 10, -3, -4, 'x');
		array.GetLowerBound(ArrayHelpers.COL_DIMENSION).ShouldBe(-3);
		array.GetLowerBound(ArrayHelpers.ROW_DIMENSION).ShouldBe(-4);
		array.GetUpperBound(ArrayHelpers.COL_DIMENSION).ShouldBe(1);
		array.GetUpperBound(ArrayHelpers.ROW_DIMENSION).ShouldBe(5);
		array[-3, -4].ShouldBe('x');
		array[0, 0].ShouldBe('x');
		array[1, 5].ShouldBe('x');
	}
}
