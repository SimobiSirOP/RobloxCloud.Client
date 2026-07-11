using System.Text.Json.Serialization;
using RobloxCloudApi.RobloxCloudApi.APIRequests.Abstractions;

namespace RobloxCloudApi.RobloxCloudApi.APITypes;

public class LuauExecutionLog : ApiDataBase
{
    [JsonPropertyName("messages")] public RobloxMessage[]? Messages { get; set; }

    [JsonPropertyName("structuredMessages")]
    public RobloxStructuredMessage[]? StructuredMessages { get; set; }
}

public enum LuauLogView
{
    VIEW_UNSPECIFIED,
    FLAT,
    STRUCTURED
}