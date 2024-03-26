using MessageDistributionSystem.Messages;
using MessageDistributionSystem.Receiver;

namespace MessageDistributionSystem.Topics;

public class Topic
{
    public Topic(string name, IReceiver addressee)
    {
        Name = name;
        Addressee = addressee;
    }

    public string Name { get; private set; }
    public IReceiver Addressee { get; private set; }

    public void SendMessage(Message message) => Addressee.ReceiveMessage(message);
}