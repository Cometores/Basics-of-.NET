using System.Drawing;

namespace ImageProcessor.Filters;

#pragma warning disable CA1416

public class SepiaFilter(float intensity) : IImageFilter
{
    public Bitmap Apply(Bitmap image)
    {
        var sepiaImage = new Bitmap(image.Width, image.Height);
        for (int y = 0; y < image.Height; y++)
        {
            for (int x = 0; x < image.Width; x++)
            {
                Color sepia = GetSepiaValue(image, x, y);
                sepiaImage.SetPixel(x, y, sepia);
            }
        }
        return sepiaImage;
    }

    private Color GetSepiaValue(Bitmap image, int x, int y)
    {
        var color = image.GetPixel(x, y);
        int tr = (int)(color.R * (1 + intensity));
        int tg = (int)(color.G * (0.769 + intensity));
        int tb = (int)(color.B * (0.189 + intensity));

        return Color.FromArgb(Math.Min(tr, 255), Math.Min(tg, 255), Math.Min(tb, 255));
    }
}