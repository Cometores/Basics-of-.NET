namespace ImageProcessor;

public static class Program
{
    private static async Task Main()
    {
        Console.WriteLine("Введите путь к папке с изображениями:");
        string inputFolder = Console.ReadLine();

        Console.WriteLine("Введите путь для сохранения обработанных изображений:");
        string outputFolder = Console.ReadLine();

        Console.WriteLine("Уменьшать изображения? (y/n):");
        bool scale = Console.ReadLine()?.ToLower() == "y";

        Console.WriteLine("Сделать изображения черно-белыми? (y/n):");
        bool grayscale = Console.ReadLine()?.ToLower() == "y";

        Console.WriteLine("Применить эффект сепии? (y/n):");
        bool sepia = Console.ReadLine()?.ToLower() == "y";

        var processor = new ImageProcessor();
        await processor.ProcessImages(inputFolder, outputFolder, scale, grayscale, sepia);
    }
}