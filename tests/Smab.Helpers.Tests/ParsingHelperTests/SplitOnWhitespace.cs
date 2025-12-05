namespace Smab.Helpers.Tests.ParsingHelperTests;

public partial class SplitOnWhitespace {
	[Fact]
	public void SplitOnWhitespace_ShouldBe() {

		const string INPUT = """
			  123, 4, 5 L		: 123 , 
			aaa,	 4, ;  x : 123 , 
			""";

		INPUT.SplitOnWhitespace().Length.ShouldBe(14);
		INPUT.SplitOnWhitespace(4).Length.ShouldBe(4);
		INPUT.SplitOnWhitespace()[4].ShouldBe(":");
		INPUT.SplitOnWhitespace()[10].ShouldBe("x");
		INPUT.TrimmedSplit(Environment.NewLine)[0].SplitOnWhitespace().Length.ShouldBe(7);
	}
}
