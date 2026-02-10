using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.Json.Serialization.Metadata;
using System.Text.Unicode;

namespace RobloxCloudApi.Helpers;

public class Serializer
{
    private static JsonSerializerOptions DefaultSettings => new()
    {
        UnmappedMemberHandling = JsonUnmappedMemberHandling.Skip,
        NumberHandling = JsonNumberHandling.AllowReadingFromString,
        Encoder = JavaScriptEncoder.Create(UnicodeRanges.All),
        IncludeFields = true,
        PropertyNameCaseInsensitive = true,
        TypeInfoResolver = new DefaultJsonTypeInfoResolver(),
        AllowTrailingCommas = true,
        ReadCommentHandling = JsonCommentHandling.Skip
    };


    private static JsonSerializerOptions IndentedSettings => new(DefaultSettings)
    {
        WriteIndented = true
    };


    public static byte[] ConvertObjectToBytes(object objectToConvert)
    {
        return JsonSerializer.SerializeToUtf8Bytes(objectToConvert, DefaultSettings);
    }

    public static T ConvertBytesToObject<T>(byte[] bytes)
    {
        return JsonSerializer.Deserialize<T>(bytes, DefaultSettings)!;
    }

    /// <summary>
    ///     Serializes an object to JSON/>
    /// </summary>
    public static string SerializeToString(object serializable)
    {
        return JsonSerializer.Serialize(serializable, DefaultSettings);
    }


    /// <summary>
    ///     Deserializes an object from JSON
    /// </summary>
    public static T SerializeFromString<T>(string json)
    {
        return JsonSerializer.Deserialize<T>(json, DefaultSettings)!;
    }

    /// <summary>
    ///     Desearializes an object from JSON placed on specific Path
    /// </summary>
    /// <param name="json">Json string</param>
    /// <param name="path">Path to object inside JSON</param>
    public static T SerializeFromString<T>(string json, string path)
    {
        if (string.IsNullOrWhiteSpace(path) && !string.IsNullOrWhiteSpace(json))
            return SerializeFromString<T>(json);

        using var doc = SerializeFromString<JsonDocument>(json);
        var currentElement = doc.RootElement;
        var segments = path.Trim().Split('/', '.', '\\', ',');

        foreach (var segment in segments)
            if (currentElement.ValueKind == JsonValueKind.Object &&
                currentElement.TryGetProperty(segment, out var nextElement))
                currentElement = nextElement;
            else
                throw new JsonException($"Path segment '{segment}' not found in the JSON structure.");

        return currentElement.Deserialize<T>(DefaultSettings)!;
    }


    /// <summary>
    ///     Serializes an object to JSON file/>
    /// </summary>
    public static void SerializeToFile(string path, object serializable)
    {
        File.WriteAllText(path, JsonSerializer.Serialize(serializable, IndentedSettings));
    }

    /// <summary>
    ///     Deserializes an object from JSON file/>
    /// </summary>
    public static T SerializeFromFile<T>(string path)
    {
        return JsonSerializer.Deserialize<T>(File.ReadAllText(path), DefaultSettings)!;
    }
}