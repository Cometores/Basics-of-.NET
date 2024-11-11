using System.Text.RegularExpressions;

namespace Rename.Formatters;

public class SnakeCaseFormatter : IFormatter
{
    public string Format(string input)
    {
        // Отделяем расширение файла, чтобы оставить его в нижнем регистре
        string extension = Path.GetExtension(input).ToLower();
        string nameWithoutExtension = Path.GetFileNameWithoutExtension(input);

        // Заменяем все пробелы, дефисы и символы подчеркивания на пробелы для разбивки слов
        nameWithoutExtension = Regex.Replace(nameWithoutExtension, @"[\s_-]+", " ").ToLower();

        // Разбиваем текст на слова, используя пробелы, и соединяем их символом "_"
        string formattedName = string.Join("_", nameWithoutExtension.Split(' '));

        return formattedName + extension;
    }
}