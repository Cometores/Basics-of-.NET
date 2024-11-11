using Rename.Formatters;

namespace Rename;

class Program
{
    private const string CAMEL_CASE = "CamelCase";
    private const string SNAKE_CASE = "snake_case";
    
    static void Main()
    {
        Console.WriteLine("Enter the path to the folder:");
        string path = Console.ReadLine() ?? throw new InvalidOperationException();

        Console.WriteLine($"Select the type of formatting ({CAMEL_CASE} or {SNAKE_CASE}):");
        string formatType = Console.ReadLine() ?? throw new InvalidOperationException();

        Console.WriteLine("Rename recursively? (yes/no):");
        bool recursive = Console.ReadLine()?.ToLower() == "yes";

        if (!Directory.Exists(path))
        {
            Console.WriteLine("The specified path does not exist.");
            return;
        }
        
        IFormatter formatter = formatType switch
        {
            CAMEL_CASE => new CamelCaseFormatter(),
            SNAKE_CASE => new SnakeCaseFormatter(),
            _ => throw new ArgumentException("Unknown formatting type.")
        };

        Renamer.RenameFilesAndFolders(path, formatter, recursive);
        Console.WriteLine("The renaming is complete.\n");

        // Call the “tree” command to display the structure
        Renamer.DisplayTree(path, recursive);
    }
}