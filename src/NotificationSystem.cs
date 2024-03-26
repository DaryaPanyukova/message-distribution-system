using MessageDistributionSystem.Messages;
using MessageDistributionSystem.Topics;

namespace MessageDistributionSystem;

public class NotificationSystem
{
    private List<Topic> _topics;

    public NotificationSystem(params Topic[] topics)
    {
        _topics = new List<Topic>(topics);
    }

    public void AddTopic(Topic topic)
    {
        _topics.Add(topic);
    }

    public void SendMessageToTopic(string topicName, Message message)
    {
        Topic? topic = _topics.FirstOrDefault(t => t.Name == topicName);
        topic?.SendMessage(message);
    }
}