namespace DirectoryAnalyzer;

internal static class Program
{
    private static Analyzer.DirectoryAnalyzer? _directoryAnalyzer;

    private static void Main()
    {
        UserInterface.IO.WriteGreeting();

        while (true)
        {
            string directory = UserInterface.IO.ReadDirectory();

            if (string.Equals(directory, "exit", StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine("Goodbye!");
                return;
            }

            if (Directory.Exists(directory))
            {
                AnalyseForDir(directory);
            }
            else
            {
                UserInterface.IO.WriteLoadFailed(directory);
            }
        }
    }

    private static void AnalyseForDir(string directory)
    {
        _directoryAnalyzer = new Analyzer.DirectoryAnalyzer(directory);
        Console.Clear();
        UserInterface.IO.WriteLoadSuccess(directory);

        while (true)
        {
            UserInterface.IO.WriteChoosingPrompt();

            if (!int.TryParse(Console.ReadLine(), out var choice))
            {
                Console.WriteLine("Invalid input. Please enter a number.");
                continue;
            }

            try
            {
                if (ProcessCommand(choice)) return;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }

    private static bool ProcessCommand(int choice)
    {
        switch (choice)
        {
            case 1:
                ShowAllExtensions();
                break;
            case 2:
                ShowFilesForExtension();
                break;
            case 3:
                ShowDiskUsageReport();
                break;
            case 4:
                Console.WriteLine("Returning to directory selection...");
                return true;
            case 5:
                Console.WriteLine("Exiting...");
                Environment.Exit(0);
                break;
            default:
                Console.WriteLine("Invalid choice. Please try again.");
                break;
        }

        return false;
    }

    private static void ShowAllExtensions()
    {
        if (_directoryAnalyzer == null)
        {
            Console.WriteLine("Directory is not initialized.");
            return;
        }

        var extensions = _directoryAnalyzer.GetFileExtensions(recursive: true);
        if (!extensions.Any())
        {
            Console.WriteLine("No file extensions found in the directory.");
            return;
        }

        Console.WriteLine("Extensions in the directory:");
        foreach (var extension in extensions)
            Console.WriteLine($"- {extension}");
    }

    private static void ShowFilesForExtension()
    {
        if (_directoryAnalyzer == null)
        {
            Console.WriteLine("Directory is not initialized.");
            return;
        }

        Console.Write("Enter the extension (e.g., .txt): ");
        string extension = Console.ReadLine()?.ToLower() ?? string.Empty;

        if (string.IsNullOrWhiteSpace(extension))
        {
            Console.WriteLine("Extension cannot be empty. Please try again.");
            return;
        }

        var files = _directoryAnalyzer.GetFilesByExtension(extension, recursive: true);
        if (!files.Any())
        {
            Console.WriteLine($"No files with extension '{extension}' found in the directory.");
            return;
        }

        Console.WriteLine($"Files with extension '{extension}':");
        foreach (var file in files)
            Console.WriteLine($"- {file}");
    }

    private static void ShowDiskUsageReport()
    {
        if (_directoryAnalyzer == null)
        {
            Console.WriteLine("Directory is not initialized.");
            return;
        }

        var fileSizes = _directoryAnalyzer.GetFileSizesByExtension(recursive: true);
        if (fileSizes == null || !fileSizes.Any())
        {
            Console.WriteLine("No data available to generate a disk usage report.");
            return;
        }

        Console.WriteLine("Disk usage report by extension:");
        UserInterface.Table.Display(fileSizes.ToList());
    }
}