using System.Text;
using System.Text.Json.Serialization;
using RobloxCloudApi.Helpers;

namespace RobloxCloudApi.ApiTypes;

public abstract class RequestBaseV2<TResponse> : RequestBase<TResponse>
{
    [JsonIgnore]
    public abstract override HttpMethod HttpMethod { get; }
    
    [JsonPropertyName("path")]
    public abstract override string RequestPath { get; }

    [JsonIgnore] public override string DeserializedPropertyPath { get; } = "";

    public override HttpContent? GetHttpContent()
    {
        if (HttpMethod == HttpMethod.Get)
            return null;
        return new StringContent(Serializer.SerializeToString(this), Encoding.UTF8, "application/json");
    }

    public override string GetRequestUri()
    {
        var properties = GetType().GetProperties()
            .Where(parameter => Attribute.IsDefined(parameter, typeof(QueryParameter)));

        StringBuilder queryAdditionString =  new StringBuilder();
        foreach (var parameter in properties)
        {
            var paramValue = parameter.GetValue(this);

            QueryParameter queryParameter =
                (QueryParameter)Attribute.GetCustomAttribute(parameter, typeof(QueryParameter))!;
            
            var paramName = queryParameter.Name ?? parameter.Name;
            
            if (queryAdditionString.Length > 0)
                queryAdditionString.Append("&");
            
            if (paramValue != null)
                queryAdditionString.Append($"{paramName}={paramValue.ToString()}");
            else if (!queryParameter.IgnoreWhenNull)
                queryAdditionString.Append($"{paramName}");
        }
        
        if (queryAdditionString.Length > 0)
            return RequestPath + "?" + queryAdditionString.ToString();
        return RequestPath;
    }
}


[AttributeUsage(AttributeTargets.Property)]
public class QueryParameter : Attribute
{
    public string? Name { get; }
    
    public bool IgnoreWhenNull { get; }

    public QueryParameter(string? name = null, bool ignoreWhenNull = false)
    {
        Name = name;
        IgnoreWhenNull = ignoreWhenNull;
    }
}