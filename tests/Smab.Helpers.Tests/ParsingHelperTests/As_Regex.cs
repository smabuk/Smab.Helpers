using System.Text.RegularExpressions;

namespace Smab.Helpers.Tests.ParsingHelperTests;
public partial class As {

	[GeneratedRegex(@"(?<number1>\d+), (?<number2>\d+), (?<number3>\d+)")]
	private static partial Regex CommaDelimitedNumberRegex();

	[GeneratedRegex(@"(?<number1>\d+)")]
	private static partial Regex NumberRegex();



	[Theory]
	[InlineData("1, 2, 3", (int[])[1, 2, 3])]
	public void Group_As_Ints_ByGroupName_ShouldBe(string input, int[] expected) {

		Match actual = CommaDelimitedNumberRegex().Match(input);

		Assert.Equal(expected[0], actual.As<int>("number1"));
		Assert.Equal(expected[1], actual.As<int>("number2"));
		Assert.Equal(expected[2], actual.As<int>("number3"));
		Assert.Equal($"{expected[2]}", actual.As("number3"));
	}

	[Theory]
	[InlineData("1, 2, 3", (int[])[1, 2, 3])]
	public void GroupAsInts_ByIndex_ShouldBe(string input, int[] expected) {

		Match actual = CommaDelimitedNumberRegex().Match(input);

		Assert.Equal(expected[0], actual.As<int>(1));
		Assert.Equal(expected[1], actual.As<int>(2));
		Assert.Equal(expected[2], actual.As<int>(3));
		Assert.Equal($"{expected[2]}", actual.As(3));
	}

	[Theory]
	[InlineData("1, 2, 3", (int[])[1, 2, 3])]
	public void MatchesAsInts_ShouldBe(string input, int[] expected) {

		MatchCollection matches = NumberRegex().Matches(input);
		int[] actual = [.. matches.As<int>()];
		Assert.Equal(expected, actual);
	}


}
