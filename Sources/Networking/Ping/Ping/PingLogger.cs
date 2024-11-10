namespace Ping.Ping;

/// <summary>
/// Represents a class for logging ping results to a specified file.
/// </summary>
public class PingLogger(string logFilePath)
{
    /// <summary>
    /// Logs the result of a ping operation to a specified log file.
    /// </summary>
    /// <param name="message">The message to be logged, typically containing information about the ping result.</param>
    public void LogPingResult(string message)
    {
        File.AppendAllText(logFilePath, $"{DateTime.Now}: {message}\n");
    }
}