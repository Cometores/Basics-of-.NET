using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Snake;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private DispatcherTimer gameTickTimer = new();

    private const int SnakeSquareSize = 20;
    private const int SnakeStartLength = 3;
    private const int SnakeStartSpeed = 400;
    private const int SnakeSpeedThreshold = 100;

    private SnakeDirection snakeDirection = SnakeDirection.Right;
    private List<SnakePart> snakeParts = new();
    private int snakeLength;
    private SolidColorBrush snakeBodyBrush = Brushes.Green;
    private SolidColorBrush snakeHeadBrush = Brushes.YellowGreen;

    public enum SnakeDirection
    {
        Left,
        Right,
        Up,
        Down
    };

    public MainWindow()
    {
        InitializeComponent();
        gameTickTimer.Tick += GameTickTimer_Tick;
    }

    private void GameTickTimer_Tick(object? sender, EventArgs e)
    {
        MoveSnake();
    }

    private void Window_ContentRendered(object? sender, EventArgs e)
    {
        DrawGameArea();
        StartNewGame();
    }

    private void StartNewGame()
    {
        snakeLength = SnakeStartLength;
        snakeDirection = SnakeDirection.Right;
        snakeParts.Add(new SnakePart() { Position = new Point(SnakeSquareSize * 5, SnakeSquareSize * 5) });
        gameTickTimer.Interval = TimeSpan.FromMilliseconds(SnakeStartSpeed);

        // Draw the snake  
        DrawSnake();

        // Go!          
        gameTickTimer.IsEnabled = true;
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

    private void DrawSnake()
    {
        foreach (SnakePart snakePart in snakeParts)
        {
            if (snakePart.UiElement == null)
            {
                snakePart.UiElement = new Rectangle()
                {
                    Width = SnakeSquareSize,
                    Height = SnakeSquareSize,
                    Fill = (snakePart.IsHead ? snakeHeadBrush : snakeBodyBrush)
                };
                GameArea.Children.Add(snakePart.UiElement);
                Canvas.SetTop(snakePart.UiElement, snakePart.Position.Y);
                Canvas.SetLeft(snakePart.UiElement, snakePart.Position.X);
            }
        }
    }

    private void MoveSnake()
    {
        // Remove the last part of the snake, in preparation of the new part added below  
        while (snakeParts.Count >= snakeLength)
        {
            GameArea.Children.Remove(snakeParts[0].UiElement);
            snakeParts.RemoveAt(0);
        }

        // Next up, we'll add a new element to the snake, which will be the (new) head  
        // Therefore, we mark all existing parts as non-head (body) elements and then  
        // we make sure that they use the body brush  
        foreach (SnakePart snakePart in snakeParts)
        {
            (snakePart.UiElement as Rectangle).Fill = snakeBodyBrush;
            snakePart.IsHead = false;
        }

        // Determine in which direction to expand the snake, based on the current direction  
        SnakePart snakeHead = snakeParts[snakeParts.Count - 1];
        double nextX = snakeHead.Position.X;
        double nextY = snakeHead.Position.Y;
        switch (snakeDirection)
        {
            case SnakeDirection.Left:
                nextX -= SnakeSquareSize;
                break;
            case SnakeDirection.Right:
                nextX += SnakeSquareSize;
                break;
            case SnakeDirection.Up:
                nextY -= SnakeSquareSize;
                break;
            case SnakeDirection.Down:
                nextY += SnakeSquareSize;
                break;
        }

        // Now add the new head part to our list of snake parts...  
        snakeParts.Add(new SnakePart()
        {
            Position = new Point(nextX, nextY),
            IsHead = true
        });
        //... and then have it drawn!  
        DrawSnake();
        // We'll get to this later...  
        //DoCollisionCheck();          
    }
}