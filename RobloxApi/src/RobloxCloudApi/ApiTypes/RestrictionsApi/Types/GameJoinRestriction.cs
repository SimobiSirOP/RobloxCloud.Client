using System.Text.Json.Serialization;
using RobloxCloudApi.Helpers.JsonConverters;

namespace RobloxCloudApi.ApiTypes.RestrictionsApi;

public class GameJoinRestriction
{
    [JsonPropertyName("active")] 
    public bool? Active;
    
    [JsonPropertyName("startTime")] 
    [JsonConverter(typeof(DateTimeIso8601Converter))]
    public DateTime? StartTime;
    
    [JsonPropertyName("duration")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public long? Duration;
    
    [JsonPropertyName("privateReason")]
    public string? PrivateReason;
    
    [JsonPropertyName("displayReason")]
    public string? DisplayReason;

    [JsonPropertyName("excludeAltAccounts")]
    public bool? ExcludeAltAccounts;
    
    [JsonPropertyName("inherited")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? Inherited;

    
}