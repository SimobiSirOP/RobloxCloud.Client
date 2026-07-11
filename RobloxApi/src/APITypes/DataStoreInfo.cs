using System.Text.Json.Serialization;
using RobloxCloudApi.APIRequests.Abstractions;
using RobloxCloudApi.Helpers.JsonConverters;

namespace RobloxCloudApi.APITypes;

public class DataStoreInfo : ApiDataBase
{
    [JsonConverter(typeof(JsonStringEnumConverter<DataStoreState>))] [JsonPropertyName("state")]
    public DataStoreState? State;

    [JsonPropertyName("createTime")]
    [JsonConverter(typeof(DateTimeIso8601Converter))]
    public DateTime? CreationTime { get; set; }

    [JsonPropertyName("expireTime")]
    [JsonConverter(typeof(DateTimeIso8601Converter))]
    public DateTime? ExpirationTime { get; set; }

    [JsonPropertyName("id")] public string? Id { get; set; }
}

public enum DataStoreState
{
    STATE_UNSPECIFIED,
    ACTIVE,
    DELETED
}