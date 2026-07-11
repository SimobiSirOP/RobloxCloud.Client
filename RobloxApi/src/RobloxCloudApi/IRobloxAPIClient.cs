using RobloxCloudApi.RobloxCloudApi.APIRequests.Abstractions;

namespace RobloxCloudApi.RobloxCloudApi;

public interface IRobloxApiClient
{
    Task<TResponse?> SendRequest<TResponse>(IRequest<TResponse> request);
}