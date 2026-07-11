using System.Text.Json.Serialization;
using RobloxCloudApi.APIRequests.RequestHelpers;
using RobloxCloudApi.APITypes;

namespace RobloxCloudApi.APIRequests.UsersApi.Requests;

internal class GetUsersFromIdsRequest : OldListRequestBase<RobloxUser[]>
{
    [JsonIgnore] public override HttpMethod HttpMethod { get; } = HttpMethod.Post;

    [JsonIgnore] public override string RequestPath { get; } = "https://users.roblox.com/v1/usernames/users";

    [JsonPropertyName("userIds")] public long[]? UserIds { get; set; }

    [JsonPropertyName("excludeBannedUsers")]
    public bool? ExcludeBannedUsers { get; set; }
}