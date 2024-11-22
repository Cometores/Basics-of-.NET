namespace DirectoryAnalyzer.Analyzer;

/// <summary>
/// Represents information about file sizes for a specific extension.
/// </summary>
public class FileExtensionInfo
{
    public string Extension { get; set; }
    public long TotalSize { get; set; }
    public int FileCount { get; set; }

    public override string ToString() =>
        $"{Extension}: {FileCount} file(s), {UserInterface.Table.BytesToText(TotalSize)}";
}