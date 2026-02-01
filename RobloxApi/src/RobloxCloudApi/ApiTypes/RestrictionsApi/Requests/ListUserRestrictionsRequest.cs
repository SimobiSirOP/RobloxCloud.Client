using System.Text.Json.Serialization;
using RobloxCloudApi.ApiTypes.RestrictionsApi.ResponseData;

namespace RobloxCloudApi.ApiTypes.RestrictionsApi;

public class ListUserRestrictionsRequest : RequestBaseV2<ListUserRestrictionsRequest>
{
    [JsonIgnore]
    public override HttpMethod HttpMethod { get; } = HttpMethod.Get;
    
    [JsonIgnore]
    public override string RequestPath => $"https://apis.roblox.com/cloud/v2/universes/{UniverseId}/user-restrictions";

    [JsonIgnore]
    public long? UniverseId;
    
    [JsonPropertyName("userRestrictions")]
    public RestrictionData[]? Restrictions { get; set; }
        
    [QueryParameter("maxPageSize")] public int? MaxPageSize { get; set; } = 10;
    
    [JsonInclude]
    [QueryParameter("pageToken", true)]
    public string? PageToken { get; set; }

}