using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
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
    private Random rnd = new();

    private const int SnakeSquareSize = 20;
    private const int SnakeStartLength = 3;
    private const int SnakeStartSpeed = 400;
    private const int SnakeSpeedThreshold = 100;

    private SnakeDirection _snakeDirection = SnakeDirection.Right;
    private List<SnakePart> _snakeParts = new();
    private int _snakeLength;
    private readonly SolidColorBrush snakeBodyBrush = Brushes.Green;
    private readonly SolidColorBrush snakeHeadBrush = Brushes.YellowGreen;

    private UIElement _snakeFood = null;
    private readonly SolidColorBrush foodBrush = Brushes.Red;

    private int currentScore = 0;

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
        // Remove potential dead snake parts and leftover food...
        foreach(SnakePart snakeBodyPart in _snakeParts)
        {
            if(snakeBodyPart.UiElement != null)
                GameArea.Children.Remove(snakeBodyPart.UiElement);
        }
        _snakeParts.Clear();
        
        if(_snakeFood != null)
            GameArea.Children.Remove(_snakeFood);

        // Reset stuff
        currentScore = 0;
        _snakeLength = SnakeStartLength;
        _snakeDirection = SnakeDirection.Right;
        _snakeParts.Add(new SnakePart() { Position = new Point(SnakeSquareSize * 5, SnakeSquareSize * 5) });
        gameTickTimer.Interval = TimeSpan.FromMilliseconds(SnakeStartSpeed);

        // Draw the snake again and some new food...
        DrawSnake();
        DrawSnakeFood();

        // Update status
        UpdateGameStatus();

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
        foreach (SnakePart snakePart in _snakeParts)
        {
            if (snakePart.UiElement == null)
            {
                snakePart.UiElement = new Rectangle
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

    private void DrawSnakeFood()
    {
        Point foodPosition = GetNextFoodPosition();
        _snakeFood = new Ellipse()
        {
            Width = SnakeSquareSize,
            Height = SnakeSquareSize,
            Fill = foodBrush
        };
        GameArea.Children.Add(_snakeFood);
        Canvas.SetTop(_snakeFood, foodPosition.Y);
        Canvas.SetLeft(_snakeFood, foodPosition.X);
    }

    private void MoveSnake()
    {
        // Remove the last part of the snake, in preparation of the new part added below
        while (_snakeParts.Count >= _snakeLength)
        {
            GameArea.Children.Remove(_snakeParts[0].UiElement);
            _snakeParts.RemoveAt(0);
        }

        // Next up, we'll add a new element to the snake, which will be the (new) head
        // Therefore, we mark all existing parts as non-head (body) elements and then
        // we make sure that they use the body brush
        foreach (SnakePart snakePart in _snakeParts)
        {
            (snakePart.UiElement as Rectangle).Fill = snakeBodyBrush;
            snakePart.IsHead = false;
        }

        // Determine in which direction to expand the snake, based on the current direction
        SnakePart snakeHead = _snakeParts[^1];
        double nextX = snakeHead.Position.X;
        double nextY = snakeHead.Position.Y;
        switch (_snakeDirection)
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
        _snakeParts.Add(new SnakePart
        {
            Position = new Point(nextX, nextY),
            IsHead = true
        });
        
        DrawSnake();
        DoCollisionCheck();
    }

    private Point GetNextFoodPosition()
    {
        int maxX = (int)(GameArea.ActualWidth / SnakeSquareSize);
        int maxY = (int)(GameArea.ActualHeight / SnakeSquareSize);
        int foodX = rnd.Next(0, maxX) * SnakeSquareSize;
        int foodY = rnd.Next(0, maxY) * SnakeSquareSize;

        foreach (SnakePart snakePart in _snakeParts)
        {
            if ((snakePart.Position.X == foodX) && (snakePart.Position.Y == foodY))
                return GetNextFoodPosition();
        }

        return new Point(foodX, foodY);
    }

    private void Window_KeyUp(object sender, KeyEventArgs e)
    {
        SnakeDirection originalSnakeDirection = _snakeDirection;
        switch (e.Key)
        {
            case Key.Up:
                if (_snakeDirection != SnakeDirection.Down)
                    _snakeDirection = SnakeDirection.Up;
                break;
            case Key.Down:
                if (_snakeDirection != SnakeDirection.Up)
                    _snakeDirection = SnakeDirection.Down;
                break;
            case Key.Left:
                if (_snakeDirection != SnakeDirection.Right)
                    _snakeDirection = SnakeDirection.Left;
                break;
            case Key.Right:
                if (_snakeDirection != SnakeDirection.Left)
                    _snakeDirection = SnakeDirection.Right;
                break;
            case Key.Space:
                StartNewGame();
                break;
        }

        if (_snakeDirection != originalSnakeDirection)
            MoveSnake();
    }

    private void DoCollisionCheck()
    {
        SnakePart snakeHead = _snakeParts[^1];

        if ((snakeHead.Position.X == Canvas.GetLeft(_snakeFood)) && (snakeHead.Position.Y == Canvas.GetTop(_snakeFood)))
        {
            EatSnakeFood();
            return;
        }

        if ((snakeHead.Position.Y < 0) || (snakeHead.Position.Y >= GameArea.ActualHeight) ||
            (snakeHead.Position.X < 0) || (snakeHead.Position.X >= GameArea.ActualWidth))
        {
            EndGame();
        }

        foreach (SnakePart snakeBodyPart in _snakeParts.Take(_snakeParts.Count - 1))
        {
            if ((snakeHead.Position.X == snakeBodyPart.Position.X) &&
                (snakeHead.Position.Y == snakeBodyPart.Position.Y))
                EndGame();
        }
    }

    private void EatSnakeFood()
    {
        _snakeLength++;
        currentScore++;
        int timerInterval = 
            Math.Max(SnakeSpeedThreshold, (int)gameTickTimer.Interval.TotalMilliseconds - (currentScore * 2));
        gameTickTimer.Interval = TimeSpan.FromMilliseconds(timerInterval);
        GameArea.Children.Remove(_snakeFood);
        DrawSnakeFood();
        UpdateGameStatus();
    }
    
    private void UpdateGameStatus()
    {
        Title = "SnakeWPF - Score: " + currentScore + " - Game speed: " + gameTickTimer.Interval.TotalMilliseconds;
    }
    
    private void EndGame()
    {
        gameTickTimer.IsEnabled = false;
        MessageBox.Show("Oooops, you died!\n\nTo start a new game, just press the Space bar...", "SnakeWPF");
    }
}