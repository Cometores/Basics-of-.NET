namespace FileDownload;

public class StatusBar
{
    private readonly int _numberOfFiles;
    private readonly int _topPosition;
    private int _filesDownloaded;

    private readonly object _lockConsole = new();
    private readonly object _lockFiles = new();
    private Task _loadingTask;
    private CancellationTokenSource _cancellationTokenSource;
    private CancellationToken _cancellationToken;

    private static readonly string[] LoadingSymbols =
    {
        "―",
        "\\",
        "|",
        "/"
    };
    private static readonly int LoadingSymbolsLength = LoadingSymbols.Length;

    public StatusBar(int numberOfFiles)
    {
        _filesDownloaded = 0;
        _numberOfFiles = numberOfFiles;
        _topPosition = Console.CursorTop;
        Console.WriteLine($"[{new string('-', numberOfFiles)}]");

        _cancellationTokenSource = new();
        _cancellationToken = _cancellationTokenSource.Token;
        _loadingTask = new Task(PrintLoading, _cancellationToken);
        _loadingTask.Start();
    }

    public void Add()
    {
        lock (_lockFiles)
        {
            PrintBar(++_filesDownloaded);
            if(_filesDownloaded == _numberOfFiles)
                _cancellationTokenSource.Cancel();
        }
    }

    [Obsolete]
    public void PrintFullBar()
    {
        for (int i = 0; i < _numberOfFiles; i++)
        {
            System.Threading.Thread.Sleep(1000);
            lock (_lockConsole)
            {
                var leftPosBefore = Console.CursorLeft;
                var ct = Console.CursorTop;
                var backgroundColor = Console.BackgroundColor;

                Console.SetCursorPosition(i + 1, _topPosition);
                Console.BackgroundColor = ConsoleColor.Cyan;
                Console.Write(" ");

                Console.BackgroundColor = backgroundColor;
                Console.SetCursorPosition(leftPosBefore, ct);
            }
        }
    }

    private void PrintBar(int leftPosition)
    {
        lock (_lockConsole)
        {
            var leftPositionBefore = Console.CursorLeft;
            var topPositionBefore = Console.CursorTop;
            var backgroundBefore = Console.BackgroundColor;

            Console.SetCursorPosition(leftPosition, _topPosition);
            Console.BackgroundColor = ConsoleColor.Green;
            Console.Write(" ");

            Console.BackgroundColor = backgroundBefore;
            Console.SetCursorPosition(leftPositionBefore, topPositionBefore);
        }
    }

    private void PrintLoading()
    {
        int i = 0;
        while (true)
        {  
            System.Threading.Thread.Sleep(200);
            lock (_lockConsole)
            {
                var leftPositionBefore = Console.CursorLeft;
                var topPositionBefore = Console.CursorTop;

                Console.SetCursorPosition(_numberOfFiles + 2, _topPosition);
                
                if (_cancellationToken.IsCancellationRequested)
                {
                    Console.Write(" ");
                    Console.SetCursorPosition(leftPositionBefore, topPositionBefore);
                    _cancellationToken.ThrowIfCancellationRequested();
                
                }
                Console.Write(LoadingSymbols[i]);

                Console.SetCursorPosition(leftPositionBefore, topPositionBefore);
            }

            i = (i + 1) % LoadingSymbolsLength;
        }
    }
}