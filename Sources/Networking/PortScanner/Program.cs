namespace PortScanner;

public static class Program
{
    private static readonly NetworkDevices NetworkDevices = new();
    private static readonly UserInterface UserInterface = new();
    private static readonly PortScanner PortScanner = new();

    private static async Task Main(string[] args)
    {
        List<(string Ip, string Mac, string Manufacturer)> devices = await NetworkDevices.GetDevicesAsync();
        if (devices.Count == 0)
        {
            Console.WriteLine("No devices found in the local network.");
            return;
        }

        string selectedDeviceIp = UserInterface.RunSelection(devices);
        var (startPort, endPort) = UserInterface.GetPorts();

        await PortScanner.ScanPortsAsync(selectedDeviceIp, startPort, endPort);
        
        UserInterface.DisplayResults(PortScanner.Results);
    }
}