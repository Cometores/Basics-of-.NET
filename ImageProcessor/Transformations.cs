using System.Drawing;
using System.Threading.Tasks.Dataflow;

#pragma warning disable CA1416

namespace ImageProcessor;

public static class Transformations
{
    public static TransformBlock<string, Bitmap> CreateScaleBlock()
    {
        return new TransformBlock<string, Bitmap>(path =>
        {
            Bitmap image;
            using (var originalImage = new Bitmap(path))
            {
                int newWidth = originalImage.Width / 2;
                int newHeight = originalImage.Height / 2;
                image = new Bitmap(originalImage, new Size(newWidth, newHeight));
            }
            Console.WriteLine($"Изображение {path} масштабировано.");
            return image;
        });
    }

    public static TransformBlock<Bitmap, Bitmap> CreateGrayscaleBlock()
    {
        return new TransformBlock<Bitmap, Bitmap>(image =>
        {
            for (int x = 0; x < image.Width; x++)
            {
                for (int y = 0; y < image.Height; y++)
                {
                    Color originalColor = image.GetPixel(x, y);
                    int grayScale = (int)(originalColor.R * 0.3 + originalColor.G * 0.59 + originalColor.B * 0.11);
                    Color grayColor = Color.FromArgb(originalColor.A, grayScale, grayScale, grayScale);
                    image.SetPixel(x, y, grayColor);
                }
            }
            Console.WriteLine("Применен черно-белый эффект.");
            return image;
        });
    }

    public static TransformBlock<Bitmap, Bitmap> CreateSepiaBlock()
    {
        return new TransformBlock<Bitmap, Bitmap>(image =>
        {
            for (int x = 0; x < image.Width; x++)
            {
                for (int y = 0; y < image.Height; y++)
                {
                    Color originalColor = image.GetPixel(x, y);
                    int tr = (int)(originalColor.R * 0.393 + originalColor.G * 0.769 + originalColor.B * 0.189);
                    int tg = (int)(originalColor.R * 0.349 + originalColor.G * 0.686 + originalColor.B * 0.168);
                    int tb = (int)(originalColor.R * 0.272 + originalColor.G * 0.534 + originalColor.B * 0.131);
                    Color sepiaColor = Color.FromArgb(originalColor.A, Math.Min(255, tr), Math.Min(255, tg), Math.Min(255, tb));
                    image.SetPixel(x, y, sepiaColor);
                }
            }
            Console.WriteLine("Применен эффект сепии.");
            return image;
        });
    }

    public static ActionBlock<Bitmap> CreateSaveBlock(string outputFolder)
    {
        return new ActionBlock<Bitmap>(async image =>
        {
            string outputFilePath = Path.Combine(outputFolder, $"{Guid.NewGuid()}.jpg");
            image.Save(outputFilePath);
            Console.WriteLine($"Изображение сохранено: {outputFilePath}");
            image.Dispose();
        });
    }
}