namespace RobloxCloudApi.RobloxCloudApi.APITypes.Operations;

public class OperationOptions
{
    public OperationOptions(TimeSpan timeBetweenAttempts, int numberOfAttemptsBeforeFailing)
    {
        TimeBetweenAttempts = timeBetweenAttempts;
        NumberOfAttemptsBeforeFailing = numberOfAttemptsBeforeFailing;
    }

    public TimeSpan TimeBetweenAttempts { get; private set; }

    public int NumberOfAttemptsBeforeFailing { get; private set; }
}