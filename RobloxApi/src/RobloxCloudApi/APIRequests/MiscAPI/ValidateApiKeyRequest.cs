using System.Text.Json.Serialization;
using RobloxCloudApi.RobloxCloudApi.APIRequests.RequestHelpers;
using RobloxCloudApi.RobloxCloudApi.APITypes;

namespace RobloxCloudApi.RobloxCloudApi.APIRequests.MiscAPI;

internal class ValidateApiKeyRequest(string apiKey) : RequestBase<ApiKeyInfo>
{
    [JsonIgnore] public override HttpMethod HttpMethod { get; } = HttpMethod.Post;

    [JsonIgnore] public override string RequestPath { get; } = "https://apis.roblox.com/api-keys/v1/introspect";

    [JsonPropertyName("apiKey")] public string ApiKey { get; set; } = apiKey;
}