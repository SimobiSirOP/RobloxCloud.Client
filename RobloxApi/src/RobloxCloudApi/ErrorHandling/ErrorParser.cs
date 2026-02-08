using System.Text;
using System.Text.Json.Serialization;
using RobloxCloudApi.ApiTypes.RequestHelpers;
using RobloxCloudApi.Helpers;

namespace RobloxCloudApi.ErrorHandling;

public static class ErrorParser
{
    public static async Task<string> GetErrorString(HttpResponseMessage response)
    {
        var error = Serializer.SerializeFromString<RobloxApiError>(await response.Content.ReadAsStringAsync());

        if (error.ErrorCode == null)
            return await GetErrorStringFromArray(response);

        return await GetBasicErrorString(response) + $"Error {error.ErrorCode}: {error.ErrorMessage}" ;

    }

    private static async Task<string> GetErrorStringFromArray(HttpResponseMessage response)
    {
        var errorMessage = Serializer.SerializeFromString<ErrorResponseArray>(await response.Content.ReadAsStringAsync());
        if (errorMessage == null)
            return await GetBasicErrorString(response);
        
        StringBuilder newErrorString = new(await GetBasicErrorString(response));
        foreach (var error in errorMessage.List)
            newErrorString.AppendLine($"Error {error.ErrorCode}: {error.ErrorMessage}");
        return newErrorString.ToString();
    }

    private static async Task<string> GetBasicErrorString(HttpResponseMessage response)
    {
        return $"{response.StatusCode}: {response.ReasonPhrase}\n";
    }
    
    private class ErrorResponseArray : ListResponseBase<RobloxApiError>
    {
        [JsonPropertyName("errors")]
        public override RobloxApiError[]? List { get; set; }
    }
}

public record struct RobloxApiError
{
    [JsonPropertyName("code")]
    public long? ErrorCode { get; set; }
    [JsonPropertyName("message")]
    public string? ErrorMessage { get; set; }
}

