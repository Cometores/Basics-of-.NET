using ImageProcessor.Filters;

namespace ImageProcessor.UserInterface;

/// <summary>
/// Represents a user interface for interacting with the Image Processor application.
/// </summary>
public interface IUserInterface
{
    /// <summary>
    /// Displays the list of files to be processed in the user interface.
    /// </summary>
    /// <param name="files">A List of strings representing file paths.</param>
    void DisplayFilesToProcess(List<string> files);

    /// <summary>
    /// Displays the progress of processing files in the user interface.
    /// </summary>
    /// <param name="processedFiles">The number of files processed.</param>
    /// <param name="totalFiles">The total number of files to process.</param>
    void DisplayProgress(int processedFiles, int totalFiles);

    /// <summary>
    /// Displays a completion message in the user interface.
    /// </summary>
    /// <param name="message">The message to display upon completion.</param>
    void ShowCompletionMessage(string message);

    /// <summary>
    /// Displays a message in the user interface indicating that a file has been saved.
    /// </summary>
    /// <param name="filePath">The path of the saved file.</param>
    void ShowFileSavedMessage(string filePath);

    /// <summary>
    /// Gets the folder path from the user.
    /// </summary>
    /// <param name="prompt">The message prompt to display to the user.</param>
    /// <returns>The folder path provided by the user.</returns>
    string GetFolderPath(string prompt);

    List<IImageFilter> GetFiltersFromUser(Dictionary<int, Func<IImageFilter>> availableFilters);
}