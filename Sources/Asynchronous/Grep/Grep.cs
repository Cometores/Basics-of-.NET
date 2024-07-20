using System.Text.RegularExpressions;

namespace Grep;

public class Grep
{
    public int Cnt { get; private set; } = 0;
    
    private string _path;
    private string _searchQuery;
    private readonly object _lockQuery = new();

    public Task GrepIt(string path, string query)
    {
        _path = path;
        _searchQuery = query;
        if (!Directory.Exists(path))
            throw new DirectoryNotFoundException();

        DirectoryInfo dir = new DirectoryInfo(path);
        return GrepDirectoryAsync(dir);
    }
    
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