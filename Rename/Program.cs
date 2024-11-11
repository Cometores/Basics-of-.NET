using Rename.Formatters;

namespace Rename;

public static class Program
{
    private static void Main()
    {
        UserInterface ui = new UserInterface();
        
        string path = ui.GetFolderPath();
        if (!Directory.Exists(path))
        {
            ui.DisplayMessage("The specified path does not exist.");
            return;
        }
        string formatType = ui.GetFormatType();
        bool recursive = ui.GetRecursiveOption();

        IFormatter formatter = formatType switch
        {
            UserInterface.CAMEL_CASE => new CamelCaseFormatter(),
            UserInterface.SNAKE_CASE => new SnakeCaseFormatter(),
            _ => throw new ArgumentException("Unknown formatting type.")
        };

        Renamer.RenameFilesAndFolders(path, formatter, recursive);
        ui.DisplayMessage("The renaming is complete.\n");

        ui.DisplayTree(path, recursive);
    }
}