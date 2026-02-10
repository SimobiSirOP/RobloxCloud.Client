using RobloxCloudApi.APIRequests.RequestHelpers;
using RobloxCloudApi.APIRequests.UniverseData.PlacesApi;
using RobloxCloudApi.APITypes.ListTypes;
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
        return (await client.ThrowIfNull().SendRequest(new GetUniversePlacesRequest()
        {
            UniverseId = universeId,
            IsUniverseCreation = isUniverseCreation,
            MaxPageSize = maxPageSize,
            Cursor = cursor,
            SortOrder = sortOrder
        }))!;
    }
}