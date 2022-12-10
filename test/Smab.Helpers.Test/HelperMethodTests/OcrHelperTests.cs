namespace Smab.Helpers.Test.HelperMethodTests;
public class OcrHelperTests
{
	[Theory]
	[InlineData("""
		.##..###...##..###..####.####..##..#..#.###...##.#..#.#.....##..###..###...###.#..#.#...#.####.
		#..#.#..#.#..#.#..#.#....#....#..#.#..#..#.....#.#.#..#....#..#.#..#.#..#.#....#..#.#...#....#.
		#..#.###..#....#..#.###..###..#....####..#.....#.##...#....#..#.#..#.#..#.#....#..#..#.#....#..
		####.#..#.#....#..#.#....#....#.##.#..#..#.....#.#.#..#....#..#.###..###...##..#..#...#....#...
		#..#.#..#.#..#.#..#.#....#....#..#.#..#..#..#..#.#.#..#....#..#.#....#.#.....#.#..#...#...#....
		#..#.###...##..###..####.#.....###.#..#.###..##..#..#.####..##..#....#..#.###...##....#...####.
		""", OcrHelpers.OcrLetterSize.Normal, "ABCDEFGHIJKLOPRSUYZ")]
	public void OcrAlphabet(string ocrAlphabet, OcrHelpers.OcrLetterSize letterSize, string expected)
	{
		string actual = OcrHelpers.IdentifyMessage(ocrAlphabet, 1, letterSize);
		Assert.Equal(expected, actual);
	}

}
