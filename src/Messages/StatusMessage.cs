using MessageDistributionSystem.Exceptions;

namespace MessageDistributionSystem.Messages;

public class StatusMessage
{
    public StatusMessage(Message message, bool isRead = false)
    {
        Message = message;
        IsRead = isRead;
    }

    public StatusMessage(int id, string title, string body, int importanceLevel, bool isRead = false)
    {
        Message = new Message(id, title, body, importanceLevel);
        IsRead = isRead;
    }

    public Message Message { get; private set; }
    public bool IsRead { get; private set; }

    public void MarkRead()
    {
        if (IsRead)
        {
            throw new ReadMessageTwiceException();
        }

        IsRead = true;
    }
}