using MessageDistributionSystem.Messages;
using MessageDistributionSystem.Receiver;

namespace MessageDistributionSystem.MessageEndpoint.Messengers;

public class MessengerReceiver : IReceiver
{
    private IMessenger _messenger;

    public MessengerReceiver(IMessenger messenger)
    {
        _messenger = messenger;
    }

    public void ReceiveMessage(Message message)
    {
        _messenger.ReceiveMessage(message);
    }
}