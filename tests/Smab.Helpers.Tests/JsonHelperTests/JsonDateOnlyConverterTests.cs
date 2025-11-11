using System.Text.Json;

namespace Smab.Helpers.Tests.JsonHelperTests;

public class JsonDateOnlyConverterTests {
	private readonly JsonSerializerOptions _options;

	public JsonDateOnlyConverterTests() {
		_options = new JsonSerializerOptions {
			Converters = { new JsonDateOnlyConverter() }
		};
	}

	[Theory]
	[InlineData(2024, 1, 15, "\"2024-01-15\"")]
	[InlineData(2023, 12, 31, "\"2023-12-31\"")]
	[InlineData(2000, 2, 29, "\"2000-02-29\"")]
	[InlineData(1999, 1, 1, "\"1999-01-01\"")]
	public void Serialize_DateOnly_ShouldReturnFormattedString(int year, int month, int day, string expected) {
		DateOnly date = new(year, month, day);

		string json = JsonSerializer.Serialize(date, _options);

		json.ShouldBe(expected);
	}

	[Theory]
	[InlineData("\"2024-01-15\"", 2024, 1, 15)]
	[InlineData("\"2023-12-31\"", 2023, 12, 31)]
	[InlineData("\"2000-02-29\"", 2000, 2, 29)]
	[InlineData("\"1999-01-01\"", 1999, 1, 1)]
	public void Deserialize_ValidDateString_ShouldReturnDateOnly(string json, int expectedYear, int expectedMonth, int expectedDay) {
		DateOnly result = JsonSerializer.Deserialize<DateOnly>(json, _options);

		result.Year.ShouldBe(expectedYear);
		result.Month.ShouldBe(expectedMonth);
		result.Day.ShouldBe(expectedDay);
	}

	[Fact]
	public void Serialize_MinValue_ShouldReturnFormattedString() {
		DateOnly date = DateOnly.MinValue;

		string json = JsonSerializer.Serialize(date, _options);

		json.ShouldBe("\"0001-01-01\"");
	}

	[Fact]
	public void Serialize_MaxValue_ShouldReturnFormattedString() {
		DateOnly date = DateOnly.MaxValue;

		string json = JsonSerializer.Serialize(date, _options);

		json.ShouldBe("\"9999-12-31\"");
	}
}
