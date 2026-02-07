using System.Collections;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;

namespace RobloxCloudApi.ApiTypes.RequestHelpers;
public abstract class ListResponseBase<T> : IEnumerable<T>
{
    [JsonPropertyName("nextPageToken")] 
    public string? NextPageToken { get; set; }
    
    public abstract T[]? List { get; set; }
    
    public IEnumerator<T> GetEnumerator() => (List ?? Enumerable.Empty<T>()).GetEnumerator();
    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}