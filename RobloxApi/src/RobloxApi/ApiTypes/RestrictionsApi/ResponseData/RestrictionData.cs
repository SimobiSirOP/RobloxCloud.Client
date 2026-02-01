using System.Text.Json.Serialization;
using RobloxApi.ApiTypes.Abstractions;
using RobloxApi.ApiTypes.RestrictionsApi.Restrictions;

namespace RobloxApi.ApiTypes.RestrictionsApi.ResponseData;

public class RestrictionData : ApiV2BaseData
{
    [JsonPropertyName("gameJoinRestriction")]
    public GameJoinRestriction? GameJoinRestriction;
}