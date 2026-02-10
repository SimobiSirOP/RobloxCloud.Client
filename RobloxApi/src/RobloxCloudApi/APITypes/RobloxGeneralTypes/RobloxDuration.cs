using System.Text.Json;
using System.Text.Json.Serialization;

namespace RobloxCloudApi.APITypes.RobloxGeneralTypes;

[JsonConverter(typeof(RobloxDurationConverter))]
public struct RobloxDuration
{
    public string Duration { get; set; }

    public RobloxDuration(double duration)
    {
        if (duration < -315576000000d || duration > 315576000000d)
            throw new ArgumentOutOfRangeException(nameof(duration));

        Duration = duration + "s";
    }

    public RobloxDuration(string durationStr)
    {
        if (!durationStr.EndsWith("s")) throw new ArgumentException("Duration string must ends with 's'.");

        if (!double.TryParse(durationStr.Substring(0, durationStr.Length - 1), out _))
            throw new ArgumentException("Duration is not a number.");

        Duration = durationStr;
    }

    public override string ToString() => Duration;
}

public class RobloxDurationConverter : JsonConverter<RobloxDuration>
{
    public override RobloxDuration Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        return new RobloxDuration(reader.GetString() ?? "0s");
    }

    public override void Write(Utf8JsonWriter writer, RobloxDuration value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value.ToString());
    }
}