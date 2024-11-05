using System.Net.Sockets;

namespace PortScanner;

public class PortScanner
{
    public async Task<string> ScanPortAsync(string host, int port)
    {
        using (var client = new TcpClient())
        {
            try
            {
                var connectTask = client.ConnectAsync(host, port);
                var result = await Task.WhenAny(connectTask, Task.Delay(2000)); // 2 seconds timeout

                if (result == connectTask && client.Connected)
                {
                    return "Open";
                }
                else
                {
                    return "Closed";
                }
            }
            catch
            {
                return "Error";
            }
        }
    }

    public async Task ScanPortsAsync(string host, int startPort, int endPort)
    {
        Console.WriteLine($"Scanning {host} from port {startPort} to {endPort}...");
        for (int port = startPort; port <= endPort; port++)
        {
            var result = await ScanPortAsync(host, port);
            Console.WriteLine($"Port {port}: {result}");
        }
    }
}