using System.Text.Json.Serialization;
using RobloxCloudApi.APIRequests.RequestHelpers;
using RobloxCloudApi.APITypes.ListTypes;

namespace RobloxCloudApi.APIRequests.UniverseData.PlacesApi;

// No auth
public class GetUniversePlacesRequest : OldListRequestBase<PlaceInfoList>
{
    [JsonIgnore]
    public override HttpMethod HttpMethod { get; } = HttpMethod.Get;
    [JsonIgnore]
    public override string RequestPath => $"https://develop.roblox.com/v1/universes/{UniverseId}/places";

    [JsonIgnore] public long? UniverseId { get; set; }

    [QueryParameter("isUniverseCreation")] public bool? IsUniverseCreation { get; set; }
}