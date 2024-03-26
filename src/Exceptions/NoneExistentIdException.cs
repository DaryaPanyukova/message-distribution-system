namespace MessageDistributionSystem.Exceptions;

public class NoneExistentIdException : Exception
{
    public NoneExistentIdException()
    {
    }

    public NoneExistentIdException(string message)
        : base(message)
    {
    }

    public NoneExistentIdException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}
