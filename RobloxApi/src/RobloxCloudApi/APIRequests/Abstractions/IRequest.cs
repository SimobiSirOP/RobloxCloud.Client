using System.Text.Json.Serialization;

namespace RobloxCloudApi.RobloxCloudApi.APIRequests.Abstractions;

public interface IRequest
{
    [JsonIgnore] public HttpMethod HttpMethod { get; }

    [JsonIgnore] public string RequestPath { get; }

    public HttpContent? GetHttpContent();

    public string GetRequestUri();
}

public interface IRequest<TResponse> : IRequest;