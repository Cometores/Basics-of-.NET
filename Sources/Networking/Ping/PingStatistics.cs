namespace Ping;

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