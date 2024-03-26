using MessageDistributionSystem.Messages;

namespace MessageDistributionSystem.Loggers;

public interface ILogger
{
    void Log(Message message);
}