using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Snake;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private const int SnakeSquareSize = 20;

    public MainWindow()
    {
        InitializeComponent();
    }

    private void Window_ContentRendered(object? sender, EventArgs e)
    {
        DrawGameArea();
        ;
    }

    private void DrawGameArea()
    {
        bool doneDrawingBackground = false;
        int nextX = 0, nextY = 0;
        int rowCounter = 0;
        bool nextIsOdd = false;

        while (doneDrawingBackground == false)
        {
            Rectangle rect = new Rectangle
            {
                Width = SnakeSquareSize,
                Height = SnakeSquareSize,
                Fill = nextIsOdd ? Brushes.White : Brushes.Black
            };
            GameArea.Children.Add(rect);
            Canvas.SetTop(rect, nextY);
            Canvas.SetLeft(rect, nextX);

            nextIsOdd = !nextIsOdd;
            nextX += SnakeSquareSize;
            if (nextX >= GameArea.ActualWidth)
            {
                nextX = 0;
                nextY += SnakeSquareSize;
                rowCounter++;
                nextIsOdd = (rowCounter % 2 != 0);
            }

            if (nextY >= GameArea.ActualHeight)
                doneDrawingBackground = true;
        }
    }
}