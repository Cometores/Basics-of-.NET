namespace DirectoryAnalyzer.Analyzer;

/// <summary>
/// Represents information about file sizes for a specific extension.
/// </summary>
public class ExtensionInfo
{
    /// <summary>
    /// Represents the name of a file extension.
    /// </summary>
    public required string Name { get; init; }

    /// <summary>
    /// Represents the total size of files for a specific extension.
    /// </summary>
    public long Size { get; init; }

    /// <summary>
    /// Represents the number of files with a specific extension.
    /// </summary>
    public int FileCount { get; init; }
}