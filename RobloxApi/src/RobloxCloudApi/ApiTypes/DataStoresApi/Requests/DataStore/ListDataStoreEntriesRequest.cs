using System.Text.Json.Serialization;
using RobloxCloudApi.ApiTypes.DataStoresApi.Types;
using RobloxCloudApi.ApiTypes.RequestHelpers;

namespace RobloxCloudApi.ApiTypes.DataStoresApi.Requests;

internal class ListDataStoreEntriesRequest : ListRequestBase<DataStoreEntryList>
{
    [JsonIgnore]
    public override HttpMethod HttpMethod { get; } = HttpMethod.Get;

    [JsonIgnore]
    public override string RequestPath {
        get
        {
            if (ScopeId == null)
                return
                    $"https://apis.roblox.com/cloud/v2/universes/{UniverseId}/data-stores/{DataStoreId}/entries/";
            return $"https://apis.roblox.com/cloud/v2/universes/{UniverseId}/data-stores/{DataStoreId}/scopes/{ScopeId}/entries/";
        }
    }
        
    [JsonIgnore]
    public long? UniverseId { get; set; }
    [JsonIgnore]
    public string? DataStoreId { get; set; }
    
    [JsonIgnore]
    public string? ScopeId { get; set; }
}
