namespace Rename.Formatters;

public class SnakeCaseFormatter : IFormatStrategy
{
    public string Format(string input)
    {
        return input.Replace(" ", "_").ToLower();
    }
}