using ImageProcessor.Filters;

namespace ImageProcessor;

public class ConsoleUI : IUserInterface
{
    public void DisplayFilesToProcess(List<string> files)
    {
        Console.WriteLine("\nФайлы, которые будут обработаны:");
        
        foreach (var file in files)
            Console.WriteLine($"- {Path.GetFileName(file)}");
    }

    public void DisplayProgress(int processedFiles, int totalFiles)
    {
        Console.SetCursorPosition(0, Console.CursorTop);
        int percentage = (int)((double)processedFiles / totalFiles * 100);
        Console.Write($"Прогресс: [{new string('#', percentage / 10)}{new string('-', 10 - percentage / 10)}] {percentage}% ({processedFiles}/{totalFiles})");
    }

    public void ShowCompletionMessage(string message)
    {
        Console.WriteLine($"\n{message}");
    }

    public void ShowFileSavedMessage(string filePath)
    {
        Console.WriteLine($"Изображение сохранено: {filePath}");
    }

    public string GetFolderPath(string prompt)
    {
        Console.WriteLine(prompt);
        return Console.ReadLine() ?? throw new InvalidOperationException("Неверный путь к папке.");
    }

    public List<IImageFilter> GetFiltersFromUser(Dictionary<int, Func<IImageFilter>> availableFilters)
    {
        var filters = new List<IImageFilter>();

        Console.WriteLine("\nВыберите фильтры для обработки изображений:");
        foreach (var filter in availableFilters)
        {
            Console.WriteLine($"{filter.Key} - {filter.Value().GetType().Name}");
        }

        Console.WriteLine("Введите номера фильтров в нужном порядке, разделяя их запятой (например, 1,2):");
        var selectedFilters = Console.ReadLine()?.Split(',').Select(s => int.Parse(s.Trim()));

        if (selectedFilters != null)
        {
            foreach (var filterIndex in selectedFilters)
            {
                if (availableFilters.TryGetValue(filterIndex, out var filterFactory))
                {
                    filters.Add(filterFactory());
                }
                else
                {
                    Console.WriteLine($"Фильтр с номером {filterIndex} не найден.");
                }
            }
        }

        return filters;
    }
}