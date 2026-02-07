using System.Text.Json.Serialization;
using RobloxCloudApi.ApiTypes.DataStoresApi.Types;

namespace RobloxCloudApi.ApiTypes.DataStoresApi.Requests;

internal class DeleteDataStoreRequest : RequestBaseV2<DataStoreInfo>
{
    [JsonIgnore]
    public override HttpMethod HttpMethod { get; } = HttpMethod.Delete;

    [JsonIgnore]
    public override string RequestPath =>
        $"https://apis.roblox.com/cloud/v2/universes/{UniverseId}/data-stores/{DataStoreId}";

    [JsonIgnore]
    public long? UniverseId { get; set; }
    [JsonIgnore]
    public string? DataStoreId { get; set; }
}