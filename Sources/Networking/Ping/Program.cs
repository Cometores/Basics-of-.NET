﻿namespace Ping;

static class Program
{
    static async Task Main(string[] args)
    {
        string host = args.Length > 0 ? args[0] : GetHost();
        int timeout = args.Length > 1 && int.TryParse(args[1], out var t) ? t : GetTimeout();
        string logFilePath = args.Length > 2 ? args[2] : "ping_log.txt";

        var pingExecutor = new PingExecutor(logFilePath);
        await pingExecutor.StartPingingAsync(host, timeout);
    }

    static string GetHost()
    {
        Console.Write("Enter host (IP address or domain): ");
        return Console.ReadLine();
    }

    static int GetTimeout()
    {
        Console.Write("Enter timeout (ms): ");
        return int.TryParse(Console.ReadLine(), out var time) ? time : 1000;
    }
}