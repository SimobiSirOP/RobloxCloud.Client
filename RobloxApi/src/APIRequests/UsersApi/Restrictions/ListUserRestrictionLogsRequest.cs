using System.Text.Json.Serialization;
using RobloxCloudApi.APIRequests.RequestHelpers;
using RobloxCloudApi.APITypes;
using RobloxCloudApi.APITypes.ListTypes;

namespace RobloxCloudApi.APIRequests.UsersApi.Requests;

[ApiTokenAuth]
internal class ListUserRestrictionLogsRequest : ListRequestBase<RestrictionList>
{
    [JsonIgnore] public long? UniverseId;

    [JsonIgnore] public override HttpMethod HttpMethod { get; } = HttpMethod.Get;

    [JsonIgnore]
    public override string RequestPath => $"https://apis.roblox.com/cloud/v2/universes/{UniverseId}/user-restrictions";

    [JsonPropertyName("userRestrictions")] public RestrictionData[]? Restrictions { get; set; }
}