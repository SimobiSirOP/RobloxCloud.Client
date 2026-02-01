using System.Text.Json.Serialization;
using RobloxApi.ApiTypes.RestrictionsApi.Responses;

namespace RobloxApi.ApiTypes.RestrictionsApi;

public class GetUserRestrictionsRequest : RequestBaseV2<RestrictionData>
{
    public override HttpMethod HttpMethod { get; } = HttpMethod.Get;
    
    [JsonPropertyName("path")]
    public override string RequestPath => $"https://apis.roblox.com/cloud/v2/universes/{UniverseId}/user-restrictions/{UserId}";
    
    public long? UniverseId { get; set; }
    
    public long? UserId { get; set; }
}