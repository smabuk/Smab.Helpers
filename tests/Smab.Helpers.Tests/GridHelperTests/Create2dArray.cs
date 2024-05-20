namespace Smab.Helpers.Tests.GridHelperTests;
public class Create2dArray {
	[Fact]
	public void Create2dArray_ShouldBe() {
		char[,] array = ArrayHelpers.Create2dArray(5, 10, 'x');
		Assert.Equal(4, array.GetUpperBound(0));
		Assert.Equal(9, array.GetUpperBound(1));
		Assert.Equal('x', array[0, 0]);
		Assert.Equal('x', array[3, 5]);
	}

	[Fact]
	public void Create2dArray_WithLowerBounds_ShouldBe() {
		char[,] array = ArrayHelpers.Create2dArray(5, 10, -3, -4, 'x');
		Assert.Equal(-3, array.GetLowerBound(0));
		Assert.Equal(-4, array.GetLowerBound(1));
		Assert.Equal(1, array.GetUpperBound(0));
		Assert.Equal(5, array.GetUpperBound(1));
		Assert.Equal('x', array[-3, -4]);
		Assert.Equal('x', array[0, 0]);
		Assert.Equal('x', array[1, 5]);
	}
}
