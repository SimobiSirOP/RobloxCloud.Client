using System.Text;
using System.Text.Json.Serialization;
using RobloxCloudApi.APIRequests.Abstractions;
using RobloxCloudApi.Helpers;

namespace RobloxCloudApi.APIRequests.RequestHelpers;

public abstract class RequestBase<TResponse> : IRequest<TResponse>
{
    [JsonIgnore]
    public abstract HttpMethod HttpMethod { get; }
    
    [JsonPropertyName("path")]
    public abstract string RequestPath { get; }

    public HttpContent? GetHttpContent()
    {
        if (HttpMethod == HttpMethod.Get)
            return null;
        return new StringContent(Serializer.SerializeToString(this), Encoding.UTF8, "application/json");
    }

    public string GetRequestUri()
    {
        var properties = GetType().GetProperties()
            .Where(parameter => Attribute.IsDefined(parameter, typeof(QueryParameter)));

        StringBuilder queryAdditionString =  new StringBuilder();
        foreach (var parameter in properties)
        {
            var rawValue = parameter.GetValue(this);
            object paramValue;
            if (rawValue.GetType().IsEnum)
                paramValue = nameof(rawValue);
            else paramValue = rawValue;
                
            
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