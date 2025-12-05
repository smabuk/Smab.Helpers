namespace Smab.Helpers.Tests.LinqHelperTests;

public class NotWhere {
	[Fact]
	public void NotWhere_Should_Negate_Where() {
		IEnumerable<int> ints = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11];

		Func<int, bool> isEven = (x => x % 2 == 0);
		Func<int, bool> isOdd = (x => x % 2 == 1);
		Func<int, bool> isGreaterThan8 = (x => x > 8);

		ints.NotWhere(isEven).Count().ShouldBe(6);
		ints.NotWhere(isEven).ShouldBe([1, 3, 5, 7, 9, 11]);

		ints.NotWhere(isOdd).Count().ShouldBe(5);
		ints.NotWhere(isOdd).ShouldBe([2, 4, 6, 8, 10]);

		ints.NotWhere(isGreaterThan8).Count().ShouldBe(8);
		ints.NotWhere(isGreaterThan8).ShouldBe([1, 2, 3, 4, 5, 6, 7, 8]);
	}
}
