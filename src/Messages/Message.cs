namespace MessageDistributionSystem.Messages;

public record Message(int Id, string Title, string Body, int ImportanceLevel)
{
    public string AsString() => Title + "\n" + Body;
}