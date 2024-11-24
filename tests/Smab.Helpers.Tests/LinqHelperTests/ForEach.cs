namespace Smab.Helpers.Tests.LinqHelperTests;
public class ForEach {
	private static readonly IEnumerable<int>    ints    = [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11];

	[Fact]
	public void ForEach_Ints_Should_Return() {
		int actual = 0;
		ints.ForEach(i => { actual += i; });
		actual.ShouldBe(66);
	}

	[Fact]
	public void ForEach_Ints_Arrray_Should_Return() {
		int[] intArray = [.. ints];
		int actual = 0;
		intArray.ForEach(i => { actual += i; });
		actual.ShouldBe(66);
	}

}
