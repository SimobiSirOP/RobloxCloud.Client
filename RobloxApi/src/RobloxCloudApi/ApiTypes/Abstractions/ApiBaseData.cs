using System.Text.Json.Serialization;
using RobloxCloudApi.Helpers.JsonConverters.RequestV2Helpers;

namespace RobloxCloudApi.ApiTypes.Abstractions;

public abstract class ApiDataBase
{
    [JsonPropertyName("path")]
    public string? RequestPath { get; set; }
}