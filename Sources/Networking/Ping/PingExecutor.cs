using System.Net.NetworkInformation;

namespace Ping;

public class PingExecutor
{
    private readonly System.Net.NetworkInformation.Ping _pingSender = new();
    private readonly PingStatistics _statistics = new();
    private readonly PingDisplay _display = new();

    public async Task StartPingingAsync(string host, int timeout)
    {
        Console.CancelKeyPress += (sender, e) =>
        {
            e.Cancel = true;
            _display.DisplayStatistics(_statistics);
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
                _display.DisplayPingResult(reply, true);
            }
            else
            {
                _statistics.AddFailure();
                _display.DisplayPingResult(reply, false);
            }
        }
        catch (Exception ex)
        {
            _statistics.AddFailure();
            _display.DisplayError(ex.Message);
        }
    }
}