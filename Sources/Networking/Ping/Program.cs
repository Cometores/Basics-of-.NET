using System.Net.NetworkInformation;

namespace Ping;

static class Program
{
    static void Main()
    {
        string host = GetHost();
        int requestCount = GetRequestCount();
        int timeout = GetTimeout();

        System.Net.NetworkInformation.Ping pingSender = new();
        PingStatistics statistics = new();

        ExecutePingRequests(pingSender, host, requestCount, timeout, statistics);
        DisplayStatistics(statistics, requestCount);
    }

    static string GetHost()
    {
        Console.Write("Enter host (IP address or domain): ");
        return Console.ReadLine();
    }

    static int GetRequestCount()
    {
        Console.Write("Enter number of requests (0 for infinite): ");
        return int.TryParse(Console.ReadLine(), out var count) ? count : 4;
    }

    static int GetTimeout()
    {
        Console.Write("Enter timeout (ms): ");
        return int.TryParse(Console.ReadLine(), out var time) ? time : 1000;
    }

    static void ExecutePingRequests(System.Net.NetworkInformation.Ping pingSender, string host, int requestCount,
        int timeout, PingStatistics statistics)
    {
        int counter = 0;

        while (requestCount == 0 || counter < requestCount)
        {
            try
            {
                var reply = pingSender.Send(host, timeout);
                if (reply.Status == IPStatus.Success)
                {
                    statistics.AddSuccess(reply.RoundtripTime);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(
                        $"Reply from {reply.Address}: bytes={reply.Buffer.Length} time={reply.RoundtripTime}ms TTL={reply.Options?.Ttl}");
                }
                else
                {
                    statistics.AddFailure();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Ping failed: {reply.Status}");
                }
            }
            catch (Exception ex)
            {
                statistics.AddFailure();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Error: {ex.Message}");
            }

            Console.ResetColor(); // Reset color after each ping
            Thread.Sleep(1000);
            counter++;
        }
    }

    static void DisplayStatistics(PingStatistics statistics, int totalRequests)
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("\nPing Statistics:");
        Console.ResetColor();
        
        Console.WriteLine($"\tTotal requests: {totalRequests}");
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