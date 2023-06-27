using System.Threading.Channels;
using FileDownload;


// DrawStatusBarWithoutLoading();
SimulateDownloading();


void DrawStatusBarWithoutLoading()
{
    StatusBar statusBar = new StatusBar(7);
    Task t = Task.Run(() => statusBar.PrintFullBar());
    
    System.Threading.Thread.Sleep(700);
    ConsoleWriter.Write("Hello");
    
    t.Wait();
}


void SimulateDownloading()
{
    StatusBar statusBar = new StatusBar(7);
    Task t1 = Task.Run(() =>
    {
        System.Threading.Thread.Sleep(4000);
        statusBar.Add();
        ConsoleWriter.Write("File 1 was installed");
    });
    Task t2 = Task.Run(() =>
    {
        System.Threading.Thread.Sleep(200);
        statusBar.Add();
        ConsoleWriter.Write("File 2 was installed");

    });
    Task t3 = Task.Run(() =>
    {
        System.Threading.Thread.Sleep(1500);
        statusBar.Add();
        ConsoleWriter.Write("File 3 was installed");

    });
    Task t4 = Task.Run(() =>
    {
        System.Threading.Thread.Sleep(800);
        statusBar.Add();
        ConsoleWriter.Write("File 4 was installed");

    });
    Task t5 = Task.Run(() =>
    {
        System.Threading.Thread.Sleep(5000);
        statusBar.Add();
        ConsoleWriter.Write("File 5 was installed");

    });
    Task t6 = Task.Run(() =>
    {
        System.Threading.Thread.Sleep(2200);
        statusBar.Add();
        ConsoleWriter.Write("File 6 was installed");

    });
    Task t7 = Task.Run(() =>
    {
        System.Threading.Thread.Sleep(1000);
        statusBar.Add();
        ConsoleWriter.Write("File 7 was installed");

    });

    Task.WaitAll(t1, t2, t3, t4, t5, t6, t7);
    System.Threading.Thread.Sleep(2000);
    ConsoleWriter.Write("Download finished");
}