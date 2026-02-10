using System.Text.Json.Serialization;
using RobloxCloudApi.APIRequests.RequestHelpers;
using RobloxCloudApi.APITypes;

namespace RobloxCloudApi.APIRequests.MiscAPI;

internal class ValidateApiKeyRequest : RequestBase<ApiKeyInfo>
{
    [JsonIgnore]
    public override HttpMethod HttpMethod { get; } = HttpMethod.Post;
    
    [JsonIgnore]
    public override string RequestPath { get; } = "https://apis.roblox.com/api-keys/v1/introspect";
    
    [JsonPropertyName("apiKey")]
    public string ApiKey { get; set; }
}