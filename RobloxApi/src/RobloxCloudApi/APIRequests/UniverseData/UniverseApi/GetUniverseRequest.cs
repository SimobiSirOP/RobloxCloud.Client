using System.Text.Json.Serialization;
using RobloxCloudApi.RobloxCloudApi.APIRequests.RequestHelpers;
using RobloxCloudApi.RobloxCloudApi.APITypes;

namespace RobloxCloudApi.RobloxCloudApi.APIRequests.UniverseData.UniverseApi;

public class GetUniverseRequest : RequestBase<RobloxUniverse>
{
    [JsonIgnore]
    public override HttpMethod HttpMethod { get; } = HttpMethod.Get;
    [JsonIgnore]
    public override string RequestPath => $"https://apis.roblox.com/cloud/v2/universes/{UniverseId}";
    
    [JsonIgnore]
    public long UniverseId { get; set; }
}