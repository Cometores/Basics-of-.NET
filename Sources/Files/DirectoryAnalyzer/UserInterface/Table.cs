using System.Text;
using DirectoryAnalyzer.Analyzer;

namespace DirectoryAnalyzer.UserInterface;

/// <summary>
/// Provides functionality to display file distribution report in a table format.
/// </summary>
public static class Table
{
    /// <summary>
    /// Displays the file distribution report in a table format.
    /// </summary>
    /// <param name="extensionInfos">A list of ExtensionInfo objects containing file size information for each extension.</param>
    public static void Display(List<ExtensionInfo>? extensionInfos)
    {
        if (extensionInfos == null || extensionInfos.Count == 0)
        {
            Console.WriteLine("No data available to generate a table.");
            return;
        }

        PrintTableHeader();

        long totalSize = 0;
        foreach (var extension in extensionInfos)
        {
            totalSize += extension.Size;
            Console.WriteLine($"{extension.Name,-18} | {extension.FileCount,8} | {BytesToText(extension.Size),13} |");
        }

        PrintTableFooter(totalSize);
    }

    /// <summary>
    /// Converts a given number of bytes into a human-readable format with appropriate units (e.g., KB, MB, GB).
    /// </summary>
    /// <param name="bytes">The number of bytes to be converted into text.</param>
    /// <returns>A string representing the given number of bytes in human-readable format with appropriate units.</returns>
    private static string BytesToText(long bytes)
    {
        string[] units = { "Byte", "KB", "MB", "GB", "TB", "PB" };
        int unitIndex = 0;

        double size = bytes;
        while (size >= 1024 && unitIndex < units.Length - 1)
        {
            size /= 1024;
            unitIndex++;
        }

        return $"{size:0.00} {units[unitIndex]}";
    }

    private static void PrintTableFooter(long totalSize)
    {
        var builder = new StringBuilder();
        builder.Clear();
        builder.AppendLine("-----------------------------------------------");
        builder.AppendLine($"Total: {BytesToText(totalSize)} across all extensions.");
        Console.WriteLine(builder.ToString());
    }

    private static void PrintTableHeader()
    {
        var builder = new StringBuilder();
        builder.AppendLine("File Distribution Report:");
        builder.AppendLine("-----------------------------------------------");
        builder.AppendLine("     Extension     |   Count  |   Total Size  |");
        builder.AppendLine("-----------------------------------------------");
        Console.Write(builder.ToString());
    }
}