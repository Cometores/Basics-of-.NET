using System.Drawing;

namespace ImageProcessor.Filters;

#pragma warning disable CA1416

/// <summary>
/// Represents a filter that inverts the colors of an image.
/// </summary>
public class InvertFilter : IImageFilter
{
    /// <inheritdoc/>
    public Bitmap Apply(Bitmap image)
    {
        var invertedImage = new Bitmap(image.Width, image.Height);

        for (int y = 0; y < image.Height; y++)
        for (int x = 0; x < image.Width; x++)
            SetInversionForPixel(image, x, y, invertedImage);

        return invertedImage;
    }

    private static void SetInversionForPixel(Bitmap image, int x, int y, Bitmap invertedImage)
    {
        var originalColor = image.GetPixel(x, y);
        var invertedColor = Color.FromArgb(
            255 - originalColor.R,
            255 - originalColor.G,
            255 - originalColor.B
        );
        invertedImage.SetPixel(x, y, invertedColor);
    }
}