using System.Text.Json.Serialization;
using RobloxCloudApi.RobloxCloudApi.APIRequests.RequestHelpers;
using RobloxCloudApi.RobloxCloudApi.APITypes.ListTypes;

namespace RobloxCloudApi.RobloxCloudApi.APIRequests.UsersApi.Requests;

public class GetUsersFromUsernamesRequest : OldListRequestBase<RobloxUserList>
{
    [JsonIgnore] public override HttpMethod HttpMethod { get; } = HttpMethod.Post;

    [JsonIgnore] public override string RequestPath { get; } = "https://users.roblox.com/v1/usernames/users";

    [JsonPropertyName("usernames")] public string[]? Usernames { get; set; }

    [JsonPropertyName("excludeBannedUsers")]
    public bool? ExcludeBannedUsers { get; set; }
}