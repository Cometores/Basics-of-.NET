﻿using System.Collections.Concurrent;
using System.Net.Sockets;
using ShellProgressBar;

namespace PortScanner;

public class PortScanner
{
    private ConcurrentBag<(int Port, string Status)> Results = new();

    public async Task ScanPortsAsync(string host, int startPort, int endPort)
    {
        int totalPorts = endPort - startPort + 1;
        var options = new ProgressBarOptions
        {
            ForegroundColor = ConsoleColor.Cyan,
            ForegroundColorDone = ConsoleColor.Green,
            BackgroundCharacter = '\u2593'
        };

        using (var progressBar = new ProgressBar(totalPorts, "Scanning ports...", options))
        {
            await Parallel.ForEachAsync(
                Enumerable.Range(startPort, totalPorts),
                new ParallelOptions { MaxDegreeOfParallelism = 10 },
                async (port, token) =>
                {
                    string status = await CheckPortAsync(host, port);
                    Results.Add((port, status));
                    progressBar.Tick($"Port {port} - {status}");
                });
        }

        DisplayResults();
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

    private void DisplayResults()
    {
        Console.Clear();
        Console.WriteLine("{0,-10} {1}", "Port", "Status");
        Console.WriteLine(new string('-', 20));
        foreach (var (port, status) in Results.OrderBy(r => r.Port))
        {
            Console.WriteLine("{0,-10} {1}", port, status);
        }
    }
}