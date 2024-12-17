using System.Drawing;

namespace ImageProcessor.Filters;

#pragma warning disable CA1416

/// <summary>
/// Represents a filter class for converting a colored image to grayscale.
/// </summary>
public class GrayscaleFilter : IImageFilter
{
    /// <inheritdoc/>
    public Bitmap Apply(Bitmap image)
    {
        var grayscaleImage = new Bitmap(image.Width, image.Height);

        for (int y = 0; y < image.Height; y++)
        for (int x = 0; x < image.Width; x++)
            SetGrayscaleForPixel(image, x, y, grayscaleImage);


        return grayscaleImage;
    }

    private static void SetGrayscaleForPixel(Bitmap image, int x, int y, Bitmap grayscaleImage)
    {
        var color = image.GetPixel(x, y);
        int gray = (int)(color.R * 0.3 + color.G * 0.59 + color.B * 0.11);
        grayscaleImage.SetPixel(x, y, Color.FromArgb(gray, gray, gray));
    }
}