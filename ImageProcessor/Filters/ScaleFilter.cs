using System.Drawing;

namespace ImageProcessor.Filters;

#pragma warning disable CA1416

public class ScaleFilter(float scaleFactor) : IImageFilter
{
    public Bitmap Apply(Bitmap image)
    {
        var newSize = new Size()
        {
            Height = (int)(image.Height * scaleFactor),
            Width = (int)(image.Width * scaleFactor)
        };
        
        return new Bitmap(image, newSize);
    }
}