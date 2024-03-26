using MessageDistributionSystem.Messages;

namespace MessageDistributionSystem.Receiver;

public class ImportanceLevelProxy : IReceiver
{
    private readonly LoggingMessagesDecorator _logger;
    private readonly int _importanceLevel;

    public ImportanceLevelProxy(LoggingMessagesDecorator logger, int importanceLevel)
    {
        _logger = logger;
        _importanceLevel = importanceLevel;
    }

    public void ReceiveMessage(Message message)
    {
        if (_importanceLevel >= message.ImportanceLevel)
        {
            _logger.ReceiveMessage(message);
        }
    }
}