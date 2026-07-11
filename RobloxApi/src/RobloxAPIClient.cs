using System.Net;
using JetBrains.Annotations;
using RobloxCloudApi.APIRequests.Abstractions;
using RobloxCloudApi.ErrorHandling;
using RobloxCloudApi.ErrorHandling.Exceptions;
using RobloxCloudApi.Helpers;

namespace RobloxCloudApi;

[PublicAPI]
public class RobloxApiClient : IRobloxApiClient
{
    private readonly HttpClient _httpClient;

    public RobloxApiClient(RobloxApiClientSettings robloxApiClientSettings, HttpClient? httpClient = default)
    {
        _robloxApiClientSettings = robloxApiClientSettings;
        _httpClient = httpClient ??
                      new HttpClient(new SocketsHttpHandler
                          { PooledConnectionIdleTimeout = TimeSpan.FromMinutes(1) });
        _httpClient.DefaultRequestHeaders.Add("x-api-key", _robloxApiClientSettings.ApiKey);
    }

    private RobloxApiClientSettings _robloxApiClientSettings { get; set; }


    public async Task<TResponse?> SendRequest<TResponse>(IRequest<TResponse> request)
    {
        if (request is null)
            throw new ArgumentNullException(nameof(request));

        for (var attempts = 0;; attempts++)
        {
            using var httpRequest = new HttpRequestMessage(request.HttpMethod, request.GetRequestUri());
            var requestContent = request.GetHttpContent();
            httpRequest.Content = requestContent;

            if (requestContent != null)
                await requestContent.LoadIntoBufferAsync().ConfigureAwait(false);

            HttpResponseMessage httpResponseMessage;
            try
            {
                httpResponseMessage = await _httpClient.SendAsync(httpRequest).ConfigureAwait(false);
            }
            catch (TaskCanceledException exception)
            {
                throw new TimeoutException("Request timed out: ", exception);
            }
            catch (Exception exception)
            {
                throw new RobloxApiException("Exception occurred during a request to Roblox API:", exception);
            }

            using (httpResponseMessage)
            {
                if (!httpResponseMessage.IsSuccessStatusCode)
                {
                    if (httpResponseMessage.StatusCode == HttpStatusCode.TooManyRequests &&
                        attempts <= _robloxApiClientSettings.AmountOfRetries)
                    {
                        await Task.Delay(_robloxApiClientSettings.Timeout).ConfigureAwait(false);
                        continue;
                    }

                    throw new RobloxApiException(await ErrorParser.GetErrorString(httpResponseMessage));
                }

                return Serializer.SerializeFromString<TResponse>(
                    await httpResponseMessage.Content.ReadAsStringAsync());
            }
        }
    }
}

public class RobloxApiClientSettings
{
    public RobloxApiClientSettings(string apiKey, TimeSpan requestTimeout, int requestRetryAmount = 5)
    {
        ApiKey = apiKey;
        Timeout = requestTimeout;
        AmountOfRetries = requestRetryAmount;
    }

    public RobloxApiClientSettings(string apiKey, int requestRetryAmount = 5)
    {
        ApiKey = apiKey;
        Timeout = new TimeSpan(0, 0, 5);
        AmountOfRetries = requestRetryAmount;
    }

    public string ApiKey { get; }

    public TimeSpan Timeout { get; }

    public int AmountOfRetries { get; }
}