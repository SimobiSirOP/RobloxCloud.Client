using RobloxCloudApi.APIRequests.Abstractions;

namespace RobloxCloudApi;

public interface IRobloxApiClient
{
    Task<TResponse?> SendRequest<TResponse>(IRequest<TResponse> request);
}