using System.Text.Json.Serialization;
using RobloxCloudApi.RobloxCloudApi.APIRequests.RequestHelpers;

namespace RobloxCloudApi.RobloxCloudApi.APITypes.ListTypes;

public class DataStoreList : ListResponseBase<DataStoreInfo>
{
    [JsonPropertyName("dataStores")] public override DataStoreInfo[]? List { get; set; }
}