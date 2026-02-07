using System.Text.Json.Serialization;
using RobloxCloudApi.Helpers.JsonConverters;

namespace RobloxCloudApi.ApiTypes.MiscApi.Types;

public class ApiKeyInfo
{
    [JsonPropertyName("Name")]
    public string? Name { get; set; }
    
    [JsonPropertyName("authorizedUserId")]
    public long?  AuthorizedUserId { get; set; }
    
    [JsonPropertyName("scopes")]
    public ApiKeyScopeInfo[]? Description { get; set; }
    
    [JsonPropertyName("enabled")]
    public bool? Enabled { get; set; }
    
    [JsonPropertyName("expired")]
    public bool? Expired { get; set; }
    
    [JsonPropertyName("expirationTimeUtc")]
    [JsonConverter(typeof(DateTimeIso8601Converter))]
    public DateTime? ExpirationTimeUtc { get; set; }
}