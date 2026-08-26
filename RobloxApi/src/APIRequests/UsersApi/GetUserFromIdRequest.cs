using System.Text.Json.Serialization;
using RobloxCloudApi.APIRequests.RequestHelpers;
using RobloxCloudApi.APITypes;

namespace RobloxCloudApi.APIRequests.UsersApi.Requests;

[ApiTokenAuth]
public class GetUserFromIdRequest : RequestBase<RobloxFullUser>
{
    [JsonIgnore] public override HttpMethod HttpMethod { get; } = HttpMethod.Get;

    [JsonIgnore] public override string RequestPath => $"https://apis.roblox.com/cloud/v2/users/{UserId}";

    [JsonPropertyName("id")] public long? UserId { get; set; }
}