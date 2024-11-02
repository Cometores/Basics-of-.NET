using System.Diagnostics;
using Rename.Formatters;

namespace Rename;

/// <summary>
/// Renames files and folders based on a specified format.
/// Displayes the structure after renaming.
/// </summary>
static class Renamer
{
    /// <summary>
    /// Renames files and folders based on a specified format.
    /// Displaying the structure after renaming.
    /// </summary>
    /// <param name="path">The path to the folder where files and folders will be renamed.</param>
    /// <param name="formatter">The formatter to apply the renaming format.</param>
    /// <param name="recursive">True if renaming should be done recursively, false otherwise.</param>
    public static void RenameFilesAndFolders(string path, Formatter formatter, bool recursive)
    {
        RenameItems(path, formatter, recursive, Directory.GetDirectories, Directory.Move);
        RenameItems(path, formatter, recursive, Directory.GetFiles, File.Move);
    }

    /// <summary>
    /// Executes the "tree" command to display the file and folder structure after potential renaming within the specified path.
    /// </summary>
    /// <param name="path">The path to the folder whose structure is to be displayed.</param>
    /// <param name="recursive">A boolean indicating whether the command should run recursively within the folder.</param>
    public static void DisplayTreeCommand(string path, bool recursive)
    {
        string command = recursive ? "/c tree /f" : "/c tree";

        var processInfo = new ProcessStartInfo("cmd", $"{command} \"{path}\"")
        {
            RedirectStandardOutput = true,
            UseShellExecute = false,
            CreateNoWindow = true
        };

        using var process = Process.Start(processInfo);
        
        if (process != null)
        {
            string output = process.StandardOutput.ReadToEnd();
            var filteredOutput = string.Join("\n", output.Split('\n')
                .SkipWhile(line => line.StartsWith("Folder PATH listing") || line.StartsWith("Volume")));
            
            Console.WriteLine("Result of file and folder structure after renaming:\n");
            Console.WriteLine(filteredOutput);
        }
    }
    
    private static void RenameItems(string path, Formatter formatter, bool recursive, 
        Func<string, string[]> getItems, Action<string, string> moveItem)
    {
        foreach (var item in getItems(path))
        {
            string newName = formatter.ApplyFormat(Path.GetFileName(item));
            string newPath = Path.Combine(Path.GetDirectoryName(item), newName);
            
            if (path != newPath)
                moveItem(item, newPath);

            if (recursive && Directory.Exists(newPath))
            {
                RenameItems(newPath, formatter, recursive, getItems, moveItem);
            }
        }
    }
}