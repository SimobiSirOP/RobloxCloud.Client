using System.Text.Json.Serialization;

namespace RobloxCloudApi.ApiTypes.RequestHelpers;

internal abstract class ListRequestBase<T> : RequestBaseV2<T>
{
    [JsonIgnore]
    public abstract override HttpMethod HttpMethod { get; }
    
    [JsonPropertyName("path")]
    public abstract override string RequestPath { get; }
    
    [QueryParameter("maxPageSize")] 
    public int? MaxPageSize { get; set; } = 10;
    
    [QueryParameter("pageToken", true)] 
    public string? PageToken { get; set; }
    
    [QueryParameter("showDeleted")] 
    public bool? ShowDeleted  { get; set; }
}