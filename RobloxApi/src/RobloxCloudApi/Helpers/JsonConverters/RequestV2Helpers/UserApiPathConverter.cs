using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;

namespace RobloxCloudApi.Helpers.JsonConverters.RequestV2Helpers;

public class UserApiPathConverter : JsonConverter<long>
{
    public override long Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var strValue = reader.GetString();
        var match = Regex.Match(strValue!, @"^users/(\d*$)");
        if (!match.Success)
            throw new JsonException("Error parsing userId from v2 request user API path");
        return long.Parse(match.Groups[1].Value);
    }

    public override void Write(Utf8JsonWriter writer, long value, JsonSerializerOptions options)
    {
        writer.WriteStringValue($"users/{value}");
    }
}

public class UserApiPathArrayConverter : JsonConverter<long[]>
{
    public override long[] Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TokenType != JsonTokenType.StartArray)
            throw new JsonException("Expected start of array.");

        var list = new List<long>();

        while (reader.Read())
        {
            if (reader.TokenType == JsonTokenType.EndArray)
                return list.ToArray();

            var strValue = reader.GetString();
            var match = Regex.Match(strValue ?? "", @"^users/(\d+)$");

            if (!match.Success)
                throw new JsonException($"Invalid user path format: {strValue}");

            list.Add(long.Parse(match.Groups[1].Value));
        }

        throw new JsonException("Unexpected end of JSON.");
    }

    public override void Write(Utf8JsonWriter writer, long[] value, JsonSerializerOptions options)
    {
        writer.WriteStartArray();
        foreach (var item in value) writer.WriteStringValue($"users/{item}");
        writer.WriteEndArray();
    }
}