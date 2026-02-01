using System.Text.Json.Serialization;
using RobloxCloudApi.ApiTypes.Abstractions;

namespace RobloxCloudApi.ApiTypes.RestrictionsApi.ResponseData;

public class RestrictionData : ApiV2BaseData
{
    [JsonPropertyName("gameJoinRestriction")]
    public GameJoinRestriction? GameJoinRestriction;
}