using System.Text.Json.Serialization;
using RobloxCloudApi.APIRequests.RequestHelpers;

namespace RobloxCloudApi.APITypes.ListTypes;

public class OrderedDataStoreEntryList : ListResponseBase<OrderedDataStoreEntry>
{
    [JsonPropertyName("orderedDataStoreEntries")] public override OrderedDataStoreEntry[]? List { get; set; }
}