using System.Text.Json.Serialization;
using RobloxCloudApi.APIRequests.RequestHelpers;
using RobloxCloudApi.APITypes;

namespace RobloxCloudApi.APIRequests.DataStores.OrderedDataStore;

internal class UpdateOrderedDataStoreEntryRequest : RequestBase<OrderedDataStoreEntry>
{
    [JsonIgnore] public override HttpMethod HttpMethod { get; } = HttpMethod.Patch;

    [JsonPropertyName("path")]
    public override string RequestPath =>
                $"https://apis.roblox.com/cloud/v2/universes/{UniverseId}/ordered-data-stores/{OrderedDataStoreId}/scopes/{ScopeId}/entries/{EntryId}";


    [JsonIgnore] public long UniverseId { get; set; }

    [JsonIgnore] public string OrderedDataStoreId { get; set; } = "";

    [JsonIgnore] public string? EntryId { get; set; }

    [JsonIgnore] public string ScopeId { get; set; }  = "";
    
    [JsonPropertyName("value")] public long Value { get; set; }

    [JsonPropertyName("allowMissing")] public bool AllowMissing { get; set; } = true;



}