using System.Text.RegularExpressions;

namespace Rename.Formatters;

public class SnakeCaseFormatter : IFormatter
{
    public string Format(string input)
    {
        // Получаем расширение файла
        string extension = Path.GetExtension(input).ToLower();
        string nameWithoutExtension = Path.GetFileNameWithoutExtension(input);

        // Используем регулярное выражение для разделения слов на основе переходов от строчных к заглавным
        nameWithoutExtension = Regex.Replace(nameWithoutExtension, @"([a-z0-9])([A-Z])", "$1_$2");

        // Заменяем пробелы, дефисы и символы подчеркивания на единый символ "_", переводим в нижний регистр
        nameWithoutExtension = Regex.Replace(nameWithoutExtension, @"[\s_-]+", "_").ToLower();

        return nameWithoutExtension + extension;
    }
}