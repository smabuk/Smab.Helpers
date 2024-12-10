namespace Smab.Helpers.Tests.ParsingHelperTests;
public class AsDigits {
	[Fact]
	public void AsDigits_Tests() {
		string digits = "045678";

		digits.AsDigits<int>().ShouldBe([0, 4, 5, 6, 7, 8]);
		digits.AsDigits<long>().ShouldBe([0, 4, 5, 6, 7, 8]);
		digits.AsDigits<double>().ShouldBe([0.0, 4.0, 5.0, 6.0, 7.0, 8.0]);

		digits.AsDigits<char>().ShouldBe(['0','4', '5', '6', '7', '8']);

		string[] intsAsStrings = ["01234", "56789", "-234"];
		intsAsStrings.AsDigits<int>().ShouldBe([1234, 56789, -234]);

		string[] doublesAsStrings = ["01234.34", "56789.56", "-234.99"];
		doublesAsStrings.AsDigits<double>().ShouldBe([1234.34, 56789.56, -234.99]);
	}

	[Fact]
	public void AsDigitsOrDefaults_Tests() {
		string digits = "045678";
		string badDigits = "045a7b";

		digits.AsDigitsOrDefault<int>(-1).ShouldBe([0, 4, 5, 6, 7, 8]);
		digits.AsDigitsOrDefault<long>(-1).ShouldBe([0, 4, 5, 6, 7, 8]);
		digits.AsDigitsOrDefault<double>(-1).ShouldBe([0.0, 4.0, 5.0, 6.0, 7.0, 8.0]);

		digits.AsDigitsOrDefault<char>('!').ShouldBe(['0','4', '5', '6', '7', '8']);

		badDigits.AsDigitsOrDefault<int>(-1).ShouldBe([0, 4, 5, -1, 7, -1]);
	}
}
