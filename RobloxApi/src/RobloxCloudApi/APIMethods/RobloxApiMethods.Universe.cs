using RobloxCloudApi.APIRequests.LuauExecution;
using RobloxCloudApi.APIRequests.RequestHelpers;
using RobloxCloudApi.APIRequests.UniverseData.PlacesApi;
using RobloxCloudApi.APITypes;
using RobloxCloudApi.APITypes.ListTypes;
using RobloxCloudApi.APITypes.Operations;
using RobloxCloudApi.APITypes.RobloxGeneralTypes;
using RobloxCloudApi.Helpers;

namespace RobloxCloudApi;

public static partial class RobloxApiMethods
{
    public static async Task<PlaceInfoList> GetUniversePlaces(
        this IRobloxApiClient client,
        long universeId,
        bool? isUniverseCreation = false,
        int maxPageSize = 10,
        string? cursor = null,
        SortOrder sortOrder = SortOrder.Asc)
    {
        return (await client.ThrowIfNull().SendRequest(new GetUniversePlacesRequest
        {
            UniverseId = universeId,
            IsUniverseCreation = isUniverseCreation,
            MaxPageSize = maxPageSize,
            Cursor = cursor,
            SortOrder = sortOrder
        }))!;
    }

    public static async Task<LuauExecutionOperation> RunLuauExecution(
        this IRobloxApiClient client,
        long universeId,
        long placeId,
        string? script,
        RobloxDuration timeout,
        bool returnErrorsInstead = false,
        bool enableBinaryOutput = false,
        RobloxBinary? binaryInput = null)
    {
        var output = new object();
        object? error = null;
        if (returnErrorsInstead)
        {
            output = null;
            error = new object();
        }

        var startOperation = await client.ThrowIfNull().SendRequest(
            new CreateLuauExecutionRequest
            {
                UniverseId = universeId,
                PlaceId = placeId,
                Timeout = timeout,
                Script = script,
                Output = output,
                Error = error,
                BinaryInput = binaryInput,
                EnableBinaryOutput = enableBinaryOutput
            })!;
        return await startOperation!.WaitForCompletionAsync<LuauExecutionOperation>(client);
    }

    public static async Task<LuauExecutionLogList> GetLuauExecutionLog(
        this IRobloxApiClient client,
        LuauExecutionOperation operation,
        string? pageToken = null,
        int maxPageSize = 10,
        LuauLogView view = LuauLogView.FLAT
    )
    {
        const string domain = "https://apis.roblox.com/cloud/v2/";

        var requestUrl = domain + operation.RequestPath;

        var request = new GetLuauExecutionLogsRequest(requestUrl)
        {
            MaxPageSize = maxPageSize,
            PageToken = pageToken,
            View = view
        };
        return (await client.ThrowIfNull().SendRequest(request))!;
    }
}