namespace Smab.Helpers.Tests.IoHelperTests;

public class Utf16CharsTests
{
	public class BlockElementsTests
	{
		[Theory]
		[InlineData('\u2580', "UPPER_HALF_BLOCK")]
		[InlineData('\u2581', "LOWER_ONE_EIGHTH_BLOCK")]
		[InlineData('\u2582', "LOWER_ONE_QUARTER_BLOCK")]
		[InlineData('\u2584', "LOWER_HALF_BLOCK")]
		[InlineData('\u2588', "FULL_BLOCK")]
		[InlineData('\u258C', "LEFT_HALF_BLOCK")]
		[InlineData('\u2590', "RIGHT_HALF_BLOCK")]
		[InlineData('\u2591', "LIGHT_SHADE")]
		[InlineData('\u2592', "MEDIUM_SHADE")]
		[InlineData('\u2593', "DARK_SHADE")]
		public void BlockElements_Constants_Should_HaveCorrectValues(char expected, string description)
		{
			char actual = description switch
			{
				"UPPER_HALF_BLOCK" => Utf16Chars.BlockElements.UPPER_HALF_BLOCK,
				"LOWER_ONE_EIGHTH_BLOCK" => Utf16Chars.BlockElements.LOWER_ONE_EIGHTH_BLOCK,
				"LOWER_ONE_QUARTER_BLOCK" => Utf16Chars.BlockElements.LOWER_ONE_QUARTER_BLOCK,
				"LOWER_HALF_BLOCK" => Utf16Chars.BlockElements.LOWER_HALF_BLOCK,
				"FULL_BLOCK" => Utf16Chars.BlockElements.FULL_BLOCK,
				"LEFT_HALF_BLOCK" => Utf16Chars.BlockElements.LEFT_HALF_BLOCK,
				"RIGHT_HALF_BLOCK" => Utf16Chars.BlockElements.RIGHT_HALF_BLOCK,
				"LIGHT_SHADE" => Utf16Chars.BlockElements.LIGHT_SHADE,
				"MEDIUM_SHADE" => Utf16Chars.BlockElements.MEDIUM_SHADE,
				"DARK_SHADE" => Utf16Chars.BlockElements.DARK_SHADE,
				_ => throw new ArgumentException($"Unknown description: {description}")
			};

			actual.ShouldBe(expected);
		}

		[Fact]
		public void BlockElements_FULL_BLOCK_Should_BeU2588()
		{
			Utf16Chars.BlockElements.FULL_BLOCK.ShouldBe('\u2588');
			((int)Utf16Chars.BlockElements.FULL_BLOCK).ShouldBe(0x2588);
		}

		[Fact]
		public void BlockElements_Shades_Should_HaveDifferentValues()
		{
			Utf16Chars.BlockElements.LIGHT_SHADE.ShouldNotBe(Utf16Chars.BlockElements.MEDIUM_SHADE);
			Utf16Chars.BlockElements.MEDIUM_SHADE.ShouldNotBe(Utf16Chars.BlockElements.DARK_SHADE);
			Utf16Chars.BlockElements.LIGHT_SHADE.ShouldNotBe(Utf16Chars.BlockElements.DARK_SHADE);
		}
	}

	public class BoxDrawingTests
	{
		[Theory]
		[InlineData('\u2500', "LIGHT_HORIZONTAL")]
		[InlineData('\u2501', "HEAVY_HORIZONTAL")]
		[InlineData('\u2502', "LIGHT_VERTICAL")]
		[InlineData('\u2503', "HEAVY_VERTICAL")]
		[InlineData('\u250C', "LIGHT_DOWN_AND_RIGHT")]
		[InlineData('\u2510', "LIGHT_DOWN_AND_LEFT")]
		[InlineData('\u2514', "LIGHT_UP_AND_RIGHT")]
		[InlineData('\u2518', "LIGHT_UP_AND_LEFT")]
		[InlineData('\u251C', "LIGHT_VERTICAL_AND_RIGHT")]
		[InlineData('\u2524', "LIGHT_VERTICAL_AND_LEFT")]
		[InlineData('\u252C', "LIGHT_DOWN_AND_HORIZONTAL")]
		[InlineData('\u2534', "LIGHT_UP_AND_HORIZONTAL")]
		[InlineData('\u253C', "LIGHT_VERTICAL_AND_HORIZONTAL")]
		[InlineData('\u2550', "DOUBLE_HORIZONTAL")]
		[InlineData('\u2551', "DOUBLE_VERTICAL")]
		public void BoxDrawing_Constants_Should_HaveCorrectValues(char expected, string constantName)
		{
			char actual = constantName switch
			{
				"LIGHT_HORIZONTAL" => Utf16Chars.BoxDrawing.LIGHT_HORIZONTAL,
				"HEAVY_HORIZONTAL" => Utf16Chars.BoxDrawing.HEAVY_HORIZONTAL,
				"LIGHT_VERTICAL" => Utf16Chars.BoxDrawing.LIGHT_VERTICAL,
				"HEAVY_VERTICAL" => Utf16Chars.BoxDrawing.HEAVY_VERTICAL,
				"LIGHT_DOWN_AND_RIGHT" => Utf16Chars.BoxDrawing.LIGHT_DOWN_AND_RIGHT,
				"LIGHT_DOWN_AND_LEFT" => Utf16Chars.BoxDrawing.LIGHT_DOWN_AND_LEFT,
				"LIGHT_UP_AND_RIGHT" => Utf16Chars.BoxDrawing.LIGHT_UP_AND_RIGHT,
				"LIGHT_UP_AND_LEFT" => Utf16Chars.BoxDrawing.LIGHT_UP_AND_LEFT,
				"LIGHT_VERTICAL_AND_RIGHT" => Utf16Chars.BoxDrawing.LIGHT_VERTICAL_AND_RIGHT,
				"LIGHT_VERTICAL_AND_LEFT" => Utf16Chars.BoxDrawing.LIGHT_VERTICAL_AND_LEFT,
				"LIGHT_DOWN_AND_HORIZONTAL" => Utf16Chars.BoxDrawing.LIGHT_DOWN_AND_HORIZONTAL,
				"LIGHT_UP_AND_HORIZONTAL" => Utf16Chars.BoxDrawing.LIGHT_UP_AND_HORIZONTAL,
				"LIGHT_VERTICAL_AND_HORIZONTAL" => Utf16Chars.BoxDrawing.LIGHT_VERTICAL_AND_HORIZONTAL,
				"DOUBLE_HORIZONTAL" => Utf16Chars.BoxDrawing.DOUBLE_HORIZONTAL,
				"DOUBLE_VERTICAL" => Utf16Chars.BoxDrawing.DOUBLE_VERTICAL,
				_ => throw new ArgumentException($"Unknown constant: {constantName}")
			};

			actual.ShouldBe(expected);
		}

		[Fact]
		public void BoxDrawing_Aliases_Should_MatchFullNames()
		{
			Utf16Chars.BoxDrawing.LIGHT_HORIZONTAL.ShouldBe(Utf16Chars.BoxDrawing.BOX_DRAWINGS_LIGHT_HORIZONTAL);
			Utf16Chars.BoxDrawing.LIGHT_VERTICAL.ShouldBe(Utf16Chars.BoxDrawing.BOX_DRAWINGS_LIGHT_VERTICAL);
			Utf16Chars.BoxDrawing.DOUBLE_HORIZONTAL.ShouldBe(Utf16Chars.BoxDrawing.BOX_DRAWINGS_DOUBLE_HORIZONTAL);
			Utf16Chars.BoxDrawing.DOUBLE_VERTICAL.ShouldBe(Utf16Chars.BoxDrawing.BOX_DRAWINGS_DOUBLE_VERTICAL);
		}

		[Fact]
		public void BoxDrawing_ArcCharacters_Should_HaveCorrectValues()
		{
			Utf16Chars.BoxDrawing.LIGHT_ARC_DOWN_AND_RIGHT.ShouldBe('\u256D');
			Utf16Chars.BoxDrawing.LIGHT_ARC_DOWN_AND_LEFT.ShouldBe('\u256E');
			Utf16Chars.BoxDrawing.LIGHT_ARC_UP_AND_LEFT.ShouldBe('\u256F');
			Utf16Chars.BoxDrawing.LIGHT_ARC_UP_AND_RIGHT.ShouldBe('\u2570');
		}
	}

	public class BrailleTests
	{
		[Theory]
		[InlineData('\u2800', "BLANK")]
		[InlineData('\u2801', "DOTS_1")]
		[InlineData('\u2803', "DOTS_12")]
		[InlineData('\u2807', "DOTS_123")]
		[InlineData('\u280F', "DOTS_1234")]
		[InlineData('\u281F', "DOTS_12345")]
		[InlineData('\u282F', "DOTS_12346")]
		[InlineData('\u283F', "DOTS_123456")]
		[InlineData('\u28FF', "DOTS_12345678")]
		public void Braille_Constants_Should_HaveCorrectValues(char expected, string pattern)
		{
			char actual = pattern switch
			{
				"BLANK" => Utf16Chars.Braille.BRAILLE_PATTERN_BLANK,
				"DOTS_1" => Utf16Chars.Braille.BRAILLE_PATTERN_DOTS_1,
				"DOTS_12" => Utf16Chars.Braille.BRAILLE_PATTERN_DOTS_12,
				"DOTS_123" => Utf16Chars.Braille.BRAILLE_PATTERN_DOTS_123,
				"DOTS_1234" => Utf16Chars.Braille.BRAILLE_PATTERN_DOTS_1234,
				"DOTS_12345" => Utf16Chars.Braille.BRAILLE_PATTERN_DOTS_12345,
				"DOTS_12346" => Utf16Chars.Braille.BRAILLE_PATTERN_DOTS_12346,
				"DOTS_123456" => Utf16Chars.Braille.BRAILLE_PATTERN_DOTS_123456,
				"DOTS_12345678" => Utf16Chars.Braille.BRAILLE_PATTERN_DOTS_12345678,
				_ => throw new ArgumentException($"Unknown pattern: {pattern}")
			};

			actual.ShouldBe(expected);
		}

		[Fact]
		public void Braille_BLANK_Should_BeU2800()
		{
			Utf16Chars.Braille.BRAILLE_PATTERN_BLANK.ShouldBe('\u2800');
			((int)Utf16Chars.Braille.BRAILLE_PATTERN_BLANK).ShouldBe(0x2800);
		}

		[Fact]
		public void Braille_FullPattern_Should_BeU28FF()
		{
			Utf16Chars.Braille.BRAILLE_PATTERN_DOTS_12345678.ShouldBe('\u28FF');
			((int)Utf16Chars.Braille.BRAILLE_PATTERN_DOTS_12345678).ShouldBe(0x28FF);
		}
	}

	public class GeometricShapesTests
	{
		[Theory]
		[InlineData('\u25A0', "BLACK_SQUARE")]
		[InlineData('\u25A1', "WHITE_SQUARE")]
		[InlineData('\u25CF', "BLACK_CIRCLE")]
		[InlineData('\u25CB', "WHITE_CIRCLE")]
		[InlineData('\u25B2', "BLACK_UP_POINTING_TRIANGLE")]
		[InlineData('\u25B3', "WHITE_UP_POINTING_TRIANGLE")]
		[InlineData('\u25B6', "BLACK_RIGHT_POINTING_TRIANGLE")]
		[InlineData('\u25BC', "BLACK_DOWN_POINTING_TRIANGLE")]
		[InlineData('\u25C0', "BLACK_LEFT_POINTING_TRIANGLE")]
		[InlineData('\u25C6', "BLACK_DIAMOND")]
		[InlineData('\u25C7', "WHITE_DIAMOND")]
		public void GeometricShapes_Constants_Should_HaveCorrectValues(char expected, string shapeName)
		{
			char actual = shapeName switch
			{
				"BLACK_SQUARE" => Utf16Chars.GeometricShapes.BLACK_SQUARE,
				"WHITE_SQUARE" => Utf16Chars.GeometricShapes.WHITE_SQUARE,
				"BLACK_CIRCLE" => Utf16Chars.GeometricShapes.BLACK_CIRCLE,
				"WHITE_CIRCLE" => Utf16Chars.GeometricShapes.WHITE_CIRCLE,
				"BLACK_UP_POINTING_TRIANGLE" => Utf16Chars.GeometricShapes.BLACK_UP_POINTING_TRIANGLE,
				"WHITE_UP_POINTING_TRIANGLE" => Utf16Chars.GeometricShapes.WHITE_UP_POINTING_TRIANGLE,
				"BLACK_RIGHT_POINTING_TRIANGLE" => Utf16Chars.GeometricShapes.BLACK_RIGHT_POINTING_TRIANGLE,
				"BLACK_DOWN_POINTING_TRIANGLE" => Utf16Chars.GeometricShapes.BLACK_DOWN_POINTING_TRIANGLE,
				"BLACK_LEFT_POINTING_TRIANGLE" => Utf16Chars.GeometricShapes.BLACK_LEFT_POINTING_TRIANGLE,
				"BLACK_DIAMOND" => Utf16Chars.GeometricShapes.BLACK_DIAMOND,
				"WHITE_DIAMOND" => Utf16Chars.GeometricShapes.WHITE_DIAMOND,
				_ => throw new ArgumentException($"Unknown shape: {shapeName}")
			};

			actual.ShouldBe(expected);
		}

		[Fact]
		public void GeometricShapes_BlackAndWhite_Should_HaveDifferentValues()
		{
			Utf16Chars.GeometricShapes.BLACK_SQUARE.ShouldNotBe(Utf16Chars.GeometricShapes.WHITE_SQUARE);
			Utf16Chars.GeometricShapes.BLACK_CIRCLE.ShouldNotBe(Utf16Chars.GeometricShapes.WHITE_CIRCLE);
			Utf16Chars.GeometricShapes.BLACK_DIAMOND.ShouldNotBe(Utf16Chars.GeometricShapes.WHITE_DIAMOND);
		}

		[Fact]
		public void GeometricShapes_Triangles_Should_PointInDifferentDirections()
		{
			char up = Utf16Chars.GeometricShapes.BLACK_UP_POINTING_TRIANGLE;
			char right = Utf16Chars.GeometricShapes.BLACK_RIGHT_POINTING_TRIANGLE;
			char down = Utf16Chars.GeometricShapes.BLACK_DOWN_POINTING_TRIANGLE;
			char left = Utf16Chars.GeometricShapes.BLACK_LEFT_POINTING_TRIANGLE;

			up.ShouldNotBe(right);
			right.ShouldNotBe(down);
			down.ShouldNotBe(left);
			left.ShouldNotBe(up);
		}
	}

	public class CharacterEncodingTests
	{
		[Theory]
		[InlineData("BlockElements.FULL_BLOCK", 0x2580, 0x259F)]
		[InlineData("BoxDrawing.LIGHT_HORIZONTAL", 0x2500, 0x257F)]
		[InlineData("Braille.BRAILLE_PATTERN_BLANK", 0x2800, 0x28FF)]
		[InlineData("GeometricShapes.BLACK_SQUARE", 0x25A0, 0x25FF)]
		public void Utf16Chars_Should_BeInValidUnicodeRanges(string category, int rangeStart, int rangeEnd)
		{
			// Test a sample character from each category is within expected Unicode block range
			int charValue = category switch
			{
				"BlockElements.FULL_BLOCK" => Utf16Chars.BlockElements.FULL_BLOCK,
				"BoxDrawing.LIGHT_HORIZONTAL" => Utf16Chars.BoxDrawing.LIGHT_HORIZONTAL,
				"Braille.BRAILLE_PATTERN_BLANK" => Utf16Chars.Braille.BRAILLE_PATTERN_BLANK,
				"GeometricShapes.BLACK_SQUARE" => Utf16Chars.GeometricShapes.BLACK_SQUARE,
				_ => throw new ArgumentException($"Unknown category: {category}")
			};

			charValue.ShouldBeGreaterThanOrEqualTo(rangeStart);
			charValue.ShouldBeLessThanOrEqualTo(rangeEnd);
		}

		[Fact]
		public void Utf16Chars_Constants_Should_BeValidCharacters()
		{
			// Sample characters should not be control characters
			char.IsControl(Utf16Chars.BlockElements.FULL_BLOCK).ShouldBeFalse();
			char.IsControl(Utf16Chars.BoxDrawing.LIGHT_HORIZONTAL).ShouldBeFalse();
			char.IsControl(Utf16Chars.GeometricShapes.BLACK_CIRCLE).ShouldBeFalse();
		}

		[Fact]
		public void Utf16Chars_Constants_Should_HaveUnicodeCategory_OtherSymbol()
		{
			// Most of these characters should be in the Symbol category
			char.GetUnicodeCategory(Utf16Chars.BlockElements.FULL_BLOCK).ShouldBe(System.Globalization.UnicodeCategory.OtherSymbol);
			char.GetUnicodeCategory(Utf16Chars.BoxDrawing.LIGHT_HORIZONTAL).ShouldBe(System.Globalization.UnicodeCategory.OtherSymbol);
			char.GetUnicodeCategory(Utf16Chars.GeometricShapes.BLACK_SQUARE).ShouldBe(System.Globalization.UnicodeCategory.OtherSymbol);
		}
	}

	public class UsageExamplesTests
	{
		[Fact]
		public void BoxDrawing_CanCreateSimpleBox()
		{
			string box = $"{Utf16Chars.BoxDrawing.LIGHT_DOWN_AND_RIGHT}" +
			             $"{Utf16Chars.BoxDrawing.LIGHT_HORIZONTAL}" +
			             $"{Utf16Chars.BoxDrawing.LIGHT_DOWN_AND_LEFT}\n" +
			             $"{Utf16Chars.BoxDrawing.LIGHT_VERTICAL} {Utf16Chars.BoxDrawing.LIGHT_VERTICAL}\n" +
			             $"{Utf16Chars.BoxDrawing.LIGHT_UP_AND_RIGHT}" +
			             $"{Utf16Chars.BoxDrawing.LIGHT_HORIZONTAL}" +
			             $"{Utf16Chars.BoxDrawing.LIGHT_UP_AND_LEFT}";

			box.ShouldContain("\u250C\u2500\u2510"); // ┌─┐
			box.ShouldContain("\u2502 \u2502");      // │ │
			box.ShouldContain("\u2514\u2500\u2518"); // └─┘
		}

		[Fact]
		public void BlockElements_CanCreateProgressBar()
		{
			string progressBar = new string(Utf16Chars.BlockElements.FULL_BLOCK, 5) +
			                     new string(Utf16Chars.BlockElements.LIGHT_SHADE, 5);

			progressBar.ShouldBe("\u2588\u2588\u2588\u2588\u2588\u2591\u2591\u2591\u2591\u2591"); // █████░░░░░
			progressBar.Length.ShouldBe(10);
		}

		[Fact]
		public void GeometricShapes_CanBeUsedAsMarkers()
		{
			string checklist = $"{Utf16Chars.GeometricShapes.BLACK_SQUARE} Completed\n" +
			                   $"{Utf16Chars.GeometricShapes.WHITE_SQUARE} Pending";

			checklist.ShouldContain("\u25A0 Completed"); // ■ Completed
			checklist.ShouldContain("\u25A1 Pending");   // □ Pending
		}
	}
}
