namespace Grep;

public class Grep
{
    private readonly string _path;
    private readonly string _searchQuery;
    public int Cnt = 0;
    private object _lockQuery = new();

    public Grep(string path, string searchQuery)
    {
        _path = path;
        _searchQuery = searchQuery;
        if (!Directory.Exists(path))
            throw new DirectoryNotFoundException();

        DirectoryInfo dir = new DirectoryInfo(path);
        Task t = DirectoryThread(dir);
        t.Wait();
    }

    private async Task DirectoryThread(DirectoryInfo dir)
    {
        List<Task> tList = new();
        foreach (DirectoryInfo childDir in dir.GetDirectories())
        {
            Task t = DirectoryThread(childDir);
            tList.Add(t);
        }

        foreach (FileInfo childFile in dir.GetFiles())
        {
            if (childFile.Extension == ".txt")
            {
                Task t = FileThread(childFile);
                tList.Add(t);
            }
        }

        Task.WaitAll(tList.ToArray());
    }

    private async Task FileThread(FileInfo file)
    {
        using StreamReader sr = new StreamReader(file.OpenRead());
        while (!sr.EndOfStream)
        {
            string? line = sr.ReadLine();
            if (line != null && line.Contains(_searchQuery))
            {
                lock (_lockQuery)
                {
                    Cnt++;
                }
            }
        }
    }
}