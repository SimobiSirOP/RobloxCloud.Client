using System.Text.Json.Serialization;
using RobloxApi.ApiTypes.Abstractions;

namespace RobloxApi.ApiTypes.UsersApi.ResponseData;

public class ThumbnailData : ApiV2BaseData
{
    public enum ThumbnailShape
    {
        ROUND,
        SQUARE
    }
    public enum ThumbnailFormat
    {
        PNG,
        JPG
    }
    
    [JsonPropertyName("done")]
    public bool? IsDone { get; set; }
    
    /// <summary>
    /// A dictionary usually consisting of "@type" and "imageUri"
    /// </summary>
    [JsonPropertyName("response")]
    public Dictionary<string, object>? ResponseObject { get; set; }
}

