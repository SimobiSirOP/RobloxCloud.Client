namespace RobloxCloudApi.ApiTypes.UsersApi;

public class ValidateDisplayNameExistingUserRequest : RequestBaseV2<object>
{
    public override HttpMethod HttpMethod { get; } = HttpMethod.Get;
    public override string RequestPath => $"https://users.roblox.com/v1/users/{UserId}/display-names/validate";
    
    public long UserId { get; set; }
    [QueryParameter("displayName")]
    public required string DisplayName { get; set; }
}