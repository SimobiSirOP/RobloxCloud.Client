using System.Text.Json.Serialization;
using RobloxCloudApi.ApiTypes.DataStoresApi.Types;
using RobloxCloudApi.Helpers.JsonConverters.RequestV2Helpers;

namespace RobloxCloudApi.ApiTypes.DataStoresApi.Requests;

internal class CreateDataStoreEntryRequest : RequestBaseV2<DataStoreEntry>
{
    [JsonIgnore]
    public override HttpMethod HttpMethod { get; } = HttpMethod.Post;

    [JsonPropertyName("path")]
    public override string RequestPath {
        get
        {
            if (ScopeId == null)
                return
                    $"https://apis.roblox.com/cloud/v2/universes/{UniverseId}/data-stores/{DataStoreId}/entries/{EntryId}";
            return $"https://apis.roblox.com/cloud/v2/universes/{UniverseId}/data-stores/{DataStoreId}/scopes/{ScopeId}/entries/{EntryId}";
        }
    }
    
    [JsonIgnore]
    public long? UniverseId { get; set; }
    [JsonIgnore]
    public string? DataStoreId { get; set; }
    
    [JsonIgnore]
    [QueryParameter("id")]
    public string? EntryId { get; set; }
    
    [JsonIgnore]
    public string? ScopeId { get; set; }
    
    [JsonPropertyName("etag")]
    public string? ETag { get; set; }
    
    [JsonPropertyName("value")]
    public string? Value { get; set; }
    
    [JsonPropertyName("users")]
    [JsonConverter(typeof(UserApiPathConverter))]
    public long[]? Users { get; set; }
    
    [JsonPropertyName("attributes")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public object[]? Attributes { get; set; }
}