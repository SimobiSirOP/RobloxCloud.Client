using System.Text.Json.Serialization;
using RobloxCloudApi.ApiTypes.RequestHelpers;
using RobloxCloudApi.ApiTypes.RestrictionsApi.ResponseData;

namespace RobloxCloudApi.ApiTypes.RestrictionsApi;

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