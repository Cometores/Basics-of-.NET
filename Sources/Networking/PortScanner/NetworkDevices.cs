using System.Diagnostics;

namespace PortScanner;

public class NetworkDevices
{
    public List<string> GetDevices()
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
            if (line.Contains("dynamic"))
            {
                var parts = line.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                if (parts.Length >= 2)
                {
                    var ip = parts[0];
                    devices.Add(ip);
                }
            }
        }

        return devices;
    }
}