namespace Smab.Helpers.Tests.GridHelperTests;

public class ReplaceTests {
	[Fact]
	public void Replace_Should_Replace_Chars() {
		char[,] input = """
			# #
			# #
			"""
			.Split(Environment.NewLine)
			.To2dArray();

		char[,] actual = input.Replace('#', '.');

		actual.ForEachCell().Count(c => c == '#').ShouldBe(0);
		actual.ForEachCell().Count(c => c == '.').ShouldBe(4);
	}

	[Fact]
	public void Replace_Should_Replace_Chars_InPlace() {
		char[,] input = """
			# #
			# #
			"""
			.Split(Environment.NewLine)
			.To2dArray();

		input.ReplaceInPlace('#', '.');

		input.ForEachCell().Count(c => c == '#').ShouldBe(0);
		input.ForEachCell().Count(c => c == '.').ShouldBe(4);
	}

}
