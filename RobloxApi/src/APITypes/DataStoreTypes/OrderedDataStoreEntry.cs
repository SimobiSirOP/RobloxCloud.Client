using System.Text.Json.Serialization;
using RobloxCloudApi.APIRequests.Abstractions;
using RobloxCloudApi.Helpers.JsonConverters;
using RobloxCloudApi.Helpers.JsonConverters.RequestV2Helpers;

namespace RobloxCloudApi.APITypes;

public class OrderedDataStoreEntry : ApiBaseData
{
    /// <summary>
    ///  Value of the entry
    /// </summary>
    [JsonPropertyName("value")]
    public long? Value { get; set; }

    [JsonPropertyName("id")] public string? Id { get; set; }
    
}