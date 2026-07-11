using System.Text.Json.Serialization;

namespace RobloxCloudApi.RobloxCloudApi.APITypes;

public class RobloxDetails
{
    [JsonPropertyName("@type")] public string? PropType { get; set; }

    [JsonExtensionData] public IDictionary<string, object>? PropData { get; set; }
}