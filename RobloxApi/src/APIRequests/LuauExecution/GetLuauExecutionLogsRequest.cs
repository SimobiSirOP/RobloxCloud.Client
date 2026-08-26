using System.Text.Json.Serialization;
using RobloxCloudApi.APIRequests.RequestHelpers;
using RobloxCloudApi.APITypes;
using RobloxCloudApi.APITypes.ListTypes;

namespace RobloxCloudApi.APIRequests.LuauExecution;

[ApiTokenAuth]
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