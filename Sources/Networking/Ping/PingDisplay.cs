using System.Net.NetworkInformation;

namespace Ping;

public class PingDisplay
{
    public void DisplayPingResult(PingReply reply, bool success)
    {
        Console.ForegroundColor = success ? ConsoleColor.Green : ConsoleColor.Red;
        Console.WriteLine(
            success
                ? $"Reply from {reply.Address}: bytes={reply.Buffer.Length} time={reply.RoundtripTime}ms TTL={reply.Options?.Ttl}"
                : $"Ping failed: {reply.Status}"
        );

        Console.ResetColor();
    }

    public void DisplayError(string message)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"Error: {message}");
        Console.ResetColor();
    }

    public void DisplayStatistics(PingStatistics statistics)
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
            Console.WriteLine("\tNo successful pings.");
        }
    }
}