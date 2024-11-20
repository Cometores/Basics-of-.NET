using Rename.Formatters;
using Rename.UserInterface;

namespace Rename;

public static class Program
{
    private static readonly Dictionary<string, IFormatter> Formatters = new()
    {
        { "CamelCase", new CamelCaseFormatter() },
        { "snake_case", new SnakeCaseFormatter() }
    };

    private static void Main()
    {
        string path = Selector.GetFolderPath();
        if (!Directory.Exists(path))
        {
            Console.WriteLine("The specified path does not exist.");
            return;
        }
        
        string formatType = Table.SelectFormatter(Formatters.Keys.ToList());
        IFormatter formatter = Formatters[formatType];
        
        bool recursive = Selector.GetYesNoInput("Rename recursively?");

        Renamer.RenameFilesAndFolders(path, formatter, recursive);
        Console.WriteLine("The renaming is complete.\n");

        Tree.Display(path, recursive);
        
        /*TODO:
           - Rename: Объединить табличный интерфейс с Пингом для выбора
           - Починить ошибку с повторным переименованием */
    }
}