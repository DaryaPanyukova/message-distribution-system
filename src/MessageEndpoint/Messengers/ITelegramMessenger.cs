namespace MessageDistributionSystem.MessageEndpoint.Messengers;

public interface ITelegramMessenger
{
    void PostNewMessage(string type, string text);
}