using System.Net;
using JetBrains.Annotations;
using RobloxCloudApi.ApiTypes.Abstractions;
using RobloxCloudApi.ErrorHandling;
using RobloxCloudApi.Exceptions;
using RobloxCloudApi.Helpers;

namespace RobloxCloudApi;

[PublicAPI]
public class RobloxApiClient : IRobloxApiClient
{
    private readonly HttpClient _httpClient;

    private RobloxApiClientSettings _robloxApiClientSettings { get; set; }
    public RobloxApiClient(RobloxApiClientSettings robloxApiClientSettings, HttpClient? httpClient = default)
    {
        _robloxApiClientSettings = robloxApiClientSettings;
        this._httpClient = httpClient ??
            new HttpClient(new SocketsHttpHandler() { PooledConnectionIdleTimeout = TimeSpan.FromMinutes(1) })
            {
                DefaultRequestHeaders = {{"x-api-key", _robloxApiClientSettings.ApiKey}},
            };
    }
    
    

    public async Task<TResponse?> SendRequest<TResponse>(IRequest<TResponse> request)
    {
        if (request is null)
            throw new ArgumentNullException(nameof(request));

        using var requestContent = request.GetHttpContent();

        for (int attempts=0;;attempts++)
        {
            using var httpRequest = new HttpRequestMessage(request.HttpMethod, request.GetRequestUri());
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
                throw new TimeoutException("Request timed out: ",  exception);
            }
            catch (Exception exception)
            {
                throw new RobloxApiException("Exception occurred during a request to Roblox API:", exception);
            }

            using (httpResponseMessage)
            {
                if (!httpResponseMessage.IsSuccessStatusCode)
                {
                    if (httpResponseMessage.StatusCode == HttpStatusCode.TooManyRequests && attempts <=_robloxApiClientSettings.AmountOfRetries)
                    {
                        await Task.Delay(_robloxApiClientSettings.Timeout).ConfigureAwait(false);
                        continue;
                    }
                    throw new RobloxApiException(await ErrorParser.GetErrorString(httpResponseMessage));
                }
                
                return Serializer.SerializeFromString<TResponse>(
                    await httpResponseMessage.Content.ReadAsStringAsync(),
                    request.DeserializedPropertyPath);
            }
        }
    }
    
}

public class RobloxApiClientSettings
{
    public string ApiKey { get; }
    
    public TimeSpan Timeout { get; }
    
    public int AmountOfRetries { get; }

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
}