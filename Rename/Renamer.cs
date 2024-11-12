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
    
    private static void RenameItems(string path, IFormatter formatter, bool recursive, 
        Func<string, string[]> getItems, Action<string, string> moveItem)
    {
        foreach (var oldPath in getItems(path))
        {
            string newPath = GetNewPath(formatter, oldPath);

            if (oldPath != newPath)
                moveItem(oldPath, newPath);

            if (recursive && Directory.Exists(newPath))
                RenameFilesAndFolders(newPath, formatter, recursive);
        }
    }

    private static string GetNewPath(IFormatter formatter, string oldPath)
    {
        string directory = Path.GetDirectoryName(oldPath)!;
        string extension = Path.GetExtension(oldPath);
        string originalName = Path.GetFileNameWithoutExtension(oldPath);
        string formattedName = formatter.Format(originalName);
        string newPath = Path.Combine(directory, formattedName + extension);
        
        // Collision check
        int suffix = 1;
        while ((File.Exists(newPath) && Path.HasExtension(oldPath)) || 
               (Directory.Exists(newPath) && !Path.HasExtension(oldPath)))
        {
            newPath = Path.Combine(directory, $"{formattedName}_{suffix}{extension}");
            suffix++;
        }

        return newPath;
    }
}