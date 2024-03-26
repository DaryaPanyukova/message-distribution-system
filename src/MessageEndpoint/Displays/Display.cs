using System.Drawing;
using MessageDistributionSystem.Messages;
using MessageDistributionSystem.Receiver;

namespace MessageDistributionSystem.MessageEndpoint.Displays;

public class Display : IReceiver
{
    private readonly DisplayDriver _driver;

    public Display(DisplayDriver driver, Color color)
    {
        _driver = driver;
        Color = color;
    }

    public Color Color { get; private set; }

    public void ReceiveMessage(Message message)
    {
        _driver.Clear();
        _driver.DisplayText(message.AsString(), Color);
    }
}