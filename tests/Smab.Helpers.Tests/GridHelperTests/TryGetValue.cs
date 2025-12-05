namespace Smab.Helpers.Tests.GridHelperTests;

public class TryGetValue {

	private static readonly char[,] INPUT = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".To2dArray(5);

	[Theory]
	[InlineData(0, 0, true, 'A')]
	[InlineData(1, 1, true, 'G')]
	[InlineData(4, 3, true, 'T')]
	[InlineData(6, 6, false)]
	public void TryGetValue_Should_Have(int X, int Y, bool isInBounds, char expected = ' ') {
		bool inBounds = INPUT.TryGetValue(X, Y, out char actual);
		inBounds.ShouldBe(isInBounds);
		if (inBounds) {
			actual.ShouldBe(expected);
		}
	}
}
