using ImageProcessor.Filters;

namespace ImageProcessor;

public static class Program
{
    public static async Task Main(string[] args)
    {
        IUserInterface ui = new ConsoleUI();
        
        Console.WriteLine("Добро пожаловать в Image Processor!");

        // Получаем папки от пользователя через интерфейс
        string inputFolder = ui.GetFolderPath("Введите путь к папке с исходными изображениями:");
        string outputFolder = ui.GetFolderPath("Введите путь к папке для сохранения обработанных изображений:");

        // Запрашиваем фильтры
        var availableFilters = new Dictionary<int, Func<IImageFilter>>
        {
            { 1, () => new GrayscaleFilter() },
            { 2, () => new SepiaFilter(0.3f) },
            { 3, () => new ScaleFilter(0.5f) } // Пример фильтра изменения размера
        };
        
        var filters = ui.GetFiltersFromUser(availableFilters);

        var imageProcessor = new ImageProcessor();
        await imageProcessor.ProcessImages(inputFolder, outputFolder, filters, ui);
    }
}

