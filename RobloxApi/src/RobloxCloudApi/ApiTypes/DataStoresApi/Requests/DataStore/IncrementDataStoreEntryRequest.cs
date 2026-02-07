using System.Text.Json.Serialization;
using RobloxCloudApi.ApiTypes.DataStoresApi.Types;
using RobloxCloudApi.Helpers.JsonConverters.RequestV2Helpers;

namespace RobloxCloudApi.ApiTypes.DataStoresApi.Requests;

internal class IncrementDataStoreEntryRequest : RequestBaseV2<DataStoreEntry>
{
    [JsonIgnore]
    public override HttpMethod HttpMethod { get; } = HttpMethod.Patch;

    [JsonPropertyName("path")]
    public override string RequestPath {
        get
        {
            if (ScopeId == null)
                return
                    $"https://apis.roblox.com/cloud/v2/universes/{UniverseId}/data-stores/{DataStoreId}/entries/{EntryId}:increment";
            return $"https://apis.roblox.com/cloud/v2/universes/{UniverseId}/data-stores/{DataStoreId}/scopes/{ScopeId}/entries/{EntryId}:increment";
        }
    }
    [JsonIgnore]
    public long? UniverseId { get; set; }
    [JsonIgnore]
    public string? DataStoreId { get; set; }
    [JsonIgnore]
    public string? EntryId { get; set; }
    [JsonIgnore]
    public string? ScopeId { get; set; }
    
    [JsonPropertyName("amount")]
    public long? Amount { get; set; }
    
    [JsonPropertyName("users")]
    [JsonConverter(typeof(UserApiPathConverter))]
    public long[]? Users { get; set; }
    
    [JsonPropertyName("attributes")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public object[]? Attributes { get; set; }
}