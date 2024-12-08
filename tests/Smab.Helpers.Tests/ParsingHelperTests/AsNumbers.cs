namespace Smab.Helpers.Tests.ParsingHelperTests;
public class AsNumbers {

	[Fact]
	public void AsNumbers_Tests() {
		"1, 2, 3, 4, 5, 6, 7".AsNumbers().ShouldBe((int[])[1, 2, 3, 4, 5, 6, 7]);
		"1, 2, 3, 4, 5, 6, 7".AsNumbers<int>().ShouldBe((int[])[1, 2, 3, 4, 5, 6, 7]);
		"1, 2, 3, 4, 5, 6, 7".AsNumbers<long>().ShouldBe((long[])[1, 2, 3, 4, 5, 6, 7]);
		"1| 2| 3| 4| 5| 6|7".AsNumbers<long>("|").ShouldBe((long[])[1, 2, 3, 4, 5, 6, 7]);
		"1| 2| 3| 4| 5| 6|7".AsNumbers<long>('|').ShouldBe((long[])[1, 2, 3, 4, 5, 6, 7]);
		"1| 2| 3| 4| 5| 6|7".AsNumbers<long>(["|"]).ShouldBe((long[])[1, 2, 3, 4, 5, 6, 7]);
		"1| 2| 3~ 4| 5| 6|7".AsNumbers<long>(['|', '~']).ShouldBe((long[])[1, 2, 3, 4, 5, 6, 7]);
	}
}
