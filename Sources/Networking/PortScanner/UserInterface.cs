using System.Collections.Concurrent;

namespace PortScanner;

using Port = (int Number, string Status);
using DeviceInfo = (string Ip, string Mac, string Manufacturer);

/// <summary>
/// Represents the user interface for interacting with the port scanner application.
/// </summary>
public class UserInterface
{
    /// <summary>
    /// Selects a device from a list of DeviceInfo by displaying them in a table and allowing the user to navigate and choose.
    /// </summary>
    /// <param name="devices">The list of DeviceInfo representing the available devices to select from.</param>
    /// <returns>The IP address of the selected device as a string.</returns>
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

    /// <summary>
    /// Gets the range of ports from user input as the start and end port numbers.
    /// </summary>
    /// <returns>A tuple containing the start and end port numbers for the port range.</returns>
    public (int startPort, int endPort) GetPortRange()
    {
        int startPort = GetPortInput("Enter start port: ");
        int endPort = GetPortInput("Enter end port: ");
        return (startPort, endPort);
    }

    /// <summary>
    /// Displays the scanning results in a formatted table by grouping and printing the port ranges and their statuses.
    /// </summary>
    /// <param name="results">The concurrent bag of ports with their corresponding statuses to display.</param>
    public void DisplayResults(ConcurrentBag<Port> results)
    {
        Console.Clear();
        Console.WriteLine("{0,-15} {1}", "Port Range", "Status");
        Console.WriteLine(new string('-', 30));

        var orderedResults = results.OrderBy(r => r.Number).ToList();
        GroupAndPrintRanges(orderedResults);
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

    private int GetPortInput(string prompt)
    {
        Console.Write(prompt);
        return int.TryParse(Console.ReadLine(), out var port) ? port : 0;
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