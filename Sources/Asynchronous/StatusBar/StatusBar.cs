namespace StatusBar;

/// <summary>
/// Represents a status bar for displaying the progress.
/// </summary>
public class StatusBar
{
    public CancellationToken CancellationToken;

    private ConsoleColor Color { get; }
    private readonly int _consoleTopPos;
    
    private static readonly string[] WheelSymbols = { "―", "\\", "|", "/" };

    private readonly int _tasksAmount;
    private int _tasksFinished;

    private readonly object _lockCounting = new();
    private CancellationTokenSource _cancellationTokenSource;

    /// <summary>
    /// Creates status bar
    /// </summary>
    /// <param name="tasksAmount">Represents status bar length</param>
    /// <param name="color">Bar's color</param>
    public StatusBar(int tasksAmount, ConsoleColor color = ConsoleColor.Cyan)
    {
        _tasksFinished = 0;
        _tasksAmount = tasksAmount;
        Color = color;
        _consoleTopPos = Console.CursorTop;
        
        // Initial status bar
        ConsoleMT.WriteLine($"[{new string('-', tasksAmount)}]");
        
        // Start loading wheel
        _cancellationTokenSource = new CancellationTokenSource();
        CancellationToken = _cancellationTokenSource.Token;
        Task.Factory.StartNew(DrawLoadingWheel, CancellationToken);
    }

    /// <summary>
    /// Increments the tasks finished count and updates the status bar progress.
    /// </summary>
    /// <remarks>
    /// This method is used to simulate the completion of a task and update the visual progress
    /// on the status bar.
    /// </remarks>
    public void Add()
    {
        lock (_lockCounting)
        {
            _tasksFinished += 1;
            PrintBar(_tasksFinished);
            if (_tasksFinished == _tasksAmount)
                _cancellationTokenSource.Cancel();
        }
    }
    
    private void PrintBar(int leftPosition)
    {
        ConsoleMT.WriteAtPos("_", leftPosition, _consoleTopPos, Color);
    }
    
    private void DrawLoadingWheel()
    {
        int i = 0;
        while (!CancellationToken.IsCancellationRequested)
        {
            ConsoleMT.WriteAtPos(WheelSymbols[i], _tasksAmount + 2, _consoleTopPos);
            
            Task.Delay(200).Wait();
            i = (i + 1) % WheelSymbols.Length;
        }

        ConsoleMT.WriteAtPos(" ", _tasksAmount + 2, _consoleTopPos);
    }
}