using System.Text.Json.Serialization;
using RobloxCloudApi.APIRequests.RequestHelpers;
using RobloxCloudApi.APITypes;

namespace RobloxCloudApi.APIRequests.UsersApi;

internal class GetUserRestrictionsRequest : RequestBase<RestrictionData>
{
    public override HttpMethod HttpMethod { get; } = HttpMethod.Get;
    
    [JsonPropertyName("path")]
    public override string RequestPath => $"https://apis.roblox.com/cloud/v2/universes/{UniverseId}/user-restrictions/{UserId}";
    
    public long? UniverseId { get; set; }
    
    public long? UserId { get; set; }
}