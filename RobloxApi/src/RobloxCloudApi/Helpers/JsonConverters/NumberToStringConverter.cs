using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace RobloxCloudApi.RobloxCloudApi.Helpers.JsonConverters;

public class NumberToStringConverter : JsonConverter<string>
{
    public override string? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TokenType == JsonTokenType.String) return reader.GetString();

        if (reader.TokenType == JsonTokenType.Number) return Encoding.UTF8.GetString(reader.ValueSpan);

        if (reader.TokenType == JsonTokenType.True || reader.TokenType == JsonTokenType.False)
            return Encoding.UTF8.GetString(reader.ValueSpan);

        return null;
    }

    public override void Write(Utf8JsonWriter writer, string value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value);
    }
}