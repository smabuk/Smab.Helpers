using System.Text.Json;

namespace Smab.Helpers.Tests.JsonHelperTests;

public class JsonTimeOnlyConverterTests {
	private readonly JsonSerializerOptions _options;

	public JsonTimeOnlyConverterTests() {
		_options = new JsonSerializerOptions {
			Converters = { new JsonTimeOnlyConverter() }
		};
	}

	[Theory]
	[InlineData(0, 0, 0, "\"00:00:00\"")]
	[InlineData(12, 30, 45, "\"12:30:45\"")]
	[InlineData(23, 59, 59, "\"23:59:59\"")]
	[InlineData(9, 5, 3, "\"09:05:03\"")]
	public void Serialize_TimeOnly_ShouldReturnFormattedString(int hour, int minute, int second, string expected) {
		TimeOnly time = new(hour, minute, second);

		string json = JsonSerializer.Serialize(time, _options);

		json.ShouldBe(expected);
	}

	[Theory]
	[InlineData("\"00:00:00\"", 0, 0, 0)]
	[InlineData("\"12:30:45\"", 12, 30, 45)]
	[InlineData("\"23:59:59\"", 23, 59, 59)]
	[InlineData("\"09:05:03\"", 9, 5, 3)]
	public void Deserialize_ValidTimeString_ShouldReturnTimeOnly(string json, int expectedHour, int expectedMinute, int expectedSecond) {
		TimeOnly result = JsonSerializer.Deserialize<TimeOnly>(json, _options);

		result.Hour.ShouldBe(expectedHour);
		result.Minute.ShouldBe(expectedMinute);
		result.Second.ShouldBe(expectedSecond);
	}

	[Fact]
	public void Serialize_MinValue_ShouldReturnFormattedString() {
		TimeOnly time = TimeOnly.MinValue;

		string json = JsonSerializer.Serialize(time, _options);

		json.ShouldBe("\"00:00:00\"");
	}

	[Fact]
	public void Serialize_MaxValue_ShouldReturnFormattedString() {
		TimeOnly time = TimeOnly.MaxValue;

		string json = JsonSerializer.Serialize(time, _options);

		json.ShouldBe("\"23:59:59\"");
	}
}
