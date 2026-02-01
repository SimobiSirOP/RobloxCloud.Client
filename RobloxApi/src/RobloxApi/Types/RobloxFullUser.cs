using System.Runtime.CompilerServices;
using System.Text.Json.Serialization;
using RobloxApi.Helpers.JsonConverters;

namespace RobloxApi.Types;

public class RobloxFullUser : RobloxUser
{
    [JsonConverter(typeof(DateTimeIso8601Converter))]
    [JsonPropertyName("createTime")]
    public DateTime? CreationTime { get; set; }
    
    [JsonPropertyName("about")]
    public string? About { get; set; }
    
    [JsonPropertyName("locale")]
    public string? Locale { get; set; }
    
    [JsonPropertyName("premium")]
    public bool? HasRobloxPremium { get; set; }
    
    [JsonPropertyName("idVerified")]
    public bool? VerifiedById { get; set; }
    
    [JsonPropertyName("socialNetworkProfiles")]
    public Dictionary<string, string>? SocialNetworkProfiles { get; set; }
}