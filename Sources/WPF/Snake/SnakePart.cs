using System.Windows;

namespace Snake;

public class SnakePart
{
    public UIElement UiElement { get; set; }

    public Point Position { get; set; }

    public bool IsHead { get; set; }
}