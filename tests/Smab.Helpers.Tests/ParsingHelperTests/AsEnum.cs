namespace Smab.Helpers.Tests.ParsingHelperTests;
public class AsEnum {

	[Theory]
	[InlineData("Zero", TestEnum.Zero)]
	[InlineData("zero", TestEnum.Zero)]
	[InlineData("one", TestEnum.One)]
	[InlineData("TwO", TestEnum.Two)]
	[InlineData("THREE", TestEnum.Three)]
	[InlineData("four", TestEnum.Four)]
	public void AsEnum_Case_Insensitive(string input, TestEnum expected) {
		input.AsEnum<TestEnum>().ShouldBe(expected);
	}

	[Theory]
	[InlineData("Zero", TestEnum.Zero)]
	[InlineData("one", TestEnum.One)]
	[InlineData("five", TestEnum.InvalidNumber)]
	public void AsEnum_With_Default(string input, TestEnum expected) {
		input.AsEnumOrDefault<TestEnum>(TestEnum.InvalidNumber).ShouldBe(expected);
	}

	[Theory]
	[InlineData('I', TestEnum.I)]
	[InlineData('v', TestEnum.V)]
	[InlineData('X', TestEnum.X)]
	public void AsEnum_From_Char(char input, TestEnum expected) {
		input.AsEnum<TestEnum>().ShouldBe(expected);
	}


	public enum TestEnum {
		InvalidNumber = int.MinValue,

		Zero = 0,
		One = 1,
		Two = 2,
		Three = 3,
		Four = 4,

		I = One,
		V = 5,
		X = 10,
	}
}
