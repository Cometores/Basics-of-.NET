namespace Rename.Formatters;

public class SnakeCaseFormatter : IFormatter
{
    public string Format(string input)
    {
        return input.Replace(" ", "_").ToLower();
    }
}