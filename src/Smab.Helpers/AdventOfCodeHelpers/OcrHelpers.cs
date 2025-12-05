namespace Smab.Helpers;

public static class OcrHelpers {
	const char Unlit = '.';
	const char Lit = '#';
	const char BadCharacter = '!';

	const int Alphabet_Normal_Grid_Width = 6;
	const int Alphabet_Normal_Grid_Height = 6;
	static readonly string[] Alphabet_Normal = [
		".##..|###..|.##..|###..|####.|####.|.##..|#..#.|###..|..##.|#..#.|#....|#...#|.....|.##..|###..|.....|###..|.###.|#####|#..#.|.....|.....|.....|#...#|####.|",
		"#..#.|#..#.|#..#.|#..#.|#....|#....|#..#.|#..#.|.#...|...#.|#.#..|#....|##.##|.....|#..#.|#..#.|.....|#..#.|#....|..#..|#..#.|.....|.....|.....|#...#|...#.|",
		"#..#.|###..|#....|#..#.|###..|###..|#....|####.|.#...|...#.|##...|#....|#.#.#|.....|#..#.|#..#.|.....|#..#.|#....|..#..|#..#.|.....|.....|.....|.#.#.|..#..|",
		"####.|#..#.|#....|#..#.|#....|#....|#.##.|#..#.|.#...|...#.|#.#..|#....|#...#|.....|#..#.|###..|.....|###..|.##..|..#..|#..#.|.....|.....|.....|..#..|.#...|",
		"#..#.|#..#.|#..#.|#..#.|#....|#....|#..#.|#..#.|.#...|#..#.|#.#..|#....|#...#|.....|#..#.|#....|.....|#.#..|...#.|..#..|#..#.|.....|.....|.....|..#..|#....|",
		"#..#.|###..|.##..|###..|####.|#....|.###.|#..#.|###..|.##..|#..#.|####.|#...#|.....|.##..|#....|.....|#..#.|###..|..#..|.##..|.....|.....|.....|..#..|####.|",
		];

	static readonly (char Letter, int Width)[] LetterWidths = [
		('A', 4),
		('B', 4),
		('C', 4),
		('D', 4),
		('E', 4),
		('F', 4),
		('G', 4),
		('H', 4),
		('I', 3),
		('J', 4),
		('K', 4),
		('L', 4),
		('M', 5),
		('N', 4),
		('O', 4),
		('P', 4),
		('Q', 4),
		('R', 4),
		('S', 4),
		('T', 4),
		('U', 4),
		('V', 4),
		('W', 4),
		('X', 4),
		('Y', 5),
		('Z', 4),
		];

	const int Alphabet_Medium_Letter_Width = 5;
	const int Alphabet_Medium_Grid_Width = 7;
	const int Alphabet_Medium_Grid_Height = 8;
	const string Alphabet_Medium = """
		......|......|......|......|......|......|......|#...#.|.###..|......|......|......|......|......|......|......|......|......|......|......|......|......|......|......|......|......|......|
		......|......|......|......|......|......|......|#...#.|..#...|......|......|......|......|......|......|......|......|......|......|......|......|......|......|......|......|......|......|
		......|......|......|......|......|......|......|#...#.|..#...|......|......|......|......|......|......|......|......|......|......|......|......|......|......|......|......|......|......|
		......|......|......|......|......|......|......|#####.|..#...|......|......|......|......|......|......|......|......|......|......|......|......|......|......|......|......|......|......|
		......|......|......|......|......|......|......|#...#.|..#...|......|......|......|......|......|......|......|......|......|......|......|......|......|......|......|......|......|......|
		......|......|......|......|......|......|......|#...#.|..#...|......|......|......|......|......|......|......|......|......|......|......|......|......|......|......|......|......|......|
		......|......|......|......|......|......|......|#...#.|..#...|......|......|......|......|......|......|......|......|......|......|......|......|......|......|......|......|......|......|
		......|......|......|......|......|......|......|#...#.|.###..|......|......|......|......|......|......|......|......|......|......|......|......|......|......|......|......|......|......|
		""";

	const int Alphabet_Large_Letter_Width = 6;
	const int Alphabet_Large_Grid_Width = 8;
	const int Alphabet_Large_Grid_Height = 10;
	const string Alphabet_Large = """
		..##...|#####..|.####..|.......|######.|######.|.####..|#....#.|.......|...###.|#....#.|#......|.......|#....#.|.......|#####..|.......|#####..|.......|.......|.......|.......|.......|#....#.|.......|######.|.......|
		.#..#..|#....#.|#....#.|.......|#......|#......|#....#.|#....#.|.......|....#..|#...#..|#......|.......|##...#.|.......|#....#.|.......|#....#.|.......|.......|.......|.......|.......|#....#.|.......|.....#.|.......|
		#....#.|#....#.|#......|.......|#......|#......|#......|#....#.|.......|....#..|#..#...|#......|.......|##...#.|.......|#....#.|.......|#....#.|.......|.......|.......|.......|.......|.#..#..|.......|.....#.|.......|
		#....#.|#....#.|#......|.......|#......|#......|#......|#....#.|.......|....#..|#.#....|#......|.......|#.#..#.|.......|#....#.|.......|#....#.|.......|.......|.......|.......|.......|.#..#..|.......|....#..|.......|
		#....#.|#####..|#......|.......|#####..|#####..|#......|######.|.......|....#..|##.....|#......|.......|#.#..#.|.......|#####..|.......|#####..|.......|.......|.......|.......|.......|..##...|.......|...#...|.......|
		######.|#....#.|#......|.......|#......|#......|#..###.|#....#.|.......|....#..|##.....|#......|.......|#..#.#.|.......|#......|.......|#..#...|.......|.......|.......|.......|.......|..##...|.......|..#....|.......|
		#....#.|#....#.|#......|.......|#......|#......|#....#.|#....#.|.......|....#..|#.#....|#......|.......|#..#.#.|.......|#......|.......|#...#..|.......|.......|.......|.......|.......|.#..#..|.......|.#.....|.......|
		#....#.|#....#.|#......|.......|#......|#......|#....#.|#....#.|.......|#...#..|#..#...|#......|.......|#...##.|.......|#......|.......|#...#..|.......|.......|.......|.......|.......|.#..#..|.......|#......|.......|
		#....#.|#....#.|#....#.|.......|#......|#......|#...##.|#....#.|.......|#...#..|#...#..|#......|.......|#...##.|.......|#......|.......|#....#.|.......|.......|.......|.......|.......|#....#.|.......|#......|.......|
		#....#.|#####..|.####..|.......|######.|#......|.###.#.|#....#.|.......|.###...|#....#.|######.|.......|#....#.|.......|#......|.......|#....#.|.......|.......|.......|.......|.......|#....#.|.......|######.|.......|
		""";

	extension(char[,] input) {
		/// <summary>
		/// Identifies and decodes a message from a 2D character array representation of text.
		/// </summary>
		/// <remarks>This method processes a 2D grid of characters to identify and decode text based on the specified
		/// lit and unlit characters. The grid is expected to follow a specific format where letters are separated by a defined
		/// number of empty columns.</remarks>
		/// <param name="input">A 2D character array representing the text to decode, where each character corresponds to a pixel or cell in the
		/// grid.</param>
		/// <param name="off">The character representing an unlit or empty cell in the grid. Defaults to <see langword="Unlit"/>.</param>
		/// <param name="on">The character representing a lit or filled cell in the grid. Defaults to <see langword="Lit"/>.</param>
		/// <param name="whitespace">The number of empty columns used to separate letters in the grid. Must be a non-negative integer. Defaults to 1.</param>
		/// <param name="ocrLetterSize">The size of the letters in the grid, specified as an <see cref="OcrLetterSize"/> value. Defaults to <see
		/// cref="OcrLetterSize.Normal"/>.</param>
		/// <returns>A <see cref="string"/> containing the decoded message. Returns an empty string if the input does not contain any
		/// recognizable text.</returns>
		public string IdentifyMessage(char off = Unlit, char on = Lit, int whitespace = 1, OcrLetterSize ocrLetterSize = OcrLetterSize.Normal)
			=> IdentifyMessage(input.AsStrings(), off, on, whitespace, ocrLetterSize);
	}

	extension(string input) {
		/// <summary>
		/// Identifies and decodes a message from a string representation of OCR-style characters.
		/// </summary>
		/// <remarks>This method processes the input string by splitting it into lines, interpreting the OCR-style grid
		/// of characters, and decoding the message based on the specified parameters. Ensure the input string is formatted
		/// correctly with consistent line endings and spacing for accurate decoding.</remarks>
		/// <param name="input">The input string containing OCR-style characters, where each line represents a row of the character grid.</param>
		/// <param name="off">The character representing an "off" or unlit segment in the OCR grid. Defaults to <see langword="Unlit"/>.</param>
		/// <param name="on">The character representing an "on" or lit segment in the OCR grid. Defaults to <see langword="Lit"/>.</param>
		/// <param name="whitespace">The number of whitespace characters separating individual OCR characters. Defaults to 1.</param>
		/// <param name="ocrLetterSize">The size of the OCR letters to interpret. Defaults to <see cref="OcrLetterSize.Normal"/>.</param>
		/// <returns>The decoded message as a string.</returns>
		public string IdentifyMessage(char off = Unlit, char on = Lit, int whitespace = 1, OcrLetterSize ocrLetterSize = OcrLetterSize.Normal)
			=> IdentifyMessage(input.ReplaceLineEndings().Split(Environment.NewLine), off, on, whitespace, ocrLetterSize);
	}

	extension(IEnumerable<string> input) {
		/// <summary>
		/// Identifies and reconstructs a message from a sequence of strings representing OCR (Optical Character Recognition)
		/// input.
		/// </summary>
		/// <remarks>This method processes the input by interpreting lit and unlit pixels as letters or digits based on
		/// the specified OCR letter size. It assumes that the input strings are of uniform length and that the OCR input
		/// adheres to the expected format.</remarks>
		/// <param name="input">The collection of strings representing the OCR input, where each string corresponds to a row of the input grid.</param>
		/// <param name="off">The character representing an "unlit" pixel in the OCR input. Defaults to <see langword="Unlit"/>.</param>
		/// <param name="on">The character representing a "lit" pixel in the OCR input. Defaults to <see langword="Lit"/>.</param>
		/// <param name="whitespace">The number of columns of whitespace between letters in the OCR input. Defaults to 1.</param>
		/// <param name="ocrLetterSize">The size of the OCR letters to interpret. Defaults to <see cref="OcrLetterSize.Normal"/>.</param>
		/// <returns>A string containing the reconstructed message. If the input contains invalid or unrecognized characters,  the
		/// method stops processing and returns the message reconstructed up to that point.</returns>
		/// <exception cref="NotImplementedException">Thrown if an unsupported value of <paramref name="ocrLetterSize"/> is provided.</exception>
		public string IdentifyMessage(char off = Unlit, char on = Lit, int whitespace = 1, OcrLetterSize ocrLetterSize = OcrLetterSize.Normal) {
			List<string> inputList = [.. input];
			for (int i = 0; i < inputList.Count; i++) {
				inputList[i] = inputList[i].Replace(off, Unlit).Replace(on, Lit);
			}
			int noOfColumns = inputList[0].Length;

			string output = "";
			int col = 0;
			while (col < noOfColumns) {
				char letter = inputList.FindLetter(col, ocrLetterSize) ?? BadCharacter;
				if (letter == BadCharacter || !char.IsLetterOrDigit(letter)) {
					break;
				}
				output += letter;
				int letterWidth = ocrLetterSize switch {
					OcrLetterSize.Normal => LetterWidths[letter - 'A'].Width,
					OcrLetterSize.Medium => Alphabet_Medium_Letter_Width,
					OcrLetterSize.Large => Alphabet_Large_Letter_Width,
					_ => throw new NotImplementedException(),
				};
				col += letterWidth + whitespace;
			}

			return output;
		}

		private string PossibleLetters(OcrLetterSize ocrLetterSize, int col, int row, string possible = null!) {
			string[] inputArray = [.. input];
			possible ??= "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
			string returnPossible = "";
			foreach (char item in possible) {
				int i = item - 'A';
				int charOffset = 1;
				int charWidth = 1;
				string alphabetSlice = "";
				if (ocrLetterSize is OcrLetterSize.Normal) {
					charOffset = i * Alphabet_Normal_Grid_Width;
					charWidth = LetterWidths[i].Width;
					alphabetSlice = Alphabet_Normal[row][charOffset..(charOffset + charWidth)];
				} else if (ocrLetterSize is OcrLetterSize.Medium) {
					charOffset = i * Alphabet_Medium_Grid_Width;
					charWidth = Alphabet_Medium_Letter_Width;
					alphabetSlice = Alphabet_Medium.Split(Environment.NewLine)[row][charOffset..(charOffset + charWidth)];
				} else if (ocrLetterSize is OcrLetterSize.Large) {
					charOffset = i * Alphabet_Large_Grid_Width;
					charWidth = Alphabet_Large_Letter_Width;
					alphabetSlice = Alphabet_Large.Split(Environment.NewLine)[row][charOffset..(charOffset + charWidth)];
				} else {
					throw new NotImplementedException();
				}
				string inputSlice;
				if (col + charWidth < inputArray[row].Length) {
					inputSlice = inputArray[row][col..(col + charWidth)];
				} else {
					inputSlice = inputArray[row][col..];
					inputSlice += new string('.', charWidth - inputSlice.Length);
				}
				if (inputSlice == alphabetSlice) {
					returnPossible += (char)(i + 'A');
				}
			}
			return returnPossible;
		}
	}

	extension(IEnumerable<string> inputList) {
		private char? FindLetter(int col, OcrLetterSize ocrLetterSize) {
			string possibleLetters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
			int gridHeight = ocrLetterSize switch {
				OcrLetterSize.Normal => Alphabet_Normal_Grid_Height,
				OcrLetterSize.Medium => Alphabet_Medium_Grid_Height,
				OcrLetterSize.Large => Alphabet_Large_Grid_Height,
				_ => throw new NotImplementedException(),
			};
			for (int i = 0; i < gridHeight; i++) {
				possibleLetters = inputList.PossibleLetters(ocrLetterSize, col, i, possibleLetters);
				if (possibleLetters.ToList().Count <= 1) {
					return possibleLetters.FirstOrDefault();
				}
			}
			return null;
		}
	}

	public enum OcrLetterSize { Normal, Medium, Large }
}
