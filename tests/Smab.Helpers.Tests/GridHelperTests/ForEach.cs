namespace Smab.Helpers.Tests.GridHelperTests;
public class ForEach {
	[Fact]
	public void ForEach_2dArray_Should_Travel_Across_Then_Down() {
		Point expectedPoint;
		(char, int)[] input = new (char, int)[26];
		for (int i = 0; i < input.GetUpperBound(0); i++) {
			input[i] = new((char)(65 + i), i + 1);
		}
		(char, int)[,] array = input.To2dArray(5);
		expectedPoint = array.Indexes().Select(p => new Point(p.X, p.Y)).Skip(7).First();
		Assert.Equal((2, 1), expectedPoint);
		(int x, int y, (char, int) value) = array.ForEachCell().Skip(7).First();
		Assert.Equal(2, x);
		Assert.Equal(1, y);
		Assert.Equal('H', value.Item1);
		Assert.Equal(8, value.Item2);
	}
}
