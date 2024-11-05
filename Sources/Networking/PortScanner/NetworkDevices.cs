using System.Diagnostics;

namespace PortScanner;

public class NetworkDevices
{
    private readonly ManufacturerService _manufacturerService;

    public NetworkDevices()
    {
        _manufacturerService = new ManufacturerService();
    }

    public async Task<List<(string Ip, string Mac, string Manufacturer)>> GetDevicesAsync()
    {
        var devices = new List<(string Ip, string Mac, string Manufacturer)>();
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
            if (line.Contains("dynamic"))
            {
                var parts = line.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                if (parts.Length >= 2)
                {
                    var ip = parts[0];
                    var mac = parts[1];
                    var manufacturer = await _manufacturerService.GetManufacturerByMacAsync(mac);
                    devices.Add((ip, mac, manufacturer));
                }
            }
        }

        return devices;
    }
}