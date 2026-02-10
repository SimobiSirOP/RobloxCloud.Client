using System.Text.Json.Serialization;

namespace RobloxCloudApi.APIRequests.Abstractions;

public abstract class ApiDataBase
{
    [JsonPropertyName("path")] public string? RequestPath { get; set; }
}