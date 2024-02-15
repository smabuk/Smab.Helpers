namespace Smab.Helpers.Test.LinqHelperTests;
public class DoesNotContain {
	[Theory]
	[InlineData(  0, false)]
	[InlineData( 11, false)]
	[InlineData( 99, true)]
	[InlineData(100, true)]
	[InlineData( 12, true)]
	[InlineData( -1, true)]
	public void DoesNotContain_Ints_ShouldBe(int number, bool expected) {
		IEnumerable<int> ints = [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11];

		ints.DoesNotContain(number).ShouldBe(expected);
		ints.ToList().DoesNotContain(number).ShouldBe(expected);
		ints.ToHashSet().DoesNotContain(number).ShouldBe(expected);
	}

	[Theory]
	[InlineData("missing", true)]
	[InlineData("badword", true)]
	[InlineData("this",    false)]
	[InlineData("a",       false)]
	[InlineData("list",    false)]
	[InlineData("repeat",  false)]
	public void DoesNotContain_Strings_ShouldBe(string word, bool expected) {
		IEnumerable<string> words = "this is a list of words that includes a repeat".Split(' ');

		words.DoesNotContain(word).ShouldBe(expected);
		words.ToList().DoesNotContain(word).ShouldBe(expected);
		words.ToHashSet().DoesNotContain(word).ShouldBe(expected);
	}
}
