using System.Collections.Concurrent;

namespace PortScanner;

using Port = (int Number, string Status);
using DeviceInfo = (string Ip, string Mac, string Manufacturer);

public class UserInterface
{
    // Main method to display device list and allow user selection
    public string SelectDevice(List<DeviceInfo> devices)
    {
        int selectedIndex = 0;
        ConsoleKey key;

        do
        {
            DisplayDeviceTable(devices, selectedIndex);
            key = Console.ReadKey(true).Key;
            selectedIndex = UpdateIndex(key, selectedIndex, devices.Count);
        } while (key != ConsoleKey.Enter);

        return devices[selectedIndex].Ip;
    }

    // Helper to display device list in table format
    private void DisplayDeviceTable(List<DeviceInfo> devices, int selectedIndex)
    {
        Console.Clear();
        Console.WriteLine("{0,-20} {1,-20} {2,-25}", "IP Address", "MAC Address", "Manufacturer");
        Console.WriteLine(new string('-', 65));

        for (int i = 0; i < devices.Count; i++)
        {
            if (i == selectedIndex)
            {
                Console.BackgroundColor = ConsoleColor.Gray;
                Console.ForegroundColor = ConsoleColor.Black;
            }
            Console.WriteLine("{0,-20} {1,-20} {2,-25}", devices[i].Ip, devices[i].Mac, devices[i].Manufacturer);
            Console.ResetColor();
        }

        Console.WriteLine(new string('-', 65));
    }

    // Method to update selection index based on arrow key input
    private int UpdateIndex(ConsoleKey key, int index, int itemCount)
    {
        if (key == ConsoleKey.UpArrow)
            return (index <= 0) ? itemCount - 1 : index - 1;
        else if (key == ConsoleKey.DownArrow)
            return (index >= itemCount - 1) ? 0 : index + 1;
        return index;
    }

    // Gets and parses port input from the user
    public (int startPort, int endPort) GetPortRange()
    {
        int startPort = GetPortInput("Enter start port: ");
        int endPort = GetPortInput("Enter end port: ");
        return (startPort, endPort);
    }

    private int GetPortInput(string prompt)
    {
        Console.Write(prompt);
        return int.TryParse(Console.ReadLine(), out var port) ? port : 0;
    }

    // Display the port scan results with grouped ranges
    public void DisplayResults(ConcurrentBag<Port> results)
    {
        Console.Clear();
        Console.WriteLine("{0,-15} {1}", "Port Range", "Status");
        Console.WriteLine(new string('-', 30));

        var orderedResults = results.OrderBy(r => r.Number).ToList();
        GroupAndPrintRanges(orderedResults);
    }

    // Groups results by range and status, printing each range
    private void GroupAndPrintRanges(List<Port> orderedResults)
    {
        int rangeStart = orderedResults[0].Number;
        int rangeEnd = rangeStart;
        string currentStatus = orderedResults[0].Status;

        for (int i = 1; i < orderedResults.Count; i++)
        {
            var (port, status) = orderedResults[i];

            if (status == currentStatus && port == rangeEnd + 1)
            {
                rangeEnd = port;
            }
            else
            {
                PrintRange(rangeStart, rangeEnd, currentStatus);
                rangeStart = port;
                rangeEnd = port;
                currentStatus = status;
            }
        }

        PrintRange(rangeStart, rangeEnd, currentStatus); // Final range
    }

    // Helper to print each range in a user-friendly format
    private void PrintRange(int start, int end, string status)
    {
        string range = start == end ? start.ToString() : $"{start}-{end}";
        Console.WriteLine("{0,-15} {1}", range, status);
    }
}