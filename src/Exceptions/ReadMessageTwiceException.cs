namespace MessageDistributionSystem.Exceptions;

public class ReadMessageTwiceException : Exception
{
    public ReadMessageTwiceException()
    {
    }

    public ReadMessageTwiceException(string message)
        : base(message)
    {
    }

    public ReadMessageTwiceException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}
