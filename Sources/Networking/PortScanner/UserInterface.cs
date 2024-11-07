using System.Collections.Concurrent;

namespace PortScanner;

public class UserInterface
{
    public string RunSelection(List<(string Ip, string Mac, string Manufacturer)> devices)
    {
        int index = 0;
        ConsoleKey key;

        do
        {
            Console.Clear();
            Console.WriteLine("{0,-20} {1,-20} {2,-25}", "IP Address", "MAC Address", "Manufacturer");
            Console.WriteLine(new string('-', 65)); // Разделитель
            
            for (int i = 0; i < devices.Count; i++)
            {
                if (i == index)
                {
                    Console.BackgroundColor = ConsoleColor.Gray;
                    Console.ForegroundColor = ConsoleColor.Black;
                }

                Console.WriteLine("{0,-20} {1,-20} {2,-25}", devices[i].Ip, devices[i].Mac, devices[i].Manufacturer);
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

        Console.WriteLine(new string('-', 65));
        
        return devices[index].Ip;
    }

    public (int, int) GetPorts()
    {
        Console.Write("Enter start port: ");
        int startPort = int.TryParse(Console.ReadLine(), out var startport) ? startport : 0;
        
        Console.Write("Enter end port: ");
        int endPort = int.TryParse(Console.ReadLine(), out var endport) ? endport : 0;

        return (startPort, endPort);
    }
    
    public void DisplayResults(ConcurrentBag<(int Port, string Status)> results)
    {
        Console.Clear();
        Console.WriteLine("{0,-15} {1}", "Port Range", "Status");
        Console.WriteLine(new string('-', 30));

        var orderedResults = results.OrderBy(r => r.Port).ToList();
        int rangeStart = orderedResults[0].Port;
        int rangeEnd = rangeStart;
        string currentStatus = orderedResults[0].Status;

        for (int i = 1; i < orderedResults.Count; i++)
        {
            var (port, status) = orderedResults[i];

            if (status == currentStatus)
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
    
        PrintRange(rangeStart, rangeEnd, currentStatus);
    }

    private void PrintRange(int start, int end, string status)
    {
        string range = start == end ? start.ToString() : $"{start}-{end}";
        Console.WriteLine("{0,-15} {1}", range, status);
    }
}