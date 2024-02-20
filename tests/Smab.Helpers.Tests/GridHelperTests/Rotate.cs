namespace Smab.Helpers.Tests.GridHelperTests;
public class Rotate(ITestOutputHelper testOutputHelper) {
	[Fact]
	public void Rotate_String() {
		string input = """
			A.B.1
			CD..2
			E.FG.
			HIJ.3
			"""
		;

		testOutputHelper.WriteLine("Rotate 0   - testing");
		string actual = input.Rotate(0);
		actual.ShouldBe(input);
		testOutputHelper.WriteLine("Rotate 0   - passed");

		testOutputHelper.WriteLine("Rotate 90  - testing");
		actual = input.Rotate(90);
		actual.ShouldBe("""
				HECA
				I.D.
				JF.B
				.G..
				3.21
				""");
		testOutputHelper.WriteLine("Rotate 90  - passed");

		testOutputHelper.WriteLine("Rotate 180 - testing");
		actual = input.Rotate(180);
		actual.ShouldBe("""
				3.JIH
				.GF.E
				2..DC
				1.B.A
				""");
		testOutputHelper.WriteLine("Rotate 180 - passed");

		testOutputHelper.WriteLine("Rotate 270 - testing");
		actual = input.Rotate(270);
		actual.ShouldBe("""
				12.3
				..G.
				B.FJ
				.D.I
				ACEH
				""");
		testOutputHelper.WriteLine("Rotate 270 - passed");

		testOutputHelper.WriteLine("Rotate -90 - testing");
		actual = input.Rotate(-90);
		actual.ShouldBe("""
				12.3
				..G.
				B.FJ
				.D.I
				ACEH
				""");
		testOutputHelper.WriteLine("Rotate -90 - passed");
	}


	[Fact]
	public void Rotate_2dArray() {
		string input = """
			A.B.1
			CD..2
			E.FG.
			HIJ.3
			"""
		;

		testOutputHelper.WriteLine("Rotate 0   - testing");
		char[,] actual = input.Split(Environment.NewLine).To2dArray().Rotate(0);
		actual.PrintAsString(0).ShouldBe(input);
		testOutputHelper.WriteLine("Rotate 0   - passed");

		testOutputHelper.WriteLine("Rotate 90  - testing");
		actual = input.Split(Environment.NewLine).To2dArray().Rotate(90);
		actual.PrintAsString(0)
			.ShouldBe("""
				HECA
				I.D.
				JF.B
				.G..
				3.21
				""");
		testOutputHelper.WriteLine("Rotate 90  - passed");

		testOutputHelper.WriteLine("Rotate 180 - testing");
		actual = input.Split(Environment.NewLine).To2dArray().Rotate(180);
		actual.PrintAsString(0)
			.ShouldBe("""
				3.JIH
				.GF.E
				2..DC
				1.B.A
				""");
		testOutputHelper.WriteLine("Rotate 180 - passed");

		testOutputHelper.WriteLine("Rotate 270 - testing");
		actual = input.Split(Environment.NewLine).To2dArray().Rotate(270);
		actual.PrintAsString(0)
			.ShouldBe("""
				12.3
				..G.
				B.FJ
				.D.I
				ACEH
				""");
		testOutputHelper.WriteLine("Rotate 270 - passed");

		testOutputHelper.WriteLine("Rotate -90 - testing");
		actual = input.Split(Environment.NewLine).To2dArray().Rotate(-90);
		actual.PrintAsString(0)
			.ShouldBe("""
				12.3
				..G.
				B.FJ
				.D.I
				ACEH
				""");
		testOutputHelper.WriteLine("Rotate -90 - passed");
	}
}
