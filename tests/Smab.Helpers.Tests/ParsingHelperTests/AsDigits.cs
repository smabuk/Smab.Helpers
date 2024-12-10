using Microsoft.VisualBasic;

namespace Smab.Helpers.Tests.ParsingHelperTests;
public class AsDigits {
	[Fact]
	public void AsDigits_Tests() {
		string digits = "045678";

		digits.AsDigits<int>().ShouldBe([0, 4, 5, 6, 7, 8]);
		digits.AsDigits<long>().ShouldBe([0, 4, 5, 6, 7, 8]);
		digits.AsDigits<double>().ShouldBe([0.0, 4.0, 5.0, 6.0, 7.0, 8.0]);

		digits.AsDigits<char>().ShouldBe(['0','4', '5', '6', '7', '8']);

		string[] strings = ["0123434", "5678956", "23499"];
		strings.AsDigits<int>().ShouldBe(
			[
			[0, 1, 2, 3, 4, 3, 4],
			[5, 6, 7, 8, 9, 5, 6],
			[2, 3 ,4 ,9 ,9]
			]);
	}

	[Fact]
	public void AsDigitsOrDefaults_Tests() {
		string digits = "045678";
		string badDigits = "045a7b";

		digits.AsDigitsOrDefaults<int>(-1).ShouldBe([0, 4, 5, 6, 7, 8]);
		digits.AsDigitsOrDefaults<long>(-1).ShouldBe([0, 4, 5, 6, 7, 8]);
		digits.AsDigitsOrDefaults<double>(-1).ShouldBe([0.0, 4.0, 5.0, 6.0, 7.0, 8.0]);

		digits.AsDigitsOrDefaults<char>('!').ShouldBe(['0','4', '5', '6', '7', '8']);

		badDigits.AsDigitsOrDefaults<int>(-1).ShouldBe([0, 4, 5, -1, 7, -1]);

		string[] strings = ["0123434", "5678956", "-234.99"];
		strings.AsDigitsOrDefaults<int>(int.MinValue).ShouldBe(
			[
			[0, 1, 2, 3, 4, 3, 4],
			[5, 6, 7, 8, 9, 5, 6],
			[int.MinValue, 2, 3 ,4, int.MinValue, 9 ,9]
			]);
	}
}
