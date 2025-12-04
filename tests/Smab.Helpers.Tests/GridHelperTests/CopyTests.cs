namespace Smab.Helpers.Tests.GridHelperTests;

public class CopyTests {
	[Fact]
	public void Copy_Should_Shallow_Copy() {
		char[,] input = """
			# #
			# #
			"""
			.Split(Environment.NewLine)
			.To2dArray();

		char[,] actual = input.Copy();

		actual.ForEachCell().Count(c => c == '#').ShouldBe(4);
		actual.ForEachCell().Count(c => c == ' ').ShouldBe(2);
	}
}
