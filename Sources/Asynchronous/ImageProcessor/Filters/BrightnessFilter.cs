using System.Drawing;

namespace ImageProcessor.Filters;

#pragma warning disable CA1416

public class BrightnessFilter(float brightnessFactor) : IImageFilter
{
    public Bitmap Apply(Bitmap image)
    {
        var brightenedImage = new Bitmap(image.Width, image.Height);

        for (int y = 0; y < image.Height; y++)
        {
            for (int x = 0; x < image.Width; x++)
            {
                ChangePixelBrightness(image, x, y, brightenedImage);
            }
        }

        return brightenedImage;
    }

    private void ChangePixelBrightness(Bitmap image, int x, int y, Bitmap brightenedImage)
    {
        var originalColor = image.GetPixel(x, y);

        int red = Math.Clamp((int)(originalColor.R * brightnessFactor), 0, 255);
        int green = Math.Clamp((int)(originalColor.G * brightnessFactor), 0, 255);
        int blue = Math.Clamp((int)(originalColor.B * brightnessFactor), 0, 255);

        brightenedImage.SetPixel(x, y, Color.FromArgb(red, green, blue));
    }
}