string dir = Directory.GetParent(Environment.CurrentDirectory).Parent
    .Parent.FullName + "\\others";

Grep.Grep g = new Grep.Grep(dir, "Alice");
Console.Write(g.Cnt);
