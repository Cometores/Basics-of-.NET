using ImageProcessor.Filters;
using ImageProcessor.UserInterface;

namespace ImageProcessor;

public static class Program
{
    public static async Task Main(string[] args)
    {
        IUserInterface ui = new ConsoleUI();

        Console.WriteLine("Welcome to Image Processor!");

        // Getting folders from the user through the interface
        string inputFolder = ui.GetFolderPath("Enter the path to the folder containing source images:");
        string outputFolder = ui.GetFolderPath("Enter the path to the folder for saving processed images:");

        // Запрашиваем фильтры
        var availableFilters = new Dictionary<int, Func<IImageFilter>>
        {
            { 1, () => new GrayscaleFilter() },
            { 2, () => new SepiaFilter(0.3f) },
            { 3, () => new ScaleFilter(0.5f) },
            { 4, () => new InvertFilter() },
            { 5, () => new BrightnessFilter(1.2f) } // Brightness 1.2 to increase by 20%
        };

        var filters = ui.GetFiltersFromUser(availableFilters);

        var imageProcessor = new ImageProcessor();
        await imageProcessor.ProcessImagesAsync(inputFolder, outputFolder, filters, ui);
        
        /* TODO: Improve the user interface
            - Add ability to change other image types
            - Improve progress bar
            - Arrow filter selection
            */
    }
}