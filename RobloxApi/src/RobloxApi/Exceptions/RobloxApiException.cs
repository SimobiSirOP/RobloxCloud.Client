namespace RobloxApi.Exceptions;

public class RobloxApiException : Exception
{
    public RobloxApiException() { }
    
    public RobloxApiException(string message) : base(message) { }
    
    public RobloxApiException(string message, Exception inner) : base(message, inner) { }
}