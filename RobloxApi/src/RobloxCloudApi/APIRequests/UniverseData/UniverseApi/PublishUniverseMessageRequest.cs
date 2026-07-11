using System.Text.Json.Serialization;
using RobloxCloudApi.RobloxCloudApi.APIRequests.RequestHelpers;

namespace RobloxCloudApi.RobloxCloudApi.APIRequests.UniverseData.UniverseApi;

public class PublishUniverseMessageRequest : RequestBase<object>
{
    [JsonIgnore]
    public override HttpMethod HttpMethod { get; } = HttpMethod.Post;
    
    [JsonIgnore]
    public override string RequestPath => $"https://apis.roblox.com/cloud/v2/universes/{UniverseId}:publishMessage";
    
    [JsonIgnore]
    public long UniverseId { get; set; }
    
    [JsonPropertyName("topic")]
    public string Topic { get; set; }
    
    [JsonPropertyName("message")]
    public string Message { get; set; }
    
    
}