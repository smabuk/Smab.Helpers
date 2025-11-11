using System.Text.Json;

namespace Smab.Helpers.Tests.JsonHelperTests;

public class JsonUnixDateConverterWithNullsTests {
	private readonly JsonSerializerOptions _options;

	public JsonUnixDateConverterWithNullsTests() {
		_options = new JsonSerializerOptions {
			Converters = { new JsonUnixDateConverterWithNulls() }
		};
	}

	[Theory]
	[InlineData(1970, 1, 1, 0, 0, 0, 0)]
	[InlineData(2024, 1, 15, 12, 30, 0, 1705321800)]
	[InlineData(2000, 1, 1, 0, 0, 0, 946684800)]
	public void Serialize_NullableDateTime_ShouldReturnUnixTimestamp(int year, int month, int day, int hour, int minute, int second, long expectedTimestamp) {
		DateTime? dateTime = new DateTime(year, month, day, hour, minute, second, DateTimeKind.Utc);

		string json = JsonSerializer.Serialize(dateTime, _options);

		json.ShouldBe(expectedTimestamp.ToString());
	}

	[Fact]
	public void Serialize_NullDateTime_ShouldReturnNull() {
		DateTime? dateTime = null;

		string json = JsonSerializer.Serialize(dateTime, _options);

		json.ShouldBe("null");
	}

	[Fact]
	public void Serialize_Year1DateTime_ShouldReturnNull() {
		DateTime? dateTime = new DateTime(1, 1, 1, 0, 0, 0, DateTimeKind.Utc);

		string json = JsonSerializer.Serialize(dateTime, _options);

		json.ShouldBe("null");
	}

	[Theory]
	[InlineData(0, 1970, 1, 1)]
	[InlineData(1705322400, 2024, 1, 15)]
	[InlineData(946684800, 2000, 1, 1)]
	public void Deserialize_UnixTimestampInSeconds_ShouldReturnNullableDateTime(double timestamp, int expectedYear, int expectedMonth, int expectedDay) {
		string json = timestamp.ToString();

		DateTime? result = JsonSerializer.Deserialize<DateTime?>(json, _options);

		result.ShouldNotBeNull();
		result.Value.Year.ShouldBe(expectedYear);
		result.Value.Month.ShouldBe(expectedMonth);
		result.Value.Day.ShouldBe(expectedDay);
		result.Value.Kind.ShouldBe(DateTimeKind.Utc);
	}

	[Theory]
	[InlineData(1705322400000, 2024, 1, 15)]
	[InlineData(946684800000, 2000, 1, 1)]
	public void Deserialize_UnixTimestampInMilliseconds_ShouldReturnNullableDateTime(double timestamp, int expectedYear, int expectedMonth, int expectedDay) {
		string json = timestamp.ToString();

		DateTime? result = JsonSerializer.Deserialize<DateTime?>(json, _options);

		result.ShouldNotBeNull();
		result.Value.Year.ShouldBe(expectedYear);
		result.Value.Month.ShouldBe(expectedMonth);
		result.Value.Day.ShouldBe(expectedDay);
		result.Value.Kind.ShouldBe(DateTimeKind.Utc);
	}

	[Fact]
	public void Deserialize_Zero_ShouldReturnEpoch() {
		string json = "0";

		DateTime? result = JsonSerializer.Deserialize<DateTime?>(json, _options);

		result.ShouldNotBeNull();
		result.Value.Year.ShouldBe(1970);
		result.Value.Month.ShouldBe(1);
		result.Value.Day.ShouldBe(1);
	}
}
