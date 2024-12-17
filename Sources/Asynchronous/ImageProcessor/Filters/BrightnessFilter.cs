using System.Drawing;

namespace ImageProcessor.Filters;

#pragma warning disable CA1416

/// <summary>
/// Represents a filter that adjusts the brightness of an image.
/// </summary>
/// <param name="brightnessFactor">The factor by which to adjust the brightness of the image.</param>
public class BrightnessFilter(float brightnessFactor) : IImageFilter
{
    /// <inheritdoc/>
    public Bitmap Apply(Bitmap image)
    {
        var brightenedImage = new Bitmap(image.Width, image.Height);

        for (int y = 0; y < image.Height; y++)
        for (int x = 0; x < image.Width; x++)
            SetBrightnessForPixel(image, x, y, brightenedImage);


        return brightenedImage;
    }

    private void SetBrightnessForPixel(Bitmap image, int x, int y, Bitmap brightenedImage)
    {
        var originalColor = image.GetPixel(x, y);

        int red = Math.Clamp((int)(originalColor.R * brightnessFactor), 0, 255);
        int green = Math.Clamp((int)(originalColor.G * brightnessFactor), 0, 255);
        int blue = Math.Clamp((int)(originalColor.B * brightnessFactor), 0, 255);

        brightenedImage.SetPixel(x, y, Color.FromArgb(red, green, blue));
    }
}