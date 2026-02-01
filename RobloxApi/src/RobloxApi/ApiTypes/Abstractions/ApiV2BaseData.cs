using System.Text.Json.Serialization;
using RobloxApi.Helpers.JsonConverters.RequestV2Helpers;

namespace RobloxApi.ApiTypes.Abstractions;

public abstract class ApiV2BaseData : IApiData
{
    [JsonPropertyName("path")]
    public string? RequestPath { get; set; }

    [JsonPropertyName("user")] 
    [JsonConverter(typeof(UserApiPathConverter))]
    public long? UserId { get; set; }
}