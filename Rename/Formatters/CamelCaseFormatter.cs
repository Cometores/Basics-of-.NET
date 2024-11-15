using System.Text.RegularExpressions;

namespace Rename.Formatters;

using System.Globalization;

public class CamelCaseFormatter : IFormatter
{
    public string Format(string input)
    {
        string nameWithoutExtension = Path.GetFileNameWithoutExtension(input);
        if (nameWithoutExtension.Contains('-') || nameWithoutExtension.Contains('_'))
            return input;
        
        string extension = Path.GetExtension(input).ToLower();

        // Используем регулярное выражение для замены пробелов, дефисов и подчеркиваний на пробелы
        nameWithoutExtension = Regex.Replace(nameWithoutExtension, @"[\s_-]+", " ").ToLower();

        // Преобразуем в Title Case и удаляем пробелы
        TextInfo textInfo = CultureInfo.CurrentCulture.TextInfo;
        string formattedName = textInfo.ToTitleCase(nameWithoutExtension).Replace(" ", "");

        return formattedName + extension;
    }
}