using MessageDistributionSystem.Messages;

namespace MessageDistributionSystem.Receiver;

public interface IReceiver
{
    void ReceiveMessage(Message message);
}