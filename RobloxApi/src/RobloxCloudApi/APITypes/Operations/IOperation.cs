namespace RobloxCloudApi.APITypes.Operations;

public interface IOperation
{
    public bool IsCompleted();
  
    public Task<IOperation> WaitForCompletionAsync(IRobloxApiClient client, string domain);
}