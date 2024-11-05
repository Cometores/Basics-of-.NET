using System.Diagnostics;
using System.Net.Sockets;

namespace PortScanner;

static class Program
{
    static async Task Main(string[] args)
    {
        List<string> devices = GetNetworkDevices();
    
        if (devices.Count == 0)
        {
            Console.WriteLine("No devices found in the local network.");
            return;
        }

        string selectedIP = SelectDevice(devices);
        Console.WriteLine($"Selected IP: {selectedIP}");

        // Далее используем выбранный IP для сканирования портов
        int startPort = GetPort("Enter start port: ");
        int endPort = GetPort("Enter end port: ");

        Console.WriteLine($"Scanning {selectedIP} from port {startPort} to {endPort}...");

        for (int port = startPort; port <= endPort; port++)
        {
            var result = await ScanPortAsync(selectedIP, port);
            Console.WriteLine($"Port {port}: {result}");
        }
    }

    static string GetHost()
    {
        Console.Write("Enter host (IP address or domain): ");
        return Console.ReadLine();
    }

    static int GetPort(string message)
    {
        Console.Write(message);
        return int.TryParse(Console.ReadLine(), out var port) ? port : 0;
    }

    static async Task<string> ScanPortAsync(string host, int port)
    {
        using var client = new TcpClient(); // closes after method is finished
        try
        {
            var connectTask = client.ConnectAsync(host, port);
            var result = await Task.WhenAny(connectTask, Task.Delay(2000)); // 2 seconds timeout

            if (result == connectTask)
                return client.Connected ? "Open" : "Closed";
            else
                return "Timed out";
        }
        catch
        {
            return "Error";
        }
    }
    
    static List<string> GetNetworkDevices()
    {
        var devices = new List<string>();
        Process process = new Process();
        process.StartInfo.FileName = "arp";
        process.StartInfo.Arguments = "-a";
        process.StartInfo.RedirectStandardOutput = true;
        process.StartInfo.UseShellExecute = false;
        process.StartInfo.CreateNoWindow = true;

        process.Start();
        string output = process.StandardOutput.ReadToEnd();
        process.WaitForExit();

        foreach (var line in output.Split('\n'))
        {
            if (line.Contains("dynamic")) // Filter out lines that include dynamic IPs
            {
                var ip = line.Split(' ', StringSplitOptions.RemoveEmptyEntries)[0];
                devices.Add(ip);
            }
        }

        return devices;
    }
    
    static string SelectDevice(List<string> devices)
    {
        int index = 0;
        ConsoleKey key;

        do
        {
            Console.Clear();
            Console.WriteLine("Select an IP address using the arrow keys:\n");

            for (int i = 0; i < devices.Count; i++)
            {
                if (i == index)
                {
                    Console.BackgroundColor = ConsoleColor.Gray;
                    Console.ForegroundColor = ConsoleColor.Black;
                }

                Console.WriteLine(devices[i]);

                Console.ResetColor();
            }

            key = Console.ReadKey(true).Key;

            if (key == ConsoleKey.UpArrow)
            {
                index = (index <= 0) ? devices.Count - 1 : index - 1;
            }
            else if (key == ConsoleKey.DownArrow)
            {
                index = (index >= devices.Count - 1) ? 0 : index + 1;
            }

        } while (key != ConsoleKey.Enter);

        return devices[index];
    }
}