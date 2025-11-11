using System.Text.Json;
using System.Text.Json.Serialization;

namespace Smab.Helpers;

/// <summary>
/// Converts <see cref="DateTime"/> values to and from their Unix timestamp representation in JSON.
/// </summary>
/// <remarks>This converter serializes <see cref="DateTime"/> values as the number of seconds since the Unix epoch
/// (January 1, 1970, 00:00:00 UTC). When deserializing, it converts Unix timestamps back into  <see cref="DateTime"/>
/// values in UTC.</remarks>
public sealed class JsonUnixDateConverter : JsonConverter<DateTime> {
	public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
		=> reader.GetDouble().FromUnixDate();

	public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
		=> writer.WriteNumberValue((value.Year == 1) ? 0 : (value - Unix.Epoch).TotalSeconds);
}

/// <summary>
/// Provides functionality to convert nullable <see cref="DateTime"/> values to and from Unix time during JSON
/// serialization and deserialization.
/// </summary>
/// <remarks>This converter handles nullable <see cref="DateTime"/> values by converting them to Unix time (the
/// number of seconds since January 1, 1970, UTC) during serialization, and by parsing Unix time back into nullable <see
/// cref="DateTime"/> values during deserialization. If the <see cref="DateTime"/> value is <c>null</c> or represents
/// the year 1 (default <see cref="DateTime"/> value), it is serialized as <c>null</c>.</remarks>
public sealed class JsonUnixDateConverterWithNulls : JsonConverter<DateTime?> {
	public override DateTime? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
		=> reader.GetDouble().FromUnixDate();

	public override void Write(Utf8JsonWriter writer, DateTime? value, JsonSerializerOptions options) {
		if (value is null) {
			writer.WriteNullValue();
		}
		if (value.HasValue) {
			if (value.Value.Year == 1) {
				writer.WriteNullValue();
			} else {
				writer.WriteNumberValue((value.Value - Unix.Epoch).TotalSeconds);
			}
		}
	}
}

internal static class Unix {
	internal static DateTime Epoch => DateTime.UnixEpoch;
}

internal static class DoubleExtensions {
	extension(double? unixDate) {
		public DateTime FromUnixDate()
		=> unixDate switch {
			> 99999999999 => Unix.Epoch.AddSeconds(unixDate / (double)1000 ?? 0.0),
			_ => Unix.Epoch.AddSeconds(unixDate ?? 0.0)
		};
	}

	extension(double unixDate) {
		public DateTime FromUnixDate()
		=> unixDate switch {
			> 99999999999 => Unix.Epoch.AddSeconds(unixDate / 1000),
			_ => Unix.Epoch.AddSeconds(unixDate)
		};
	}
}
