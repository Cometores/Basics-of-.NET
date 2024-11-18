using System.Drawing;

namespace ImageProcessor.Filters;

#pragma warning disable CA1416
  

public class InvertFilter : IImageFilter
{
    public Bitmap Apply(Bitmap image)
    {
        var invertedImage = new Bitmap(image.Width, image.Height);
        
        for (int y = 0; y < image.Height; y++)
        {
            for (int x = 0; x < image.Width; x++)
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

        return invertedImage;
    }
}