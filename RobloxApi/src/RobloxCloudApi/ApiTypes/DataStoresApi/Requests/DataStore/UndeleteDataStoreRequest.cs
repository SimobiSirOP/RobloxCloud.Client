using System.Text.Json.Serialization;
using RobloxCloudApi.ApiTypes.DataStoresApi.Types;

namespace RobloxCloudApi.ApiTypes.DataStoresApi.Requests;

internal class UndeleteDataStoreRequest : RequestBaseV2<DataStoreInfo>
{
    [JsonIgnore]
    public override HttpMethod HttpMethod { get; } = HttpMethod.Post;

    [JsonIgnore]
    public override string RequestPath =>
        $"https://apis.roblox.com/cloud/v2/universes/{UniverseId}/data-stores/{DataStoreId}:undelete";

    [JsonIgnore]
    public long? UniverseId { get; set; }
    [JsonIgnore]
    public string? DataStoreId { get; set; }
}