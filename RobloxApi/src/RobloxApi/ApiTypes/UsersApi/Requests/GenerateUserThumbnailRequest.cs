using System.Text.Json.Serialization;
using RobloxApi.ApiTypes.UsersApi.ResponseData;

namespace RobloxApi.ApiTypes.UsersApi;

public class GenerateUserThumbnailRequest : RequestBaseV2<ThumbnailData>
{
    
    public override HttpMethod HttpMethod { get; } = HttpMethod.Get;
    public override string RequestPath => $"https://apis.roblox.com/cloud/v2/users/{UserId}:generateThumbnail";
    
    public long? UserId { get; set; }
    
    /// <summary>
    /// Currently supported values: 48, 50, 60, 75, 100, 110, 150, 180, 352, 420, 720. Default is 420.
    /// <see href="https://create.roblox.com/docs/cloud/reference/features/users#Cloud_GenerateUserThumbnail"/>
    /// </summary>
    [QueryParameter("size")]
    public int? Size { get; set; }
    
    /// <summary>
    /// Supported formats: PNG or JPG. Default: PNG
    /// <see href="https://create.roblox.com/docs/cloud/reference/features/users#Cloud_GenerateUserThumbnail"/>
    /// </summary>
    [QueryParameter("format")]
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public ThumbnailData.ThumbnailFormat? Format { get; set; }
    
    /// <summary>
    /// Supported shapes: ROUND, SQUARE. Default: ROUND
    /// <see href="https://create.roblox.com/docs/cloud/reference/features/users#Cloud_GenerateUserThumbnail"/>
    /// </summary>
    [QueryParameter("shape")]
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public ThumbnailData.ThumbnailShape? Shape { get; set; }
}
