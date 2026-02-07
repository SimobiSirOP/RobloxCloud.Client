using System.Text.Json.Serialization;
using RobloxCloudApi.ApiTypes.DataStoresApi.Types;
using RobloxCloudApi.ApiTypes.RequestHelpers;
using RobloxCloudApi.ApiTypes.RestrictionsApi.ResponseData;

namespace RobloxCloudApi.ApiTypes.DataStoresApi.Requests;

internal class ListDataStoresRequest : ListRequestBase<DataStoreList>
{
    [JsonIgnore]
    public override HttpMethod HttpMethod { get; } = HttpMethod.Get;
    [JsonIgnore]
    public override string RequestPath => $"https://apis.roblox.com/cloud/v2/universes/{UniverseId}/data-stores";
    
    [JsonIgnore]
    public long? UniverseId { get; set; }
}