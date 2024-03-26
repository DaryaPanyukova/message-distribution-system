using MessageDistributionSystem.Messages;

namespace MessageDistributionSystem.MessageEndpoint.Messengers;

public class TelegramMessengerAdapter : IMessenger
{
    private readonly ITelegramMessenger _messenger;

    public TelegramMessengerAdapter(ITelegramMessenger messenger)
    {
        _messenger = messenger;
    }

    public void ReceiveMessage(Message message)
    {
        _messenger.PostNewMessage("Notification", message.AsString());
    }
}