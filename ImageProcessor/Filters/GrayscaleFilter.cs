using System.Drawing;

namespace ImageProcessor.Filters;

#pragma warning disable CA1416

public class GrayscaleFilter : IImageFilter
{
    public Bitmap Apply(Bitmap image)
    {
        var grayscaleImage = new Bitmap(image.Width, image.Height);
        
        for (int y = 0; y < image.Height; y++)
        {
            for (int x = 0; x < image.Width; x++)
            {
                int gray = GetGrayValue(image, x, y);
                grayscaleImage.SetPixel(x, y, Color.FromArgb(gray, gray, gray));
            }
        }

        return grayscaleImage;
    }

    private static int GetGrayValue(Bitmap image, int x, int y)
    {
        var color = image.GetPixel(x, y);
        return (int)(color.R * 0.3 + color.G * 0.59 + color.B * 0.11);
    }
}