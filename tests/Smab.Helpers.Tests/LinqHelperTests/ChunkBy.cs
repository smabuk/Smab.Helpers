namespace Smab.Helpers.Tests.LinqHelperTests;

public class ChunkBy {
	[Fact]
	public void ChunkBy_EmptySequence_ShouldReturnEmpty() {
		IEnumerable<int> source = [];

		List<List<int>> result = [.. source.ChunkBy(x => x == 0)];

		result.ShouldBeEmpty();
	}

	[Fact]
	public void ChunkBy_NoMatches_ShouldReturnSingleChunk() {
		IEnumerable<int> source = [1, 2, 3, 4, 5];

		List<List<int>> result = [.. source.ChunkBy(x => x == 0)];

		result.Count.ShouldBe(1);
		result[0].ShouldBe([1, 2, 3, 4, 5]);
	}

	[Fact]
	public void ChunkBy_SingleMatch_ShouldSplitIntoTwoChunks() {
		IEnumerable<int> source = [1, 2, 0, 3, 4];

		List<List<int>> result = [.. source.ChunkBy(x => x == 0)];

		result.Count.ShouldBe(2);
		result[0].ShouldBe([1, 2]);
		result[1].ShouldBe([3, 4]);
	}

	[Fact]
	public void ChunkBy_MultipleMatches_ShouldCreateMultipleChunks() {
		IEnumerable<int> source = [1, 2, 0, 3, 4, 0, 5, 6];

		List<List<int>> result = [.. source.ChunkBy(x => x == 0)];

		result.Count.ShouldBe(3);
		result[0].ShouldBe([1, 2]);
		result[1].ShouldBe([3, 4]);
		result[2].ShouldBe([5, 6]);
	}

	[Fact]
	public void ChunkBy_ConsecutiveMatches_ShouldSkipEmptyChunks() {
		IEnumerable<int> source = [1, 2, 0, 0, 3, 4];

		List<List<int>> result = [.. source.ChunkBy(x => x == 0)];

		result.Count.ShouldBe(2);
		result[0].ShouldBe([1, 2]);
		result[1].ShouldBe([3, 4]);
	}

	[Fact]
	public void ChunkBy_StartsWithMatch_ShouldSkipEmptyFirstChunk() {
		IEnumerable<int> source = [0, 1, 2, 3];

		List<List<int>> result = [.. source.ChunkBy(x => x == 0)];

		result.Count.ShouldBe(1);
		result[0].ShouldBe([1, 2, 3]);
	}

	[Fact]
	public void ChunkBy_EndsWithMatch_ShouldNotIncludeEmptyLastChunk() {
		IEnumerable<int> source = [1, 2, 3, 0];

		List<List<int>> result = [.. source.ChunkBy(x => x == 0)];

		result.Count.ShouldBe(1);
		result[0].ShouldBe([1, 2, 3]);
	}

	[Fact]
	public void ChunkBy_AllMatches_ShouldReturnEmpty() {
		IEnumerable<int> source = [0, 0, 0];

		List<List<int>> result = [.. source.ChunkBy(x => x == 0)];

		result.ShouldBeEmpty();
	}

	[Fact]
	public void ChunkBy_WithConversion_EmptySequence_ShouldReturnEmpty() {
		IEnumerable<int> source = [];

		List<List<string>> result = [.. source.ChunkBy(x => x == 0, x => x.ToString())];

		result.ShouldBeEmpty();
	}

	[Fact]
	public void ChunkBy_WithConversion_ShouldConvertElements() {
		IEnumerable<int> source = [1, 2, 0, 3, 4];

		List<List<string>> result = [.. source.ChunkBy(x => x == 0, x => x.ToString())];

		result.Count.ShouldBe(2);
		result[0].ShouldBe(["1", "2"]);
		result[1].ShouldBe(["3", "4"]);
	}

	[Fact]
	public void ChunkBy_WithConversion_NoMatches_ShouldReturnSingleConvertedChunk() {
		IEnumerable<int> source = [1, 2, 3, 4, 5];

		List<List<string>> result = [.. source.ChunkBy(x => x == 0, x => $"value_{x}")];

		result.Count.ShouldBe(1);
		result[0].ShouldBe(["value_1", "value_2", "value_3", "value_4", "value_5"]);
	}

	[Fact]
	public void ChunkBy_WithConversion_MultipleChunks_ShouldConvertAllElements() {
		IEnumerable<int> source = [1, 2, 0, 3, 4, 0, 5, 6];

		List<List<string>> result = [.. source.ChunkBy(x => x == 0, x => x.ToString())];

		result.Count.ShouldBe(3);
		result[0].ShouldBe(["1", "2"]);
		result[1].ShouldBe(["3", "4"]);
		result[2].ShouldBe(["5", "6"]);
	}

	[Fact]
	public void ChunkBy_WithConversion_ComplexTransformation_ShouldWork() {
		IEnumerable<int> source = [1, 2, 0, 3, 4];

		List<List<int>> result = [.. source.ChunkBy(x => x == 0, x => x * 10)];

		result.Count.ShouldBe(2);
		result[0].ShouldBe([10, 20]);
		result[1].ShouldBe([30, 40]);
	}

	[Fact]
	public void ChunkBy_WithConversion_StringToLong_ShouldParseCorrectly() {
		IEnumerable<string> source = ["123", "456", "", "789", "1000"];

		List<List<long>> result = [.. source.ChunkBy(x => string.IsNullOrEmpty(x), x => x.As<long>())];

		result.Count.ShouldBe(2);
		result[0].ShouldBe([123L, 456L]);
		result[1].ShouldBe([789L, 1000L]);
	}

	[Fact]
	public void ChunkBy_WithConversion_StringToLong_WithMultipleSeparators_ShouldParseCorrectly() {
		IEnumerable<string> source = ["100", "200", "300", "", "1234567890", "9876543210", "", "42", "99"];

		List<List<long>> result = [.. source.ChunkBy(x => string.IsNullOrEmpty(x), x => x.As<long>())];

		result.Count.ShouldBe(3);
		result[0].ShouldBe([100L, 200L, 300L]);
		result[1].ShouldBe([1234567890L, 9876543210L]);
		result[2].ShouldBe([42L, 99L]);
	}

	[Fact]
	public void ChunkBy_WithConversion_StringToLong_WithNegativeNumbers_ShouldParseCorrectly() {
		IEnumerable<string> source = ["-100", "200", "", "-300", "400"];

		List<List<long>> result = [.. source.ChunkBy(x => string.IsNullOrEmpty(x), x => x.As<long>())];

		result.Count.ShouldBe(2);
		result[0].ShouldBe([-100L, 200L]);
		result[1].ShouldBe([-300L, 400L]);
	}

	[Fact]
	public void ChunkBy_WithConversion_StringToLong_WithLargeNumbers_ShouldParseCorrectly() {
		IEnumerable<string> source = ["9223372036854775807", "1", "", "-9223372036854775808"];

		List<List<long>> result = [.. source.ChunkBy(x => string.IsNullOrEmpty(x), x => x.As<long>())];

		result.Count.ShouldBe(2);
		result[0].ShouldBe([9223372036854775807L, 1L]);
		result[1].ShouldBe([-9223372036854775808L]);
	}

	[Fact]
	public void ChunkByEmpty_EmptySequence_ShouldReturnEmpty() {
		IEnumerable<string?> source = [];

		List<List<string>> result = [.. source.ChunkByEmpty()];

		result.ShouldBeEmpty();
	}

	[Fact]
	public void ChunkByEmpty_NoEmptyStrings_ShouldReturnSingleChunk() {
		IEnumerable<string?> source = ["one", "two", "three"];

		List<List<string>> result = [.. source.ChunkByEmpty()];

		result.Count.ShouldBe(1);
		result[0].ShouldBe(["one", "two", "three"]);
	}

	[Fact]
	public void ChunkByEmpty_SingleEmptyString_ShouldSplitIntoTwoChunks() {
		IEnumerable<string?> source = ["one", "two", "", "three", "four"];

		List<List<string>> result = [.. source.ChunkByEmpty()];

		result.Count.ShouldBe(2);
		result[0].ShouldBe(["one", "two"]);
		result[1].ShouldBe(["three", "four"]);
	}

	[Fact]
	public void ChunkByEmpty_NullString_ShouldSplitChunks() {
		IEnumerable<string?> source = ["one", "two", null, "three", "four"];

		List<List<string>> result = [.. source.ChunkByEmpty()];

		result.Count.ShouldBe(2);
		result[0].ShouldBe(["one", "two"]);
		result[1].ShouldBe(["three", "four"]);
	}

	[Fact]
	public void ChunkByEmpty_WhitespaceString_ShouldSplitChunks() {
		IEnumerable<string?> source = ["one", "two", "   ", "three", "four"];

		List<List<string>> result = [.. source.ChunkByEmpty()];

		result.Count.ShouldBe(2);
		result[0].ShouldBe(["one", "two"]);
		result[1].ShouldBe(["three", "four"]);
	}

	[Fact]
	public void ChunkByEmpty_MultipleEmptyStrings_ShouldCreateMultipleChunks() {
		IEnumerable<string?> source = ["one", "two", "", "three", "four", "", "five"];

		List<List<string>> result = [.. source.ChunkByEmpty()];

		result.Count.ShouldBe(3);
		result[0].ShouldBe(["one", "two"]);
		result[1].ShouldBe(["three", "four"]);
		result[2].ShouldBe(["five"]);
	}

	[Fact]
	public void ChunkByEmpty_ConsecutiveEmptyStrings_ShouldSkipEmptyChunks() {
		IEnumerable<string?> source = ["one", "two", "", "", "three", "four"];

		List<List<string>> result = [.. source.ChunkByEmpty()];

		result.Count.ShouldBe(2);
		result[0].ShouldBe(["one", "two"]);
		result[1].ShouldBe(["three", "four"]);
	}

	[Fact]
	public void ChunkByEmpty_StartsWithEmpty_ShouldSkipEmptyFirstChunk() {
		IEnumerable<string?> source = ["", "one", "two", "three"];

		List<List<string>> result = [.. source.ChunkByEmpty()];

		result.Count.ShouldBe(1);
		result[0].ShouldBe(["one", "two", "three"]);
	}

	[Fact]
	public void ChunkByEmpty_EndsWithEmpty_ShouldNotIncludeEmptyLastChunk() {
		IEnumerable<string?> source = ["one", "two", "three", ""];

		List<List<string>> result = [.. source.ChunkByEmpty()];

		result.Count.ShouldBe(1);
		result[0].ShouldBe(["one", "two", "three"]);
	}

	[Fact]
	public void ChunkByEmpty_AllEmpty_ShouldReturnEmpty() {
		IEnumerable<string?> source = ["", null, "   "];

		List<List<string>> result = [.. source.ChunkByEmpty()];

		result.ShouldBeEmpty();
	}

	[Fact]
	public void ChunkByEmpty_MixedWhitespace_ShouldTreatAsEmpty() {
		IEnumerable<string?> source = ["one", "\t", "two", "\n", "three", "  \t  "];

		List<List<string>> result = [.. source.ChunkByEmpty()];

		result.Count.ShouldBe(3);
		result[0].ShouldBe(["one"]);
		result[1].ShouldBe(["two"]);
		result[2].ShouldBe(["three"]);
	}

	[Fact]
	public void ChunkBy_IsDeferred_ShouldNotEvaluateUntilEnumerated() {
		bool predicateCalled = false;
		IEnumerable<int> source = [1, 2, 3];

		IEnumerable<List<int>> result = source.ChunkBy(x => {
			predicateCalled = true;
			return x == 0;
		});

		predicateCalled.ShouldBeFalse();

		List<List<int>> materializedResult = [.. result];

		predicateCalled.ShouldBeTrue();
	}

	[Fact]
	public void ChunkBy_WithConversion_IsDeferred_ShouldNotEvaluateUntilEnumerated() {
		bool conversionCalled = false;
		IEnumerable<int> source = [1, 2, 3];

		IEnumerable<List<string>> result = source.ChunkBy(
			x => x == 0,
			x => {
				conversionCalled = true;
				return x.ToString();
			}
		);

		conversionCalled.ShouldBeFalse();

		List<List<string>> materializedResult = [.. result];

		conversionCalled.ShouldBeTrue();
	}

	private static readonly string[] sourceArray = ["one", "two", ""];

	[Fact]
	public void ChunkByEmpty_IsDeferred_ShouldNotEvaluateUntilEnumerated() {
		List<string> evaluatedItems = [];
		IEnumerable<string?> source = sourceArray.Select(x => {
			evaluatedItems.Add(x);
			return x;
		});

		IEnumerable<List<string>> result = source.ChunkByEmpty();

		evaluatedItems.ShouldBeEmpty();

		List<List<string>> materializedResult = [.. result];

		evaluatedItems.Count.ShouldBe(3);
	}
}
