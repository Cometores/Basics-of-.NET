namespace FileDownload;

public class ConsoleWriter : IWriter
{
    private static object _lock = new();

    public static void Write(string message)
    {
        lock (_lock)
        {
            Console.WriteLine(message);
        }
    }
    
    public static void Write(string message, int leftPos, int topPos, ConsoleColor backgroundColor = ConsoleColor.Black)
    {
        lock (_lock)
        {
            int leftPosBefore = Console.CursorLeft;
            int topPosBefore = Console.CursorTop;
            ConsoleColor backgroundColorBefore = Console.BackgroundColor;
            
            // Set values for message
            Console.SetCursorPosition(leftPos, topPos);
            Console.BackgroundColor = backgroundColor;
            
            Console.Write(message);

            // Reset values
            Console.SetCursorPosition(leftPosBefore, topPosBefore);
            Console.BackgroundColor = backgroundColorBefore;
        }
    }
}