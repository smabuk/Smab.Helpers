namespace Smab.Helpers.Tests.GridHelperTests;

public class ToDisplayStrings {

	[Fact]
	public void ToDisplayStrings_SimpleIntGrid_Should_ReturnCorrectStrings() {
		Grid<int> grid = new(3, 2) {
			[0, 0] = 1,
			[1, 0] = 2,
			[2, 0] = 3,
			[0, 1] = 4,
			[1, 1] = 5,
			[2, 1] = 6
		};

		string[] result = [.. grid.ToDisplayStrings()];

		result.Length.ShouldBe(2);
		result[0].ShouldBe("123");
		result[1].ShouldBe("456");
	}

	[Fact]
	public void ToDisplayStrings_SimpleCharGrid_Should_ReturnCorrectStrings() {
		Grid<char> grid = new(3, 2) {
			[0, 0] = 'a',
			[1, 0] = 'b',
			[2, 0] = 'c',
			[0, 1] = 'd',
			[1, 1] = 'e',
			[2, 1] = 'f'
		};

		string[] result = [.. grid.ToDisplayStrings()];

		result.Length.ShouldBe(2);
		result[0].ShouldBe("abc");
		result[1].ShouldBe("def");
	}

	[Fact]
	public void ToDisplayStrings_WithSingleReplacement_Should_ApplyReplacement() {
		Grid<char> grid = new(3, 2) {
			[0, 0] = 'a',
			[1, 0] = 'b',
			[2, 0] = 'c',
			[0, 1] = 'd',
			[1, 1] = 'e',
			[2, 1] = 'f'
		};

		string[] result = [.. grid.ToDisplayStrings([("b", "*")])];

		result.Length.ShouldBe(2);
		result[0].ShouldBe("a*c");
		result[1].ShouldBe("def");
	}

	[Fact]
	public void ToDisplayStrings_WithMultipleReplacements_Should_ApplyAll() {
		Grid<char> grid = new(3, 2) {
			[0, 0] = 'a',
			[1, 0] = 'b',
			[2, 0] = 'c',
			[0, 1] = 'd',
			[1, 1] = 'e',
			[2, 1] = 'f'
		};

		string[] result = [.. grid.ToDisplayStrings([("a", "1"), ("c", "3"), ("e", "5")])];

		result.Length.ShouldBe(2);
		result[0].ShouldBe("1b3");
		result[1].ShouldBe("d5f");
	}

	[Fact]
	public void ToDisplayStrings_WithNoMatches_Should_ReturnUnchanged() {
		Grid<char> grid = new(2, 2) {
			[0, 0] = 'a',
			[1, 0] = 'b',
			[0, 1] = 'c',
			[1, 1] = 'd'
		};

		string[] result = [.. grid.ToDisplayStrings([("x", "y"), ("z", "w")])];

		result.Length.ShouldBe(2);
		result[0].ShouldBe("ab");
		result[1].ShouldBe("cd");
	}

	[Fact]
	public void ToDisplayStrings_EmptyReplacements_Should_ReturnOriginal() {
		Grid<int> grid = new(2, 2) {
			[0, 0] = 1,
			[1, 0] = 2,
			[0, 1] = 3,
			[1, 1] = 4
		};

		string[] result = [.. grid.ToDisplayStrings()];

		result.Length.ShouldBe(2);
		result[0].ShouldBe("12");
		result[1].ShouldBe("34");
	}

	[Fact]
	public void ToDisplayStrings_LargerGrid_Should_HandleCorrectly() {
		Grid<int> grid = new(4, 3);
		for (int r = 0; r < 3; r++) {
			for (int c = 0; c < 4; c++) {
				grid[c, r] = r * 4 + c + 1;
			}
		}

		string[] result = [.. grid.ToDisplayStrings()];

		result.Length.ShouldBe(3);
		result[0].ShouldBe("1234");
		result[1].ShouldBe("5678");
		result[2].ShouldBe("9101112");
	}

	[Fact]
	public void ToDisplayStrings_WithNullValue_Should_HandleAsEmptyString() {
		Grid<string?> grid = new(3, 2);
		grid[0, 0] = "a";
		grid[1, 0] = null;
		grid[2, 0] = "c";
		grid[0, 1] = "d";
		grid[1, 1] = "e";
		grid[2, 1] = null;

		string[] result = [.. grid.ToDisplayStrings()];

		result.Length.ShouldBe(2);
		result[0].ShouldBe("ac");
		result[1].ShouldBe("de");
	}

	[Fact]
	public void ToDisplayStrings_WithStringGrid_Should_ConcatenateStrings() {
		Grid<string> grid = new(2, 2);
		grid[0, 0] = "ab";
		grid[1, 0] = "cd";
		grid[0, 1] = "ef";
		grid[1, 1] = "gh";

		string[] result = [.. grid.ToDisplayStrings()];

		result.Length.ShouldBe(2);
		result[0].ShouldBe("abcd");
		result[1].ShouldBe("efgh");
	}

	[Fact]
	public void ToDisplayStrings_WithReplacementsOnStrings_Should_ReplaceCorrectly() {
		Grid<string> grid = new(2, 2);
		grid[0, 0] = "ab";
		grid[1, 0] = "cd";
		grid[0, 1] = "ef";
		grid[1, 1] = "gh";

		string[] result = [.. grid.ToDisplayStrings([("cd", "XX"), ("gh", "YY")])];

		result.Length.ShouldBe(2);
		result[0].ShouldBe("abXX");
		result[1].ShouldBe("efYY");
	}

	[Fact]
	public void ToDisplayStrings_SingleRowGrid_Should_ReturnSingleString() {
		Grid<char> grid = new(5, 1) {
			[0, 0] = 'h',
			[1, 0] = 'e',
			[2, 0] = 'l',
			[3, 0] = 'l',
			[4, 0] = 'o'
		};

		string[] result = [.. grid.ToDisplayStrings()];

		result.Length.ShouldBe(1);
		result[0].ShouldBe("hello");
	}

	[Fact]
	public void ToDisplayStrings_SingleColumnGrid_Should_ReturnMultipleStrings() {
		Grid<int> grid = new(1, 3) {
			[0, 0] = 1,
			[0, 1] = 2,
			[0, 2] = 3
		};

		string[] result = [.. grid.ToDisplayStrings()];

		result.Length.ShouldBe(3);
		result[0].ShouldBe("1");
		result[1].ShouldBe("2");
		result[2].ShouldBe("3");
	}

	[Fact]
	public void ToDisplayStringWithNewLines_Should_JoinWithNewLines() {
		Grid<char> grid = new(3, 2) {
			[0, 0] = 'a',
			[1, 0] = 'b',
			[2, 0] = 'c',
			[0, 1] = 'd',
			[1, 1] = 'e',
			[2, 1] = 'f'
		};

		string result = grid.ToDisplayStringWithNewLines();

		result.ShouldBe($"abc{Environment.NewLine}def");
	}

	[Fact]
	public void ToDisplayStringWithNewLines_WithReplacements_Should_ApplyReplacements() {
		Grid<char> grid = new(3, 2) {
			[0, 0] = 'a',
			[1, 0] = 'b',
			[2, 0] = 'c',
			[0, 1] = 'd',
			[1, 1] = 'e',
			[2, 1] = 'f'
		};

		string result = grid.ToDisplayStringWithNewLines([("b", "*"), ("e", "#")]);

		result.ShouldBe($"a*c{Environment.NewLine}d#f");
	}

	[Fact]
	public void ToDisplayStringWithNewLines_LargerGrid_Should_FormatCorrectly() {
		Grid<int> grid = new(3, 3);
		int value = 1;
		for (int r = 0; r < 3; r++) {
			for (int c = 0; c < 3; c++) {
				grid[c, r] = value++;
			}
		}

		string result = grid.ToDisplayStringWithNewLines();

		string expected = $"123{Environment.NewLine}456{Environment.NewLine}789";
		result.ShouldBe(expected);
	}

	[Fact]
	public void ToDisplayString_WithDefaultSeparator_Should_ConcatenateAll() {
		Grid<char> grid = new(2, 2) {
			[0, 0] = 'a',
			[1, 0] = 'b',
			[0, 1] = 'c',
			[1, 1] = 'd'
		};

		string result = grid.ToDisplayString();

		result.ShouldBe("abcd");
	}

	[Fact]
	public void ToDisplayString_WithEmptySeparator_Should_ConcatenateAll() {
		Grid<int> grid = new(2, 2) {
			[0, 0] = 1,
			[1, 0] = 2,
			[0, 1] = 3,
			[1, 1] = 4
		};

		string result = grid.ToDisplayString("");

		result.ShouldBe("1234");
	}

	[Fact]
	public void ToDisplayString_WithCustomSeparator_Should_UseSeparator() {
		Grid<char> grid = new(2, 2) {
			[0, 0] = 'a',
			[1, 0] = 'b',
			[0, 1] = 'c',
			[1, 1] = 'd'
		};

		string result = grid.ToDisplayString("|");

		result.ShouldBe("ab|cd");
	}

	[Fact]
	public void ToDisplayString_WithCommaSeparator_Should_UseSeparator() {
		Grid<int> grid = new(2, 2) {
			[0, 0] = 1,
			[1, 0] = 2,
			[0, 1] = 3,
			[1, 1] = 4
		};

		string result = grid.ToDisplayString(",");

		result.ShouldBe("12,34");
	}

	[Fact]
	public void ToDisplayString_WithReplacements_Should_ApplyReplacements() {
		Grid<char> grid = new(2, 2) {
			[0, 0] = 'a',
			[1, 0] = 'b',
			[0, 1] = 'c',
			[1, 1] = 'd'
		};

		string result = grid.ToDisplayString("|", [("a", "1"), ("d", "4")]);

		result.ShouldBe("1b|c4");
	}

	[Fact]
	public void ToDisplayString_WithNullSeparator_Should_UseEmptyString() {
		Grid<int> grid = new(2, 2) {
			[0, 0] = 1,
			[1, 0] = 2,
			[0, 1] = 3,
			[1, 1] = 4
		};

		string result = grid.ToDisplayString(null);

		result.ShouldBe("1234");
	}

	[Fact]
	public void ToDisplayStrings_WithDuplicateReplacements_Should_UseLastOccurrence() {
		Grid<char> grid = new(2, 1) {
			[0, 0] = 'a',
			[1, 0] = 'b'
		};

		// According to docs: "If multiple replacements are specified for the same original value, the last occurrence is used"
		string[] result = [.. grid.ToDisplayStrings([("a", "X"), ("a", "Y")])];

		result[0].ShouldBe("Yb");
	}

	[Fact]
	public void ToDisplayStrings_WithBooleanGrid_Should_ConvertToString() {
		Grid<bool> grid = new(2, 2);
		grid[0, 0] = true;
		grid[1, 0] = false;
		grid[0, 1] = false;
		grid[1, 1] = true;

		string[] result = [.. grid.ToDisplayStrings()];

		result.Length.ShouldBe(2);
		result[0].ShouldBe("TrueFalse");
		result[1].ShouldBe("FalseTrue");
	}

	[Fact]
	public void ToDisplayStrings_WithBooleanReplacements_Should_ReplaceCorrectly() {
		Grid<bool> grid = new(2, 2);
		grid[0, 0] = true;
		grid[1, 0] = false;
		grid[0, 1] = false;
		grid[1, 1] = true;

		string[] result = [.. grid.ToDisplayStrings([("True", "1"), ("False", "0")])];

		result.Length.ShouldBe(2);
		result[0].ShouldBe("10");
		result[1].ShouldBe("01");
	}

	[Fact]
	public void ToDisplayStrings_SingleCellGrid_Should_ReturnSingleCharacter() {
		Grid<char> grid = new(1, 1) {
			[0, 0] = 'X'
		};

		string[] result = [.. grid.ToDisplayStrings()];

		result.Length.ShouldBe(1);
		result[0].ShouldBe("X");
	}

	[Fact]
	public void ToDisplayStringWithNewLines_SingleRow_Should_NotAddNewLine() {
		Grid<char> grid = new(3, 1) {
			[0, 0] = 'a',
			[1, 0] = 'b',
			[2, 0] = 'c'
		};

		string result = grid.ToDisplayStringWithNewLines();

		result.ShouldBe("abc");
		result.ShouldNotContain(Environment.NewLine);
	}

	[Fact]
	public void ToDisplayString_EmptyStringReplacements_Should_RemoveCharacters() {
		Grid<char> grid = new(3, 1) {
			[0, 0] = 'a',
			[1, 0] = 'b',
			[2, 0] = 'c'
		};

		string[] result = [.. grid.ToDisplayStrings([("b", "")])];

		result[0].ShouldBe("ac");
	}

	[Fact]
	public void ToDisplayStrings_WithMultiCharReplacements_Should_Work() {
		Grid<char> grid = new(3, 1) {
			[0, 0] = 'a',
			[1, 0] = 'b',
			[2, 0] = 'c'
		};

		string[] result = [.. grid.ToDisplayStrings([("b", "XXX")])];

		result[0].ShouldBe("aXXXc");
	}

	[Fact]
	public void ToDisplayStrings_ComplexReplacements_Should_BuildCorrectOutput() {
		Grid<char> grid = new(4, 2) {
			[0, 0] = '#',
			[1, 0] = '.',
			[2, 0] = '#',
			[3, 0] = '.',
			[0, 1] = '.',
			[1, 1] = '#',
			[2, 1] = '.',
			[3, 1] = '#'
		};

		string[] result = [.. grid.ToDisplayStrings([("#", "█"), (".", " ")])];

		result.Length.ShouldBe(2);
		result[0].ShouldBe("█ █ ");
		result[1].ShouldBe(" █ █");
	}
}
