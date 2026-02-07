using System.Text.Json.Serialization;
using RobloxCloudApi.ApiTypes.RequestHelpers;

namespace RobloxCloudApi.ApiTypes.DataStoresApi.Types;

public class DataStoreEntryList : ListResponseBase<DataStoreEntry>
{
    [JsonPropertyName("dataStoreEntries")]
    public override DataStoreEntry[]? List { get; set; }
}