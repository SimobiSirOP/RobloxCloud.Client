using System.Text.Json.Serialization;

namespace RobloxApi.ApiTypes.Abstractions;

public interface IRequest
{
    [JsonIgnore]
    public HttpMethod HttpMethod { get; }
    
    [JsonIgnore]
    public string RequestPath { get; }
    
    [JsonIgnore]
    public string DeserializedPropertyPath { get; }

    public HttpContent? GetHttpContent();

    public string GetRequestUri();
}

public interface IRequest<TResponse> : IRequest;