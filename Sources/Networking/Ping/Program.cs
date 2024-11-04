using System.Net.NetworkInformation;

namespace Ping;

static class Program
{
    static async Task Main(string[] args)
    {
        string host = args.Length > 0 ? args[0] : GetHost();
        int timeout = args.Length > 1 && int.TryParse(args[1], out var t) ? t : GetTimeout();

        System.Net.NetworkInformation.Ping pingSender = new();
        PingStatistics statistics = new();

        Console.WriteLine("Press Ctrl + C to stop the ping process.\n");

        try
        {
            await ExecuteInfinitePingRequestsAsync(pingSender, host, timeout, statistics);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
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

    static async Task ExecuteInfinitePingRequestsAsync(System.Net.NetworkInformation.Ping pingSender, string host,
        int timeout, PingStatistics statistics)
    {
        Console.CancelKeyPress += (sender, e) =>
        {
            e.Cancel = true;
            Console.WriteLine("\nPing process interrupted by user.");
            DisplayStatistics(statistics);
            Environment.Exit(0);
        };

        while (true)
        {
            await SendPingAsync(pingSender, host, timeout, statistics);
            await Task.Delay(1000); // Delay between pings
        }
    }

    static async Task SendPingAsync(System.Net.NetworkInformation.Ping pingSender, string host, int timeout,
        PingStatistics statistics)
    {
        try
        {
            var reply = await pingSender.SendPingAsync(host, timeout);
            if (reply.Status == IPStatus.Success)
            {
                statistics.AddSuccess(reply.RoundtripTime);
                DisplayPingResult(reply, true);
            }
            else
            {
                statistics.AddFailure();
                DisplayPingResult(reply, false);
            }
        }
        catch (Exception ex)
        {
            statistics.AddFailure();
            DisplayError(ex.Message);
        }
    }

    static void DisplayPingResult(PingReply reply, bool success)
    {
        Console.ForegroundColor = success ? ConsoleColor.Green : ConsoleColor.Red;
        if (success)
        {
            Console.WriteLine(
                $"Reply from {reply.Address}: bytes={reply.Buffer.Length} time={reply.RoundtripTime}ms TTL={reply.Options?.Ttl}");
        }
        else
        {
            Console.WriteLine($"Ping failed: {reply.Status}");
        }

        Console.ResetColor();
    }

    static void DisplayError(string message)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"Error: {message}");
        Console.ResetColor();
    }

    static void DisplayStatistics(PingStatistics statistics)
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("\nPing Statistics:");
        Console.ResetColor();

        Console.WriteLine($"\tSuccessful pings: {statistics.SuccessCount}");
        Console.WriteLine($"\tFailed pings: {statistics.FailureCount}");
        if (statistics.SuccessCount > 0)
        {
            Console.WriteLine($"\tMin roundtrip time: {statistics.MinRoundtripTime}ms");
            Console.WriteLine($"\tMax roundtrip time: {statistics.MaxRoundtripTime}ms");
            Console.WriteLine($"\tAverage roundtrip time: {statistics.AverageRoundtripTime}ms");
        }
        else
        {
            Console.WriteLine("No successful pings.");
        }
    }
}