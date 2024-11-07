using System.Collections.Concurrent;
using System.Net.Sockets;
using ShellProgressBar;

namespace PortScanner;

public class PortScanner
{
    public readonly ConcurrentBag<(int Port, string Status)> Results = new();

    readonly ProgressBarOptions _progressBarOptions = new()
    {
        ForegroundColor = ConsoleColor.Cyan,
        ForegroundColorDone = ConsoleColor.Green,
        BackgroundCharacter = '\u2593',
        
    };

    /// <summary>
    /// Asynchronously scans a range of ports on the specified host and updates the <see cref="ConcurrentBag{T}"/> Results with port status.
    /// </summary>
    /// <param name="host">The host to scan ports on.</param>
    /// <param name="startPort">The starting port number of the range to scan.</param>
    /// <param name="endPort">The ending port number of the range to scan.</param>
    /// <returns>A Task representing the asynchronous operation.</returns>
    public async Task ScanPortsAsync(string host, int startPort, int endPort)
    {
        int totalPorts = endPort - startPort + 1;

        using var progressBar = new ProgressBar(totalPorts, "Scanning ports...", _progressBarOptions);
        
        await Parallel.ForEachAsync(
            Enumerable.Range(startPort, totalPorts),
            new ParallelOptions { MaxDegreeOfParallelism = 100 },
            async (port, _) =>
            {
                string status = await CheckPortAsync(host, port);
                Results.Add((port, status));
                progressBar.Tick($"Port {port} - {status}");
            });
    }

    private async Task<string> CheckPortAsync(string host, int port)
    {
        using var client = new TcpClient();
        try
        {
            var connectTask = client.ConnectAsync(host, port);
            var result = await Task.WhenAny(connectTask, Task.Delay(2000));
            return client.Connected ? "Open" : "Closed";
        }
        catch
        {
            return "Error";
        }
    }
}