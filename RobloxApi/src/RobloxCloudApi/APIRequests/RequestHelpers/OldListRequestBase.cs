namespace RobloxCloudApi.APIRequests.RequestHelpers;

/// <summary>
/// Used for v1 api lists
/// </summary>
public abstract class OldListRequestBase<T> : RequestBase<T>
{
    [QueryParameter("cursor",true)]
    public string? Cursor { get; set; }
    
    [QueryParameter("sortOrder",true)]
    public SortOrder? SortOrder { get; set; }
    
    [QueryParameter("limit",true)]
    public int? MaxPageSize { get; set; }
    
}

public enum SortOrder
{
    Asc,
    Desc
}