namespace Rename.Formatters;

public class Formatter(IFormatStrategy strategy)
{
    public string ApplyFormat(string input)
    {
        return strategy.Format(input);
    }
}