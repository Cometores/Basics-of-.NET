namespace DirectoryAnalyzer;

/// <summary>
/// Represents a menu handler for interacting with the directory analyzer.
/// </summary>
internal class MenuHandler(Analyzer.DirectoryAnalyzer analyzer)
{
    /// <summary>
    /// Executes the menu interface for interacting with the directory analyzer.
    /// </summary>
    /// <remarks>
    /// This method clears the console, writes a success message for the loaded directory, and then displays a menu prompt to the user.
    /// The user is expected to enter a numeric choice corresponding to a command to be processed.
    /// If an invalid input is provided, an error message is displayed, and the prompt is repeated.
    /// The method handles exceptions that might occur during command processing and displays an error message if needed.
    /// </remarks>
    public void Run()
    {
        Console.Clear();
        UserInterface.IO.WriteLoadSuccess(analyzer.Path);

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

    /// <summary>
    /// Processes the user's command choice to execute the corresponding action in the menu.
    /// </summary>
    /// <returns>Boolean indicating whether the method should return to directory selection (true) or exit the program (false).</returns>
    private bool ProcessCommand(int choice)
    {
        switch (choice)
        {
            case 1:
                DisplayAllExtensions();
                break;
            case 2:
                DisplayFilesForExtension();
                break;
            case 3:
                DisplayDiskUsageReport();
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

    private void DisplayAllExtensions()
    {
        var extensions = analyzer.GetFileExtensions(recursive: true);
        if (!extensions.Any())
        {
            Console.WriteLine("No file extensions found in the directory.");
            return;
        }

        Console.WriteLine("Extensions in the directory:");
        foreach (var extension in extensions)
            Console.WriteLine($"- {extension}");
    }

    private void DisplayFilesForExtension()
    {
        Console.Write("Enter the extension (e.g., .txt): ");
        string extension = Console.ReadLine()?.ToLower() ?? string.Empty;

        if (string.IsNullOrWhiteSpace(extension))
        {
            Console.WriteLine("Extension cannot be empty. Please try again.");
            return;
        }

        var files = analyzer.GetFilesByExtension(extension, recursive: true);
        if (!files.Any())
        {
            Console.WriteLine($"No files with extension '{extension}' found in the directory.");
            return;
        }

        Console.WriteLine($"Files with extension '{extension}':");
        foreach (var file in files)
            Console.WriteLine($"- {file}");
    }

    private void DisplayDiskUsageReport()
    {
        var fileSizes = analyzer.GetFileSizesByExtension(recursive: true);
        if (fileSizes == null || !fileSizes.Any())
        {
            Console.WriteLine("No data available to generate a disk usage report.");
            return;
        }

        Console.WriteLine("Disk usage report by extension:");
        UserInterface.Table.Display(fileSizes.ToList());
    }
}