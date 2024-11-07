using System.Collections.Concurrent;
using System.Net.Sockets;

namespace PortScanner;

public class PortScanner
{
    private ConcurrentBag<(int Port, string Status)> _results = new();

    public async Task ScanPortsAsync(string host, int startPort, int endPort)
    {
        await Parallel.ForEachAsync(
            Enumerable.Range(startPort, endPort - startPort + 1),
            new ParallelOptions { MaxDegreeOfParallelism = 10 },
            async (port, token) =>
            {
                string status = await CheckPortAsync(host, port);
                _results.Add((port, status));
                Console.WriteLine($"Port {port}: {status}");
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