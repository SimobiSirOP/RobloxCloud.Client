using System.Text.Json.Serialization;
using RobloxCloudApi.RobloxCloudApi.APIRequests.RequestHelpers;
using RobloxCloudApi.RobloxCloudApi.APITypes;
using RobloxCloudApi.RobloxCloudApi.APITypes.ListTypes;

namespace RobloxCloudApi.RobloxCloudApi.APIRequests.UsersApi.Requests;

internal class ListUserRestrictionsRequest : ListRequestBase<RestrictionList>
{
    [JsonIgnore] public long? UniverseId;

    [JsonIgnore] public override HttpMethod HttpMethod { get; } = HttpMethod.Get;

    [JsonIgnore]
    public override string RequestPath => $"https://apis.roblox.com/cloud/v2/universes/{UniverseId}/user-restrictions";

    [JsonPropertyName("userRestrictions")] public RestrictionData[]? Restrictions { get; set; }
}