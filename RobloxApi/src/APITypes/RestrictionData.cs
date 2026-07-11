using System.Text.Json.Serialization;
using RobloxCloudApi.APIRequests.Abstractions;
using RobloxCloudApi.Helpers.JsonConverters;

namespace RobloxCloudApi.APITypes;

public class RestrictionData : ApiBaseData
{
    [JsonPropertyName("gameJoinRestriction")]
    public GameJoinRestriction? GameJoinRestriction;
}

public class GameJoinRestriction
{
    [JsonPropertyName("active")] public bool? Active;

    [JsonPropertyName("displayReason")] public string? DisplayReason;

    [JsonPropertyName("duration")] 
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Duration;

    [JsonPropertyName("excludeAltAccounts")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? ExcludeAltAccounts;

    [JsonPropertyName("inherited")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? Inherited;

    [JsonPropertyName("privateReason")] public string? PrivateReason;

    [JsonPropertyName("startTime")] [JsonConverter(typeof(DateTimeIso8601Converter))]
    public DateTime? StartTime;
}