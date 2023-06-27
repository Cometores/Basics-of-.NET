using System.Threading.Channels;
using FileDownload;


// DrawStatusBarWithoutLoading();
SimulateDownloading();


void DrawStatusBarWithoutLoading()
{
    StatusBar statusBar = new StatusBar(7);
    Task t = Task.Run(() => statusBar.PrintFullBar());
    
    System.Threading.Thread.Sleep(700);
    Console.WriteLine("Hello");
    
    t.Wait();
}

void SimulateDownloading()
{
    StatusBar statusBar = new StatusBar(7);
    Task t1 = Task.Run(() =>
    {
        System.Threading.Thread.Sleep(4000);
        statusBar.Add();
    });
    Task t2 = Task.Run(() =>
    {
        System.Threading.Thread.Sleep(200);
        statusBar.Add();
    });
    Task t3 = Task.Run(() =>
    {
        System.Threading.Thread.Sleep(1500);
        statusBar.Add();
    });
    Task t4 = Task.Run(() =>
    {
        System.Threading.Thread.Sleep(800);
        statusBar.Add();
    });
    Task t5 = Task.Run(() =>
    {
        System.Threading.Thread.Sleep(5000);
        statusBar.Add();
    });
    Task t6 = Task.Run(() =>
    {
        System.Threading.Thread.Sleep(2200);
        statusBar.Add();
    });
    Task t7 = Task.Run(() =>
    {
        System.Threading.Thread.Sleep(1000);
        statusBar.Add();
    });

    Task.WaitAll(t1, t2, t3, t4, t5, t6, t7);
    System.Threading.Thread.Sleep(2000);
    Console.WriteLine("Download finished");
}