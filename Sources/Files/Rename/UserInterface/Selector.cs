namespace Rename.UserInterface;

/// <summary>
/// The Selector class provides static methods for interacting with the user interface to get input and make selections.
/// </summary>
public abstract class Selector
{
    /// <summary>
    /// Prompts the user with a message to ask for a Yes or No input.
    /// </summary>
    /// <param name="prompt">The message displayed to the user.</param>
    /// <returns>True if the user inputs 'y', False if the user inputs 'n'.</returns>
    public static bool GetYesNoInput(string prompt)
    {
        var initialCursorPos = Console.GetCursorPosition();
        Console.WriteLine($"{prompt} ( y / n )");
        
        while (true)
        {
            var key = Console.ReadKey(true).Key;
        
            switch (key)
            {
                case ConsoleKey.Y:
                    Console.SetCursorPosition(initialCursorPos.Left, initialCursorPos.Top);
                    Console.Write($"{prompt} (");
                    Highlight(" y ");
                    Console.WriteLine("/ n )");
                    return true;
                case ConsoleKey.N:
                    Console.SetCursorPosition(initialCursorPos.Left, initialCursorPos.Top);
                    Console.Write($"{prompt} ( y /");
                    Highlight(" n ");
                    Console.WriteLine(")");
                    return false;
            }
        }
    }

    private static void Highlight(string text)
    {
        Console.BackgroundColor = ConsoleColor.Gray;
        Console.ForegroundColor = ConsoleColor.Black;
        Console.Write(text);
        Console.ResetColor();
    }


    /// <summary>
    /// Prompts the user to enter a folder path.
    /// </summary>
    /// <returns>The folder path entered by the user after trimming any leading or trailing white spaces.</returns>
    public static string GetFolderPath()
    {
        Console.WriteLine("Enter the path to the folder:");
        string path = Console.ReadLine() ?? throw new InvalidOperationException("Path cannot be null.");
        if (!Directory.Exists(path))
        {
            throw new DirectoryNotFoundException("The specified folder does not exist.");
        }
        
        return path.Trim();
    }
}