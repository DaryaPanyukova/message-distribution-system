using System.Drawing;

namespace MessageDistributionSystem.MessageEndpoint.Displays;

public class DisplayDriver : IDisplayDriver
{
    public void Clear()
    {
        Console.Clear();
    }

    public void DisplayText(string text, Color color)
    {
        Console.WriteLine(Crayon.Output.Rgb(color.R, color.G, color.B).Text(text));
    }
}