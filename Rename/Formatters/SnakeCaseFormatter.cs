using System.Text.RegularExpressions;

namespace Rename.Formatters;

public class SnakeCaseFormatter : IFormatter
{
    public string Format(string input)
    {
        string name = Path.GetFileNameWithoutExtension(input);
        if (!Regex.IsMatch(name, @"([a-z0-9])([A-Z])"))
            return input;

        string extension = Path.GetExtension(input).ToLower();

        // Используем регулярное выражение для разделения слов на основе переходов от строчных к заглавным
        name = Regex.Replace(name, @"([a-z0-9])([A-Z])", "$1_$2");

        // Заменяем пробелы, дефисы и символы подчеркивания на единый символ "_", переводим в нижний регистр
        name = Regex.Replace(name, @"[\s_-]+", "_").ToLower();

        return name + extension;
    }
}