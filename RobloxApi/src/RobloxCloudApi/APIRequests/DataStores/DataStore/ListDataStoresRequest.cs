using System.Text.Json.Serialization;
using RobloxCloudApi.RobloxCloudApi.APIRequests.RequestHelpers;
using RobloxCloudApi.RobloxCloudApi.APITypes.ListTypes;

namespace RobloxCloudApi.RobloxCloudApi.APIRequests.DataStores;

internal class ListDataStoresRequest : ListRequestBase<DataStoreList>
{
    [JsonIgnore] public override HttpMethod HttpMethod { get; } = HttpMethod.Get;

    [JsonIgnore]
    public override string RequestPath => $"https://apis.roblox.com/cloud/v2/universes/{UniverseId}/data-stores";

    [JsonIgnore] public long? UniverseId { get; set; }
}