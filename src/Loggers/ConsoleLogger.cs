using MessageDistributionSystem.Messages;

namespace MessageDistributionSystem.Loggers;

public class ConsoleLogger : ILogger
{
    public void Log(Message message)
    {
        Console.WriteLine("id: " + message.Id);
        Console.WriteLine("title: " + message.Title);
        Console.WriteLine("body: " + message.Body);
        Console.WriteLine("Importance level: " + message.ImportanceLevel);
    }
}