using System.Text.Json.Serialization;
using RobloxCloudApi.APIRequests.RequestHelpers;

namespace RobloxCloudApi.APITypes.ListTypes;

public class RestrictionList : ListResponseBase<RestrictionData>
{
    [JsonPropertyName("userRestrictions")]
    public override RestrictionData[]? List { get; set; }
}