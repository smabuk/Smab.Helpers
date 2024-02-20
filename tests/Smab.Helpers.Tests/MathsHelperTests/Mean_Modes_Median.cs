namespace Smab.Helpers.Tests.MathsHelperTests;
public class Mean_Modes_Median {
	[Theory]
	[InlineData(new int[] { 2, 5, 4, 4, 4, 4, 3, 2, 2, 2 }, 3.2)]
	[InlineData(new int[] { 5 }, 5)]
	public void Should_Find_Mean(int[] input, double expected) {
		double actual = MathsHelpers.Mean<int>(input);
		Assert.Equal(expected, actual);
	}

	[Theory]
	[InlineData(new int[] { 2, 5, 4, 4, 4, 4, 3, 2, 2, 2 }, 3.5)]
	[InlineData(new int[] { 5, 1, 3 }, 3)]
	public void Should_Find_Median(int[] input, double expected) {
		double actual = MathsHelpers.MedianAsDouble<int>(input);
		Assert.Equal(expected, actual);
	}

	[Theory]
	[InlineData(new int[] { 1, 5, 4, 4, 4, 4, 3, 2, 2, 2 }, new int[] { 4 })]
	[InlineData(new int[] { 2, 5, 4, 4, 4, 4, 3, 2, 2, 2 }, new int[] { 2, 4 })]
	[InlineData(new int[] { 5, 1, 3 }, new int[] { 5, 1, 3 })]
	public void Should_Find_Modes(int[] input, int[] expected) {
		int[] actual = MathsHelpers.Modes(input).ToArray();
		Assert.Equal(expected, actual);
	}
}
