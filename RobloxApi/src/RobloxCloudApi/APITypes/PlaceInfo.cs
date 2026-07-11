using System.Text.Json.Serialization;

namespace RobloxCloudApi.RobloxCloudApi.APITypes;

public class PlaceInfo
{
    [JsonPropertyName("id")] public long? Id { get; set; }

    [JsonPropertyName("UniverseId")] public long? UniverseId { get; set; }

    [JsonPropertyName("name")] public string? Name { get; set; }

    [JsonPropertyName("description")] public string? Description { get; set; }
}