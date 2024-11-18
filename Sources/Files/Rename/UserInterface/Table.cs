namespace Rename.UserInterface;

public abstract class Table
{
    public static string SelectFormatter(List<string> formatters)
    {
        int selectedIndex = 0;
        ConsoleKey key;

        do
        {
            DisplayDeviceTable(formatters, selectedIndex);
            key = Console.ReadKey(true).Key;
            selectedIndex = UpdateIndex(key, selectedIndex, formatters.Count);
        } while (key != ConsoleKey.Enter);

        return formatters[selectedIndex];
    }
    
    private static void DisplayDeviceTable(List<string> formatters, int selectedIndex)
    {
        Console.Clear();

        for (int i = 0; i < formatters.Count; i++)
        {
            if (i == selectedIndex)
            {
                Console.BackgroundColor = ConsoleColor.Gray;
                Console.ForegroundColor = ConsoleColor.Black;
            }
            Console.WriteLine(formatters[i]);
            Console.ResetColor();
        }
    }
    
    private static int UpdateIndex(ConsoleKey key, int index, int itemCount)
    {
        return key switch
        {
            ConsoleKey.UpArrow => (index <= 0) ? itemCount - 1 : index - 1,
            ConsoleKey.DownArrow => (index >= itemCount - 1) ? 0 : index + 1,
            _ => index
        };
    }
}