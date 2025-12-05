namespace Smab.Helpers.Tests.MathsHelperTests;

public class LinearEquations {

	[Theory]
	[InlineData(94, 22, 8400, 34, 67, 5400, 80, 40)]
	[InlineData(17, 84, 7870, 86, 37, 6450, 38, 86)]
	public void TrySolveLinearEquations_ShouldBe_True(long ax, long bx, long cx, long ay, long by, long cy, long expectedA, long expectedB) {
		MathsHelpers.TrySolveLinearEquations(ax, bx, cx, ay, by, cy, out (long A, long B) actual).ShouldBeTrue();
		actual.A.ShouldBe(expectedA);
		actual.B.ShouldBe(expectedB);
	}

	[Theory]
	[InlineData(69, 27, 18641, 23, 71, 10279)]
	[InlineData(26, 67, 12748, 66, 21, 12176)]
	public void TrySolveLinearEquations_Should_Fail(long ax, long bx, long cx, long ay, long by, long cy) {
		MathsHelpers.TrySolveLinearEquations(ax, bx, cx, ay, by, cy, out (long A, long B) _).ShouldBeFalse();
	}
}
