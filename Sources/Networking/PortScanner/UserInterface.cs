namespace PortScanner;

public class UserInterface
{
    public string SelectDevice(List<string> devices)
    {
        int index = 0;
        ConsoleKey key;

        do
        {
            Console.Clear();
            Console.WriteLine("Select an IP address using the arrow keys:\n");

            for (int i = 0; i < devices.Count; i++)
            {
                if (i == index)
                {
                    Console.BackgroundColor = ConsoleColor.Gray;
                    Console.ForegroundColor = ConsoleColor.Black;
                }

                Console.WriteLine(devices[i]);
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

        return devices[index];
    }

    public int GetPort(string message)
    {
        Console.Write(message);
        return int.TryParse(Console.ReadLine(), out var port) ? port : 0;
    }
}