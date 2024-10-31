using System.Diagnostics;
using Rename.Formatters;
using Formatter = Rename.Formatters.Formatter;

namespace Rename;

class Program
{
    static void Main()
    {
        Console.WriteLine("Введите путь к папке:");
        string path = Console.ReadLine();

        Console.WriteLine("Выберите тип форматирования (CamelCase или SnakeCase):");
        string formatType = Console.ReadLine();

        Console.WriteLine("Переименовывать рекурсивно? (да/нет):");
        bool recursive = Console.ReadLine()?.ToLower() == "да";

        if (Directory.Exists(path))
        {
            RenameFilesAndFolders(path, formatType, recursive);
            Console.WriteLine("Переименование завершено.");

            // Вызов команды "tree" для отображения структуры
            DisplayTreeCommand(path, recursive);
        }
        else
        {
            Console.WriteLine("Указанный путь не существует.");
        }
    }

    static void RenameFilesAndFolders(string path, string formatType, bool recursive)
    {
        IFormatStrategy formatter = formatType switch
        {
            "CamelCase" => new CamelCaseFormatter(),
            "SnakeCase" => new SnakeCaseFormatter(),
            _ => throw new ArgumentException("Неизвестный тип форматирования")
        };

        var renamer = new Formatter(formatter);

        foreach (var directory in Directory.GetDirectories(path))
        {
            string newDirectoryName = renamer.ApplyFormat(Path.GetFileName(directory));
            string newDirectoryPath = Path.Combine(Path.GetDirectoryName(directory), newDirectoryName);
            Directory.Move(directory, newDirectoryPath);

            if (recursive)
            {
                RenameFilesAndFolders(newDirectoryPath, formatType, recursive);
            }
        }

        foreach (var file in Directory.GetFiles(path))
        {
            string newFileName = renamer.ApplyFormat(Path.GetFileName(file));
            string newFilePath = Path.Combine(Path.GetDirectoryName(file), newFileName);
            File.Move(file, newFilePath);
        }
    }

    static void DisplayTreeCommand(string path, bool recursive)
    {
        string command = recursive ? "/c tree /f" : "/c tree";

        var processInfo = new ProcessStartInfo("cmd", $"{command} \"{path}\"")
        {
            RedirectStandardOutput = true,
            UseShellExecute = false,
            CreateNoWindow = true
        };

        using (var process = Process.Start(processInfo))
        {
            string output = process.StandardOutput.ReadToEnd();
            var filteredOutput = string.Join("\n", output.Split('\n')
                .SkipWhile(line => line.StartsWith("Folder PATH listing") || line.StartsWith("Volume")));
            Console.WriteLine("Результат структуры файлов и папок после переименования:\n");
            Console.WriteLine(filteredOutput);
        }
    }
}