namespace RobloxCloudApi.RobloxCloudApi.APITypes.Operations;

public interface IOperation
{
    public bool IsCompleted();

    public Task<T> WaitForCompletionAsync<T>(IRobloxApiClient client, string domain) where T : class, IOperation;
}