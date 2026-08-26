namespace RobloxCloudApi.ErrorHandling.Exceptions;

public class RobloxAuthException : Exception
{
    public RobloxAuthException()
    {
    }

    public RobloxAuthException(string message) : base(message)
    {
    }

    public RobloxAuthException(string message, Exception inner) : base(message, inner)
    {
    }
}