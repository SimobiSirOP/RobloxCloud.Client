using System.Text.Json.Serialization;
using RobloxCloudApi.APIRequests.RequestHelpers;
using RobloxCloudApi.APITypes.ListTypes;

namespace RobloxCloudApi.APIRequests.DataStores;

[ApiTokenAuth]
internal class ListDataStoresRequest : ListRequestBase<DataStoreList>
{
    [JsonIgnore] public override HttpMethod HttpMethod { get; } = HttpMethod.Get;

    [JsonIgnore]
    public override string RequestPath => $"https://apis.roblox.com/cloud/v2/universes/{UniverseId}/data-stores";

    [JsonIgnore] public long? UniverseId { get; set; }
}