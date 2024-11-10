using System.Net.NetworkInformation;
using Ping.Ping;

namespace Ping;

/// <summary>
/// Represents a class for displaying the result of ping operations and related statistics.
/// </summary>
public static class UserInterface
{
    /// <summary>
    /// Displays the result of a ping operation.
    /// </summary>
    /// <param name="reply">The PingReply object containing the result of the ping operation.</param>
    /// <param name="success">A boolean indicating whether the ping operation was successful or not.</param>
    public static void DisplayPingResult(PingReply reply, bool success)
    {
        Console.ForegroundColor = success ? ConsoleColor.Green : ConsoleColor.Red;
        Console.WriteLine(
            success
                ? $"Reply from {reply.Address}: bytes={reply.Buffer.Length} time={reply.RoundtripTime}ms TTL={reply.Options?.Ttl}"
                : $"Ping failed: {reply.Status}"
        );

        Console.ResetColor();
    }

    /// <summary>
    /// Displays an error message on the console in red color.
    /// </summary>
    /// <param name="message">The error message to be displayed.</param>
    public static void DisplayError(string message)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"Error: {message}");
        Console.ResetColor();
    }

    /// <summary>
    /// Displays the statistics of the ping operations including success count, failure count, min, max, and average roundtrip times.
    /// </summary>
    /// <param name="statistics">The PingStatistics object containing the statistical information of the ping operations.</param>
    public static void DisplayStatistics(PingStatistics statistics)
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

    public static string GetHost()
    {
        Console.Write("Enter host (IP address or domain): ");
        return Console.ReadLine();
    }

    public static int GetTimeout()
    {
        Console.Write("Enter timeout (ms): ");
        return int.TryParse(Console.ReadLine(), out var time) ? time : 1000;
    }

    public static void DisplayCancelCombination()
    {
        Console.WriteLine("Press Ctrl + C to stop the ping process.\n");
    }
}