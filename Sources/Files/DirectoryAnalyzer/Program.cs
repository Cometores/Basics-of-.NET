namespace DirectoryAnalyzer;

internal static class Program
{
    private static Analyzer.DirectoryAnalyzer? _directoryAnalyzer;
    private static string? _dirPath;

    private static void Main()
    {
        WriteGreeting();

        while (true)
        {
            _dirPath = DirInput();

            if (string.Equals(_dirPath, "exit", StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine("Goodbye!");
                return;
            }

            if (Directory.Exists(_dirPath))
            {
                WriteLoadSuccess(_dirPath);
                MainMenu(_dirPath);
            }
            else
            {
                WriteLoadFailed(_dirPath);
            }
        }
    }

    private static void WriteLoadFailed(string input)
    {
        Console.ForegroundColor = ConsoleColor.DarkRed;
        Console.Write("Error: The directory '");
        Console.ResetColor();
        
        Console.Write(input);
        
        Console.ForegroundColor = ConsoleColor.DarkRed;
        Console.WriteLine("' does not exist. Please try again.\n");
        Console.ResetColor();
    }

    private static void WriteLoadSuccess(string input)
    {
        Console.Write($"Directory '{input}' loaded successfully.");
    }

    private static string DirInput()
    {
        Console.Write("Input your directory (or type '");

        Console.ForegroundColor = ConsoleColor.Red;
        Console.Write("exit");
        Console.ResetColor();

        Console.Write("' to quit): ");

        return Console.ReadLine() ?? string.Empty;
    }

    private static void WriteGreeting()
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("Welcome to the Directory Analyzer!\n");
        Console.ResetColor();
    }

    private static void MainMenu(string input)
    {
        _directoryAnalyzer = new Analyzer.DirectoryAnalyzer(input);

        while (true)
        {
            Console.WriteLine("\nChoose an action:");
            Console.WriteLine("1. Show all file extensions");
            Console.WriteLine("2. Show files for a specific extension");
            Console.WriteLine("3. Show disk usage report");
            Console.WriteLine("4. Change directory");
            Console.WriteLine("5. Exit");
            Console.Write("Enter your choice: ");

            if (!int.TryParse(Console.ReadLine(), out var choice))
            {
                Console.WriteLine("Invalid input. Please enter a number.");
                continue;
            }

            try
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
                        return;
                    case 5:
                        Console.WriteLine("Exiting...");
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
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
        Console.WriteLine(UserInterface.Table.Display(fileSizes));
    }
}