namespace Smab.Helpers.Tests.GridHelperTests;

public class To2dArray {
	[Theory]
	[InlineData(new int[] { 1, 2, 3, 4, 5, 6 }
		, 2, 3
		, 2, 3, 6)]
	[InlineData(new int[] { 1, 2, 3, 4, 5, 6 }
		, 3, 2
		, 3, 2, 6)]
	[InlineData(new int[] { 1, 2, 3, 4, 5, 6, 7, 8 }
		, 3, null
		, 3, 3, 9)]
	[InlineData(new int[] { 1, 2, 3, 4, 5, 6, 7, 8 }
		, 5, null
		, 5, 2, 10)]
	public void To2dArray_Int_Should_Have_Shape(int[] input, int cols, int? rows,
		int expectedCols, int expectedRows, int expectedLength) {
		int[,] array = input.To2dArray(cols, rows);
		Assert.Equal(expectedLength, array.Length);
		Assert.Equal(expectedCols, array.GetUpperBound(0) + 1);
		Assert.Equal(expectedRows, array.GetUpperBound(1) + 1);
		Assert.Equal(expectedCols, array.ColsCount());
		Assert.Equal(expectedRows, array.RowsCount());
	}

	[Fact]
	public void To2dArray_String_To_Char() {
		string[] input = ["1234567890", "abcdefghij", "0987654321", "zyxwvutsrq"];
		char[,] array = input.To2dArray();
		Assert.Equal(40, array.Length);
		Assert.Equal(10, array.GetUpperBound(0) + 1);
		Assert.Equal(4, array.GetUpperBound(1) + 1);
		Assert.Equal('1', array[0, 0]);
		Assert.Equal('u', array[5, 3]);
		Assert.Equal('d', array[3, 1]);
		Assert.Equal('6', array[4, 2]);
		Assert.Equal('t', array[6, 3]);
	}

	[Fact]
	public void To2dArray_IEnumerableOf_IEnumerableOfT() {

		int[,] array = TestData.GetIEnumerableTestData().To2dArray();

		Assert.Equal(50, array.Length);
		Assert.Equal(10, array.GetUpperBound(0) + 1);
		Assert.Equal(5, array.GetUpperBound(1) + 1);
		Assert.Equal(1, array[0, 0]);
		Assert.Equal(34, array[3, 3]);
		Assert.Equal(14, array[3, 1]);
		Assert.Equal(25, array[4, 2]);
		Assert.Equal(37, array[6, 3]);
	}

	[Fact]
	public void To2dArray_Points_To_Char() {
		Point[] input = [new(1, 3), new(2, 4), new(3, 6)];
		char[,] array = input.To2dArray(initial: ' ', value: '#');
		Assert.Equal(28, array.Length);
		Assert.Equal(4, array.GetUpperBound(0) + 1);
		Assert.Equal(7, array.GetUpperBound(1) + 1);
		Assert.Equal(' ', array[0, 0]);
		Assert.Equal(' ', array[3, 5]);
		Assert.Equal('#', array[1, 3]);
		Assert.Equal('#', array[2, 4]);
		Assert.Equal('#', array[3, 6]);
	}

	[Fact]
	public void To2dArray_Points_With_Negatives_To_Char() {
		Point[] input = [new(1, -3), new(2, 4), new(3, 6)];
		char[,] array = input.To2dArray(initial: ' ', value: '#');
		Assert.Equal(40, array.Length);
		Assert.Equal(4, array.GetUpperBound(0) + 1);
		Assert.Equal(10, array.GetUpperBound(1) + 1);
		Assert.Equal(' ', array[0, 0]);
		Assert.Equal(' ', array[3, 3]);
		Assert.Equal('#', array[1, 0]);
		Assert.Equal('#', array[2, 7]);
		Assert.Equal('#', array[3, 9]);
	}

	[Fact]
	public void To2dArray_Tuple_Should_HaveShape() {
		(char, int)[] input = new (char, int)[8];
		for (int i = 0; i < input.GetUpperBound(0); i++) {
			input[i] = new((char)(65 + i), i + 1);
		}
		(char, int)[,] array = input.To2dArray(4, 2);
		Assert.Equal(8, array.Length);
		Assert.Equal(4, array.GetUpperBound(0) + 1);
		Assert.Equal(2, array.GetUpperBound(1) + 1);
		Assert.Equal(('E', 5), array[0, 1]);

		Array.Clear(array);
		array = input.To2dArray(2);
		Assert.Equal(8, array.Length);
		Assert.Equal(2, array.GetUpperBound(0) + 1);
		Assert.Equal(4, array.GetUpperBound(1) + 1);
		Assert.Equal(('C', 3), array[0, 1]);

		Array.Clear(array);
		array = input.To2dArray(3);
		Assert.Equal(9, array.Length);
		Assert.Equal(3, array.GetUpperBound(0) + 1);
		Assert.Equal(3, array.GetUpperBound(1) + 1);
		Assert.Equal(('G', 7), array[0, 2]);
	}

	public static class TestData {
		public static IEnumerable<IEnumerable<int>> GetIEnumerableTestData() {
			for (int r = 0; r < 50; r += 10) {
				yield return [r + 1, r + 2, r + 3, r + 4, r + 5, r + 6, r + 7, r + 8, r + 9, r + 10];
			}
		}
	}
}

