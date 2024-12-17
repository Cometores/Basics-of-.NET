using ImageProcessor.Filters;

namespace ImageProcessor.UserInterface;

/// <summary>
/// ConsoleUI class that implements the IUserInterface interface.
/// This class provides methods to display information, prompts, and handle user interaction through the console.
/// </summary>
public class ConsoleUI : IUserInterface
{
    /// <inheritdoc/>
    public void ShowCompletionMessage(string message) => Console.WriteLine($"\n{message}");

    /// <inheritdoc/>
    public void ShowFileSavedMessage(string filePath) => Console.WriteLine($"\t- Image has been saved: {filePath}");

    /// <inheritdoc/>
    public void DisplayFilesToProcess(List<string> files)
    {
        Console.WriteLine("\nFiles to be processed:");

        foreach (var file in files)
            Console.WriteLine($"- {Path.GetFileName(file)}");
    }

    /// <inheritdoc/>
    public void DisplayProgress(int processedFiles, int totalFiles)
    {
        Console.SetCursorPosition(0, Console.CursorTop);
        int percentage = (int)((double)processedFiles / totalFiles * 100);
        Console.Write(
            $"Progress: [{new string('#', percentage / 10)}{new string('-', 10 - percentage / 10)}] {percentage}% ({processedFiles}/{totalFiles})");
    }

    /// <inheritdoc/>
    public string GetFolderPath(string prompt)
    {
        Console.WriteLine(prompt);
        string folderPath = Console.ReadLine() ?? throw new InvalidOperationException("Incorrect folder path.");
        return folderPath.Trim();
    }

    /// <inheritdoc/>
    public List<IImageFilter> GetFiltersFromUser(Dictionary<int, Func<IImageFilter>> availableFilters)
    {
        var filters = new List<IImageFilter>();

        Console.WriteLine("\nChoose filters for image processing:");
        foreach (var filter in availableFilters)
            Console.WriteLine($"{filter.Key} - {filter.Value().GetType().Name}");


        Console.WriteLine("Enter the filter numbers in the desired order, separated by commas (e.g. 1,2):");
        var selectedFilters = Console.ReadLine()?.Split(',').Select(s => int.Parse(s.Trim()));

        if (selectedFilters == null) return filters;
        foreach (var filterIndex in selectedFilters)
        {
            if (availableFilters.TryGetValue(filterIndex, out var filter))
                filters.Add(filter());
            else
                Console.WriteLine($"The filter with the number {{filterIndex}} was not found.");
        }

        return filters;
    }
}