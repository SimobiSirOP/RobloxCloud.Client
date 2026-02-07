using System.Text.Json.Serialization;
using RobloxCloudApi.ApiTypes.RequestHelpers;

namespace RobloxCloudApi.ApiTypes.RestrictionsApi.ResponseData;

public class RestrictionList : ListResponseBase<RestrictionData>
{
    [JsonPropertyName("userRestrictions")]
    public override RestrictionData[]? List { get; set; }
}