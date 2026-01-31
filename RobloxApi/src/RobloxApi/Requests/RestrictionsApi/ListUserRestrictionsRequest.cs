using System.Text.Json.Serialization;

namespace RobloxApi.Requests;

public class ListUserRestrictionsRequest : RequestBaseV2<ListUserRestrictionsRequest>
{
    [JsonIgnore]
    public override HttpMethod HttpMethod { get; } = HttpMethod.Get;
    
    [JsonPropertyName("path")]
    public override string RequestPath => $"https://apis.roblox.com/cloud/v2/universes/{UniverseId}/user-restrictions";

    [JsonIgnore]
    public long? UniverseId;
    
    [JsonPropertyName("userRestrictions")]
    public RestrictionRequest[]? UserRestrictions { get; set; }
    
    [QueryParameter("maxPageSize")] public int? MaxPageSize { get; set; } = 10;
    
    [JsonPropertyName("nextPageToken")] 
    [QueryParameter("pageToken", true)]
    public string? PageToken { get; set; }

}