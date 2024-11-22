// ReSharper disable InconsistentNaming

namespace DirectoryAnalyzer.UserInterface;

public static class IO
{
    public static void WriteLoadSuccess(string directory)
    {
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.Write("Directory ");
        Console.ResetColor();

        Console.Write(directory);
        
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.WriteLine(" loaded successfully.");
        Console.ResetColor();
    }

    public static void WriteLoadFailed(string directory)
    {
        Console.ForegroundColor = ConsoleColor.DarkRed;
        Console.Write("Error: The directory ");
        Console.ResetColor();

        Console.Write(directory);

        Console.ForegroundColor = ConsoleColor.DarkRed;
        Console.WriteLine(" does not exist. Please try again.\n");
        Console.ResetColor();
    }

    public static string ReadDirectory()
    {
        Console.Write("Input your ");
        
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write("directory ");
        Console.ResetColor();
        
        Console.Write("(or type '");

        Console.ForegroundColor = ConsoleColor.Red;
        Console.Write("exit");
        Console.ResetColor();

        Console.Write("' to quit): ");

        return Console.ReadLine() ?? string.Empty;
    }

    public static void WriteGreeting()
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("Welcome to the Directory Analyzer!\n");
        Console.ResetColor();
    }

    public static void WriteChoosingPrompt()
    {
        Console.WriteLine("\nChoose an action:");
        Console.WriteLine("1. Show all file extensions");
        Console.WriteLine("2. Show files for a specific extension");
        Console.WriteLine("3. Show disk usage report");
        Console.WriteLine("4. Change directory");
        Console.WriteLine("5. Exit");
        Console.Write("Enter your choice: ");
    }
}