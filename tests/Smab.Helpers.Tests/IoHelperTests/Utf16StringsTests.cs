namespace Smab.Helpers.Tests.IoHelperTests;

public class Utf16StringsTests {
	public class MathematicalAlphanumericSymbolsTests {
		[Fact]
		public void MathematicalBold_Constants_Should_NotBeEmpty() {
			Utf16Strings.MATHEMATICAL_BOLD_CAPITAL_A.ShouldNotBeNullOrEmpty();
			Utf16Strings.MATHEMATICAL_BOLD_CAPITAL_B.ShouldNotBeNullOrEmpty();
			Utf16Strings.MATHEMATICAL_BOLD_CAPITAL_C.ShouldNotBeNullOrEmpty();
			Utf16Strings.MATHEMATICAL_BOLD_SMALL_A.ShouldNotBeNullOrEmpty();
			Utf16Strings.MATHEMATICAL_BOLD_SMALL_B.ShouldNotBeNullOrEmpty();
			Utf16Strings.MATHEMATICAL_BOLD_SMALL_C.ShouldNotBeNullOrEmpty();
		}

		[Fact]
		public void MathematicalBold_And_Italic_Should_BeDifferent() {
			Utf16Strings.MATHEMATICAL_BOLD_CAPITAL_A.ShouldNotBe(Utf16Strings.MATHEMATICAL_ITALIC_CAPITAL_A);
			Utf16Strings.MATHEMATICAL_BOLD_SMALL_A.ShouldNotBe(Utf16Strings.MATHEMATICAL_ITALIC_SMALL_A);
		}

		[Fact]
		public void MathematicalItalic_Constants_Should_NotBeEmpty() {
			Utf16Strings.MATHEMATICAL_ITALIC_CAPITAL_A.ShouldNotBeNullOrEmpty();
			Utf16Strings.MATHEMATICAL_ITALIC_SMALL_A.ShouldNotBeNullOrEmpty();
		}

		[Fact]
		public void MathematicalBoldItalic_Constants_Should_NotBeEmpty() {
			Utf16Strings.MATHEMATICAL_BOLD_ITALIC_CAPITAL_A.ShouldNotBeNullOrEmpty();
			Utf16Strings.MATHEMATICAL_BOLD_ITALIC_SMALL_A.ShouldNotBeNullOrEmpty();
		}

		[Fact]
		public void MathematicalScript_Constants_Should_NotBeEmpty() {
			Utf16Strings.MATHEMATICAL_SCRIPT_CAPITAL_A.ShouldNotBeNullOrEmpty();
			Utf16Strings.MATHEMATICAL_SCRIPT_SMALL_A.ShouldNotBeNullOrEmpty();
		}

		[Fact]
		public void MathematicalFraktur_Constants_Should_NotBeEmpty() {
			Utf16Strings.MATHEMATICAL_FRAKTUR_CAPITAL_A.ShouldNotBeNullOrEmpty();
			Utf16Strings.MATHEMATICAL_FRAKTUR_SMALL_A.ShouldNotBeNullOrEmpty();
		}

		[Fact]
		public void MathematicalDoubleStruck_Constants_Should_NotBeEmpty() {
			Utf16Strings.MATHEMATICAL_DOUBLE_STRUCK_CAPITAL_A.ShouldNotBeNullOrEmpty();
			Utf16Strings.MATHEMATICAL_DOUBLE_STRUCK_SMALL_A.ShouldNotBeNullOrEmpty();
		}

		[Fact]
		public void MathematicalSansSerif_Constants_Should_NotBeEmpty() {
			Utf16Strings.MATHEMATICAL_SANS_SERIF_CAPITAL_A.ShouldNotBeNullOrEmpty();
			Utf16Strings.MATHEMATICAL_SANS_SERIF_SMALL_A.ShouldNotBeNullOrEmpty();
		}

		[Fact]
		public void MathematicalMonospace_Constants_Should_NotBeEmpty() {
			Utf16Strings.MATHEMATICAL_MONOSPACE_CAPITAL_A.ShouldNotBeNullOrEmpty();
			Utf16Strings.MATHEMATICAL_MONOSPACE_SMALL_A.ShouldNotBeNullOrEmpty();
		}

		[Fact]
		public void AllMathematicalStyles_Should_BeDistinct() {
			string[] styles =
			[
				Utf16Strings.MATHEMATICAL_BOLD_CAPITAL_A,
				Utf16Strings.MATHEMATICAL_ITALIC_CAPITAL_A,
				Utf16Strings.MATHEMATICAL_BOLD_ITALIC_CAPITAL_A,
				Utf16Strings.MATHEMATICAL_SCRIPT_CAPITAL_A,
				Utf16Strings.MATHEMATICAL_FRAKTUR_CAPITAL_A,
				Utf16Strings.MATHEMATICAL_DOUBLE_STRUCK_CAPITAL_A,
				Utf16Strings.MATHEMATICAL_SANS_SERIF_CAPITAL_A,
				Utf16Strings.MATHEMATICAL_MONOSPACE_CAPITAL_A
			];

			styles.Distinct().Count().ShouldBe(styles.Length);
		}

		[Fact]
		public void MathematicalBold_CapitalAndSmall_Should_BeDifferent() {
			Utf16Strings.MATHEMATICAL_BOLD_CAPITAL_A.ShouldNotBe(Utf16Strings.MATHEMATICAL_BOLD_SMALL_A);
			Utf16Strings.MATHEMATICAL_BOLD_CAPITAL_Z.ShouldNotBe(Utf16Strings.MATHEMATICAL_BOLD_SMALL_Z);
		}

		[Fact]
		public void MathematicalBold_DifferentLetters_Should_BeDifferent() {
			Utf16Strings.MATHEMATICAL_BOLD_CAPITAL_A.ShouldNotBe(Utf16Strings.MATHEMATICAL_BOLD_CAPITAL_B);
			Utf16Strings.MATHEMATICAL_BOLD_SMALL_A.ShouldNotBe(Utf16Strings.MATHEMATICAL_BOLD_SMALL_B);
		}
	}

	public class MathematicalDigitsTests {
		[Fact]
		public void MathematicalBoldDigits_Constants_Should_NotBeEmpty() {
			Utf16Strings.MATHEMATICAL_BOLD_DIGIT_ZERO.ShouldNotBeNullOrEmpty();
			Utf16Strings.MATHEMATICAL_BOLD_DIGIT_ONE.ShouldNotBeNullOrEmpty();
			Utf16Strings.MATHEMATICAL_BOLD_DIGIT_NINE.ShouldNotBeNullOrEmpty();
		}

		[Fact]
		public void MathematicalDoubleStruckDigits_Constants_Should_NotBeEmpty() {
			Utf16Strings.MATHEMATICAL_DOUBLE_STRUCK_DIGIT_ZERO.ShouldNotBeNullOrEmpty();
			Utf16Strings.MATHEMATICAL_DOUBLE_STRUCK_DIGIT_ONE.ShouldNotBeNullOrEmpty();
			Utf16Strings.MATHEMATICAL_DOUBLE_STRUCK_DIGIT_NINE.ShouldNotBeNullOrEmpty();
		}

		[Fact]
		public void MathematicalSansSerifDigits_Constants_Should_NotBeEmpty() {
			Utf16Strings.MATHEMATICAL_SANS_SERIF_DIGIT_ZERO.ShouldNotBeNullOrEmpty();
			Utf16Strings.MATHEMATICAL_SANS_SERIF_DIGIT_NINE.ShouldNotBeNullOrEmpty();
		}

		[Fact]
		public void MathematicalMonospaceDigits_Constants_Should_NotBeEmpty() {
			Utf16Strings.MATHEMATICAL_MONOSPACE_DIGIT_ZERO.ShouldNotBeNullOrEmpty();
			Utf16Strings.MATHEMATICAL_MONOSPACE_DIGIT_NINE.ShouldNotBeNullOrEmpty();
		}

		[Fact]
		public void AllDigitStyles_Should_BeDistinct() {
			string[] styles =
			[
				Utf16Strings.MATHEMATICAL_BOLD_DIGIT_ZERO,
				Utf16Strings.MATHEMATICAL_DOUBLE_STRUCK_DIGIT_ZERO,
				Utf16Strings.MATHEMATICAL_SANS_SERIF_DIGIT_ZERO,
				Utf16Strings.MATHEMATICAL_MONOSPACE_DIGIT_ZERO
			];

			styles.Distinct().Count().ShouldBe(styles.Length);
		}

		[Fact]
		public void MathematicalBoldDigits_AllTenDigits_Should_BeDistinct() {
			string[] digits =
			[
				Utf16Strings.MATHEMATICAL_BOLD_DIGIT_ZERO,
				Utf16Strings.MATHEMATICAL_BOLD_DIGIT_ONE,
				Utf16Strings.MATHEMATICAL_BOLD_DIGIT_TWO,
				Utf16Strings.MATHEMATICAL_BOLD_DIGIT_THREE,
				Utf16Strings.MATHEMATICAL_BOLD_DIGIT_FOUR,
				Utf16Strings.MATHEMATICAL_BOLD_DIGIT_FIVE,
				Utf16Strings.MATHEMATICAL_BOLD_DIGIT_SIX,
				Utf16Strings.MATHEMATICAL_BOLD_DIGIT_SEVEN,
				Utf16Strings.MATHEMATICAL_BOLD_DIGIT_EIGHT,
				Utf16Strings.MATHEMATICAL_BOLD_DIGIT_NINE
			];

			digits.Distinct().Count().ShouldBe(10);
		}
	}

	public class GreekLettersTests {
		[Fact]
		public void MathematicalBoldGreek_CapitalLetters_Should_NotBeEmpty() {
			Utf16Strings.MATHEMATICAL_BOLD_CAPITAL_ALPHA.ShouldNotBeNullOrEmpty();
			Utf16Strings.MATHEMATICAL_BOLD_CAPITAL_BETA.ShouldNotBeNullOrEmpty();
			Utf16Strings.MATHEMATICAL_BOLD_CAPITAL_GAMMA.ShouldNotBeNullOrEmpty();
			Utf16Strings.MATHEMATICAL_BOLD_CAPITAL_OMEGA.ShouldNotBeNullOrEmpty();
		}

		[Fact]
		public void MathematicalBoldGreek_SmallLetters_Should_NotBeEmpty() {
			Utf16Strings.MATHEMATICAL_BOLD_SMALL_ALPHA.ShouldNotBeNullOrEmpty();
			Utf16Strings.MATHEMATICAL_BOLD_SMALL_BETA.ShouldNotBeNullOrEmpty();
			Utf16Strings.MATHEMATICAL_BOLD_SMALL_GAMMA.ShouldNotBeNullOrEmpty();
			Utf16Strings.MATHEMATICAL_BOLD_SMALL_OMEGA.ShouldNotBeNullOrEmpty();
		}

		[Fact]
		public void MathematicalItalicGreek_CapitalLetters_Should_NotBeEmpty() {
			Utf16Strings.MATHEMATICAL_ITALIC_CAPITAL_ALPHA.ShouldNotBeNullOrEmpty();
			Utf16Strings.MATHEMATICAL_ITALIC_CAPITAL_BETA.ShouldNotBeNullOrEmpty();
			Utf16Strings.MATHEMATICAL_ITALIC_CAPITAL_OMEGA.ShouldNotBeNullOrEmpty();
		}

		[Fact]
		public void MathematicalGreek_CapitalAndSmall_Should_BeDifferent() {
			Utf16Strings.MATHEMATICAL_BOLD_CAPITAL_ALPHA.ShouldNotBe(Utf16Strings.MATHEMATICAL_BOLD_SMALL_ALPHA);
			Utf16Strings.MATHEMATICAL_BOLD_CAPITAL_BETA.ShouldNotBe(Utf16Strings.MATHEMATICAL_BOLD_SMALL_BETA);
		}

		[Fact]
		public void GreekLetters_BoldAndItalic_Should_BeDifferent() {
			Utf16Strings.MATHEMATICAL_BOLD_CAPITAL_ALPHA.ShouldNotBe(Utf16Strings.MATHEMATICAL_ITALIC_CAPITAL_ALPHA);
			Utf16Strings.MATHEMATICAL_BOLD_SMALL_ALPHA.ShouldNotBe(Utf16Strings.MATHEMATICAL_ITALIC_SMALL_ALPHA);
		}

		[Fact]
		public void MathematicalBoldGreek_DifferentLetters_Should_BeDifferent() {
			Utf16Strings.MATHEMATICAL_BOLD_CAPITAL_ALPHA.ShouldNotBe(Utf16Strings.MATHEMATICAL_BOLD_CAPITAL_BETA);
			Utf16Strings.MATHEMATICAL_BOLD_CAPITAL_BETA.ShouldNotBe(Utf16Strings.MATHEMATICAL_BOLD_CAPITAL_GAMMA);
		}
	}

	public class PlayingCardsTests {
		[Fact]
		public void PlayingCards_Spades_Should_NotBeEmpty() {
			Utf16Strings.PLAYING_CARD_ACE_OF_SPADES.ShouldNotBeNullOrEmpty();
			Utf16Strings.PLAYING_CARD_TWO_OF_SPADES.ShouldNotBeNullOrEmpty();
			Utf16Strings.PLAYING_CARD_KING_OF_SPADES.ShouldNotBeNullOrEmpty();
		}

		[Fact]
		public void PlayingCards_DifferentSuits_Should_HaveDifferentAces() {
			string[] aces =
			[
				Utf16Strings.PLAYING_CARD_ACE_OF_SPADES,
				Utf16Strings.PLAYING_CARD_ACE_OF_HEARTS,
				Utf16Strings.PLAYING_CARD_ACE_OF_DIAMONDS,
				Utf16Strings.PLAYING_CARD_ACE_OF_CLUBS
			];

			aces.Distinct().Count().ShouldBe(4);
		}

		[Fact]
		public void PlayingCards_Back_Should_Exist() {
			Utf16Strings.PLAYING_CARD_BACK.ShouldNotBeNullOrEmpty();
		}

		[Fact]
		public void PlayingCards_Jokers_Should_Exist() {
			Utf16Strings.PLAYING_CARD_RED_JOKER.ShouldNotBeNullOrEmpty();
			Utf16Strings.PLAYING_CARD_BLACK_JOKER.ShouldNotBeNullOrEmpty();
			Utf16Strings.PLAYING_CARD_WHITE_JOKER.ShouldNotBeNullOrEmpty();
		}

		[Fact]
		public void PlayingCards_Jokers_Should_BeDifferent() {
			Utf16Strings.PLAYING_CARD_RED_JOKER.ShouldNotBe(Utf16Strings.PLAYING_CARD_BLACK_JOKER);
			Utf16Strings.PLAYING_CARD_BLACK_JOKER.ShouldNotBe(Utf16Strings.PLAYING_CARD_WHITE_JOKER);
		}

		[Fact]
		public void PlayingCards_TarotCards_Should_Exist() {
			Utf16Strings.PLAYING_CARD_FOOL.ShouldNotBeNullOrEmpty();
			Utf16Strings.PLAYING_CARD_TRUMP_1.ShouldNotBeNullOrEmpty();
			Utf16Strings.PLAYING_CARD_TRUMP_21.ShouldNotBeNullOrEmpty();
		}

		[Fact]
		public void PlayingCards_DifferentRanks_Should_BeDifferent() {
			Utf16Strings.PLAYING_CARD_ACE_OF_SPADES.ShouldNotBe(Utf16Strings.PLAYING_CARD_TWO_OF_SPADES);
			Utf16Strings.PLAYING_CARD_TWO_OF_SPADES.ShouldNotBe(Utf16Strings.PLAYING_CARD_KING_OF_SPADES);
		}
	}

	public class DominoTilesTests {
		[Fact]
		public void DominoTiles_Horizontal_Should_NotBeEmpty() {
			Utf16Strings.DOMINO_TILE_HORIZONTAL_00_00.ShouldNotBeNullOrEmpty();
			Utf16Strings.DOMINO_TILE_HORIZONTAL_00_01.ShouldNotBeNullOrEmpty();
			Utf16Strings.DOMINO_TILE_HORIZONTAL_06_06.ShouldNotBeNullOrEmpty();
		}

		[Fact]
		public void DominoTiles_Vertical_Should_NotBeEmpty() {
			Utf16Strings.DOMINO_TILE_VERTICAL_00_00.ShouldNotBeNullOrEmpty();
			Utf16Strings.DOMINO_TILE_VERTICAL_00_01.ShouldNotBeNullOrEmpty();
			Utf16Strings.DOMINO_TILE_VERTICAL_06_06.ShouldNotBeNullOrEmpty();
		}

		[Fact]
		public void DominoTiles_Back_Should_Exist() {
			Utf16Strings.DOMINO_TILE_HORIZONTAL_BACK.ShouldNotBeNullOrEmpty();
			Utf16Strings.DOMINO_TILE_VERTICAL_BACK.ShouldNotBeNullOrEmpty();
		}

		[Fact]
		public void DominoTiles_HorizontalAndVertical_Should_BeDifferent() {
			Utf16Strings.DOMINO_TILE_HORIZONTAL_00_00.ShouldNotBe(Utf16Strings.DOMINO_TILE_VERTICAL_00_00);
			Utf16Strings.DOMINO_TILE_HORIZONTAL_06_06.ShouldNotBe(Utf16Strings.DOMINO_TILE_VERTICAL_06_06);
		}

		[Fact]
		public void DominoTiles_DifferentValues_Should_BeDifferent() {
			Utf16Strings.DOMINO_TILE_HORIZONTAL_00_00.ShouldNotBe(Utf16Strings.DOMINO_TILE_HORIZONTAL_00_01);
			Utf16Strings.DOMINO_TILE_HORIZONTAL_00_01.ShouldNotBe(Utf16Strings.DOMINO_TILE_HORIZONTAL_06_06);
		}
	}

	public class MahjongTilesTests {
		[Fact]
		public void MahjongTiles_Winds_Should_NotBeEmpty() {
			Utf16Strings.MAHJONG_TILE_EAST_WIND.ShouldNotBeNullOrEmpty();
			Utf16Strings.MAHJONG_TILE_SOUTH_WIND.ShouldNotBeNullOrEmpty();
			Utf16Strings.MAHJONG_TILE_WEST_WIND.ShouldNotBeNullOrEmpty();
			Utf16Strings.MAHJONG_TILE_NORTH_WIND.ShouldNotBeNullOrEmpty();
		}

		[Fact]
		public void MahjongTiles_Winds_Should_BeDistinct() {
			string[] winds =
			[
				Utf16Strings.MAHJONG_TILE_EAST_WIND,
				Utf16Strings.MAHJONG_TILE_SOUTH_WIND,
				Utf16Strings.MAHJONG_TILE_WEST_WIND,
				Utf16Strings.MAHJONG_TILE_NORTH_WIND
			];

			winds.Distinct().Count().ShouldBe(4);
		}

		[Fact]
		public void MahjongTiles_Dragons_Should_NotBeEmpty() {
			Utf16Strings.MAHJONG_TILE_RED_DRAGON.ShouldNotBeNullOrEmpty();
			Utf16Strings.MAHJONG_TILE_GREEN_DRAGON.ShouldNotBeNullOrEmpty();
			Utf16Strings.MAHJONG_TILE_WHITE_DRAGON.ShouldNotBeNullOrEmpty();
		}

		[Fact]
		public void MahjongTiles_Dragons_Should_BeDistinct() {
			string[] dragons =
			[
				Utf16Strings.MAHJONG_TILE_RED_DRAGON,
				Utf16Strings.MAHJONG_TILE_GREEN_DRAGON,
				Utf16Strings.MAHJONG_TILE_WHITE_DRAGON
			];

			dragons.Distinct().Count().ShouldBe(3);
		}

		[Fact]
		public void MahjongTiles_Seasons_Should_NotBeEmpty() {
			Utf16Strings.MAHJONG_TILE_SPRING.ShouldNotBeNullOrEmpty();
			Utf16Strings.MAHJONG_TILE_SUMMER.ShouldNotBeNullOrEmpty();
			Utf16Strings.MAHJONG_TILE_AUTUMN.ShouldNotBeNullOrEmpty();
			Utf16Strings.MAHJONG_TILE_WINTER.ShouldNotBeNullOrEmpty();
		}

		[Fact]
		public void MahjongTiles_Flowers_Should_NotBeEmpty() {
			Utf16Strings.MAHJONG_TILE_PLUM.ShouldNotBeNullOrEmpty();
			Utf16Strings.MAHJONG_TILE_ORCHID.ShouldNotBeNullOrEmpty();
			Utf16Strings.MAHJONG_TILE_BAMBOO.ShouldNotBeNullOrEmpty();
			Utf16Strings.MAHJONG_TILE_CHRYSANTHEMUM.ShouldNotBeNullOrEmpty();
		}

		[Fact]
		public void MahjongTiles_Back_Should_Exist() {
			Utf16Strings.MAHJONG_TILE_BACK.ShouldNotBeNullOrEmpty();
		}

		[Fact]
		public void MahjongTiles_Joker_Should_Exist() {
			Utf16Strings.MAHJONG_TILE_JOKER.ShouldNotBeNullOrEmpty();
		}
	}

	public class EnclosedAlphanumericsTests {
		[Fact]
		public void EnclosedAlphanumerics_Digits_Should_NotBeEmpty() {
			Utf16Strings.DIGIT_ZERO_FULL_STOP.ShouldNotBeNullOrEmpty();
			Utf16Strings.DIGIT_ZERO_COMMA.ShouldNotBeNullOrEmpty();
			Utf16Strings.DIGIT_ONE_COMMA.ShouldNotBeNullOrEmpty();
		}

		[Fact]
		public void EnclosedAlphanumerics_ParenthesizedLetters_Should_BeDistinct() {
			Utf16Strings.PARENTHESIZED_LATIN_CAPITAL_LETTER_A.ShouldNotBe(Utf16Strings.PARENTHESIZED_LATIN_CAPITAL_LETTER_B);
			Utf16Strings.PARENTHESIZED_LATIN_CAPITAL_LETTER_A.ShouldNotBe(Utf16Strings.PARENTHESIZED_LATIN_CAPITAL_LETTER_Z);
		}

		[Fact]
		public void EnclosedAlphanumerics_SquaredLetters_Should_BeDistinct() {
			Utf16Strings.SQUARED_LATIN_CAPITAL_LETTER_A.ShouldNotBe(Utf16Strings.SQUARED_LATIN_CAPITAL_LETTER_B);
			Utf16Strings.SQUARED_LATIN_CAPITAL_LETTER_A.ShouldNotBe(Utf16Strings.NEGATIVE_SQUARED_LATIN_CAPITAL_LETTER_A);
		}

		[Fact]
		public void EnclosedAlphanumerics_SpecialSquared_Should_Exist() {
			Utf16Strings.SQUARED_CL.ShouldNotBeNullOrEmpty();
			Utf16Strings.SQUARED_COOL.ShouldNotBeNullOrEmpty();
			Utf16Strings.SQUARED_FREE.ShouldNotBeNullOrEmpty();
			Utf16Strings.SQUARED_OK.ShouldNotBeNullOrEmpty();
			Utf16Strings.SQUARED_SOS.ShouldNotBeNullOrEmpty();
		}

		[Fact]
		public void EnclosedAlphanumerics_SpecialSquared_Should_BeDistinct() {
			string[] special =
			[
				Utf16Strings.SQUARED_CL,
				Utf16Strings.SQUARED_COOL,
				Utf16Strings.SQUARED_FREE,
				Utf16Strings.SQUARED_OK,
				Utf16Strings.SQUARED_SOS
			];

			special.Distinct().Count().ShouldBe(special.Length);
		}
	}

	public class RegionalIndicatorSymbolsTests {
		[Fact]
		public void RegionalIndicatorSymbols_Should_NotBeEmpty() {
			Utf16Strings.REGIONAL_INDICATOR_SYMBOL_LETTER_A.ShouldNotBeNullOrEmpty();
			Utf16Strings.REGIONAL_INDICATOR_SYMBOL_LETTER_B.ShouldNotBeNullOrEmpty();
			Utf16Strings.REGIONAL_INDICATOR_SYMBOL_LETTER_Z.ShouldNotBeNullOrEmpty();
		}

		[Fact]
		public void RegionalIndicatorSymbols_AllLetters_Should_BeDistinct() {
			string[] indicators =
			[
				Utf16Strings.REGIONAL_INDICATOR_SYMBOL_LETTER_A,
				Utf16Strings.REGIONAL_INDICATOR_SYMBOL_LETTER_B,
				Utf16Strings.REGIONAL_INDICATOR_SYMBOL_LETTER_C,
				Utf16Strings.REGIONAL_INDICATOR_SYMBOL_LETTER_Z
			];

			indicators.Distinct().Count().ShouldBe(indicators.Length);
		}

		[Fact]
		public void RegionalIndicatorSymbols_CanFormCountryFlags() {
			string usFlag = Utf16Strings.REGIONAL_INDICATOR_SYMBOL_LETTER_U +
							Utf16Strings.REGIONAL_INDICATOR_SYMBOL_LETTER_S;

			usFlag.ShouldNotBeNullOrEmpty();
			usFlag.Length.ShouldBeGreaterThan(0);
		}

		[Fact]
		public void RegionalIndicatorSymbols_FirstAndLast_Should_BeDifferent() {
			Utf16Strings.REGIONAL_INDICATOR_SYMBOL_LETTER_A.ShouldNotBe(Utf16Strings.REGIONAL_INDICATOR_SYMBOL_LETTER_Z);
		}
	}

	public class EmojiTests {
		[Fact]
		public void Emojis_Weather_Should_NotBeEmpty() {
			Utf16Strings.CYCLONE.ShouldNotBeNullOrEmpty();
			Utf16Strings.RAINBOW.ShouldNotBeNullOrEmpty();
			Utf16Strings.FOGGY.ShouldNotBeNullOrEmpty();
			Utf16Strings.CLOSED_UMBRELLA.ShouldNotBeNullOrEmpty();
		}

		[Fact]
		public void Emojis_Celestial_Should_NotBeEmpty() {
			Utf16Strings.NEW_MOON_SYMBOL.ShouldNotBeNullOrEmpty();
			Utf16Strings.FULL_MOON_SYMBOL.ShouldNotBeNullOrEmpty();
			Utf16Strings.SUN_WITH_FACE.ShouldNotBeNullOrEmpty();
			Utf16Strings.GLOWING_STAR.ShouldNotBeNullOrEmpty();
		}

		[Fact]
		public void Emojis_Food_Should_NotBeEmpty() {
			Utf16Strings.HAMBURGER.ShouldNotBeNullOrEmpty();
			Utf16Strings.SLICE_OF_PIZZA.ShouldNotBeNullOrEmpty();
			Utf16Strings.HOT_DOG.ShouldNotBeNullOrEmpty();
			Utf16Strings.TACO.ShouldNotBeNullOrEmpty();
		}

		[Fact]
		public void Emojis_Faces_Should_NotBeEmpty() {
			Utf16Strings.GRINNING_FACE.ShouldNotBeNullOrEmpty();
			Utf16Strings.FACE_WITH_TEARS_OF_JOY.ShouldNotBeNullOrEmpty();
			Utf16Strings.SMILING_FACE_WITH_HEART_SHAPED_EYES.ShouldNotBeNullOrEmpty();
			Utf16Strings.THINKING_FACE.ShouldNotBeNullOrEmpty();
		}

		[Fact]
		public void Emojis_Hearts_Should_NotBeEmpty() {
			Utf16Strings.BLUE_HEART.ShouldNotBeNullOrEmpty();
			Utf16Strings.GREEN_HEART.ShouldNotBeNullOrEmpty();
			Utf16Strings.YELLOW_HEART.ShouldNotBeNullOrEmpty();
			Utf16Strings.PURPLE_HEART.ShouldNotBeNullOrEmpty();
			Utf16Strings.BLACK_HEART.ShouldNotBeNullOrEmpty();
			Utf16Strings.WHITE_HEART.ShouldNotBeNullOrEmpty();
			Utf16Strings.BROWN_HEART.ShouldNotBeNullOrEmpty();
			Utf16Strings.ORANGE_HEART.ShouldNotBeNullOrEmpty();
		}

		[Fact]
		public void Emojis_Hearts_Should_BeDistinct() {
			string[] hearts =
			[
				Utf16Strings.BLUE_HEART,
				Utf16Strings.GREEN_HEART,
				Utf16Strings.YELLOW_HEART,
				Utf16Strings.PURPLE_HEART,
				Utf16Strings.BLACK_HEART,
				Utf16Strings.WHITE_HEART,
				Utf16Strings.BROWN_HEART,
				Utf16Strings.ORANGE_HEART
			];

			hearts.Distinct().Count().ShouldBe(hearts.Length);
		}

		[Fact]
		public void Emojis_Animals_Should_NotBeEmpty() {
			Utf16Strings.DOG_FACE.ShouldNotBeNullOrEmpty();
			Utf16Strings.CAT_FACE.ShouldNotBeNullOrEmpty();
			Utf16Strings.MOUSE_FACE.ShouldNotBeNullOrEmpty();
			Utf16Strings.RABBIT_FACE.ShouldNotBeNullOrEmpty();
			Utf16Strings.PANDA_FACE.ShouldNotBeNullOrEmpty();
		}
	}

	public class TransportationTests {
		[Fact]
		public void Transportation_Vehicles_Should_NotBeEmpty() {
			Utf16Strings.AUTOMOBILE.ShouldNotBeNullOrEmpty();
			Utf16Strings.TAXI.ShouldNotBeNullOrEmpty();
			Utf16Strings.BUS.ShouldNotBeNullOrEmpty();
			Utf16Strings.TRAIN.ShouldNotBeNullOrEmpty();
			Utf16Strings.ROCKET.ShouldNotBeNullOrEmpty();
		}

		[Fact]
		public void Transportation_Aircraft_Should_NotBeEmpty() {
			Utf16Strings.AIRPLANE_DEPARTURE.ShouldNotBeNullOrEmpty();
			Utf16Strings.AIRPLANE_ARRIVING.ShouldNotBeNullOrEmpty();
			Utf16Strings.HELICOPTER.ShouldNotBeNullOrEmpty();
		}

		[Fact]
		public void Transportation_WaterVehicles_Should_NotBeEmpty() {
			Utf16Strings.SHIP.ShouldNotBeNullOrEmpty();
			Utf16Strings.SPEEDBOAT.ShouldNotBeNullOrEmpty();
			Utf16Strings.ROWBOAT.ShouldNotBeNullOrEmpty();
		}

		[Fact]
		public void Transportation_Vehicles_Should_BeDistinct() {
			string[] vehicles =
			[
				Utf16Strings.AUTOMOBILE,
				Utf16Strings.TAXI,
				Utf16Strings.BUS,
				Utf16Strings.TRAIN,
				Utf16Strings.ROCKET
			];

			vehicles.Distinct().Count().ShouldBe(vehicles.Length);
		}
	}

	public class ChessSymbolsTests {
		[Fact]
		public void ChessSymbols_NeutralPieces_Should_NotBeEmpty() {
			Utf16Strings.NEUTRAL_CHESS_KING.ShouldNotBeNullOrEmpty();
			Utf16Strings.NEUTRAL_CHESS_QUEEN.ShouldNotBeNullOrEmpty();
			Utf16Strings.NEUTRAL_CHESS_ROOK.ShouldNotBeNullOrEmpty();
			Utf16Strings.NEUTRAL_CHESS_BISHOP.ShouldNotBeNullOrEmpty();
			Utf16Strings.NEUTRAL_CHESS_KNIGHT.ShouldNotBeNullOrEmpty();
			Utf16Strings.NEUTRAL_CHESS_PAWN.ShouldNotBeNullOrEmpty();
		}

		[Fact]
		public void ChessSymbols_NeutralPieces_Should_BeDistinct() {
			string[] pieces =
			[
				Utf16Strings.NEUTRAL_CHESS_KING,
				Utf16Strings.NEUTRAL_CHESS_QUEEN,
				Utf16Strings.NEUTRAL_CHESS_ROOK,
				Utf16Strings.NEUTRAL_CHESS_BISHOP,
				Utf16Strings.NEUTRAL_CHESS_KNIGHT,
				Utf16Strings.NEUTRAL_CHESS_PAWN
			];

			pieces.Distinct().Count().ShouldBe(pieces.Length);
		}

		[Fact]
		public void ChessSymbols_RotatedKnights_Should_Exist() {
			Utf16Strings.WHITE_CHESS_KNIGHT_ROTATED_FORTY_FIVE_DEGREES.ShouldNotBeNullOrEmpty();
			Utf16Strings.WHITE_CHESS_KNIGHT_ROTATED_NINETY_DEGREES.ShouldNotBeNullOrEmpty();
			Utf16Strings.WHITE_CHESS_KNIGHT_ROTATED_ONE_HUNDRED_THIRTY_FIVE_DEGREES.ShouldNotBeNullOrEmpty();
		}

		[Fact]
		public void ChessSymbols_TurnedPieces_Should_Exist() {
			Utf16Strings.WHITE_CHESS_TURNED_KING.ShouldNotBeNullOrEmpty();
			Utf16Strings.BLACK_CHESS_TURNED_KING.ShouldNotBeNullOrEmpty();
			Utf16Strings.NEUTRAL_CHESS_TURNED_KING.ShouldNotBeNullOrEmpty();
		}
	}

	public class XiangqiSymbolsTests {
		[Fact]
		public void XiangqiSymbols_RedPieces_Should_Exist() {
			Utf16Strings.XIANGQI_RED_GENERAL.ShouldNotBeNullOrEmpty();
			Utf16Strings.XIANGQI_RED_MANDARIN.ShouldNotBeNullOrEmpty();
			Utf16Strings.XIANGQI_RED_ELEPHANT.ShouldNotBeNullOrEmpty();
			Utf16Strings.XIANGQI_RED_HORSE.ShouldNotBeNullOrEmpty();
			Utf16Strings.XIANGQI_RED_CANNON.ShouldNotBeNullOrEmpty();
			Utf16Strings.XIANGQI_RED_SOLDIER.ShouldNotBeNullOrEmpty();
		}

		[Fact]
		public void XiangqiSymbols_BlackPieces_Should_Exist() {
			Utf16Strings.XIANGQI_BLACK_GENERAL.ShouldNotBeNullOrEmpty();
			Utf16Strings.XIANGQI_BLACK_MANDARIN.ShouldNotBeNullOrEmpty();
			Utf16Strings.XIANGQI_BLACK_ELEPHANT.ShouldNotBeNullOrEmpty();
			Utf16Strings.XIANGQI_BLACK_HORSE.ShouldNotBeNullOrEmpty();
			Utf16Strings.XIANGQI_BLACK_CANNON.ShouldNotBeNullOrEmpty();
			Utf16Strings.XIANGQI_BLACK_SOLDIER.ShouldNotBeNullOrEmpty();
		}

		[Fact]
		public void XiangqiSymbols_RedAndBlack_Should_BeDifferent() {
			Utf16Strings.XIANGQI_RED_GENERAL.ShouldNotBe(Utf16Strings.XIANGQI_BLACK_GENERAL);
			Utf16Strings.XIANGQI_RED_SOLDIER.ShouldNotBe(Utf16Strings.XIANGQI_BLACK_SOLDIER);
		}
	}

	public class AlchemicalSymbolsTests {
		[Fact]
		public void AlchemicalSymbols_Elements_Should_Exist() {
			Utf16Strings.ALCHEMICAL_SYMBOL_FOR_AIR.ShouldNotBeNullOrEmpty();
			Utf16Strings.ALCHEMICAL_SYMBOL_FOR_FIRE.ShouldNotBeNullOrEmpty();
			Utf16Strings.ALCHEMICAL_SYMBOL_FOR_EARTH.ShouldNotBeNullOrEmpty();
			Utf16Strings.ALCHEMICAL_SYMBOL_FOR_WATER.ShouldNotBeNullOrEmpty();
			Utf16Strings.ALCHEMICAL_SYMBOL_FOR_QUINTESSENCE.ShouldNotBeNullOrEmpty();
		}

		[Fact]
		public void AlchemicalSymbols_Elements_Should_BeDistinct() {
			string[] elements =
			[
				Utf16Strings.ALCHEMICAL_SYMBOL_FOR_AIR,
				Utf16Strings.ALCHEMICAL_SYMBOL_FOR_FIRE,
				Utf16Strings.ALCHEMICAL_SYMBOL_FOR_EARTH,
				Utf16Strings.ALCHEMICAL_SYMBOL_FOR_WATER,
				Utf16Strings.ALCHEMICAL_SYMBOL_FOR_QUINTESSENCE
			];

			elements.Distinct().Count().ShouldBe(elements.Length);
		}

		[Fact]
		public void AlchemicalSymbols_Metals_Should_Exist() {
			Utf16Strings.ALCHEMICAL_SYMBOL_FOR_GOLD.ShouldNotBeNullOrEmpty();
			Utf16Strings.ALCHEMICAL_SYMBOL_FOR_SILVER.ShouldNotBeNullOrEmpty();
		}

		[Fact]
		public void AlchemicalSymbols_Substances_Should_Exist() {
			Utf16Strings.ALCHEMICAL_SYMBOL_FOR_SULFUR.ShouldNotBeNullOrEmpty();
			Utf16Strings.ALCHEMICAL_SYMBOL_FOR_SALT.ShouldNotBeNullOrEmpty();
		}
	}

	public class StringPropertiesTests {
		[Fact]
		public void AllConstants_Should_NotBeNull() {
			Utf16Strings.MATHEMATICAL_BOLD_CAPITAL_A.ShouldNotBeNull();
			Utf16Strings.PLAYING_CARD_ACE_OF_SPADES.ShouldNotBeNull();
			Utf16Strings.DOMINO_TILE_HORIZONTAL_00_00.ShouldNotBeNull();
			Utf16Strings.MAHJONG_TILE_EAST_WIND.ShouldNotBeNull();
		}

		[Fact]
		public void AllConstants_Should_NotBeEmpty() {
			Utf16Strings.MATHEMATICAL_BOLD_CAPITAL_A.ShouldNotBeEmpty();
			Utf16Strings.PLAYING_CARD_ACE_OF_SPADES.ShouldNotBeEmpty();
			Utf16Strings.GRINNING_FACE.ShouldNotBeEmpty();
		}

		[Fact]
		public void MathematicalCharacters_Should_BeAtLeast1Character() {
			Utf16Strings.MATHEMATICAL_BOLD_CAPITAL_A.Length.ShouldBeGreaterThanOrEqualTo(1);
			Utf16Strings.MATHEMATICAL_ITALIC_SMALL_A.Length.ShouldBeGreaterThanOrEqualTo(1);
		}

		[Fact]
		public void EmojiCharacters_Should_BeValidUnicode() {
			Utf16Strings.GRINNING_FACE.Length.ShouldBeGreaterThan(0);
			Utf16Strings.HEART_WITH_ARROW.Length.ShouldBeGreaterThan(0);
		}

		[Fact]
		public void StringConstants_Should_BeStrings() {
			Utf16Strings.MATHEMATICAL_BOLD_CAPITAL_A.ShouldBeOfType<string>();
			Utf16Strings.PLAYING_CARD_ACE_OF_SPADES.ShouldBeOfType<string>();
			Utf16Strings.GRINNING_FACE.ShouldBeOfType<string>();
		}
	}

	public class UsageExamplesTests {
		[Fact]
		public void MathematicalAlphanumerics_CanBeUsedForStyling() {
			string boldText = $"{Utf16Strings.MATHEMATICAL_BOLD_CAPITAL_H}" +
							  $"{Utf16Strings.MATHEMATICAL_BOLD_SMALL_E}" +
							  $"{Utf16Strings.MATHEMATICAL_BOLD_SMALL_L}" +
							  $"{Utf16Strings.MATHEMATICAL_BOLD_SMALL_L}" +
							  $"{Utf16Strings.MATHEMATICAL_BOLD_SMALL_O}";

			boldText.ShouldNotBeNullOrEmpty();
			boldText.Length.ShouldBeGreaterThan(0);
		}

		[Fact]
		public void PlayingCards_CanRepresentPokerHand() {
			string royalFlush = $"{Utf16Strings.PLAYING_CARD_ACE_OF_SPADES} " +
								$"{Utf16Strings.PLAYING_CARD_KING_OF_SPADES} " +
								$"{Utf16Strings.PLAYING_CARD_QUEEN_OF_SPADES}";

			royalFlush.ShouldNotBeNullOrEmpty();
			royalFlush.Length.ShouldBeGreaterThan(0);
		}

		[Fact]
		public void RegionalIndicators_CanFormCountryCodes() {
			string usFlag = Utf16Strings.REGIONAL_INDICATOR_SYMBOL_LETTER_U +
							Utf16Strings.REGIONAL_INDICATOR_SYMBOL_LETTER_S;

			string ukFlag = Utf16Strings.REGIONAL_INDICATOR_SYMBOL_LETTER_G +
							Utf16Strings.REGIONAL_INDICATOR_SYMBOL_LETTER_B;

			usFlag.ShouldNotBeNullOrEmpty();
			ukFlag.ShouldNotBeNullOrEmpty();
			usFlag.ShouldNotBe(ukFlag);
		}

		[Fact]
		public void Emojis_CanBeUsedInMessages() {
			string message = $"Hello {Utf16Strings.WAVING_HAND_SIGN}! " +
							 $"Welcome {Utf16Strings.PARTY_POPPER} " +
							 $"{Utf16Strings.CONFETTI_BALL}";

			message.ShouldNotBeNullOrEmpty();
			message.ShouldContain("Hello");
			message.ShouldContain("Welcome");
		}

		[Fact]
		public void MahjongTiles_CanRepresentGameState() {
			string windTiles = $"{Utf16Strings.MAHJONG_TILE_EAST_WIND} " +
							   $"{Utf16Strings.MAHJONG_TILE_SOUTH_WIND} " +
							   $"{Utf16Strings.MAHJONG_TILE_WEST_WIND} " +
							   $"{Utf16Strings.MAHJONG_TILE_NORTH_WIND}";

			windTiles.ShouldNotBeNullOrEmpty();
			windTiles.Contains(' ').ShouldBeTrue();
		}

		[Fact]
		public void ColoredHearts_CanShowDiversity() {
			string hearts = $"{Utf16Strings.BLUE_HEART}" +
							$"{Utf16Strings.GREEN_HEART}" +
							$"{Utf16Strings.YELLOW_HEART}" +
							$"{Utf16Strings.PURPLE_HEART}" +
							$"{Utf16Strings.ORANGE_HEART}";

			hearts.ShouldNotBeNullOrEmpty();
			hearts.Length.ShouldBeGreaterThan(0);
		}
	}

	public class BlockSextantTests {
		[Fact]
		public void BlockSextants_Should_Exist() {
			Utf16Strings.BLOCK_SEXTANT_1.ShouldNotBeNullOrEmpty();
			Utf16Strings.BLOCK_SEXTANT_12.ShouldNotBeNullOrEmpty();
			Utf16Strings.BLOCK_SEXTANT_123.ShouldNotBeNullOrEmpty();
			Utf16Strings.BLOCK_SEXTANT_1234.ShouldNotBeNullOrEmpty();
			Utf16Strings.BLOCK_SEXTANT_12345.ShouldNotBeNullOrEmpty();
		}

		[Fact]
		public void BlockSextants_Different_Should_BeDifferent() {
			Utf16Strings.BLOCK_SEXTANT_1.ShouldNotBe(Utf16Strings.BLOCK_SEXTANT_2);
			Utf16Strings.BLOCK_SEXTANT_12.ShouldNotBe(Utf16Strings.BLOCK_SEXTANT_34);
		}
	}

	public class SymbolTests {
		[Fact]
		public void ReligiousSymbols_Should_Exist() {
			Utf16Strings.CROSS_POMMEE.ShouldNotBeNullOrEmpty();
			Utf16Strings.WHITE_LATIN_CROSS.ShouldNotBeNullOrEmpty();
			Utf16Strings.HEAVY_LATIN_CROSS.ShouldNotBeNullOrEmpty();
			Utf16Strings.OM_SYMBOL.ShouldNotBeNullOrEmpty();
			Utf16Strings.DOVE_OF_PEACE.ShouldNotBeNullOrEmpty();
		}

		[Fact]
		public void CelestialSymbols_Should_Exist() {
			Utf16Strings.LOT_OF_FORTUNE.ShouldNotBeNullOrEmpty();
			Utf16Strings.OCCULTATION.ShouldNotBeNullOrEmpty();
			Utf16Strings.LUNAR_ECLIPSE.ShouldNotBeNullOrEmpty();
		}

		[Fact]
		public void GeometricSymbols_Should_Exist() {
			Utf16Strings.LARGE_RED_CIRCLE.ShouldNotBeNullOrEmpty();
			Utf16Strings.LARGE_BLUE_CIRCLE.ShouldNotBeNullOrEmpty();
			Utf16Strings.LARGE_ORANGE_DIAMOND.ShouldNotBeNullOrEmpty();
			Utf16Strings.LARGE_BLUE_DIAMOND.ShouldNotBeNullOrEmpty();
		}
	}

	public class ArrowTests {
		[Fact]
		public void Arrows_BasicDirections_Should_Exist() {
			Utf16Strings.LEFTWARDS_ARROW_WITH_SMALL_TRIANGLE_ARROWHEAD.ShouldNotBeNullOrEmpty();
			Utf16Strings.UPWARDS_ARROW_WITH_SMALL_TRIANGLE_ARROWHEAD.ShouldNotBeNullOrEmpty();
			Utf16Strings.RIGHTWARDS_ARROW_WITH_SMALL_TRIANGLE_ARROWHEAD.ShouldNotBeNullOrEmpty();
			Utf16Strings.DOWNWARDS_ARROW_WITH_SMALL_TRIANGLE_ARROWHEAD.ShouldNotBeNullOrEmpty();
		}

		[Fact]
		public void Arrows_HeavyVariants_Should_Exist() {
			Utf16Strings.LEFTWARDS_HEAVY_ARROW.ShouldNotBeNullOrEmpty();
			Utf16Strings.UPWARDS_HEAVY_ARROW.ShouldNotBeNullOrEmpty();
			Utf16Strings.RIGHTWARDS_HEAVY_ARROW.ShouldNotBeNullOrEmpty();
			Utf16Strings.DOWNWARDS_HEAVY_ARROW.ShouldNotBeNullOrEmpty();
		}

		[Fact]
		public void Arrows_SansSerifVariants_Should_Exist() {
			Utf16Strings.LEFTWARDS_SANS_SERIF_ARROW.ShouldNotBeNullOrEmpty();
			Utf16Strings.NORTH_WEST_SANS_SERIF_ARROW.ShouldNotBeNullOrEmpty();
			Utf16Strings.LEFT_RIGHT_SANS_SERIF_ARROW.ShouldNotBeNullOrEmpty();
		}

		[Fact]
		public void Arrows_Directions_Should_BeDifferent() {
			Utf16Strings.LEFTWARDS_HEAVY_ARROW.ShouldNotBe(Utf16Strings.RIGHTWARDS_HEAVY_ARROW);
			Utf16Strings.UPWARDS_HEAVY_ARROW.ShouldNotBe(Utf16Strings.DOWNWARDS_HEAVY_ARROW);
		}
	}

	public class ClockFaceTests {
		[Fact]
		public void ClockFaces_Hours_Should_Exist() {
			Utf16Strings.CLOCK_FACE_ONE_OCLOCK.ShouldNotBeNullOrEmpty();
			Utf16Strings.CLOCK_FACE_SIX_OCLOCK.ShouldNotBeNullOrEmpty();
			Utf16Strings.CLOCK_FACE_TWELVE_OCLOCK.ShouldNotBeNullOrEmpty();
		}

		[Fact]
		public void ClockFaces_HalfHours_Should_Exist() {
			Utf16Strings.CLOCK_FACE_ONE_THIRTY.ShouldNotBeNullOrEmpty();
			Utf16Strings.CLOCK_FACE_SIX_THIRTY.ShouldNotBeNullOrEmpty();
			Utf16Strings.CLOCK_FACE_TWELVE_THIRTY.ShouldNotBeNullOrEmpty();
		}

		[Fact]
		public void ClockFaces_AllHours_Should_BeDistinct() {
			string[] hours =
			[
				Utf16Strings.CLOCK_FACE_ONE_OCLOCK,
				Utf16Strings.CLOCK_FACE_TWO_OCLOCK,
				Utf16Strings.CLOCK_FACE_THREE_OCLOCK,
				Utf16Strings.CLOCK_FACE_TWELVE_OCLOCK
			];

			hours.Distinct().Count().ShouldBe(hours.Length);
		}

		[Fact]
		public void ClockFaces_HourAndHalfHour_Should_BeDifferent() {
			Utf16Strings.CLOCK_FACE_ONE_OCLOCK.ShouldNotBe(Utf16Strings.CLOCK_FACE_ONE_THIRTY);
			Utf16Strings.CLOCK_FACE_SIX_OCLOCK.ShouldNotBe(Utf16Strings.CLOCK_FACE_SIX_THIRTY);
		}
	}
}
