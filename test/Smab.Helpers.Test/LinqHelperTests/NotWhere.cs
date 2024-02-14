namespace Smab.Helpers.Test.LinqHelperTests;
public class NotWhereTests {
	[Fact]
	public void NotWhere_Negates_Where() {
		IEnumerable<int> ints = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11];

		ints.Count().ShouldBe(11);
		ints.Where(x => x % 2 == 0).Count().ShouldBe(5);
		ints.NotWhere(x => x % 2 == 0).Count().ShouldBe(6);
	}
}
