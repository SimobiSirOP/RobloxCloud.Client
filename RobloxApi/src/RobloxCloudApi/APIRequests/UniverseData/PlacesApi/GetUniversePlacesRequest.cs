using System.Text.Json.Serialization;
using RobloxCloudApi.APIRequests.RequestHelpers;
using RobloxCloudApi.APITypes.ListTypes;

namespace RobloxCloudApi.APIRequests.UniverseData.PlacesApi;

public class GetUniversePlacesRequest : OldListRequestBase<PlaceInfoList>
{
    public override HttpMethod HttpMethod { get; } = HttpMethod.Get;
    public override string RequestPath => $"https://develop.roblox.com/v1/universes/{UniverseId}/places";

    [JsonIgnore] public long? UniverseId { get; set; }

    [QueryParameter("isUniverseCreation")] public bool? IsUniverseCreation { get; set; }
}