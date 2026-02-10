using System.Text.Json.Serialization;
using RobloxCloudApi.APITypes.RobloxGeneralTypes;
using RobloxCloudApi.ErrorHandling;
using RobloxCloudApi.Helpers.JsonConverters;
using RobloxCloudApi.Helpers.JsonConverters.RequestV2Helpers;

namespace RobloxCloudApi.APITypes.Operations;

public class LuauExecutionOperation : BaseOperation
{
    [JsonPropertyName("createTime")]
    [JsonConverter(typeof(DateTimeIso8601Converter))]
    public DateTime? CreationTime { get; set; }
    
    [JsonPropertyName("updateTime")]
    [JsonConverter(typeof(DateTimeIso8601Converter))]
    public DateTime? UpdateTime { get; set; }
    
    [JsonPropertyName("user")]
    [JsonConverter(typeof(UserApiPathConverter))]
    public long? UserId { get; set; }
    
    [JsonPropertyName("state")]
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public LuauExecutionState?  State { get; set; }
    
    [JsonPropertyName("script")]
    public string? Script {get; set;}
    
    [JsonPropertyName("timeout")]
    public RobloxDuration? Timeout { get; set; }
    
    [JsonPropertyName("errors")]
    public RobloxError[]? Errors { get; set; }
    
    [JsonPropertyName("output")]
    public object? Output { get; set; }
    
    [JsonPropertyName("binaryInput")]
    public RobloxBytes? BinaryInput { get; set; }
    
    [JsonPropertyName("enableBinaryOutput")]
    public bool? EnableBinaryOutput { get; set; }
    
    [JsonPropertyName("binaryOutputUrl")]
    public string? BinaryOutputUrl { get; set; }
    
    
    
    public override bool IsCompleted()
    {
        return State != LuauExecutionState.PROCESSING;
    }
}

public enum LuauExecutionState
{
    STATE_UNSPECIFIED,
    PROCESSING,
    FAILED,
    COMPLETE
}