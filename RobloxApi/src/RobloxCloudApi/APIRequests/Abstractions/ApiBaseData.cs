using System.Text.Json.Serialization;

namespace RobloxCloudApi.RobloxCloudApi.APIRequests.Abstractions;

/// <summary>
/// Class for V2 API Data without handled path databinding
/// </summary>
public abstract class ApiDataBase
{
    [JsonPropertyName("path")] public string? RequestPath { get; set; }
}