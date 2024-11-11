using System.Globalization;

namespace Rename.Formatters;

public class CamelCaseFormatter : IFormatter
{
    public string Format(string input)
    {
        TextInfo textInfo = CultureInfo.CurrentCulture.TextInfo;
        return textInfo.ToTitleCase(input.ToLower()).Replace(" ", "");
    }
}