namespace RobloxCloudApi.APITypes.RobloxGeneralTypes;

public struct RobloxDuration
{
    public string Duration  { get; set; }

    public RobloxDuration(double duration)
    {
        if (duration < -315576000000d ||  duration > 315576000000d)
        { throw new ArgumentOutOfRangeException(nameof(duration)); }

        Duration = duration.ToString() + "s";
    }

    public RobloxDuration(string durationStr)
    {
        if (!durationStr.EndsWith("s"))
            { throw new ArgumentException("Duration string must ends with 's'."); }

        if (double.TryParse(durationStr.Substring(0, durationStr.Length - 1), out _))
        {
            throw new ArgumentException("Duration is not a number."); 
        }
        
        Duration = durationStr;
    }
}