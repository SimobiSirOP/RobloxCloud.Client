using System.Text.Json.Serialization;
using RobloxCloudApi.APIRequests.RequestHelpers;
using RobloxCloudApi.APITypes;
using RobloxCloudApi.APITypes.ListTypes;

namespace RobloxCloudApi.APIRequests.UsersApi;

internal class ListUserRestrictionsRequest : ListRequestBase<RestrictionList>
{
    [JsonIgnore]
    public override HttpMethod HttpMethod { get; } = HttpMethod.Get;
    
    [JsonIgnore]
    public override string RequestPath => $"https://apis.roblox.com/cloud/v2/universes/{UniverseId}/user-restrictions";

    [JsonIgnore]
    public long? UniverseId;
    
    [JsonPropertyName("userRestrictions")]
    public RestrictionData[]? Restrictions { get; set; }
    
}