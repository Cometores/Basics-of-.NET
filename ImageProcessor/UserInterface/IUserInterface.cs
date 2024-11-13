using ImageProcessor.Filters;

namespace ImageProcessor.UserInterface;

public interface IUserInterface
{
    void DisplayFilesToProcess(List<string> files);
    void DisplayProgress(int processedFiles, int totalFiles);
    void ShowCompletionMessage(string message);
    void ShowFileSavedMessage(string filePath);
    string GetFolderPath(string prompt);
    List<IImageFilter> GetFiltersFromUser(Dictionary<int, Func<IImageFilter>> availableFilters);
}