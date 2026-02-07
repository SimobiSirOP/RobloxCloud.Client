using System.Text.Json.Serialization;
using RobloxCloudApi.ApiTypes.RequestHelpers;

namespace RobloxCloudApi.ApiTypes.DataStoresApi.Types;

public class DataStoreList : ListResponseBase<DataStoreInfo>
{
    [JsonPropertyName("dataStores")]
    public override DataStoreInfo[]? List { get; set; }
}