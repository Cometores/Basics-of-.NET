namespace FileDownload;

public class StatusBar
{
    private readonly int _numberOfFiles;
    private readonly int _topPosition;
    private int _filesDownloaded;

    // private readonly object _lockConsole = new();
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
        ConsoleWriter.Write($"[{new string('-', numberOfFiles)}]");
    
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
            ConsoleWriter.Write("_", i + 1, _topPosition, ConsoleColor.Cyan);
            System.Threading.Thread.Sleep(1000);
        }
    }

    private void PrintBar(int leftPosition)
    {
        ConsoleWriter.Write("_", leftPosition, _topPosition, ConsoleColor.Cyan);
    }
    
    private void PrintLoading()
    {
        int i = 0;
        while (true)
        {  
            if (_cancellationToken.IsCancellationRequested)
            {
                ConsoleWriter.Write(" ", _numberOfFiles + 2, _topPosition);
                _cancellationToken.ThrowIfCancellationRequested();
            }
            
            ConsoleWriter.Write(LoadingSymbols[i], _numberOfFiles + 2, _topPosition);
            System.Threading.Thread.Sleep(200);
           
            i = (i + 1) % LoadingSymbolsLength;
        }
    }
}