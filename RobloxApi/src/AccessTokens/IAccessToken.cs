using JetBrains.Annotations;

namespace RobloxCloudApi.AccessTokens;

public interface IAccessToken
{
    [System.Diagnostics.Contracts.Pure]
    public HttpRequestMessage ApplyToRequest(HttpRequestMessage request);
}