namespace Smab.Helpers.Test.GridHelperTests;
public class Create2dArray {
	[Fact]
	public void Create2dArray_ShouldBe() {
		char[,] array = ArrayHelpers.Create2dArray(5, 10, 'x');
		Assert.Equal(5, array.GetUpperBound(0) + 1);
		Assert.Equal(10, array.GetUpperBound(1) + 1);
		Assert.Equal('x', array[0, 0]);
		Assert.Equal('x', array[3, 5]);
	}
}
