using System.Text.Json.Serialization;
using RobloxCloudApi.APIRequests.RequestHelpers;
using RobloxCloudApi.APITypes;
using RobloxCloudApi.Helpers.JsonConverters.RequestV2Helpers;

namespace RobloxCloudApi.APIRequests.UsersApi;

internal class RestrictionRequest : RequestBase<RestrictionData>
{
    // Currently, Roblox has only gameJoinRestriction, that is just a ban
    [JsonPropertyName("gameJoinRestriction")]
    public GameJoinRestriction? GameJoinRestriction;

    [JsonIgnore] public long? UniverseId;

    [JsonPropertyName("user")] [JsonConverter(typeof(UserApiPathConverter))]
    public long? UserId;

    [JsonConstructor]
    public RestrictionRequest()
    {
    }

    public RestrictionRequest(long universeId, long userId, GameJoinRestriction? gameJoinRestriction)
    {
        UniverseId = universeId;
        UserId = userId;
        GameJoinRestriction = gameJoinRestriction;
    }

    [JsonIgnore] public override HttpMethod HttpMethod { get; } = HttpMethod.Patch;

    [JsonPropertyName("path")]
    public override string RequestPath =>
        $"https://apis.roblox.com/cloud/v2/universes/{UniverseId}/user-restrictions/{UserId}";
}