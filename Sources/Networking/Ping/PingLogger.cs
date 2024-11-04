namespace Ping;

public class PingLogger
{
    private readonly string _logFilePath;

    public PingLogger(string logFilePath)
    {
        _logFilePath = logFilePath;
    }

    public void LogPingResult(string message)
    {
        File.AppendAllText(_logFilePath, $"{DateTime.Now}: {message}\n");
    }
}