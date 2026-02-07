using RobloxCloudApi.ApiTypes.DataStoresApi.Requests;
using RobloxCloudApi.ApiTypes.DataStoresApi.Types;
using RobloxCloudApi.Helpers;

namespace RobloxCloudApi;

public static partial class RobloxApiMethods
{
    /// <summary>
    /// Use this method to get all DataStores in Universe
    /// </summary>
    /// <param name="client">The instance of <see cref="IRobloxApiClient"/></param>
    /// 
    /// <param name="universeId">A roblox universe ID</param>
    /// <param name="pageToken">A pageToken of next list page</param>
    /// <param name="maxPageSize">Size of a page, a number between 1 and 100</param>
    /// <param name="showDeleted">Should it return deleted DataStores or not</param>
    /// <returns>An instance of <see cref="DataStoreList"/></returns>
    public static async Task<DataStoreList> GetDataStores(
        this IRobloxApiClient client,
        long universeId,
        string? pageToken = null,
        int maxPageSize = 10,
        bool showDeleted = false
        )
    {
        return (await client.ThrowIfNull().SendRequest(
            new ListDataStoresRequest()
            {
                PageToken = pageToken,
                MaxPageSize = maxPageSize,
                ShowDeleted = showDeleted,
                UniverseId = universeId
            }))!;
    }

    /// <summary>
    /// Use this method to delete DataStore. It sets state of DataStore to "DELETED" to delete DataStore
    /// </summary>
    /// <param name="client">An instance of <see cref="IRobloxApiClient"/></param>
    /// <param name="universeId">A roblox universe ID</param>
    /// <param name="dataStoreId">A DataStore Id (name)</param>
    /// <returns></returns>
    public static async Task<DataStoreInfo> DeleteDataStore(
        this IRobloxApiClient client,
        long universeId,
        string? dataStoreId)
    {
        return (await client.ThrowIfNull().SendRequest(
            new DeleteDataStoreRequest()
            {
                UniverseId = universeId,
                DataStoreId = dataStoreId
            }
        ))!;
    }

    public static async Task<DataStoreInfo> CreateDataStore(
        this IRobloxApiClient client,
        long universeId,
        string? newDataStoreId)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Use this method to get a list of entries in a DataStore
    /// </summary>
    /// <param name="client">An instance of <see cref="IRobloxApiClient"/></param>
    /// <param name="universeId">A roblox universe ID</param>
    /// <param name="dataStoreId">A DataStore Id (name)</param>
    /// <param name="scopeId">A scope of DataStore if needed</param>
    /// <param name="pageToken">A pageToken of next ListPage</param>
    /// <param name="maxPageSize">A number of items to return, a value between 1 and 100</param>
    /// <param name="showDeleted">Should is also return deleted entries or not</param>
    /// <returns>An instance of <see cref="DataStoreEntryList"/></returns>
    public static async Task<DataStoreEntryList> GetDataStoreEntries(
        this IRobloxApiClient client,
        long universeId,
        string dataStoreId,
        string? scopeId = null,
        string? pageToken = null,
        int maxPageSize = 10,
        bool showDeleted = false)
    {
        return (await client.ThrowIfNull().SendRequest(new ListDataStoreEntriesRequest()
        {
            UniverseId = universeId,
            DataStoreId = dataStoreId,
            ScopeId = scopeId,
            PageToken = pageToken,
            MaxPageSize = maxPageSize,
            ShowDeleted = showDeleted
        }))!;
    }

    /// <summary>
    /// Use this method to get entry revisions
    /// </summary>
    /// <param name="client">An instance of <see cref="IRobloxApiClient"/></param>
    /// <param name="universeId">A roblox universe ID</param>
    /// <param name="dataStoreId">A DataStore Id (name)</param>
    /// <param name="scopeId">A scope of DataStore if needed</param>
    /// <param name="entryId">A id of DataStore entry</param>
    /// <param name="pageToken">A pageToken of next ListPage</param>
    /// <param name="maxPageSize">A number of items to return, a value between 1 and 100</param>
    /// <param name="showDeleted">Should is also return deleted entries or not</param>
    /// <returns>An instance of <see cref="DataStoreEntryList"/></returns>
    public static async Task<DataStoreEntryList> GetDataStoreEntryRevisions(
        this IRobloxApiClient client,
        long universeId,
        string dataStoreId,
        string entryId,
        string? scopeId = null,
        string? pageToken = null,
        int maxPageSize = 10,
        bool showDeleted = false
    )
    {
        return (await client.ThrowIfNull().SendRequest(new GetDataStoreEntryRevisionsRequest()
        {
            DataStoreId = dataStoreId,
            EntryId = entryId,
            ScopeId = scopeId,
            PageToken = pageToken,
            MaxPageSize = maxPageSize,
            ShowDeleted = showDeleted,
            UniverseId = universeId
        }))!;
    }

    /// <summary>
    /// Use this method to get information about an entry
    /// </summary>
    /// <param name="client">An instance of <see cref="IRobloxApiClient"/></param>
    /// <param name="universeId">A roblox universe ID</param>
    /// <param name="dataStoreId">A DataStore ID (name)</param>
    /// <param name="scopeId">A scope of DataStore if needed</param>
    /// <param name="entryId">An ID of DataStore entry</param>
    /// <returns>An instance of <see cref="DataStoreEntry"/></returns>
    public static async Task<DataStoreEntry> GetDataStoreEntry(
        this IRobloxApiClient client,
        long universeId,
        string dataStoreId,
        string entryId,
        string? scopeId = null)
    {
        return (await client.ThrowIfNull().SendRequest(new GetDataStoreEntryRequest()
        {
            DataStoreId = dataStoreId,
            UniverseId = universeId,
            EntryId = entryId,
            ScopeId = scopeId
        }))!;
    }

    /// <summary>
    /// Use this method to update a DataStore Entry
    /// </summary>
    /// <param name="client">An instance of <see cref="IRobloxApiClient"/></param>
    /// <param name="universeId">A roblox universe ID</param>
    /// <param name="dataStoreId">A DataStore ID (name)</param>
    /// <param name="entryId">An id of DataStore entry</param>
    /// <param name="scopeId">A scope of DataStore if needed</param>
    /// <param name="value">New value of dataStoreEntry (Serialized JSON)</param>
    /// <param name="dataStoreUsersIds">A list of User id's affected by dataStore</param>
    /// <param name="attributes">A DataStore attributes</param>
    /// <param name="eTag">Etag of a DataStore</param>
    /// <param name="allowMissing">Should it create a entry if it doesn't exist or not</param>
    /// <returns>An updated instance of <see cref="DataStoreEntry"/></returns>
    public static async Task<DataStoreEntry> UpdateDataStoreEntry(
        this IRobloxApiClient client,
        long universeId,
        string dataStoreId,
        string entryId,
        string? scopeId,
        string value,
        long[] dataStoreUsersIds,
        object[]? attributes = null,
        string? eTag = "",
        bool allowMissing = false
    )
    {
        return (await client.ThrowIfNull().SendRequest(new UpdateDataStoreEntryRequest()
        {
            UniverseId = universeId,
            DataStoreId = dataStoreId,
            EntryId = entryId,
            ScopeId = scopeId,
            Value = value,
            Attributes = attributes,
            Users = dataStoreUsersIds,
            ETag = eTag,
            AllowMissing = allowMissing
        }))!;
    }


    /// <summary>
    /// Use this method to update a DataStore Entry
    /// </summary>
    /// <param name="client">An instance of <see cref="IRobloxApiClient"/></param>
    /// <param name="universeId">A roblox universe ID</param>
    /// <param name="dataStoreId">A DataStore ID (name)</param>
    /// <param name="entryId">An id of DataStore entry</param>
    /// <param name="value">New value of dataStoreEntry (Serialized JSON)</param>
    /// <param name="dataStoreUsersIds">A list of User id's affected by dataStore</param>
    /// <param name="attributes">A DataStore attributes</param>
    /// <param name="eTag">Etag of a DataStore</param>
    /// <param name="allowMissing">Should it create a entry if it doesn't exist or not</param>
    /// <returns>An updated instance of <see cref="DataStoreEntry"/></returns>
    public static async Task<DataStoreEntry> UpdateDataStoreEntry(
        this IRobloxApiClient client,
        long universeId,
        string dataStoreId,
        string entryId,
        string value,
        long[] dataStoreUsersIds,
        object[]? attributes = null,
        string? eTag = "",
        bool allowMissing = false
    )
    {
        return (await client.UpdateDataStoreEntry(universeId, dataStoreId, entryId, null, value, dataStoreUsersIds,
            attributes, eTag));
    }

    /// <summary>
    /// Use this method to delete a DataStore Entry. It sets an Entry State to "DELETED"
    /// </summary>
    /// <param name="client">An instance of <see cref="IRobloxApiClient"/></param>
    /// <param name="universeId">A roblox universe ID</param>
    /// <param name="dataStoreId">A DataStore ID (name)</param>
    /// <param name="scopeId">A scope of DataStore if needed</param>
    /// <param name="entryId">An ID of DataStore entry</param>
    /// <returns>An instance of <see cref="DataStoreEntry"/></returns>
    public static async Task<DataStoreEntry> DeleteDataStoreEntry(
        this IRobloxApiClient client,
        long universeId,
        string dataStoreId,
        string entryId,
        string? scopeId = null)
    {
        return (await client.ThrowIfNull().SendRequest(new DeleteDataStoreEntryRequest()
        {
            UniverseId = universeId,
            DataStoreId = dataStoreId,
            EntryId = entryId,
            ScopeId = scopeId
        }))!;
    }


    /// <summary>
    /// Use this method to create a new a DataStore Entry
    /// </summary>
    /// <param name="client">An instance of <see cref="IRobloxApiClient"/></param>
    /// <param name="universeId">A roblox universe ID</param>
    /// <param name="dataStoreId">A DataStore ID (name)</param>
    /// <param name="entryId">An id of DataStore entry</param>
    /// <param name="scopeId">A scope of DataStore if needed</param>
    /// <param name="value">New value of dataStoreEntry (Serialized JSON)</param>
    /// <param name="dataStoreUsersIds">A list of User id's affected by dataStore</param>
    /// <param name="attributes">A DataStore attributes</param>
    /// <param name="eTag">Etag of a DataStore</param>
    /// <returns>An instance of new <see cref="DataStoreEntry"/></returns>
    public static async Task<DataStoreEntry> CreateDataStoreEntry(
        this IRobloxApiClient client,
        long universeId,
        string dataStoreId,
        string entryId,
        string? scopeId,
        string value,
        long[] dataStoreUsersIds,
        object[]? attributes = null,
        string? eTag = ""
    )
    {
        return (await client.ThrowIfNull().SendRequest(new CreateDataStoreEntryRequest()
        {
            UniverseId = universeId,
            DataStoreId = dataStoreId,
            EntryId = entryId,
            ScopeId = scopeId,
            Value = value,
            Attributes = attributes,
            Users = dataStoreUsersIds,
            ETag = eTag
        }))!;
    }

    /// <summary>
    /// Use this method to create a new a DataStore Entry
    /// </summary>
    /// <param name="client">An instance of <see cref="IRobloxApiClient"/></param>
    /// <param name="universeId">A roblox universe ID</param>
    /// <param name="dataStoreId">A DataStore ID (name)</param>
    /// <param name="entryId">An id of DataStore entry</param>
    /// <param name="value">New value of dataStoreEntry (Serialized JSON)</param>
    /// <param name="dataStoreUsersIds">A list of User id's affected by dataStore</param>
    /// <param name="attributes">A DataStore attributes</param>
    /// <param name="eTag">Etag of a DataStore</param>
    /// <returns>An instance of new <see cref="DataStoreEntry"/></returns>
    public static async Task<DataStoreEntry> CreateDataStoreEntry(
        this IRobloxApiClient client,
        long universeId,
        string dataStoreId,
        string entryId,
        string value,
        long[] dataStoreUsersIds,
        object[]? attributes = null,
        string? eTag = ""
    )
    {
        return (await client.CreateDataStoreEntry(universeId, dataStoreId, entryId, null, value, dataStoreUsersIds,
            attributes, eTag));
    }

    /// <summary>
    /// Use this method to create a new a DataStore Entry
    /// </summary>
    /// <param name="client">An instance of <see cref="IRobloxApiClient"/></param>
    /// <param name="universeId">A roblox universe ID</param>
    /// <param name="dataStoreId">A DataStore ID (name)</param>
    /// <param name="entryId">An id of DataStore entry</param>
    /// <param name="scopeId">A scope of DataStore if needed</param>
    /// <param name="amount">New value of dataStoreEntry (Serialized JSON)</param>
    /// <param name="dataStoreUsersIds">A list of User id's affected by dataStore</param>
    /// <param name="attributes">A DataStore attributes</param>
    /// <returns>An updated instance of <see cref="DataStoreEntry"/></returns>
    public static async Task<DataStoreEntry> IncrementDataStoreEntry(
        this IRobloxApiClient client,
        long universeId,
        string dataStoreId,
        string entryId,
        string? scopeId,
        int amount,
        long[] dataStoreUsersIds,
        object[]? attributes = null
    )
    {
        return (await client.ThrowIfNull().SendRequest(new IncrementDataStoreEntryRequest()
        {
            UniverseId = universeId,
            DataStoreId = dataStoreId,
            EntryId = entryId,
            ScopeId = scopeId,
            Amount = amount,
            Attributes = attributes,
            Users = dataStoreUsersIds,
        }))!;
    }

    /// <summary>
    /// Use this method to create a new a DataStore Entry
    /// </summary>
    /// <param name="client">An instance of <see cref="IRobloxApiClient"/></param>
    /// <param name="universeId">A roblox universe ID</param>
    /// <param name="dataStoreId">A DataStore ID (name)</param>
    /// <param name="entryId">An id of DataStore entry</param>
    /// <param name="amount">New value of dataStoreEntry (Serialized JSON)</param>
    /// <param name="dataStoreUsersIds">A list of User id's affected by dataStore</param>
    /// <param name="attributes">A DataStore attributes</param>
    /// <returns>An updated instance of <see cref="DataStoreEntry"/></returns>
    public static async Task<DataStoreEntry> IncrementDataStoreEntry(
        this IRobloxApiClient client,
        long universeId,
        string dataStoreId,
        string entryId,
        int amount,
        long[] dataStoreUsersIds,
        object[]? attributes = null
    )
    {
        return (await client.IncrementDataStoreEntry(universeId, dataStoreId, entryId, null, amount, dataStoreUsersIds))!;
    }
}