using System.Text.Json.Serialization;
using RobloxCloudApi.Helpers.JsonConverters.RequestV2Helpers;

namespace RobloxCloudApi.ApiTypes.Abstractions;

public abstract class ApiV2BaseData : IApiData
{
    [JsonPropertyName("path")]
    public string? RequestPath { get; set; }

    [JsonPropertyName("user")] 
    [JsonConverter(typeof(UserApiPathConverter))]
    public long? UserId { get; set; }
}