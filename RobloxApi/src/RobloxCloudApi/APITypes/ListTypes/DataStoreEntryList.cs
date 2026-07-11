using System.Text.Json.Serialization;
using RobloxCloudApi.RobloxCloudApi.APIRequests.RequestHelpers;

namespace RobloxCloudApi.RobloxCloudApi.APITypes.ListTypes;

public class DataStoreEntryList : ListResponseBase<DataStoreEntry>
{
    [JsonPropertyName("dataStoreEntries")] public override DataStoreEntry[]? List { get; set; }
}