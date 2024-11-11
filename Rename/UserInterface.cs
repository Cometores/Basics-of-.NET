namespace Rename;

/// <summary>
/// Represents a user interface for interacting with the user, displaying messages, and handling user inputs for a renaming application.
/// </summary>
public class UserInterface
{
    public const string CAMEL_CASE = "CamelCase";
    public const string SNAKE_CASE = "snake_case";

    public string GetFolderPath()
    {
        Console.WriteLine("Enter the path to the folder:");
        return Console.ReadLine() ?? throw new InvalidOperationException("Path cannot be null.");
    }

    public string GetFormatType()
    {
        Console.WriteLine($"Select the type of formatting ({CAMEL_CASE} or {SNAKE_CASE}):");
        return Console.ReadLine() ?? throw new InvalidOperationException("Format type cannot be null.");
    }

    public bool GetRecursiveOption()
    {
        Console.WriteLine("Rename recursively? (yes/no):");
        return Console.ReadLine()?.ToLower() == "yes";
    }

    public void DisplayMessage(string message)
    {
        Console.WriteLine(message);
    }

    /// <summary>
    /// Displays the directory structure starting from the given path.
    /// </summary>
    /// <param name="path">The root directory path to start displaying the tree.</param>
    /// <param name="recursive">Boolean flag to indicate if the tree should be displayed recursively.</param>
    /// <param name="indent">Optional parameter for indentation in the tree structure. Default is an empty string.</param>
    public void DisplayTree(string path, bool recursive, string indent = "")
    {
        // Display the root path, Happens only once
        if (string.IsNullOrEmpty(indent))
        {
            Console.WriteLine(path);
        }

        var directories = Directory.GetDirectories(path);
        var files = Directory.GetFiles(path);

        // Display directories with proper indentation
        foreach (var directory in directories)
        {
            Console.WriteLine($"{indent}├── {Path.GetFileName(directory)}");
            if (recursive)
            {
                DisplayTree(directory, true, indent + "│   ");
            }
        }

        // Display files with proper indentation
        for (int i = 0; i < files.Length; i++)
        {
            string prefix = i == files.Length - 1 
                ? "└──" 
                : "├──";
            Console.WriteLine($"{indent}{prefix} {Path.GetFileName(files[i])}");
        }
    }
}