namespace Grep;

public class Grep
{
    public int Cnt { get; private set; } = 0;
    
    private string _searchQuery;
    private readonly object _lockQuery = new();

    /// <summary>
    /// Searches for specific strings in files located in a folder and subfolders.
    /// </summary>
    /// <param name="path">Absolute path to directory</param>
    /// <param name="query">Search string</param>
    public Task GrepItAsync(string path, string query)
    {
        _searchQuery = query;
        if (!Directory.Exists(path))
            throw new DirectoryNotFoundException();

        DirectoryInfo dir = new DirectoryInfo(path);
        return GrepDirectoryAsync(dir);
    }
    
    /// <summary>
    /// Creates new <c>GrepDirectory thread</c> for each directory founded and <c>GrepFile thread</c> for each file.
    /// </summary>
    /// <param name="dir">Directory to grep</param>
    private Task GrepDirectoryAsync(DirectoryInfo dir)
    {
        List<Task> tasks = new();
        foreach (DirectoryInfo childDir in dir.GetDirectories())
        {
            Task directoryTask = GrepDirectoryAsync(childDir);
            tasks.Add(directoryTask);
        }

        foreach (FileInfo childFile in dir.GetFiles())
        {
            if (childFile.Extension == ".txt")
            {
                Task fileTask = GrepFileAsync(childFile);
                tasks.Add(fileTask);
            }
        }
        return Task.WhenAll(tasks);
    }

    /// <summary>
    /// Searches the file for sequence match.
    /// </summary>
    /// <param name="file">File to grep</param>
    private async Task GrepFileAsync(FileInfo file)
    {
        using StreamReader sr = new StreamReader(file.OpenRead());
        while (!sr.EndOfStream)
        {
            string? line = await sr.ReadLineAsync();
            if (line != null && line.Contains(_searchQuery, StringComparison.OrdinalIgnoreCase))
            {
                lock (_lockQuery)
                    Cnt++;
            }
        }
    }
}