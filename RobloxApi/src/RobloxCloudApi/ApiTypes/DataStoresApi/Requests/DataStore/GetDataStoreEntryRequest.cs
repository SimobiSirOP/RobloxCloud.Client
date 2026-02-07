using System.Text.Json.Serialization;
using RobloxCloudApi.ApiTypes.DataStoresApi.Types;

namespace RobloxCloudApi.ApiTypes.DataStoresApi.Requests;

internal class GetDataStoreEntryRequest : RequestBaseV2<DataStoreEntry>
{
    [JsonIgnore]
    public override HttpMethod HttpMethod { get; } = HttpMethod.Get;

    [JsonIgnore]
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
    public string? EntryId { get; set; }
    [JsonIgnore]
    public string? ScopeId { get; set; }
}