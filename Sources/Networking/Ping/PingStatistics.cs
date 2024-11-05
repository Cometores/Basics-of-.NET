namespace Ping;

/// <summary>
/// Represents a class for storing statistics related to ping operations.
/// The class includes properties for tracking the number of successful and failed pings,
/// as well as the total roundtrip time, minimum roundtrip time, maximum roundtrip time,
/// and average roundtrip time.
/// </summary>
public class PingStatistics
{
    public int SuccessCount { get; private set; }
    public int FailureCount { get; private set; }
    public long TotalRoundtripTime { get; private set; }
    public long MinRoundtripTime { get; private set; } = long.MaxValue;
    public long MaxRoundtripTime { get; private set; } = 0;

    public void AddSuccess(long roundtripTime)
    {
        SuccessCount++;
        TotalRoundtripTime += roundtripTime;
        MinRoundtripTime = Math.Min(MinRoundtripTime, roundtripTime);
        MaxRoundtripTime = Math.Max(MaxRoundtripTime, roundtripTime);
    }

    public void AddFailure() => FailureCount++;

    public long AverageRoundtripTime => SuccessCount > 0 ? TotalRoundtripTime / SuccessCount : 0;
}