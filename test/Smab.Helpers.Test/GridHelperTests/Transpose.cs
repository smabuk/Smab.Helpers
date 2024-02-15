namespace Smab.Helpers.Test.GridHelperTests;
public class Transpose {
	[Fact]
	public void Transpose_2dArray() {
		char[,] input = """
			# #
			## 
			"""
			.Split(Environment.NewLine)
			.To2dArray();

		char[,] actual = input.Transpose();
		actual.GetUpperBound(0).ShouldBe(1);
		actual.GetUpperBound(1).ShouldBe(2);
		actual[0, 0].ShouldBe('#');
		actual[1, 0].ShouldBe('#');
		actual[0, 1].ShouldBe(' ');
		actual[1, 1].ShouldBe('#');
		actual[0, 2].ShouldBe('#');
		actual[1, 2].ShouldBe(' ');
	}

	[Fact]
	public void Transpose_Strings() {
		List<string> actual = [.."""
			#.#
			##.
			"""
			.Split(Environment.NewLine)
			.Transpose()];

		actual[0].Length.ShouldBe(2);
		actual.Count.ShouldBe(3);
		actual[0].ShouldBe("##");
		actual[1].ShouldBe(".#");
		actual[2].ShouldBe("#.");
	}
}
