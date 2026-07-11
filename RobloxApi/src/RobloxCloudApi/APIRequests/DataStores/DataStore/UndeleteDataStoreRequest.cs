using System.Text.Json.Serialization;
using RobloxCloudApi.RobloxCloudApi.APIRequests.RequestHelpers;
using RobloxCloudApi.RobloxCloudApi.APITypes;

namespace RobloxCloudApi.RobloxCloudApi.APIRequests.DataStores;

internal class UndeleteDataStoreRequest : RequestBase<DataStoreInfo>
{
    [JsonIgnore] public override HttpMethod HttpMethod { get; } = HttpMethod.Post;

    [JsonIgnore]
    public override string RequestPath =>
        $"https://apis.roblox.com/cloud/v2/universes/{UniverseId}/data-stores/{DataStoreId}:undelete";

    [JsonIgnore] public long? UniverseId { get; set; }

    [JsonIgnore] public string? DataStoreId { get; set; }
}