using System.Text;
using System.Text.Json.Serialization;
using RobloxApi.ApiTypes.Abstractions;
using RobloxApi.Helpers;

namespace RobloxApi.ApiTypes;

public abstract class RequestBase<TResponse> : IRequest<TResponse>
{
    [JsonIgnore] 
    public abstract HttpMethod HttpMethod { get; }
    
    [JsonIgnore]
    public abstract string RequestPath { get; }

    [JsonIgnore] public virtual string DeserializedPropertyPath { get; } = "";
    
    public virtual HttpContent? GetHttpContent()
    {
        return new StringContent(Serializer.SerializeToString(this), Encoding.UTF8, "application/json");
    }

    public virtual string GetRequestUri()
    {
        return RequestPath;
    }
}