using RobloxCloudApi.APIRequests.RequestHelpers;

namespace RobloxCloudApi.APIRequests.UsersApi.Requests;

public class ValidateDisplayNameExistingUserRequest : RequestBase<object>
{
    public override HttpMethod HttpMethod { get; } = HttpMethod.Get;
    public override string RequestPath => $"https://users.roblox.com/v1/users/{UserId}/display-names/validate";

    public long UserId { get; set; }

    [QueryParameter("displayName")] public required string DisplayName { get; set; }
}