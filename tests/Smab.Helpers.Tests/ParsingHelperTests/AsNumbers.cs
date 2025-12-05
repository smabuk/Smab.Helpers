namespace Smab.Helpers.Tests.ParsingHelperTests;

public class AsNumbers {

	[Fact]
	public void AsNumbers_Tests() {
		"1, 2, 3, 4, 5, 6, 7".AsInts().ShouldBe((int[])[1, 2, 3, 4, 5, 6, 7]);
		"1, 2, 3, 4, 5, 6, 7".AsLongs().ShouldBe((long[])[1, 2, 3, 4, 5, 6, 7]);
		"1, 2, 3, 4, 5, 6, 7".AsNumbers<int>().ShouldBe((int[])[1, 2, 3, 4, 5, 6, 7]);
		"1, 2, 3, 4, 5, 6, 7".AsNumbers<long>().ShouldBe((long[])[1, 2, 3, 4, 5, 6, 7]);
		"1| 2| 3| 4| 5| 6|7".AsNumbers<long>("|").ShouldBe((long[])[1, 2, 3, 4, 5, 6, 7]);
		"1| 2| 3| 4| 5| 6|7".AsNumbers<long>('|').ShouldBe((long[])[1, 2, 3, 4, 5, 6, 7]);
		"1| 2| 3| 4| 5| 6|7".AsNumbers<long>(["|"]).ShouldBe((long[])[1, 2, 3, 4, 5, 6, 7]);
		"1| 2| 3~ 4| 5| 6|7".AsNumbers<long>(['|', '~']).ShouldBe((long[])[1, 2, 3, 4, 5, 6, 7]);
		"1| 2| 3~ 4| 5| 6|7".AsNumbers<long>().ShouldBe((long[])[1, 2, 3, 4, 5, 6, 7]);


		string[] intsAsStrings = ["01234", "56789", "-234"];
		intsAsStrings.AsNumbers<int>().ShouldBe([[1234], [56789], [-234]]);

		string[] doublesAsStrings = ["01234.34", "56789.56", "-234.99"];
		doublesAsStrings.AsNumbers<double>().ShouldBe([[1234.34], [56789.56], [-234.99]]);
	}
}
