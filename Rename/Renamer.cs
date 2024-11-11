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