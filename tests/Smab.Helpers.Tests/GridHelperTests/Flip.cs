namespace Smab.Helpers.Tests.GridHelperTests;

public class Flip {

	private static readonly char[,] INPUT_ARRAY = """
		A.B.1
		CD..2
		E.FG.
		HIJ.3
		""".Split(Environment.NewLine).To2dArray();

	[Fact]
	public void Flip_Horizontally() {
		char[,] array = INPUT_ARRAY.FlipHorizontally();
		string actual = string.Join(Environment.NewLine, array.AsStrings());
		actual.ShouldBe("""
			1.B.A
			2..DC
			.GF.E
			3.JIH
			""");
	}

	[Fact]
	public void Flip_Vertically() {
		char[,] array = INPUT_ARRAY.FlipVertically();
		string actual = string.Join(Environment.NewLine, array.AsStrings());
		actual.ShouldBe("""
			HIJ.3
			E.FG.
			CD..2
			A.B.1
			""");
	}
}
