using System.Net.NetworkInformation;

namespace Ping.Ping;

/// <summary>
/// Represents a class that executes ping operations asynchronously and displays the results and statistics.
/// </summary>
public class PingExecutor(string logFilePath)
{
    private readonly System.Net.NetworkInformation.Ping _pingSender = new();
    private readonly PingStatistics _statistics = new();
    private readonly PingLogger _logger = new(logFilePath);

    /// <summary>
    /// Initiates asynchronous pinging process to the specified host with the given timeout.
    /// </summary>
    /// <param name="host">The host to ping, can be an IP address or domain.</param>
    /// <param name="timeout">The timeout value in milliseconds for each ping operation.</param>
    /// <returns>Returns a Task representing the asynchronous operation.</returns>
    public async Task StartPingingAsync(string host, int timeout)
    {
        UserInterface.DisplayCancelCombination();
        Console.CancelKeyPress += (sender, e) =>
        {
            e.Cancel = true;
            UserInterface.DisplayStatistics(_statistics);
            Environment.Exit(0);
        };

        while (true)
        {
            await SendPingAsync(host, timeout);
            await Task.Delay(1000); // Delay between pings
        }
    }

    private async Task SendPingAsync(string host, int timeout)
    {
        try
        {
            var reply = await _pingSender.SendPingAsync(host, timeout);
            if (reply.Status == IPStatus.Success)
            {
                _statistics.AddSuccess(reply.RoundtripTime);
                UserInterface.DisplayPingResult(reply, true);
                _logger.LogPingResult($"Reply from {reply.Address}: time={reply.RoundtripTime}ms");
            }
            else
            {
                _statistics.AddFailure();
                UserInterface.DisplayPingResult(reply, false);
                _logger.LogPingResult($"Ping failed: {reply.Status}");
            }
        }
        catch (Exception ex)
        {
            _statistics.AddFailure();
            UserInterface.DisplayError(ex.Message);
            _logger.LogPingResult($"Error: {ex.Message}");
        }
    }
}