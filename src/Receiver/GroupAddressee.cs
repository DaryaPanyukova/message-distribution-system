using System.Collections.ObjectModel;
using MessageDistributionSystem.Messages;

namespace MessageDistributionSystem.Receiver;

public class GroupAddressee : IReceiver
{
    private readonly ReadOnlyCollection<IReceiver> _addressees;

    public GroupAddressee(params IReceiver[] receivers)
    {
        _addressees = new List<IReceiver>(receivers).AsReadOnly();
    }

    public void ReceiveMessage(Message message)
    {
        foreach (IReceiver receiver in _addressees)
        {
            receiver.ReceiveMessage(message);
        }
    }
}