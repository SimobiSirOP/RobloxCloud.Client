using RobloxCloudApi.APIRequests.Abstractions;
using RobloxCloudApi.APIRequests.RequestHelpers;
using RobloxCloudApi.Helpers;

namespace RobloxCloudApi.APITypes.Operations;

public abstract class BaseOperation : ApiDataBase, IOperation
{
    public abstract bool IsCompleted();
    
    public static OperationOptions OperationOptions { private get; set; } = new OperationOptions(TimeSpan.FromSeconds(15), 5);
    
    public async Task<IOperation> WaitForCompletionAsync(IRobloxApiClient client, string domain = "https://apis.roblox.com/cloud/v2")
    {
        if (this.IsCompleted()) return this;

        
        // Preparing operation request
        if (!domain.EndsWith("/")) domain += "/";
        
        string operationPath;
        if (RequestPath != null && RequestPath.StartsWith(domain))
            operationPath = RequestPath;
        else operationPath = domain + RequestPath;

        var operationRequest = new OperationRequest<IOperation>(operationPath);
        
        for (int attempt = 0; attempt < OperationOptions.NumberOfAttemptsBeforeFailing; attempt++ )
        {
            IOperation? result = null;
            result = await client.ThrowIfNull().SendRequest(operationRequest);
            if (this.IsCompleted())
                return result!;
            await Task.Delay(OperationOptions.TimeBetweenAttempts);
        }
        return null!;
    }
}