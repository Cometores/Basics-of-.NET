namespace PortScanner;

using DeviceInfo = (string Ip, string Mac, string Manufacturer);

public static class Program
{
    private static readonly NetworkDevices NetworkDevices = new();
    private static readonly UserInterface UserInterface = new();
    private static readonly PortScanner PortScanner = new();

    private static async Task Main(string[] args)
    {
        List<DeviceInfo> devices = await NetworkDevices.GetDevicesAsync();
        if (devices.Count == 0)
        {
            Console.WriteLine("No devices found in the local network.");
            return;
        }

        string selectedDeviceIp = UserInterface.SelectDevice(devices);
        var portRange = UserInterface.GetPortRange();

        await PortScanner.ScanPortsAsync(selectedDeviceIp, portRange.startPort, portRange.endPort);
        
        UserInterface.DisplayResults(PortScanner.Results);
    }
}