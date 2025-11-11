using System.Text.Json;

namespace Smab.Helpers.Tests.JsonHelperTests;

public class JsonUnixDateConverterTests {
	private readonly JsonSerializerOptions _options;

	public JsonUnixDateConverterTests() {
		_options = new JsonSerializerOptions {
			Converters = { new JsonUnixDateConverter() }
		};
	}

	[Theory]
	[InlineData(1970, 1, 1, 0, 0, 0, 0)]
	[InlineData(2024, 1, 15, 12, 40, 0, 1705322400)]
	[InlineData(2000, 1, 1, 0, 0, 0, 946684800)]
	[InlineData(1990, 6, 13, 0, 0, 0, 645235200)]
	public void Serialize_DateTime_ShouldReturnUnixTimestamp(int year, int month, int day, int hour, int minute, int second, long expectedTimestamp) {
		DateTime dateTime = new(year, month, day, hour, minute, second, DateTimeKind.Utc);

		string json = JsonSerializer.Serialize(dateTime, _options);

		json.ShouldBe(expectedTimestamp.ToString());
	}

	[Fact]
	public void Serialize_EpochDateTime_ShouldReturnZero() {
		DateTime epoch = new(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

		string json = JsonSerializer.Serialize(epoch, _options);

		json.ShouldBe("0");
	}

	[Fact]
	public void Serialize_Year1DateTime_ShouldReturnZero() {
		DateTime year1 = new(1, 1, 1, 0, 0, 0, DateTimeKind.Utc);

		string json = JsonSerializer.Serialize(year1, _options);

		json.ShouldBe("0");
	}

	[Theory]
	[InlineData(0, 1970, 1, 1)]
	[InlineData(1705322400, 2024, 1, 15)]
	[InlineData(946684800, 2000, 1, 1)]
	[InlineData(645235200, 1990, 6, 13)]
	public void Deserialize_UnixTimestampInSeconds_ShouldReturnDateTime(double timestamp, int expectedYear, int expectedMonth, int expectedDay) {
		string json = timestamp.ToString();

		DateTime result = JsonSerializer.Deserialize<DateTime>(json, _options);

		result.Year.ShouldBe(expectedYear);
		result.Month.ShouldBe(expectedMonth);
		result.Day.ShouldBe(expectedDay);
		result.Kind.ShouldBe(DateTimeKind.Utc);
	}

	[Theory]
	[InlineData(1705322400000, 2024, 1, 15)]
	[InlineData(946684800000, 2000, 1, 1)]
	public void Deserialize_UnixTimestampInMilliseconds_ShouldReturnDateTime(double timestamp, int expectedYear, int expectedMonth, int expectedDay) {
		string json = timestamp.ToString();

		DateTime result = JsonSerializer.Deserialize<DateTime>(json, _options);

		result.Year.ShouldBe(expectedYear);
		result.Month.ShouldBe(expectedMonth);
		result.Day.ShouldBe(expectedDay);
		result.Kind.ShouldBe(DateTimeKind.Utc);
	}

	[Fact]
	public void Deserialize_Zero_ShouldReturnEpoch() {
		string json = "0";

		DateTime result = JsonSerializer.Deserialize<DateTime>(json, _options);

		result.Year.ShouldBe(1970);
		result.Month.ShouldBe(1);
		result.Day.ShouldBe(1);
	}
}
