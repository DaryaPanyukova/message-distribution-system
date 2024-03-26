using System.Drawing;

namespace MessageDistributionSystem.MessageEndpoint.Displays;

public interface IDisplayDriver
{
    void Clear();

    void DisplayText(string text, Color color);
}