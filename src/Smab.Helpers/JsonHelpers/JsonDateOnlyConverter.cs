using System.Text.Json;
using System.Text.Json.Serialization;

namespace Smab.Helpers;

/// <summary>
/// Provides custom JSON serialization and deserialization for <see cref="DateOnly"/> values.
/// </summary>
/// <remarks>This converter serializes <see cref="DateOnly"/> values to JSON strings in the "yyyy-MM-dd" format
/// and deserializes JSON strings in a compatible date format back to <see cref="DateOnly"/> instances.</remarks>
public sealed class JsonDateOnlyConverter : JsonConverter<DateOnly> {
	public override DateOnly Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
		=> DateOnly.FromDateTime(reader.GetDateTime());

	public override void Write(Utf8JsonWriter writer, DateOnly value, JsonSerializerOptions options)
		=> writer.WriteStringValue(value.ToString("yyyy-MM-dd"));
}

/// <summary>
/// Provides custom JSON serialization and deserialization for <see cref="TimeOnly"/> values.
/// </summary>
/// <remarks>This converter serializes <see cref="TimeOnly"/> values to JSON as strings in the "HH:mm:ss" format
/// and deserializes them from JSON strings representing a time in the same format.</remarks>
public sealed class JsonTimeOnlyConverter : JsonConverter<TimeOnly> {
	public override TimeOnly Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
		=> TimeOnly.Parse(reader.GetString() ?? "");

	public override void Write(Utf8JsonWriter writer, TimeOnly value, JsonSerializerOptions options)
		=> writer.WriteStringValue(value.ToString("HH:mm:ss"));
}
