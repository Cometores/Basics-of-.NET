namespace PortScanner;

public class UserInterface
{
    public string SelectDevice(List<(string Ip, string Mac, string Manufacturer)> devices)
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

        return devices[index].Ip;
    }

    public int GetPort(string message)
    {
        Console.Write(message);
        return int.TryParse(Console.ReadLine(), out var port) ? port : 0;
    }
}