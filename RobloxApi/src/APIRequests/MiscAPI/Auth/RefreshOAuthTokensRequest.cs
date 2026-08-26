using System.Text.Json.Serialization;
using RobloxCloudApi.APIRequests.RequestHelpers;
using RobloxCloudApi.APITypes;

namespace RobloxCloudApi.APIRequests.MiscAPI.Auth;

public class RefreshOAuthTokensRequest : RequestBase<TokenExchangeResponse>
{
    [JsonIgnore]
    public override HttpMethod HttpMethod { get; } = HttpMethod.Post;

    [JsonIgnore] public override string RequestPath => "https://apis.roblox.com/oauth/v1/token";
    
    [JsonPropertyName("refresh_token")] public string? RefreshToken { get; set; }
    
    [JsonPropertyName("grant_type")] public string? GrantType { get; set; } = "refresh_token";
    
    [JsonPropertyName("client_id")] public string CliendId { get; set; }
    
    [JsonPropertyName("client_secret")] public string? ClientSecret { get; set; }
    
}