namespace FileDownload;

public static class ConsoleWriterDownload
{
    public static void DrawStatusBarWithoutLoading()
    {
        StatusBar statusBar = new StatusBar(7);
        Task t = Task.Run(() => statusBar.PrintFullBar());
        
        System.Threading.Thread.Sleep(700);
        ConsoleWriter.Write("Hello");
        
        t.Wait();
    }
    
    
    public static void SimulateDownloading()
    {
        Random random = new();
        int numberOfFiles = 7;
        Task[] fileTasks = new Task[7]; 
        StatusBar statusBar = new StatusBar(numberOfFiles);

        for (int i = 0; i < numberOfFiles; i++)
        {
            var fileN = i;
            Task downloadTask = Task.Run(() =>
            {
                System.Threading.Thread.Sleep(random.Next(500, 6000));
                statusBar.Add();
                ConsoleWriter.Write($"File {fileN + 1} was installed");
            });
            fileTasks[fileN] = downloadTask;
        }

        Task.WaitAll(fileTasks);
        System.Threading.Thread.Sleep(1500);
        ConsoleWriter.Write("Download finished");
    }
}