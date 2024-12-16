using DirectoryAnalyzer.UserInterface;

namespace DirectoryAnalyzer;

internal static class Program
{
    private static void Main()
    {
        IO.WriteGreeting();

        while (true)
        {
            string directory = IO.ReadDirectory();

            bool exitRequested = string.Equals(directory, "exit", StringComparison.OrdinalIgnoreCase);
            if (exitRequested)
            {
                Console.WriteLine("Goodbye!");
                return;
            }

            if (Directory.Exists(directory))
            {
                Analyzer.DirectoryAnalyzer analyzer = new(directory);
                MenuHandler menuHandler = new(analyzer);
                menuHandler.Run();
            }
            else
            {
                IO.WriteLoadFailed(directory);
            }
        }
    }
}