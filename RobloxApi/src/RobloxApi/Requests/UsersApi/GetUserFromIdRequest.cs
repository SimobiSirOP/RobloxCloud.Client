using System.Text.Json.Serialization;
using RobloxApi.Types;

namespace RobloxApi.Requests;

public class GetUserFromIdRequest : RequestBaseV2<RobloxUser>
{
    [JsonIgnore] public override HttpMethod HttpMethod { get; } = HttpMethod.Get;

    [JsonIgnore]
    public override string RequestPath => $"https://apis.roblox.com/cloud/v2/users/{UserId}";

    [JsonPropertyName("id")]
    public long? UserId { get; set; }
}
        