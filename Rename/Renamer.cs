using Rename.Formatters;

namespace Rename;

/// <summary>
/// Renames files and folders based on a specified format and displays the structure after renaming.
/// </summary>
static class Renamer
{
    /// <summary>
    /// Renames files and folders based on a specified format and displays the structure after renaming.
    /// </summary>
    /// <param name="path">Path to the folder where files and folders will be renamed.</param>
    /// <param name="formatter">The formatter to apply the renaming format.</param>
    /// <param name="recursive">True if renaming should be done recursively, false otherwise.</param>
    public static void RenameFilesAndFolders(string path, IFormatter formatter, bool recursive)
    {
        RenameItems(path, formatter, recursive, Directory.GetDirectories, Directory.Move);
        RenameItems(path, formatter, recursive, Directory.GetFiles, File.Move);
    }

    /// <summary>
    /// Executes the "tree" command to display the file and folder structure after potential renaming within the specified path.
    /// </summary>
    /// <param name="path">The path to the folder whose structure is to be displayed.</param>
    /// <param name="recursive">A boolean indicating whether the command should run recursively within the folder.</param>
    public static void DisplayTree(string path, bool recursive, string indent = "")
    {
        // Вывод пути к корневой директории
        if (string.IsNullOrEmpty(indent))
        {
            Console.WriteLine(path);
        }
        
        var directories = Directory.GetDirectories(path);
        var files = Directory.GetFiles(path);

        // Вывод файлов и папок с нужными отступами
        foreach (var directory in directories)
        {
            Console.WriteLine($"{indent}├── {Path.GetFileName(directory)}");
            if (recursive)
            {
                DisplayTree(directory, true, indent + "│   ");
            }
        }

        for (int i = 0; i < files.Length; i++)
        {
            string prefix = i == files.Length - 1 
                ? "└──" 
                : "├──";
            Console.WriteLine($"{indent}{prefix} {Path.GetFileName(files[i])}");
        }
    }
    
    private static void RenameItems(string path, IFormatter formatter, bool recursive, 
        Func<string, string[]> getItems, Action<string, string> moveItem)
    {
        foreach (var item in getItems(path))
        {
            string newName = formatter.Format(Path.GetFileName(item));
            string newPath = Path.Combine(Path.GetDirectoryName(item), newName);
            
            if (item != newPath)
                moveItem(item, newPath);

            if (recursive && Directory.Exists(newPath))
            {
                RenameItems(newPath, formatter, recursive, getItems, moveItem);
            }
        }
    }
}