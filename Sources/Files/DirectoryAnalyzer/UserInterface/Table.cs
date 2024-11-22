using System.Text;
using DirectoryAnalyzer.Analyzer;

namespace DirectoryAnalyzer.UserInterface;

public static class Table
{
    public static string Display(IEnumerable<FileExtensionInfo>? fileExtensionInfos)
    {
        if (fileExtensionInfos == null)
            return "No data available to generate a chart.";

        var fileInfoList = fileExtensionInfos.ToList();

        if (fileInfoList.Count == 0)
            return "No data available to generate a chart.";

        long totalSize = fileInfoList.Sum(info => info.TotalSize);

        var builder = new StringBuilder();
        builder.AppendLine("File Distribution Report:");
        builder.AppendLine("-----------------------------------------------");
        builder.AppendLine("        Ext        |   Count   |  Total Size  |");
        builder.AppendLine("-----------------------------------------------");

        foreach (var info in fileInfoList)
        {
            // Генерация строки для текущего расширения
            builder.AppendLine(
                $"{info.Extension,-18} | {info.FileCount,8} | {BytesToText(info.TotalSize),13} |"
            );
        }

        builder.AppendLine("-----------------------------------------------");
        builder.AppendLine($"Total: {BytesToText(totalSize)} across all extensions.");
        return builder.ToString();
    }

    public static string BytesToText(long bytes)
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
}