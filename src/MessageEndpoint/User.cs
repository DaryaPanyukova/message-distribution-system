using MessageDistributionSystem.Exceptions;
using MessageDistributionSystem.Messages;
using MessageDistributionSystem.Receiver;

namespace MessageDistributionSystem.MessageEndpoint;

public class User : IReceiver
{
    public IList<StatusMessage> Messages { get; private set; } = new List<StatusMessage>();

    public void ReceiveMessage(Message message)
    {
        Messages.Add(new StatusMessage(message));
    }

    public void MarkMessageRead(int messageId)
    {
        foreach (StatusMessage message in Messages)
        {
            if (message.Message.Id == messageId)
            {
                message.MarkRead();
                return;
            }
        }

        throw new NoneExistentIdException();
    }

    public bool IsMessageRead(int messageId)
    {
        foreach (StatusMessage message in Messages)
        {
            if (message.Message.Id == messageId)
            {
                return message.IsRead;
            }
        }

        throw new NoneExistentIdException();
    }
}