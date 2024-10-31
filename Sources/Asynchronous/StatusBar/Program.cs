namespace StatusBar;

public static class Program
{
    public static void Main(string[] args)
    {
        Random random = new();
        
        int numberOfFiles = 7;
        Task[] fileTasks = new Task[numberOfFiles]; 
        StatusBar statusBar = new StatusBar(numberOfFiles);

        // Downloading files parallel
        for (int i = 0; i < numberOfFiles; i++)
        {
            int fileN = i;
            Task downloadTask = Task.Run(() => { SimulateFileDownload(random, statusBar, fileN); });
            fileTasks[fileN] = downloadTask;
        }

        // Waiting for download
        Task.WaitAll(fileTasks);
        Thread.Sleep(1500);
        ConsoleMT.WriteLine("Download finished");
    }

    /// <summary>
    /// Simulates the download of a file with a random delay and updates the status bar accordingly.
    /// </summary>
    /// <param name="random">An instance of the Random class for generating random delays.</param>
    /// <param name="statusBar">The StatusBar object representing the UI for the download progress.</param>
    /// <param name="fileN">The index of the file being downloaded.</param>
    private static void SimulateFileDownload(Random random, StatusBar statusBar, int fileN)
    {
        Thread.Sleep(random.Next(500, 6000));

        statusBar.Add();
        ConsoleMT.WriteLine($"File {fileN + 1} was installed");
    }
}