using System.Text.Json.Serialization;
using RobloxCloudApi.RobloxCloudApi.APIRequests.RequestHelpers;

namespace RobloxCloudApi.RobloxCloudApi.APITypes.ListTypes;

public class LuauExecutionLogList : ListResponseBase<LuauExecutionLog>
{
    [JsonPropertyName("luauExecutionSessionTaskLogs")]
    public override LuauExecutionLog[]? List { get; set; }
}