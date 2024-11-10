using Ping.Ping;

namespace Ping;

static class Program
{
    static async Task Main(string[] args)
    {
        string host = args.Length > 0 ? args[0] : UserInterface.GetHost();
        int timeout = args.Length > 1 && int.TryParse(args[1], out var t) ? t :  UserInterface.GetTimeout();
        string logFilePath = args.Length > 2 ? args[2] : "ping_log.txt";

        var pingExecutor = new PingExecutor(logFilePath);
        await pingExecutor.StartPingingAsync(host, timeout);
    }
}