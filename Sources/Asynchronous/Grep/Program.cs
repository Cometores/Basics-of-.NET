public static class Program
{
    public static async Task Main(string[] args)
    {
        string dir = Directory.GetParent(Environment.CurrentDirectory).Parent
            .Parent.FullName + "\\others";

        Grep.Grep g = new Grep.Grep();

        await g.GrepIt(dir, "Alice");
        Console.Write(g.Cnt);
    }
}