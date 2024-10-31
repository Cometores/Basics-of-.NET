namespace StatusBar;

/// <summary>
/// Represents a utility class for writing messages to the console in multithreaded programming.
/// </summary>
public class ConsoleMT
{
    private static object _lock = new();

    /// <summary>
    /// Writes the specified message to the console output.
    /// </summary>
    public static void WriteLine(string message)
    {
        lock (_lock)
        {
            Console.WriteLine(message);
        }
    }

    /// <summary>
    /// Writes a message to the console output at a specific position.
    /// </summary>
    public static void WriteAtPos(string message, int leftPos, int topPos, ConsoleColor backgroundColor = ConsoleColor.Black)
    {
        lock (_lock)
        {
            // Saving previous Console seetings
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