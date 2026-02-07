using System.Text.Json.Serialization;
using JetBrains.Annotations;
using RobloxCloudApi.ApiTypes.Abstractions;

namespace RobloxCloudApi.ApiTypes.UsersApi.ResponseData;

[PublicAPI]
public class ThumbnailData : ApiDataBase
{
    public enum ThumbnailShape
    {
        ROUND,
        SQUARE,
    }
    public enum ThumbnailFormat
    {
        PNG,
        JPG,
    }
    
    // 48, 50, 60, 75, 100, 110, 150, 180, 352, 420, 720. Default is 420. 
    public enum ThumbnailSize
    {
        Size48,
        Size50,
        Size60,
        Size75,
        Size100,
        Size110,
        Size150,
        Size180,
        Size352,
        Size420,
        Size720,
    }
    
    [JsonPropertyName("done")]
    public bool? IsDone { get; set; }
    
    /// <summary>
    /// A dictionary usually consisting of "@type" and "imageUri"
    /// </summary>
    [JsonPropertyName("response")]
    public Dictionary<string, object>? ResponseObject { get; set; }

    
}

