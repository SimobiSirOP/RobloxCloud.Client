using System.Text.Json.Serialization;
using RobloxCloudApi.RobloxCloudApi.APIRequests.RequestHelpers;

namespace RobloxCloudApi.RobloxCloudApi.APITypes.ListTypes;

public class RestrictionList : ListResponseBase<RestrictionData>
{
    [JsonPropertyName("userRestrictions")] public override RestrictionData[]? List { get; set; }
}