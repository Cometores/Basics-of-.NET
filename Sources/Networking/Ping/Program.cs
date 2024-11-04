using System.Net.NetworkInformation;
namespace Ping;

static class Program
{
    static void Main()
    {
        Console.Write("Enter host (IP address or domain): ");
        string host = Console.ReadLine();

        Console.Write("Enter number of requests (0 for infinite): ");
        int requestCount = int.TryParse(Console.ReadLine(), out var count) ? count : 4;

        System.Net.NetworkInformation.Ping pingSender = new();
        int counter = 0;

        while (requestCount == 0 || counter < requestCount)
        {
            try
            {
                PingReply reply = pingSender.Send(host);
                Console.WriteLine(reply.Status == IPStatus.Success
                    ? $"Reply from {reply.Address}: bytes={reply.Buffer.Length} time={reply.RoundtripTime}ms TTL={reply.Options?.Ttl}"
                    : $"Ping failed: {reply.Status}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            Thread.Sleep(1000); // wait 1 second between pings
            counter++;
        }
    }
}