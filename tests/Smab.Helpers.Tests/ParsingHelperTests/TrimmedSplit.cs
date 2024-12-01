namespace Smab.Helpers.Tests.ParsingHelperTests;
public partial class TrimmedSplit {
	[Fact]
	public void TrimmedSplit_ShouldBe() {

		const string INPUT = """
			  123, 4, 5 L : 123 , 
			aaa, 4, ;  x : 123 , 
			""";

		INPUT.TrimmedSplit().Length.ShouldBe(14);
		INPUT.TrimmedSplit(Environment.NewLine).Length.ShouldBe(2);
		INPUT.TrimmedSplit(',').Length.ShouldBe(6);
		INPUT.TrimmedSplit([";"]).Length.ShouldBe(2);
		INPUT.TrimmedSplit([";"]).Last().ShouldBe("x : 123 ,");
		INPUT.TrimmedSplit(",", 5)[^2].ShouldBe("aaa");
	}
}
