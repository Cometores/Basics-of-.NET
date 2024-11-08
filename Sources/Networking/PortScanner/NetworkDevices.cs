using System.Diagnostics;

namespace PortScanner;

using DeviceInfo = (string Ip, string Mac, string Manufacturer);

/// <summary>
/// Represents a class for obtaining information about network devices within the same subnet by using ARP commands
/// and a service to retrieve manufacturer information based on MAC addresses.
/// </summary>
public class NetworkDevices
{
    private readonly ManufacturerService _manufacturerService;
    private readonly Process _process;
    private readonly List<DeviceInfo> _devices = [];

    public NetworkDevices()
    {
        _manufacturerService = new ManufacturerService();

        _process = new Process();
        _process.StartInfo.FileName = "arp";
        _process.StartInfo.Arguments = "-a";
        _process.StartInfo.RedirectStandardOutput = true;
        _process.StartInfo.UseShellExecute = false;
        _process.StartInfo.CreateNoWindow = true;
    }

    /// <summary>
    /// Asynchronously retrieves information about network devices within the same subnet by using ARP commands
    /// and a service to retrieve manufacturer information based on MAC addresses.
    /// </summary>
    /// <returns>A list of DeviceInfo tuples containing IP address, MAC address, and manufacturer information for each
    /// network device found in the local subnet.</returns>
    public async Task<List<DeviceInfo>> GetDevicesAsync()
    {
        string output = GetArpOutput();

        foreach (var line in output.Split('\n'))
        {
            if (!line.Contains("dynamic")) continue;

            var parts = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            if (parts.Length >= 2)
            {
                string ip = parts[0];
                string mac = parts[1];
                string manufacturer = await _manufacturerService.GetManufacturerByMacAsync(mac);
                _devices.Add((ip, mac, manufacturer));
            }
        }

        return _devices;
    }

    private string GetArpOutput()
    {
        _process.Start();
        string output = _process.StandardOutput.ReadToEnd();
        _process.WaitForExit();

        return output;
    }
}