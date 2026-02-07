using System.Text.Json.Serialization;

namespace RobloxCloudApi.ApiTypes.MiscApi.Types;

public class ApiKeyScopeInfo
{
    [JsonPropertyName("name")]
    public string? Name { get; set; }
    
    [JsonPropertyName("operations")]
    public string[]?  Operations { get; set; }
    
    [JsonExtensionData]
    public Dictionary<string, object>? ExtensionData { get; set; }
}