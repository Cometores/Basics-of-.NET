namespace Rename.UserInterface;

public abstract class Tree
{
    /// <summary>
    /// Displays the directory structure starting from the given path.
    /// </summary>
    /// <param name="path">The root directory path to start displaying the tree.</param>
    /// <param name="recursive">Boolean flag to indicate if the tree should be displayed recursively.</param>
    /// <param name="indent">Optional parameter for indentation in the tree structure. Default is an empty string.</param>
    public static void Display(string path, bool recursive, string indent = "")
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
                Display(directory, true, indent + "│   ");
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