using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;

namespace RobloxApi.Helpers.JsonConverters.RequestV2Helpers;

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