namespace RobloxCloudApi.ApiTypes.UsersApi;

public class ValidateDisplayNameNewUserRequest : RequestBaseV2<object>
{
    public override HttpMethod HttpMethod { get; } = HttpMethod.Get;
    public override string RequestPath => $"https://users.roblox.com/v1/display-names/validate";
    
    [QueryParameter("displayName")]
    public required string DisplayName { get; set; }
}