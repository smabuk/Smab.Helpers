using System.Collections;

namespace Smab.Helpers.Tests.GridHelperTests;
public class Indexes {
	[Fact]
	public void Indexes_Should_Travel_Across_Then_Down() {
		(char, int)[] input = new (char, int)[26];
		for (int i = 0; i < input.GetUpperBound(0); i++) {
			input[i] = new((char)(65 + i), i + 1);
		}
		(char, int)[,] array = input.To2dArray(5);
		IEnumerator<(int Col, int Row)> actualEnumerator = array.Indexes().GetEnumerator();
		for (int row = 0; row < array.RowsCount(); row++) {
			for (int col = 0; col < array.ColsCount(); col++) {
				_ = actualEnumerator.MoveNext();
				(int Col, int Row) actual = actualEnumerator.Current;
				actual.ShouldBe((col, row));
			}
		}
		array.Indexes().Count().ShouldBe(30);
		array.Indexes().First().ShouldBe((0, 0));
		array.Indexes().Last().ShouldBe((4, 5));
	}
}
