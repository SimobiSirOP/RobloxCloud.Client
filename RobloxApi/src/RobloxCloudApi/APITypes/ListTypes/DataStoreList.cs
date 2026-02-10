using System.Text.Json.Serialization;
using RobloxCloudApi.APIRequests.RequestHelpers;

namespace RobloxCloudApi.APITypes.ListTypes;

public class DataStoreList : ListResponseBase<DataStoreInfo>
{
    [JsonPropertyName("dataStores")]
    public override DataStoreInfo[]? List { get; set; }
}