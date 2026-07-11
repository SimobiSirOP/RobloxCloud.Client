using System.Text.Json.Serialization;
using RobloxCloudApi.RobloxCloudApi.APIRequests.RequestHelpers;
using RobloxCloudApi.RobloxCloudApi.APITypes;

namespace RobloxCloudApi.RobloxCloudApi.APIRequests.DataStores;

internal class DeleteDataStoreRequest : RequestBase<DataStoreInfo>
{
    [JsonIgnore] public override HttpMethod HttpMethod { get; } = HttpMethod.Delete;

    [JsonIgnore]
    public override string RequestPath =>
        $"https://apis.roblox.com/cloud/v2/universes/{UniverseId}/data-stores/{DataStoreId}";

    [JsonIgnore] public long? UniverseId { get; set; }

    [JsonIgnore] public string? DataStoreId { get; set; }
}