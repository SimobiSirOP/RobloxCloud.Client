using System.Text.Json.Serialization;
using RobloxCloudApi.ApiTypes.RestrictionsApi.ResponseData;
using RobloxCloudApi.Helpers.JsonConverters.RequestV2Helpers;

namespace RobloxCloudApi.ApiTypes.RestrictionsApi;


internal class RestrictionRequest : RequestBaseV2<RestrictionData>
{
    [JsonIgnore]
    public override HttpMethod HttpMethod { get; } = HttpMethod.Patch;
    
    [JsonPropertyName("user")]
    [JsonConverter(typeof(UserApiPathConverter))]
    public long? UserId;
    
    [JsonIgnore]
    public long? UniverseId;
    
    [JsonPropertyName("path")]
    public override string RequestPath => $"https://apis.roblox.com/cloud/v2/universes/{UniverseId}/user-restrictions/{UserId}";

    // Currently, Roblox has only gameJoinRestriction, that is just a ban
    [JsonPropertyName("gameJoinRestriction")]
    public GameJoinRestriction? GameJoinRestriction;

    [JsonConstructor]
    public RestrictionRequest() {}
    
    public RestrictionRequest(long universeId, long userId, GameJoinRestriction? gameJoinRestriction)
    {
        UniverseId = universeId;
        UserId = userId;
        GameJoinRestriction = gameJoinRestriction;
    }
}