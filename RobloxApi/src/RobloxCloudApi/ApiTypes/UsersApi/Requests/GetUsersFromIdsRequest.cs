using System.Text.Json.Serialization;
using RobloxCloudApi.Types;

namespace RobloxCloudApi.ApiTypes.UsersApi;

public class GetUsersFromIdsRequest : RequestBase<RobloxUser[]>
{
    [JsonIgnore] 
    public override HttpMethod HttpMethod { get; } = HttpMethod.Post;

    [JsonIgnore] 
    public override string RequestPath { get; } = "https://users.roblox.com/v1/usernames/users";

    [JsonIgnore] 
    public override string DeserializedPropertyPath { get; } = "data";

    [JsonPropertyName("userIds")] 
    public long[]? UserIds { get; set; }
    
    [JsonPropertyName("excludeBannedUsers")]
    public bool? ExcludeBannedUsers { get; set; }
}