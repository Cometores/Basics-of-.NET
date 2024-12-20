﻿namespace DirectoryAnalyzer.Analyzer;

/// <summary>
/// Represents a directory analyzer that provides methods to analyze the contents of a directory.
/// </summary>
public class DirectoryAnalyzer
{
    /// <summary>
    /// Path of the directory being analyzed.
    /// </summary>
    public string Path { get; }
    
    public DirectoryAnalyzer(string path)
    {
        if (!Directory.Exists(path))
            throw new DirectoryNotFoundException($"The directory '{path}' does not exist.");

        Path = path;
    }

    /// <summary>
    /// Retrieves all unique file extensions in the directory.
    /// </summary>
    /// <param name="recursive">Include subdirectories.</param>
    /// <returns>A set of unique file extensions.</returns>
    public IEnumerable<string> GetFileExtensions(bool recursive = false)
    {
        var searchOption = recursive ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly;

        return Directory.EnumerateFiles(Path, "*.*", searchOption)
            .AsParallel()
            .Select(file => System.IO.Path.GetExtension(file).ToLower())
            .Where(extension => !string.IsNullOrEmpty(extension))
            .Distinct();
    }

    /// <summary>
    /// Retrieves a list of files with the specified extension.
    /// </summary>
    /// <param name="extension">File extension (e.g., ".txt").</param>
    /// <param name="recursive">Include subdirectories.</param>
    /// <returns>A list of relative file paths.</returns>
    public IEnumerable<string> GetFilesByExtension(string extension, bool recursive = false)
    {
        if (string.IsNullOrWhiteSpace(extension))
            throw new ArgumentException("Extension cannot be null or empty.", nameof(extension));

        var searchOption = recursive ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly;

        var files = Directory.EnumerateFiles(Path, "*.*", searchOption)
            .AsParallel()
            .Where(file => System.IO.Path.GetExtension(file).Equals(extension, StringComparison.OrdinalIgnoreCase))
            .Select(file => System.IO.Path.GetRelativePath(Path, file))
            .ToList();

        return files;
    }

    /// <summary>
    /// Calculates the total size of files grouped by extension using parallel processing.
    /// </summary>
    /// <param name="recursive">Include subdirectories.</param>
    /// <returns>A collection of file extension sizes.</returns>
    public IEnumerable<ExtensionInfo>? GetFileSizesByExtension(bool recursive = false)
    {
        var searchOption = recursive ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly;
        var files = Directory.EnumerateFiles(Path, "*.*", searchOption).ToList();

        var groupedExtensions = files
            .AsParallel()
            .GroupBy(file => System.IO.Path.GetExtension(file).ToLower())
            .Select(group => new ExtensionInfo
            {
                Name = group.Key,
                Size = group.Sum(file => new FileInfo(file).Length),
                FileCount = group.Count()
            })
            .OrderByDescending(extInfo => extInfo.Size)
            .ToList();

        return groupedExtensions;
    }
}