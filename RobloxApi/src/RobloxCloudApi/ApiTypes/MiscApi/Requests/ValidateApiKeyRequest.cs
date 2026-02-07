using System.Text.Json.Serialization;
using RobloxCloudApi.ApiTypes.MiscApi.Types;

namespace RobloxCloudApi.ApiTypes.MiscApi.Requests;

internal class ValidateApiKeyRequest : RequestBase<ApiKeyInfo>
{
    [JsonIgnore]
    public override HttpMethod HttpMethod { get; } = HttpMethod.Post;
    
    [JsonIgnore]
    public override string RequestPath { get; } = "https://apis.roblox.com/api-keys/v1/introspect";
    
    [JsonPropertyName("apiKey")]
    public string ApiKey { get; set; }
}