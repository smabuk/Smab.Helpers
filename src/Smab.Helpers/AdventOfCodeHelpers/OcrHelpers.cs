﻿namespace Smab.Helpers;

public static class OcrHelpers {
	const char Unlit = '.';
	const char Lit   = '#';
	const char BadCharacter = '!';

	static readonly int Alphabet_Normal_Grid_Width = 6;
	static readonly int Alphabet_Normal_Grid_Height = 6;
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

	public static string IdentifyMessage(this char[,] input, char off = Unlit, char on = Lit, int whitespace = 1, OcrLetterSize ocrLetterSize = OcrLetterSize.Normal)
		=> IdentifyMessage(input.AsStrings(), off, on, whitespace, ocrLetterSize);

	public static string IdentifyMessage(this string input, char off = Unlit, char on = Lit, int whitespace = 1, OcrLetterSize ocrLetterSize = OcrLetterSize.Normal)
		=> IdentifyMessage(input.ReplaceLineEndings().Split(Environment.NewLine), off, on, whitespace, ocrLetterSize);

	public static string IdentifyMessage(this IEnumerable<string> input, char off = Unlit, char on = Lit, int whitespace = 1, OcrLetterSize ocrLetterSize = OcrLetterSize.Normal) {
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




	private static char? FindLetter(this IEnumerable<string> inputList, int col, OcrLetterSize ocrLetterSize) {
		string possibleLetters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
		int gridHeight = ocrLetterSize switch {
			OcrLetterSize.Normal => Alphabet_Normal_Grid_Height,
			OcrLetterSize.Medium => Alphabet_Medium_Grid_Height,
			OcrLetterSize.Large  => Alphabet_Large_Grid_Height,
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

	private static string PossibleLetters(this IEnumerable<string> input, OcrLetterSize ocrLetterSize, int col, int row, string possible = null!) {
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

	public enum OcrLetterSize { Normal, Medium, Large }
}
