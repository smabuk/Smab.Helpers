using System.Diagnostics.CodeAnalysis;

namespace Smab.Helpers.Tests.ParsingHelperTests;
public partial class As {
	[Theory]
	[InlineData('1', 1)]
	[InlineData('6', 6)]
	public void AsInt_FromChar_ShouldBe(char input, int expected) {
		int actual = input.As<int>();
		Assert.Equal(expected, actual);
	}

	[Theory]
	[InlineData("1", 1)]
	[InlineData("23", 23)]
	[InlineData("-46", -46)]
	[InlineData("", 0)]
	[InlineData("xyz", 0)]
	public void AsInt_ShouldBe(string input, int expected) {
		int actual = input.As<int>();
		Assert.Equal(expected, actual);
	}

	[Theory]
	[InlineData("1", -99, 1)]
	[InlineData("23", -99, 23)]
	[InlineData("-46", -99, -46)]
	[InlineData("", -99, -99)]
	[InlineData("xyz", -99, -99)]
	public void AsInt__WithDefault_ShouldBe(string input, int defaultValue, int expected) {
		int actual = input.As(defaultValue);
		Assert.Equal(expected, actual);
	}

	[Theory]
	[InlineData((string[])["1", "2", "3"], (int[])[1, 2, 3,])]
	public void AsInts_ShouldBe(string[] input, int[] expected) {
		int[] actual = [.. ParsingHelpers.As<int>(input)];
		Assert.Equal(expected, actual);
	}

	[Theory]
	[InlineData((string[])["1", "2", "3"], (int[])[1, 2, 3,])]
	[InlineData((string[])["3", "2", "1"], (int[])[3, 2, 1,])]
	public void AsInts_ShouldBe_AsExtensionMethod(string[] input, int[] expected) {
		int[] actual = [.. input.As<int>()];
		Assert.Equal(expected, actual);
	}
	[Theory]
	[InlineData("1 2 3", (int[])[1, 2, 3])]
	[InlineData("3 2 1", (int[])[3, 2, 1])]
	[InlineData("3   2 1", (int[])[3, 2, 1])]
	[InlineData("3  2 1", (int[])[3, 2, 1])]
	[InlineData("", (int[])[])]
	public void AsInts_FromString_ShouldBe_AsExtensionMethod(string input, int[] expected) {
		int[] actual = [.. input.As<int>((char[]?)null)];
		Assert.Equal(expected, actual);
	}

	[Theory]
	[InlineData("1, 2, 3", (int[])[1, 2, 3])]
	[InlineData("3, 2, 1", (int[])[3, 2, 1])]
	[InlineData("3,   2, 1", (int[])[3, 2, 1])]
	public void AsInts_FromString_WithSeps_ShouldBe_AsExtensionMethod(string input, int[] expected) {
		int[] actual = [.. input.As<int>(',')];
		Assert.Equal(expected, actual);

		actual = [.. input.As<int>([","])];
		Assert.Equal(expected, actual);

		string[] stringSeps = [","];
		actual = [.. input.As<int>(stringSeps)];
		Assert.Equal(expected, actual);

		char[] charSeps = [','];
		actual = [.. input.As<int>(charSeps)];
		Assert.Equal(expected, actual);
	}

	[Theory]
	[InlineData("1", 1)]
	[InlineData("23", 23)]
	[InlineData("-46", -46)]
	[InlineData("", 0)]
	[InlineData("xyz", 0)]
	public void AsLong_ShouldBe(string input, long expected) {
		long actual = input.As<long>();
		Assert.Equal(expected, actual);
	}

	[Theory]
	[InlineData("1", -99, 1)]
	[InlineData("23", -99, 23)]
	[InlineData("-46", -99, -46)]
	[InlineData("", -99, -99)]
	[InlineData("xyz", -99, -99)]
	public void AsLong__WithDefault_ShouldBe(string input, long defaultValue, long expected) {
		long actual = input.As(defaultValue);
		Assert.Equal(expected, actual);
	}

	[Theory]
	[InlineData((string[])["1", "2", "3"], (long[])[1, 2, 3,])]
	public void AsLongs_ShouldBe(string[] input, long[] expected) {
		long[] actual = [.. ParsingHelpers.As<long>(input)];
		Assert.Equal(expected, actual);
	}

	[Theory]
	[InlineData((string[])["1", "2", "3"], (long[])[1, 2, 3,])]
	[InlineData((string[])["3", "2", "1"], (long[])[3, 2, 1,])]
	public void AsLongs_ShouldBe_AsExtensionMethod(string[] input, long[] expected) {
		long[] actual = [.. input.As<long>()];
		Assert.Equal(expected, actual);
	}

	[Theory]
	[InlineData("1", 1)]
	[InlineData("2", 2)]
	[InlineData("3", 3)]
	[InlineData("4", 4)]
	[InlineData("4abc", 5)]
	public void As_Int_ShouldBe(string input, int expected) {
		int actual = input.As(5);
		Assert.Equal(expected, actual);
	}

	[Theory]
	[InlineData("One, 1", "One", 1)]
	[InlineData("Two, 2", "Two", 2)]
	[InlineData("Three, 3", "Three", 3)]
	[InlineData("Four, 4", "Four", 4)]
	[InlineData("Four, abc", "Bad", 999)]
	public void As_T_ShouldBe(string input, string expectedString, int expectedInt) {
		SomeThing badThing = new("Bad", 999);

		SomeThing actual = input.As<SomeThing>(badThing);
		SomeThing expected = new(expectedString, expectedInt);

		Assert.Equal(expected, actual);
	}

	[Theory]
	[InlineData((string[])["One, 1", "Two, 2"], "One", 1, "Two", 2)]
	[InlineData((string[])["One, 1", "Two, x"], "One", 1, "Bad", 999)]
	public void As_EnumerableOfT_ShouldBe(string[] input, string string1, int int1, string string2, int int2) {
		SomeThing badThing = new("Bad", 999);

		SomeThing expected0 = new(string1, int1);
		SomeThing expected1 = new(string2, int2);

		SomeThing[] actual = [.. input.As<SomeThing>(badThing)];
		Assert.Equal(expected0, actual[0]);
		Assert.Equal(expected1, actual[1]);
	}

	private record SomeThing(string ThisIsAString, int ThisIsAnInt) : ISimpleParsable<SomeThing> {
		public static SomeThing Parse(string s, IFormatProvider? provider) {
			string[] tokens = s.Split(',');
			return new(tokens[0], int.Parse(tokens[1]));
		}

		public static bool TryParse([NotNullWhen(true)] string? s, IFormatProvider? provider, [MaybeNullWhen(false)] out SomeThing result) => ISimpleParsable<SomeThing>.TryParse(s, provider, out result);
	}

}
