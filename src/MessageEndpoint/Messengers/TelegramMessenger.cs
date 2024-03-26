namespace MessageDistributionSystem.MessageEndpoint.Messengers;

public class TelegramMessenger : ITelegramMessenger
{
    public void PostNewMessage(string type, string text)
    {
        Console.WriteLine(type + " : " + text);
    }
}