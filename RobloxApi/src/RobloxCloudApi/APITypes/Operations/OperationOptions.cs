namespace RobloxCloudApi.APITypes.Operations;

public class OperationOptions
{
    public TimeSpan TimeBetweenAttempts { get; private set; }
    
    public int NumberOfAttemptsBeforeFailing { get; private set; }

    public OperationOptions(TimeSpan timeBetweenAttempts, int numberOfAttemptsBeforeFailing)
    {
        TimeBetweenAttempts = timeBetweenAttempts;
        this.NumberOfAttemptsBeforeFailing = numberOfAttemptsBeforeFailing;
    }
}