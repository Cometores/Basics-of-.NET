namespace PortScanner;

static class Program
{
    static async Task Main(string[] args)
    {
        NetworkDevices networkDevices = new NetworkDevices();
        UserInterface userInterface = new UserInterface();
        PortScanner portScanner = new PortScanner();

        List<string> devices = networkDevices.GetDevices();
        if (devices.Count == 0)
        {
            Console.WriteLine("No devices found in the local network.");
            return;
        }

        string selectedIP = userInterface.SelectDevice(devices);
        Console.WriteLine($"Selected IP: {selectedIP}");

        int startPort = userInterface.GetPort("Enter start port: ");
        int endPort = userInterface.GetPort("Enter end port: ");

        await portScanner.ScanPortsAsync(selectedIP, startPort, endPort);
    }
}