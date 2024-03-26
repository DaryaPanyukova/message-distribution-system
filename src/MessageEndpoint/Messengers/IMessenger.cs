using MessageDistributionSystem.Messages;

namespace MessageDistributionSystem.MessageEndpoint.Messengers;

public interface IMessenger
{
    public void ReceiveMessage(Message message);
}