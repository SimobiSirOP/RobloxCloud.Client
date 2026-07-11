using RobloxCloudApi.APIRequests.RequestHelpers;

namespace RobloxCloudApi.APIRequests.UsersApi.Requests;

public class ValidateDisplayNameNewUserRequest : RequestBase<object>
{
    public override HttpMethod HttpMethod { get; } = HttpMethod.Get;
    public override string RequestPath => "https://users.roblox.com/v1/display-names/validate";

    [QueryParameter("displayName")] public required string DisplayName { get; set; }
}