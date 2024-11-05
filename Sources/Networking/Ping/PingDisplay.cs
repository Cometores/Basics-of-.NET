using System.Net.NetworkInformation;

namespace Ping;

/// <summary>
/// Represents a class for displaying the result of ping operations and related statistics.
/// </summary>
public class PingDisplay
{
    /// <summary>
    /// Displays the result of a ping operation.
    /// </summary>
    /// <param name="reply">The PingReply object containing the result of the ping operation.</param>
    /// <param name="success">A boolean indicating whether the ping operation was successful or not.</param>
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

    /// <summary>
    /// Displays an error message on the console in red color.
    /// </summary>
    /// <param name="message">The error message to be displayed.</param>
    public void DisplayError(string message)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"Error: {message}");
        Console.ResetColor();
    }

    /// <summary>
    /// Displays the statistics of the ping operations including success count, failure count, min, max, and average roundtrip times.
    /// </summary>
    /// <param name="statistics">The PingStatistics object containing the statistical information of the ping operations.</param>
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