using System.Text.Json.Serialization;
using RobloxCloudApi.APIRequests.RequestHelpers;
using RobloxCloudApi.APITypes;

namespace RobloxCloudApi.APIRequests.MiscAPI.Auth;

public class ObtainOAuthTokensRequest : RequestBase<TokenExchangeResponse>
{
    [JsonIgnore]
    public override HttpMethod HttpMethod { get; } = HttpMethod.Post;

    [JsonIgnore] public override string RequestPath => "https://apis.roblox.com/oauth/v1/token";
    
    [JsonPropertyName("code")] public string? Code { get; set; }
    
    [JsonPropertyName("code_verifier")] public string? CodeVerifier { get; set; }

    [JsonPropertyName("grant_type")] public string? GrantType { get; set; } = "authorization_code";
    
    [JsonPropertyName("client_id")] public string CliendId { get; set; }
    
    [JsonPropertyName("client_secret")] public string? ClientSecret { get; set; }
    
}