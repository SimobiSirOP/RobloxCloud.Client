using System.Net;
using JetBrains.Annotations;
using RobloxCloudApi.ApiTypes.Abstractions;
using RobloxCloudApi.Exceptions;
using RobloxCloudApi.Helpers;

namespace RobloxCloudApi;

[PublicAPI]
public class RobloxApiClient
{
    private readonly HttpClient _httpClient;
    
    public RobloxApiClient(string apiKey, HttpClient? httpClient = default)
    {
        this._httpClient = httpClient ??
            new HttpClient(new SocketsHttpHandler() { PooledConnectionIdleTimeout = TimeSpan.FromMinutes(1) })
            {
                DefaultRequestHeaders = {{"x-api-key", apiKey}}
            };
    }
    
    private static readonly int AmountOfRetries = 5;
    private static readonly int DelayBetweenRetries = 5; // in seconds 
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
                    if (httpResponseMessage.StatusCode == HttpStatusCode.TooManyRequests && attempts <= AmountOfRetries)
                    {
                        await Task.Delay(DelayBetweenRetries * 1000);
                        continue;
                    }
                    throw new RobloxApiException("Request error: " + httpResponseMessage.StatusCode + " " +
                                                 httpResponseMessage.ReasonPhrase);
                }
                
                return Serializer.SerializeFromString<TResponse>(
                    await httpResponseMessage.Content.ReadAsStringAsync(),
                    request.DeserializedPropertyPath);
            }
        }
    }
    
    
}