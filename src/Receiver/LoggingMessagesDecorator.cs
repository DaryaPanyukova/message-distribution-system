using MessageDistributionSystem.Loggers;
using MessageDistributionSystem.Messages;

namespace MessageDistributionSystem.Receiver;

public class LoggingMessagesDecorator : IReceiver
{
    private readonly ILogger _logger;

    private readonly IReceiver _receiver;
    public LoggingMessagesDecorator(ILogger logger, IReceiver receiver)
    {
        _logger = logger;
        _receiver = receiver;
    }

    public void ReceiveMessage(Message message)
    {
        _logger.Log(message);
        _receiver.ReceiveMessage(message);
    }
}