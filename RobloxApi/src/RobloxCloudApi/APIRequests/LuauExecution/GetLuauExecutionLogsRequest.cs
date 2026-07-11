using System.Text.Json.Serialization;
using RobloxCloudApi.RobloxCloudApi.APIRequests.RequestHelpers;
using RobloxCloudApi.RobloxCloudApi.APITypes;
using RobloxCloudApi.RobloxCloudApi.APITypes.ListTypes;

namespace RobloxCloudApi.RobloxCloudApi.APIRequests.LuauExecution;

internal class GetLuauExecutionLogsRequest : ListRequestBase<LuauExecutionLogList>
{
    public GetLuauExecutionLogsRequest(string path)
    {
        RequestPath = path;
    }

    [JsonIgnore] public override HttpMethod HttpMethod { get; } = HttpMethod.Get;

    [JsonIgnore] public override string RequestPath { get; }

    [QueryParameter("view")] public LuauLogView View { get; set; }
}