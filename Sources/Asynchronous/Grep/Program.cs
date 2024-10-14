namespace Grep;

public static class Program
{
    public static async Task Main(string[] args)
    {
        string dir = (Directory.GetParent(Environment.CurrentDirectory).Parent).Parent.FullName + "\\others";

        Grep g = new Grep();

        await g.GrepItAsync(dir, "Alice");
        Console.Write(g.Cnt);
    }
}